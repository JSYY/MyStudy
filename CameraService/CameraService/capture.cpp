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
    // 初始化COM库
    hr = CoInitialize(NULL);
    if (FAILED(hr))
    {
        std::cerr << "COM 初始化失败，错误代码: " << std::hex << hr << std::endl;
    }
    // 创建GraphBuilder对象
    hr = CoCreateInstance(CLSID_FilterGraph, NULL, CLSCTX_INPROC_SERVER, IID_IGraphBuilder, (void**)&pGraph);
    if (FAILED(hr))
    {
        std::cerr << "创建GraphBuilder对象失败" << std::endl;
        CoUninitialize();
    }
}

void Capture::BindingDevice()
{
    // 创建设备枚举器
    hr = CoCreateInstance(CLSID_SystemDeviceEnum, NULL, CLSCTX_INPROC_SERVER, IID_ICreateDevEnum, (void**)&pDevEnum);
    if (FAILED(hr))
    {
        std::cerr << "创建设备枚举器失败" << std::endl;
    }

    // 创建视频设备类别枚举器
    hr = pDevEnum->CreateClassEnumerator(CLSID_VideoInputDeviceCategory, &pEnum, 0);
    if (FAILED(hr))
    {
        std::cerr << "创建视频设备类别枚举器失败" << std::endl;
        pDevEnum->Release();
    }

    // 获取第一个视频设备（摄像头）的Moniker
    ULONG cFetched;
    hr = pEnum->Next(1, &pMoniker, &cFetched);
    if (FAILED(hr))
    {
        std::cerr << "未找到摄像头设备" << std::endl;
        pEnum->Release();
        pDevEnum->Release();
    }

    // 通过Moniker绑定到视频捕获设备过滤器
    hr = pMoniker->BindToObject(NULL, NULL, IID_IBaseFilter, (void**)&pCaptureFilter);
    pMoniker->Release();
    if (FAILED(hr))
    {
        std::cerr << "绑定到视频捕获设备过滤器失败" << std::endl;
        pEnum->Release();
        pDevEnum->Release();
    }

    // 将视频捕获设备过滤器添加到GraphBuilder
    hr = pGraph->AddFilter(pCaptureFilter, L"Video Capture");
    if (FAILED(hr))
    {
        std::cerr << "添加视频捕获设备过滤器到GraphBuilder失败" << std::endl;
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }
}

void Capture::AddSampleGrabber()
{
    // 创建并添加Sample Grabber过滤器到GraphBuilder
    hr = CoCreateInstance(CLSID_SampleGrabber, NULL, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&pSampleGrabberFilter);
    if (FAILED(hr))
    {
        std::cerr << "创建Sample Grabber过滤器失败" << std::endl;
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    hr = pSampleGrabberFilter->QueryInterface(IID_ISampleGrabber, (void**)&pSampleGrabber);
    if (FAILED(hr))
    {
        std::cerr << "获取ISampleGrabber接口失败" << std::endl;
        pSampleGrabberFilter->Release();
        pCaptureFilter->Release();
        pEnum->Release();
        pDevEnum->Release();
        pGraph->Release();
        CoUninitialize();
    }

    // 设置Sample Grabber的媒体类型，这里设置为RGB24格式视频数据
    AM_MEDIA_TYPE mt;
    ZeroMemory(&mt, sizeof(AM_MEDIA_TYPE));
    //mt.majortype = MEDIA_TYPE_Video;
    //mt.subtype = MEDIA_SUBTYPE_RGB24;
    hr = pSampleGrabber->SetMediaType(&mt);
    if (FAILED(hr))
    {
        std::cerr << "设置Sample Grabber媒体类型失败" << std::endl;
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
        std::cerr << "添加Sample Grabber过滤器到GraphBuilder失败" << std::endl;
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
    // 查找视频捕获过滤器（pCaptureFilter）的输出引脚
    IEnumPins* pEnumPins = NULL;
    hr = pCaptureFilter->EnumPins(&pEnumPins);
    if (FAILED(hr))
    {
        std::cerr << "无法枚举视频捕获过滤器的引脚" << std::endl;
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
        std::cerr << "未找到视频捕获过滤器的输出引脚" << std::endl;
    }

    // 查找Sample Grabber过滤器（pSampleGrabberFilter）的输入引脚
    pEnumPins = NULL;
    hr = pSampleGrabberFilter->EnumPins(&pEnumPins);
    if (FAILED(hr))
    {
        std::cerr << "无法枚举Sample Grabber过滤器的引脚" << std::endl;
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
        std::cerr << "未找到Sample Grabber过滤器的输入引脚" << std::endl;
        pOutPin->Release();
    }

    // 使用找到的输入和输出引脚进行连接
    hr = pGraph->Connect(pOutPin, pInPin);
    if (FAILED(hr))
    {
        std::cerr << "连接视频捕获设备过滤器和Sample Grabber过滤器失败，错误码: " << hr << std::endl;
        pInPin->Release();
        pOutPin->Release();
        // 释放相关资源，如之前添加的过滤器、GraphBuilder等，代码省略
        CoUninitialize();
    }

    // 连接成功后，释放引脚指针
    pInPin->Release();
    pOutPin->Release();
}

void Capture::SetGrabberCallback()
{
    // 创建回调实例，并设置Sample Grabber的回调
    pGrabberCB = new MyGrabberCB();
    hr = pSampleGrabber->SetCallback(pGrabberCB, 1);  // 0表示使用SampleCB回调
    if (FAILED(hr))
    {
        std::cerr << "设置Sample Grabber回调失败" << std::endl;
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
    // 获取媒体控制接口并运行过滤器图
    hr = pGraph->QueryInterface(IID_IMediaControl, (void**)&pMediaControl);
    if (FAILED(hr))
    {
        std::cerr << "获取媒体控制接口失败" << std::endl;
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
        std::cerr << "运行过滤器图失败" << std::endl;
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
    // 停止过滤器图运行
    hr = pMediaControl->Stop();
    pMediaControl->Release();

    // 释放相关资源
    delete pGrabberCB;
    pSampleGrabber->Release();
    //pSampleGrabberFilter->Release();
    //pCaptureFilter->Release();
    pEnum->Release();
    pDevEnum->Release();
    // 移除过滤器
    if (pSampleGrabberFilter) {
        pGraph->RemoveFilter(pSampleGrabberFilter);
        //pSampleGrabberFilter->Release();
    }
    if (pCaptureFilter) {
        pGraph->RemoveFilter(pCaptureFilter);
        //pCaptureFilter->Release();
    }
    // 释放 IGraphBuilder 接口
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