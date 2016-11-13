using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleware.SyncData.Interface;

namespace Teleware.SyncData.Util
{
    public static class LogUtil
    {
        public static ILogger logger;

        public static void WriteDebugLog(Type t, string msg)
        {
            logger.WriteLog(t, LogLevel.DEBUG, msg);
        }

        public static void WriteDebugLog(Type t, string msg, Exception innerException)
        {
            logger.WriteLog(t, LogLevel.DEBUG, msg, innerException);
        }

        public static void WriteInfoLog(Type t, string msg)
        {
            logger.WriteLog(t, LogLevel.INFO, msg);
        }

        public static void WriteInfoLog(Type t, string msg, Exception innerException)
        {
            logger.WriteLog(t, LogLevel.INFO, msg, innerException);
        }
        public static void WriteErrorLog(Type t, string msg)
        {
            logger.WriteLog(t, LogLevel.ERROR, msg);
        }

        public static void WriteErrorLog(Type t, string msg, Exception innerException)
        {
            logger.WriteLog(t, LogLevel.ERROR, msg, innerException);
        }

        public static void WriteWarningLog(Type t, string msg)
        {
            logger.WriteLog(t, LogLevel.WARNING, msg);
        }

        public static void WriteWarningLog(Type t, string msg, Exception innerException)
        {
            logger.WriteLog(t, LogLevel.WARNING, msg, innerException);
        }
    }
}
