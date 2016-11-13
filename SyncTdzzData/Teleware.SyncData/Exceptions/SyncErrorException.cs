using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Teleware.SyncData.Exceptions
{
    public class SyncErrorException : Exception
    {
        public SyncErrorException(string msg)
        {

        }

        public SyncErrorException(string msg, Exception innerException)
        {

        }

        public SyncErrorException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
