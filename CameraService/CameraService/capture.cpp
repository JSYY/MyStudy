#include "capture.h"

Capture::Capture()
{
    hr = NULL;
    pGraph = NULL;
    pCaptureFilter = NULL;
    pSampleGrabber = NULL;
    pSampleGrabberFilter = NULL;
    pMediaControl = NULL;
    pGrabberCB = NULL;

    pEnum = NULL;
    pDevEnum = NULL;
    pMoniker = NULL;
}

void Capture::InitDevice()
{
    CreateGraphBuilder();
    BindingDevice();
    AddSampleGrabber();
    Connect();
    SetGrabberCallback();
}

void Capture::CreateGraphBuilder()
{
    // ��ʼ��COM��
    hr = CoInitialize(NULL);
    if (FAILED(hr))
    {
        std::cerr << "COM ��ʼ��ʧ�ܣ��������: " << std::hex << hr << std::endl;
    }
    // ����GraphBuilder����
    hr = CoCreateInstance(CLSID_FilterGraph, NULL, CLSCTX_INPROC_SERVER, IID_IGraphBuilder, (void**)&pGraph);
    if (FAILED(hr))
    {
        std::cerr << "����GraphBuilder����ʧ��" << std::endl;
        CoUninitialize();
    }
}

void Capture::BindingDevice()
{
    // �����豸ö����
    hr = CoCreateInstance(CLSID_SystemDeviceEnum, NULL, CLSCTX_INPROC_SERVER, IID_ICreateDevEnum, (void**)&pDevEnum);
    if (FAILED(hr))
    {
        std::cerr << "�����豸ö����ʧ��" << std::endl;
    }

    // ������Ƶ�豸���ö����
    hr = pDevEnum->CreateClassEnumerator(CLSID_VideoInputDeviceCategory, &pEnum, 0);
    if (FAILED(hr))
    {
        std::cerr << "������Ƶ�豸���ö����ʧ��" << std::endl;
        pDevEnum->Release();
    }

    // ��ȡ��һ����Ƶ�豸������ͷ����Moniker
    ULONG cFetched;
    hr = pEnum->Next(1, &pMoniker, &cFetched);
    if (FAILED(hr))
    {
        std::cerr << "δ�ҵ�����ͷ�豸" << std::endl;
        pEnum->Release();
        pDevEnum->Release();
    }

    // ͨ��Moniker�󶨵���Ƶ�����豸������
    hr = pMoniker->BindToObject(NULL, NULL, IID_IBaseFilter, (void**)&pCaptureFilter);
    pMoniker->Release();
    if (FAILED(hr))
    {
        std::cerr << "�󶨵���Ƶ�����豸������ʧ��" << std::endl;
        pEnum->Release();
        pDevEnum->Release();
    }

    // ����Ƶ�����豸��������ӵ�GraphBuilder
    hr = pGraph->AddFilter(pCaptureFilter, L"Video Capture");
    if (FAILED(hr))
    {
        std::cerr << "�����Ƶ�����豸��������GraphBuilderʧ��" << std::endl;
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }
}

void Capture::AddSampleGrabber()
{
    // ���������Sample Grabber��������GraphBuilder
    hr = CoCreateInstance(CLSID_SampleGrabber, NULL, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&pSampleGrabberFilter);
    if (FAILED(hr))
    {
        std::cerr << "����Sample Grabber������ʧ��" << std::endl;
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    hr = pSampleGrabberFilter->QueryInterface(IID_ISampleGrabber, (void**)&pSampleGrabber);
    if (FAILED(hr))
    {
        std::cerr << "��ȡISampleGrabber�ӿ�ʧ��" << std::endl;
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    // ����Sample Grabber��ý�����ͣ���������ΪRGB24��ʽ��Ƶ����
    AM_MEDIA_TYPE mt;
    ZeroMemory(&mt, sizeof(AM_MEDIA_TYPE));
    //mt.majortype = MEDIA_TYPE_Video;
    //mt.subtype = MEDIA_SUBTYPE_RGB24;
    hr = pSampleGrabber->SetMediaType(&mt);
    if (FAILED(hr))
    {
        std::cerr << "����Sample Grabberý������ʧ��" << std::endl;
        pSampleGrabber->Release();
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    hr = pGraph->AddFilter(pSampleGrabberFilter, L"Sample Grabber");
    if (FAILED(hr))
    {
        std::cerr << "���Sample Grabber��������GraphBuilderʧ��" << std::endl;
        pSampleGrabber->Release();
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }
}

void Capture::Connect()
{
    // ������Ƶ�����������pCaptureFilter�����������
    IEnumPins* pEnumPins = NULL;
    hr = pCaptureFilter->EnumPins(&pEnumPins);
    if (FAILED(hr))
    {
        std::cerr << "�޷�ö����Ƶ���������������" << std::endl;
    }

    IPin* pOutPin = NULL;
    ULONG ulFetched;
    while (pEnumPins->Next(1, &pOutPin, &ulFetched) == S_OK)
    {
        PIN_DIRECTION pinDir;
        pOutPin->QueryDirection(&pinDir);
        if (pinDir == PINDIR_OUTPUT)
        {
            break;
        }
        pOutPin->Release();
        pOutPin = NULL;
    }
    pEnumPins->Release();
    if (pOutPin == NULL)
    {
        std::cerr << "δ�ҵ���Ƶ������������������" << std::endl;
    }

    // ����Sample Grabber��������pSampleGrabberFilter������������
    pEnumPins = NULL;
    hr = pSampleGrabberFilter->EnumPins(&pEnumPins);
    if (FAILED(hr))
    {
        std::cerr << "�޷�ö��Sample Grabber������������" << std::endl;
        pOutPin->Release();
    }

    IPin* pInPin = NULL;
    while (pEnumPins->Next(1, &pInPin, &ulFetched) == S_OK)
    {
        PIN_DIRECTION pinDir;
        pInPin->QueryDirection(&pinDir);
        if (pinDir == PINDIR_INPUT)
        {
            break;
        }
        pInPin->Release();
        pInPin = NULL;
    }
    pEnumPins->Release();
    if (pInPin == NULL)
    {
        std::cerr << "δ�ҵ�Sample Grabber����������������" << std::endl;
        pOutPin->Release();
    }

    // ʹ���ҵ��������������Ž�������
    hr = pGraph->Connect(pOutPin, pInPin);
    if (FAILED(hr))
    {
        std::cerr << "������Ƶ�����豸��������Sample Grabber������ʧ�ܣ�������: " << hr << std::endl;
        pInPin->Release();
        pOutPin->Release();
        // �ͷ������Դ����֮ǰ��ӵĹ�������GraphBuilder�ȣ�����ʡ��
        CoUninitialize();
    }

    // ���ӳɹ����ͷ�����ָ��
    pInPin->Release();
    pOutPin->Release();
}

void Capture::SetGrabberCallback()
{
    // �����ص�ʵ����������Sample Grabber�Ļص�
    pGrabberCB = new MyGrabberCB();
    hr = pSampleGrabber->SetCallback(pGrabberCB, 1);  // 0��ʾʹ��SampleCB�ص�
    if (FAILED(hr))
    {
        std::cerr << "����Sample Grabber�ص�ʧ��" << std::endl;
        delete pGrabberCB;
        pSampleGrabber->Release();
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }
}

void Capture::Run()
{
    // ��ȡý����ƽӿڲ����й�����ͼ
    hr = pGraph->QueryInterface(IID_IMediaControl, (void**)&pMediaControl);
    if (FAILED(hr))
    {
        std::cerr << "��ȡý����ƽӿ�ʧ��" << std::endl;
        delete pGrabberCB;
        pSampleGrabber->Release();
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    hr = pMediaControl->Run();
    if (FAILED(hr))
    {
        std::cerr << "���й�����ͼʧ��" << std::endl;
        pMediaControl->Release();
        delete pGrabberCB;
        pSampleGrabber->Release();
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }
}

void Capture::Stop()
{
    // ֹͣ������ͼ����
    hr = pMediaControl->Stop();
    pMediaControl->Release();

    // �ͷ������Դ
    delete pGrabberCB;
    pSampleGrabber->Release();
    //pSampleGrabberFilter->Release();
    //pCaptureFilter->Release();
    pEnum->Release();
    pDevEnum->Release();
    // �Ƴ�������
    if (pSampleGrabberFilter) {
        pGraph->RemoveFilter(pSampleGrabberFilter);
        //pSampleGrabberFilter->Release();
    }
    if (pCaptureFilter) {
        pGraph->RemoveFilter(pCaptureFilter);
        //pCaptureFilter->Release();
    }
    // �ͷ� IGraphBuilder �ӿ�
    if (pGraph) {
        pGraph->Release();
    }
    CoUninitialize();
}

extern "C" __declspec(dllexport) Capture * CreateMyClass() {
    return new Capture();
}

extern "C" __declspec(dllexport) void Start(Capture* cap) {
    cap->InitDevice();
    cap->Run();
}

extern "C" __declspec(dllexport) void Stop(Capture * cap) {
    cap->Stop();
}