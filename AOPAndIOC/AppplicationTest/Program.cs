using System;
using UIH.MicroConsole.Common.Unity;

namespace AppplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new UnityApplication(typeof(StartUpModule)).WaitForExit();
        }
    }
}
