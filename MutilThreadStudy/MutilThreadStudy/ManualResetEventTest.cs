using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    public class ManualResetEventTest
    {
        private ManualResetEvent _manualResetEvent;

        public ManualResetEventTest()
        {
            _manualResetEvent = new ManualResetEvent(false);
        }

        public void SetTrue()
        {
            _manualResetEvent.Set();
        }

        public void SetFalse()
        {
            _manualResetEvent.Reset();
        }

        public void MyFunc()
        {
            Console.WriteLine("ManualResetEventTest MyFunc Start");
            for(int i = 0; i < 10; i++)
            {
                _manualResetEvent.WaitOne();
                Thread.Sleep(2000);
                Console.WriteLine("ManualResetEventTest MyFunc:" + i);
            }
        }
    }
}
