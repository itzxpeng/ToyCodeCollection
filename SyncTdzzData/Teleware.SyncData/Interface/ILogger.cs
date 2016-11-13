using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teleware.SyncData.Interface
{
    public interface ILogger
    {
        void WriteLog(Type t, LogLevel logLevel, string msg);

        void WriteLog(Type t, LogLevel logLevel, string msg, Exception ex);
    }
}
