using System;
using System.IO;

namespace Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.methodA();
            }
            catch (TestException e)
            {
                Console.WriteLine("Main catch " + e._error);
            }

        }

        public void methodA()
        {

            methodB();

        }
        public void methodB()
        {
            throw new TestException("123");
        }

    }
    public class TestException : Exception
    {
        public string _error;
        public TestException(string error)
        {
            _error = error;
        }
    }
}
