using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleware.SyncData.Exceptions;
using Teleware.SyncData.Export;
using Teleware.SyncData.Import;
using Teleware.SyncData.Interface;
using Teleware.SyncData.Loggers;
using Teleware.SyncData.Util;

namespace Teleware.SyncData
{
    public class SyncData
    {
        OperateType operateType;
        string folderPath = "";

        public SyncData(OperateType operateType, string folderPath)
        {
            this.operateType = operateType;
            this.folderPath = folderPath;
            
        }

        public void SyncTdzzData(Action<int, int> counter, string beginDate = "", string endDate = "")
        {
            ISyncData syncData = null;
            switch (operateType)
            {
                case OperateType.Export:
                    syncData = new SyncDataExport(this.folderPath, beginDate, endDate);
                    break;
                case OperateType.Import:
                    syncData = new SyncDataImport(this.folderPath);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            try
            {
                bool isSync = syncData.SyncTdzzData(counter);
                if (!isSync)
                {
                    throw new SyncErrorException("Sync tdzz data error, please try again later");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
