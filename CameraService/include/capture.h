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
#include "sampleGrabber.h"

#ifdef CameraService						// 如果 MYDLL 有定义，说明当前头文件是"DLL项目"在使用
#define PORT __declspec(dllexport)  // 将 PORT 定义为 导出功能
#else								// 如果 MYDLL 没有定义，说明当前头文件是"exe项目"在使用
#define PORT __declspec(dllimport)	// 将 PORT 定义为 导入功能
#endif

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

