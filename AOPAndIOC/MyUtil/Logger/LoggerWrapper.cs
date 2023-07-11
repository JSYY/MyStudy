using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch= true)]
namespace MyUtil.Logger
{
    public class LoggerWrapper
    {
        private ILog _log;

        public LoggerWrapper(string name)
        {
            _log = LogManager.GetLogger(name);
        }

        public void LogError(string message)
        {
            _log.Error(message);
        }

        public void LogWarn(string message)
        {
            _log.Warn(message);
        }

        public void LogInfo(string message)
        {
            _log.Info(message);
        }
    }
}
