#include "sampleGrabber.h"

STDMETHODIMP_(HRESULT __stdcall) MyGrabberCB::QueryInterface(REFIID riid, void** ppv)
{
    if (riid == IID_ISampleGrabberCB || riid == IID_IUnknown)
    {
        *ppv = (void*)this;
        return S_OK;
    }
    return E_NOINTERFACE;
}

STDMETHODIMP_(HRESULT __stdcall) MyGrabberCB::SampleCB(double SampleTime, IMediaSample* pSample)
{
    BYTE* pBuffer = NULL;
    long bufferSize = 0;
    pSample->GetPointer(&pBuffer);
    bufferSize = pSample->GetActualDataLength();
    std::cout << "SampleCB: Frame size: " << bufferSize << " bytes" << std::endl;
    return S_OK;
}

STDMETHODIMP_(HRESULT __stdcall) MyGrabberCB::BufferCB(double SampleTime, BYTE* pBuffer, long BufferLen)
{
    std::cout << "BufferCB: Frame size: " << BufferLen << " bytes" << std::endl;
    return S_OK;
}

