using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Logger
{
    public interface IMyLogger
    {
        void LogDevInformation(string info);
        void LogErrorInformation(string info);
        void LogWarningInformation(string info);
    }
    
    public class MyLogger:IMyLogger
    {
        private LoggerWrapper _loggerWrapper;

        public MyLogger(string name)
        {
            _loggerWrapper = new LoggerWrapper(name);
        }

        public void LogErrorInformation(string info)
        {
            _loggerWrapper.LogError(info);
        }

        public void LogDevInformation(string info)
        {
            _loggerWrapper.LogInfo(info);
        }

        public void LogWarningInformation(string info)
        {
            _loggerWrapper.LogWarn(info);
        }
    }
}
