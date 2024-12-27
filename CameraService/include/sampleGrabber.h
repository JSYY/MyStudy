#pragma once
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
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv);

    // �����ص����������ڴ����ȡ����������֡������
    STDMETHODIMP SampleCB(double SampleTime, IMediaSample* pSample);

    // �������ص����������ܺ�SampleCB���ƣ�����������ʽ��ͬ
    STDMETHODIMP BufferCB(double SampleTime, BYTE* pBuffer, long BufferLen);
};

