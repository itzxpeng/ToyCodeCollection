using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using Teleware.SyncData.Model;

namespace Teleware.SyncData.DbOperates
{
    public class DbHelper
    {
        private static string jgptConnString = System.Configuration.ConfigurationManager.AppSettings["jgptConnString"].ToString();

        private static string zdbaConnString = System.Configuration.ConfigurationManager.AppSettings["zdbaConnString"].ToString();
        public static IList<ZD_INIT> getInit(string sqlStr)
        {
            IList<ZD_INIT> initList = new List<ZD_INIT>();
            using (OracleConnection conn = new OracleConnection(jgptConnString))
            {
                conn.Open();

                OracleCommand command = conn.CreateCommand();
                command.CommandText = sqlStr;
                command.CommandType = System.Data.CommandType.Text;
                OracleDataReader oracleDataReader = command.ExecuteReader();
                while(oracleDataReader.Read())
                {
                    ZD_INIT init = new ZD_INIT();
                    init.INIT_CFWCRQ = oracleDataReader["INIT_CFWCRQ"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(oracleDataReader["INIT_CFWCRQ"]);
                    init.INIT_CFWCRY = oracleDataReader["INIT_CFWCRY"] == DBNull.Value ? 0 : Convert.ToDecimal(oracleDataReader["INIT_CFWCRY"]);
                    init.INIT_CQH = oracleDataReader["INIT_CQH"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_CQH"]);
                    init.INIT_CQRK = oracleDataReader["INIT_CQRK"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_CQRK"]);
                    init.INIT_GUID = oracleDataReader["INIT_GUID"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_GUID"]);
                    init.INIT_ISCFWC = oracleDataReader["INIT_ISCFWC"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_ISCFWC"]);
                    init.INIT_NYAZ_HB = oracleDataReader["INIT_NYAZ_HB"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_HB"]);
                    init.INIT_NYAZ_LD = oracleDataReader["INIT_NYAZ_LD"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_LD"]);
                    init.INIT_NYAZ_NY = oracleDataReader["INIT_NYAZ_NY"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_NY"]);
                    init.INIT_NYAZ_NZF = oracleDataReader["INIT_NYAZ_NZF"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_NZF"]);
                    init.INIT_NYAZ_QT = oracleDataReader["INIT_NYAZ_QT"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_QT"]);
                    init.INIT_NYAZ_SB = oracleDataReader["INIT_NYAZ_SB"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_SB"]);
                    init.INIT_NYAZ_ZRK = oracleDataReader["INIT_NYAZ_ZRK"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_NYAZ_ZRK"]);
                    init.INIT_PFWH = oracleDataReader["INIT_PFWH"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_PFWH"]);
                    init.INIT_PFWH1 = oracleDataReader["INIT_PFWH1"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_PFWH1"]);
                    init.INIT_PFWH2 = oracleDataReader["INIT_PFWH2"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_PFWH2"]);
                    init.INIT_PFWH3 = oracleDataReader["INIT_PFWH3"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_PFWH3"]);
                    init.INIT_PZJG = oracleDataReader["INIT_PZJG"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_PZJG"]);
                    init.INIT_PZSJ = oracleDataReader["INIT_PZSJ"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(oracleDataReader["INIT_PZSJ"]);
                    init.INIT_XMLX = oracleDataReader["INIT_XMLX"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["INIT_XMLX"]);
                    init.INIT_XMMC = oracleDataReader["INIT_XMMC"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_XMMC"]);
                    init.INIT_XZQDM = oracleDataReader["INIT_XZQDM"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_XZQDM"]);
                    init.INIT_XZQMC = oracleDataReader["INIT_XZQMC"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_XZQMC"]);
                    init.INIT_ZFY = oracleDataReader["INIT_ZFY"] == DBNull.Value ? 0 : Convert.ToDecimal(oracleDataReader["INIT_ZFY"]);
                    init.INIT_ZMJ = oracleDataReader["INIT_ZMJ"] == DBNull.Value ? 0 : Convert.ToDecimal(oracleDataReader["INIT_ZMJ"]);

                    initList.Add(init);
                }
                oracleDataReader.Close();
            }
            return initList;
        }

        public static IList<ZD_INIT_YDQK> getInitYdqk(string sqlStr)
        {
            IList<ZD_INIT_YDQK> ydqkList = new List<ZD_INIT_YDQK>();
            using (OracleConnection conn = new OracleConnection(jgptConnString))
            {
                conn.Open();

                OracleCommand command = conn.CreateCommand();
                command.CommandText = sqlStr;
                command.CommandType = System.Data.CommandType.Text;
                OracleDataReader oracleDataReader = command.ExecuteReader();
                while (oracleDataReader.Read())
                {
                    ZD_INIT_YDQK ydqk = new ZD_INIT_YDQK();
                    ydqk.YDQK_CQH = oracleDataReader["YDQK_CQH"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_CQH"]);
                    ydqk.INIT_GUID = oracleDataReader["INIT_GUID"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["INIT_GUID"]);
                    ydqk.YDQK_CQRK = oracleDataReader["YDQK_CQRK"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_CQRK"]);
                    ydqk.YDQK_GUID = oracleDataReader["YDQK_GUID"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["YDQK_GUID"]);
                    ydqk.YDQK_NYAZ_HB = oracleDataReader["YDQK_NYAZ_HB"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_HB"]);
                    ydqk.YDQK_NYAZ_LD = oracleDataReader["YDQK_NYAZ_LD"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_LD"]);
                    ydqk.YDQK_NYAZ_NY = oracleDataReader["YDQK_NYAZ_NY"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_NY"]);
                    ydqk.YDQK_NYAZ_NZF = oracleDataReader["YDQK_NYAZ_NZF"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_NZF"]);
                    ydqk.YDQK_NYAZ_QT = oracleDataReader["YDQK_NYAZ_QT"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_QT"]);
                    ydqk.YDQK_NYAZ_SB = oracleDataReader["YDQK_NYAZ_SB"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_SB"]);
                    ydqk.YDQK_NYAZ_ZRK = oracleDataReader["YDQK_NYAZ_ZRK"] == DBNull.Value ? 0 : Convert.ToInt32(oracleDataReader["YDQK_NYAZ_ZRK"]);
                    ydqk.YDQK_XZQDM = oracleDataReader["YDQK_XZQDM"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["YDQK_XZQDM"]);
                    ydqk.YDQK_XZQMC = oracleDataReader["YDQK_XZQMC"] == DBNull.Value ? "" : Convert.ToString(oracleDataReader["YDQK_XZQMC"]);
                    ydqk.YDQK_ZFY = oracleDataReader["YDQK_ZFY"] == DBNull.Value ? 0 : Convert.ToDecimal(oracleDataReader["YDQK_ZFY"]);
                    ydqk.YDQK_ZMJ = oracleDataReader["YDQK_ZMJ"] == DBNull.Value ? 0 : Convert.ToDecimal(oracleDataReader["YDQK_ZMJ"]);

                    ydqkList.Add(ydqk);
                }
                oracleDataReader.Close();
            }
            return ydqkList;
        }

        public static object ExecuteSqlString(string sqlStr, System.Data.CommandType commandType = System.Data.CommandType.Text, ZD_INIT init = null)
        {
            using (OracleConnection conn = new OracleConnection(zdbaConnString))
            {
                conn.Open();

                OracleCommand command = conn.CreateCommand();
                command.CommandText = sqlStr;
                command.CommandType = commandType;
                if(init != null)
                {
                    command.Parameters.Add("V_INIT_GUID", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_GUID"].Value = init.INIT_GUID;
                    command.Parameters.Add("V_INIT_XMMC", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_XMMC"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PZSJ", OracleType.DateTime).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PZSJ"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_XZQDM", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_XZQDM"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_XZQMC", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_XZQMC"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_XMLX", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_XMLX"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PZJG", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PZJG"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PFWH", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PFWH"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PFWH1", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PFWH1"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PFWH2", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PFWH2"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_PFWH3", OracleType.VarChar).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_PFWH3"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_ISCFWC", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_ISCFWC"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_ZMJ", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_ZMJ"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_ZFY", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_ZFY"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_ZRK", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_ZRK"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_NY", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_NY"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_HB", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_HB"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_SB", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_SB"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_LD", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_LD"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_NZF", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_NZF"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_NYAZ_QT", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_NYAZ_QT"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_CQH", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_CQH"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_CQRK", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_CQRK"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_CFWCRQ", OracleType.DateTime).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_CFWCRQ"].Value = init.INIT_XMMC;
                    command.Parameters.Add("V_INIT_CFWCRY", OracleType.Number).Direction = ParameterDirection.Input;
                    command.Parameters["V_INIT_CFWCRY"].Value = init.INIT_XMMC;

                    command.Parameters.Add("V_INIT_SEC", OracleType.Number).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    return command.Parameters["V_INIT_SEC"].Value.ToString();

                }

                return command.ExecuteNonQuery();
            }
        }
    }
}
