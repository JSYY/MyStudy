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
        void LogDevInformation(string info, object[] args = null);
        void LogErrorInformation(string info, object[] args = null);
        void LogWarningInformation(string info, object[] args = null);
    }
    
    public class MyLogger:IMyLogger
    {
        private LoggerWrapper _loggerWrapper;

        public MyLogger()
        {
            _loggerWrapper = new LoggerWrapper();
        }

        public void LogErrorInformation(string info,object[] args = null)
        {
            _loggerWrapper.LogError(info,args);
        }

        public void LogDevInformation(string info, object[] args = null)
        {
            _loggerWrapper.LogInfo(info,args);
        }

        public void LogWarningInformation(string info, object[] args = null)
        {
            _loggerWrapper.LogWarn(info,args);
        }
    }
}
