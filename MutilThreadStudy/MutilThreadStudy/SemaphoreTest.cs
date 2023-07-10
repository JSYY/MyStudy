using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    public class SemaphoreTest
    {
        private Semaphore _semaphorePool;

        public SemaphoreTest() {
            //第一个参数为空位，第二个参数为最大容量
            _semaphorePool = new Semaphore(0, 1);
        }

        public void Set(int number)
        {
            _semaphorePool.Release(number);
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(MyFunc));
                thread.Start(i);
            }
        }

        private void MyFunc(object number)
        {
            Console.WriteLine("Thread {0} start",number);
            _semaphorePool.WaitOne();
            Console.WriteLine("Thread {0} do something !!!,{1}",number,DateTime.Now.ToString());
            Thread.Sleep(2000);
            var count = _semaphorePool?.Release();
            Console.WriteLine("Thread {0} release the semaphore!!!,before release count is {1},{2}",number,count,DateTime.Now.ToString());
        }
    }
}
