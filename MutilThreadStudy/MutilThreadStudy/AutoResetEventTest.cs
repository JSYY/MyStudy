using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    public class AutoResetEventTest
    {
        private AutoResetEvent _resetEvent;

        public AutoResetEventTest() {
            _resetEvent = new AutoResetEvent(false);
        }

        public void SetTrue()
        {
            _resetEvent.Set();
        }

        public void MyFunc()
        {
            Console.WriteLine("AutoResetEventTest MyFunc start");
            for (int i = 0; i < 10; i++)
            {
                _resetEvent.WaitOne();
                Console.WriteLine("AutoResetEventTest MyFunc:" + i);
            }
        }
    }
}
