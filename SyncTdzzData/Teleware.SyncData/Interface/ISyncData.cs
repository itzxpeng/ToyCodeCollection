using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teleware.SyncData.Interface
{
    public interface ISyncData
    {
        bool SyncTdzzData(Action<int,int> counter);
    }
}
