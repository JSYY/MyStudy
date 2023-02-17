﻿using ApplicationMain;
using MyUnity.ApplicationContext;
using MyUnity.Attributes;
using MyUnity.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTest
{
    [DependsOn(typeof(MainModule))]
    public class StartUpModule: UnityModule
    {
        private readonly IUnityApplicationContext _applicationContext;
        public StartUpModule(IUnityApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
