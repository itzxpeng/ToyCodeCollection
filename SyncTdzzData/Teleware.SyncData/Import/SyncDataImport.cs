using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Teleware.SyncData.DbOperates;
using Teleware.SyncData.Interface;
using Teleware.SyncData.Model;
using Teleware.SyncData.Util;

namespace Teleware.SyncData.Import
{
    public class SyncDataImport : ISyncData
    {
        IDbOperate dbOperate = null;
        
        string importPath = String.Empty;

        public SyncDataImport(string importPath)
        {
            this.importPath = importPath;
            //instantiation the interface IDbOperate
            dbOperate = new DbOperate();
        }
        public bool SyncTdzzData(Action<int, int> counter)
        {
            int totle = 0, success = 0;
            try
            {
                FileInfo[] fileInfos = new DirectoryInfo(this.importPath).GetFiles();
                totle = fileInfos.Length;

                foreach (FileInfo fi in fileInfos)
                {
                    try
                    {
                        if(fi.Extension.ToLower() == ".json")
                        {
                            ZD_INIT init = Newtonsoft.Json.JsonConvert.DeserializeObject<ZD_INIT>(File.ReadAllText(fi.FullName));
                            dbOperate.SaveZDINITToDB(init);

                            success++;
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        LogUtil.WriteErrorLog(typeof(SyncDataImport), "导入项目:" + fi.Name + "失败，失败原因是：" + ex.Message, ex);
                    }

                }
                counter(totle, success);

                return true;
            }
            catch (Exception ex)
            {
                LogUtil.WriteErrorLog(typeof(SyncDataImport), "导入项目失败，失败原因是：" + ex.Message, ex);
                return false;
            }
        }
    }
}
