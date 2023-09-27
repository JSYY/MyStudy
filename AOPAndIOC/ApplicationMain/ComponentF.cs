using MyUnity.Attributes;
using MyUtil;
using MyUtil.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationMain
{
    public interface IComponentF 
    {
        void TestActionSynchronizer();
    }

    [Component]
    public class ComponentF : IComponentF
    {
        private IMyLogger _logger;
        private readonly IActionSynchronizer _actionSynchronizer;

        public ComponentF(IMyLogger logger)
        {
            _logger = logger;
            _actionSynchronizer = new ActionSynchronizer("ComponentF");
        }

        public void TestActionSynchronizer()
        {
            _logger.LogDevInformation("excute TestActionSynchronizer");
            for(int i=1;i<=10;i++)
            {
                _actionSynchronizer.BeginInvoke(() => { methodA(i); });
            }
        }

        private void methodA(int i)
        {
            Thread.Sleep(10000);
            Console.WriteLine(i);
            _logger.LogDevInformation("excute methodA output {0}",new object[] { i });
        }
    }
}
