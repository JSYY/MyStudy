using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace MyUtil.Logger
{
    public class LoggerWrapper
    {
        private ILog _log;

        public LoggerWrapper()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logger\\log4net.config")));
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void LogError(string message,object[] args=null)
        {
            if (args == null)
            {
                _log.Error(message);
            }
            else
            {
                _log.Error(string.Format(message, args));
            }
        }

        public void LogWarn(string message, object[] args = null)
        {
            if (args == null)
            {
                _log.Warn(message);
            }
            else
            {
                _log.Warn(string.Format(message, args));
            }
        }

        public void LogInfo(string message, object[] args = null)
        {
            if (args == null)
            {
                _log.Info(message);
            }
            else
            {
                _log.Info(string.Format(message, args));
            }
        }
    }
}
