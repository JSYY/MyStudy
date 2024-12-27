#include <iostream>
#include "capture.h"

int main()
{
    Capture cap;
    cap.InitDevice();
    cap.Run();
    Sleep(5000);
    cap.Stop();
}

