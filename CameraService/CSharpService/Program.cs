using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSharpService
{
    class Program
    {
        [DllImport("CameraService.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateMyClass();

        [DllImport("CameraService.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Start(IntPtr obj);

        [DllImport("CameraService.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Stop(IntPtr obj);


        static void Main(string[] args)
        {
            IntPtr objPtr = CreateMyClass();
            if (objPtr != IntPtr.Zero)
            {
                // 调用成员函数
                Start(objPtr);
                Thread.Sleep(5000);
                Stop(objPtr);
            }
        }
    }
}
