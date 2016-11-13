using System;
using System.Collections.Generic;
using Teleware.SyncData.DbOperates;
using Teleware.SyncData.Interface;
using Teleware.SyncData.Model;
using Teleware.SyncData.Util;

namespace Teleware.SyncData.Export
{
    public class SyncDataExport : ISyncData
    {
        string exportPath = String.Empty;
        IDbOperate dbOperate = null;
        string beginDate = String.Empty, endDate = String.Empty;
        public SyncDataExport(string exportPath, string beginDate, string endDate)
        {
            this.exportPath = exportPath;
            this.beginDate = beginDate;
            this.endDate = endDate;
            //instantiation the interface IDbOperate
            dbOperate = new DbOperate();
        }

        public bool SyncTdzzData(Action<int,int> counter)
        {
            int totle = 0, success = 0;
            try
            {
                IList<ZD_INIT> initList = dbOperate.GetZDINITList(this.beginDate, this.endDate);
                if (initList == null) return false;
                totle = initList.Count;
                foreach (ZD_INIT init in initList)
                {
                    try
                    {
                        string initString = Newtonsoft.Json.JsonConvert.SerializeObject(init);

                        string fileFullName = System.IO.Path.Combine(this.exportPath, init.INIT_GUID + ".json");
                        System.IO.File.AppendAllText(fileFullName, initString);
                        success++;
                    }
                    catch (Exception ex)
                    {
                        LogUtil.WriteErrorLog(typeof(SyncDataExport), "导出项目:" + init.INIT_GUID + "失败，失败原因是：" + ex.Message, ex);
                    }

                }
                counter(totle, success);

                return true;
            }
            catch (Exception ex)
            {
                LogUtil.WriteErrorLog(typeof(SyncDataExport), "导出项目失败，失败原因是：" + ex.Message, ex);
                return false;
            }
            
        }
    }
}
