using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleware.SyncData.Model;

namespace Teleware.SyncData.Interface
{
    public interface IDbOperate
    {
        IList<ZD_INIT> GetZDINITList(string beginDate, string endDate);

        void SaveZDINITToDB(ZD_INIT ZD_INIT);
    }
}
