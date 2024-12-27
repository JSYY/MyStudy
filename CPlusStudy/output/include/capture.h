#ifdef MYDLL						// 如果 MYDLL 有定义，说明当前头文件是"DLL项目"在使用
#define PORT __declspec(dllexport)  // 将 PORT 定义为 导出功能
#else								// 如果 MYDLL 没有定义，说明当前头文件是"exe项目"在使用
#define PORT __declspec(dllimport)	// 将 PORT 定义为 导入功能
#endif

#include <windows.h>
#include <dshow.h>
#include <iostream>
#include <strmif.h>
// 引入COM库初始化相关头文件
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

    // 样本回调函数，用于处理获取到的样本（帧）数据
    STDMETHODIMP SampleCB(double SampleTime, IMediaSample* pSample)
    {
        BYTE* pBuffer = NULL;
        long bufferSize = 0;
        pSample->GetPointer(&pBuffer);
        bufferSize = pSample->GetActualDataLength();

        // 这里简单打印出帧数据的大小，实际应用中可将数据进行保存、处理等操作
        std::cout << "SampleCB: Frame size: " << bufferSize << " bytes" << std::endl;
        return S_OK;
    }

    // 缓冲区回调函数，功能和SampleCB类似，不过参数形式不同，本示例选择使用SampleCB
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

