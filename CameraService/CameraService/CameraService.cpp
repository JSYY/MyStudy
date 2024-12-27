#include "capture.h"

int main()
{
    Capture h;
    h.InitDevice();
    h.Run();
    Sleep(5000);
    h.Stop();

    return 0;
}