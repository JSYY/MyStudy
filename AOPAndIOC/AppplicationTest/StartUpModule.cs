using MyUnity.ApplicationContext;
using MyUnity.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTest
{
    public class StartUpModule: BasicUnityModule
    {
        public StartUpModule(IUnityApplicationContext applicationContext, IUnityConfiguration configuration)
            : base(applicationContext, configuration)
        {

        }
    }
}
