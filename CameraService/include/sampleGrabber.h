#pragma once
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
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv);

    // 样本回调函数，用于处理获取到的样本（帧）数据
    STDMETHODIMP SampleCB(double SampleTime, IMediaSample* pSample);

    // 缓冲区回调函数，功能和SampleCB类似，不过参数形式不同
    STDMETHODIMP BufferCB(double SampleTime, BYTE* pBuffer, long BufferLen);
};

