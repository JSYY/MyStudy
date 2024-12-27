#ifdef MYDLL						// ��� MYDLL �ж��壬˵����ǰͷ�ļ���"DLL��Ŀ"��ʹ��
#define PORT __declspec(dllexport)  // �� PORT ����Ϊ ��������
#else								// ��� MYDLL û�ж��壬˵����ǰͷ�ļ���"exe��Ŀ"��ʹ��
#define PORT __declspec(dllimport)	// �� PORT ����Ϊ ���빦��
#endif

#include <windows.h>
#include <dshow.h>
#include <iostream>
#include <strmif.h>
// ����COM���ʼ�����ͷ�ļ�
#pragma comment(lib, "strmiids.lib")
#define __IDxtCompositor_INTERFACE_DEFINED__
#define __IDxtAlphaSetter_INTERFACE_DEFINED__
#define __IDxtJpeg_INTERFACE_DEFINED__
#define __IDxtKey_INTERFACE_DEFINED__
#include "qedit.h"

class MyGrabberCB : public ISampleGrabberCB
{
public:
    STDMETHODIMP_(ULONG) AddRef() { return 2; }
    STDMETHODIMP_(ULONG) Release() { return 1; }
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv)
    {
        if (riid == IID_ISampleGrabberCB || riid == IID_IUnknown)
        {
            *ppv = (void*)this;
            return S_OK;
        }
        return E_NOINTERFACE;
    }

    // �����ص����������ڴ����ȡ����������֡������
    STDMETHODIMP SampleCB(double SampleTime, IMediaSample* pSample)
    {
        BYTE* pBuffer = NULL;
        long bufferSize = 0;
        pSample->GetPointer(&pBuffer);
        bufferSize = pSample->GetActualDataLength();

        // ����򵥴�ӡ��֡���ݵĴ�С��ʵ��Ӧ���пɽ����ݽ��б��桢����Ȳ���
        std::cout << "SampleCB: Frame size: " << bufferSize << " bytes" << std::endl;
        return S_OK;
    }

    // �������ص����������ܺ�SampleCB���ƣ�����������ʽ��ͬ����ʾ��ѡ��ʹ��SampleCB
    STDMETHODIMP BufferCB(double SampleTime, BYTE* pBuffer, long BufferLen)
    {
        return S_OK;
    }
};

class PORT Capture
{
public:
	HRESULT hr;
	IGraphBuilder* pGraph;
	IBaseFilter* pCaptureFilter;
	ISampleGrabber* pSampleGrabber;
	IBaseFilter* pSampleGrabberFilter;
	IMediaControl* pMediaControl;
    MyGrabberCB* pGrabberCB;

	IEnumMoniker* pEnum;
	ICreateDevEnum* pDevEnum;
	IMoniker* pMoniker;

private:
    void CreateGraphBuilder();
    void BindingDevice();
    void AddSampleGrabber();
    void Connect();
    void SetGrabberCallback();

public:
    Capture();
    void InitDevice();
	void Run();
	void Stop();
};

