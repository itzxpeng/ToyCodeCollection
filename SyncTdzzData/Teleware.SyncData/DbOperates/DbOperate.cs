using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teleware.SyncData.Interface;
using Teleware.SyncData.Model;

namespace Teleware.SyncData.DbOperates
{
    public class DbOperate : IDbOperate
    {
        public IList<ZD_INIT> GetZDINITList(string beginDate, string endDate)
        {
            try
            {
                IList<ZD_INIT> initList = GetInitList(beginDate, endDate);
                IList<ZD_INIT_YDQK> ydqkList = GetInitYdqkList(beginDate, endDate);


                return MergeObjectToOne(initList, ydqkList);

            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void SaveZDINITToDB(ZD_INIT ZD_INIT)
        {
            try
            {
                bool isExistsHD = DeleteINIT(ZD_INIT.INIT_GUID);

                SaveIINIT(ZD_INIT, isExistsHD);
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        #region export priveate function

        private IList<ZD_INIT> GetInitList(string beginDate, string endDate)
        {
            string sqlTemplate = @"select *
                                      from V_ZD_INIT k
                                     where k.INIT_GUID in
                                           (select j.jsxmzj zj
                                              from ddxzscfb_quan j
                                             where j.zj in
                                                   (select n.zj
                                                      from log_ddxzscfb_quan n
                                                     where n.flag_date >=
                                                           to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and n.flag_date <
                                                           to_date('{1}', 'yyyy-mm-dd hh24:mi:ss') + 1)
                                            union all
                                            select t.zj
                                              from log_jgspzdqk t
                                             where t.flag_date >= to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                               and t.flag_date < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss') + 1)";
            try
            {
                string sqlStr = String.Format(sqlTemplate, beginDate, endDate);
                IList<ZD_INIT> initList = DbHelper.getInit(sqlStr);
                return initList;
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        private IList<ZD_INIT_YDQK> GetInitYdqkList(string beginDate, string endDate)
        {
            string sqlTemplate = @"select *
                              from V_ZD_INIT_YDQK k
                             where k.INIT_GUID in
                                   (select j.jsxmzj zj
                                      from ddxzscfb_quan j
                                     where j.zj in
                                           (select n.zj
                                              from log_ddxzscfb_quan n
                                             where n.flag_date >=
                                                   to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                               and n.flag_date <
                                                   to_date('{1}', 'yyyy-mm-dd hh24:mi:ss') + 1)
                                    union all
                                    select t.zj
                                      from log_jgspzdqk t
                                     where t.flag_date >= to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                       and t.flag_date < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss'))";
            try
            {
                string sqlStr = String.Format(sqlTemplate, beginDate, endDate);
                IList<ZD_INIT_YDQK> ydqkList = DbHelper.getInitYdqk(sqlStr);
                return ydqkList;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private IList<ZD_INIT> MergeObjectToOne(IList<ZD_INIT> initList, IList<ZD_INIT_YDQK> initYdqkList)
        {
            IList<ZD_INIT> resultList = new List<ZD_INIT>();
            try
            {
                foreach (ZD_INIT init in initList)
                {
                    IList<ZD_INIT_YDQK> ydqkList = initYdqkList.Where(r => r.INIT_GUID == init.INIT_GUID).ToList<ZD_INIT_YDQK>();
                    foreach (ZD_INIT_YDQK ydqk in ydqkList)
                    {
                        init.ZD_INIT_YDQKs.Add(ydqk);
                    }
                    resultList.Add(init);
                }
                return resultList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

            
        }

        #endregion

        #region import private function
        private bool DeleteINIT(string initGuid)
        {
            
            //string sqlstr = String.Format("delete from zd_ydqk_hd d where d.YDQK_GUID in (select k.YDQK_GUID from ZD_INIT_YDQK k where k.init_sec in (select t.init_sec from zd_init i where i.init_guid = '{0}'))", initGuid);
            string ydqkSqlStr = String.Format("delete from zd_init_ydqk d where d.init_sec in (select k.init_sec from zd_init k where k.init_guid = '{0}')", initGuid);
            string initSqlStr = String.Format("delete from zd_init d where d.init_guid = '{0}'", initGuid);
            try
            {
                //DbHelper.ExecuteSqlString(sqlstr);
                int ydqkInt = (int)DbHelper.ExecuteSqlString(ydqkSqlStr);
                int initInt = (int)DbHelper.ExecuteSqlString(initSqlStr);

                if (ydqkInt + initInt > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveIINIT(ZD_INIT initList,bool isExistsHD)
        {
            int init_sec = 0;
            try
            {
                string initSqlStr = "insertINIT";
                object initsecObject = DbHelper.ExecuteSqlString(initSqlStr, System.Data.CommandType.StoredProcedure, initList);
                if (initsecObject != null)
                    init_sec = (int)initsecObject;

                if (initList.ZD_INIT_YDQKs != null && initList.ZD_INIT_YDQKs.Count > 0)
                {
                    foreach (ZD_INIT_YDQK ydqk in initList.ZD_INIT_YDQKs)
                    {
                        string ydqkSqlStr = String.Format(@"insert into zd_init_ydqk (YDQK_SEC,INIT_SEC,YDQK_GUID,YDQK_XZQDM,YDQK_XZQMC,YDQK_ZMJ,YDQK_ZFY,
                                                YDQK_NYAZ_ZRK,YDQK_NYAZ_NY,YDQK_NYAZ_SB,YDQK_NYAZ_HB,YDQK_NYAZ_LD,YDQK_NYAZ_NZF,YDQK_CQH,
                                                YDQK_CQRK,YDQK_NYAZ_QT)
                                                values(s_zd_init_ydqk.nextval,{0},'{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})",
                                                    init_sec, ydqk.YDQK_GUID, ydqk.YDQK_XZQDM, ydqk.YDQK_XZQMC, ydqk.YDQK_ZMJ, ydqk.YDQK_ZFY,
                                                    ydqk.YDQK_NYAZ_ZRK, ydqk.YDQK_NYAZ_NY, ydqk.YDQK_NYAZ_SB, ydqk.YDQK_NYAZ_HB, ydqk.YDQK_NYAZ_LD,
                                                    ydqk.YDQK_NYAZ_NZF, ydqk.YDQK_CQH, ydqk.YDQK_CQRK, ydqk.YDQK_NYAZ_QT);
                        DbHelper.ExecuteSqlString(ydqkSqlStr);
                    }
                }

                if (!isExistsHD)
                {
                    string sqlstr = "insert into zd_ydqk_hd select s_zd_ydqk_hd.nextval hd_sec, t.ydqk_zmj hd_zmj, t.ydqk_zfy hd_zfy, t.ydqk_nyaz_zrk hd_zrk, t.ydqk_guid from zd_init_ydqk t where not exists(select * from zd_ydqk_hd d where d.ydqk_guid = t.ydqk_guid)";
                    DbHelper.ExecuteSqlString(sqlstr);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }
}