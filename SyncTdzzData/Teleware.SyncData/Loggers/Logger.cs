using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleware.SyncData.Interface;

namespace Teleware.SyncData.Loggers
{
    public class Logger : ILogger
    {

        public void WriteLog(Type t, LogLevel logLevel, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            switch (logLevel)
            {
                case LogLevel.DEBUG:
                    log.Debug(msg);
                    break;
                case LogLevel.INFO:
                    log.Info(msg);
                    break;
                case LogLevel.WARNING:
                    log.Warn(msg);
                    break;
                case LogLevel.ERROR:
                    log.Error(msg);
                    break;
            }
        }

        public void WriteLog(Type t, LogLevel logLevel, string msg, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            switch (logLevel)
            {
                case LogLevel.DEBUG:
                    log.Debug(msg, ex);
                    break;
                case LogLevel.INFO:
                    log.Info(msg, ex);
                    break;
                case LogLevel.WARNING:
                    log.Warn(msg, ex);
                    break;
                case LogLevel.ERROR:
                    log.Error(msg, ex);
                    break;
            }
        }
    }
}
