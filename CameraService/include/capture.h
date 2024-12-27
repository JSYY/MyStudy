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
#include "sampleGrabber.h"

#ifdef CameraService						// ��� MYDLL �ж��壬˵����ǰͷ�ļ���"DLL��Ŀ"��ʹ��
#define PORT __declspec(dllexport)  // �� PORT ����Ϊ ��������
#else								// ��� MYDLL û�ж��壬˵����ǰͷ�ļ���"exe��Ŀ"��ʹ��
#define PORT __declspec(dllimport)	// �� PORT ����Ϊ ���빦��
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

