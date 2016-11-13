using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teleware.SyncData.Model
{
    public class ZD_INIT
    {
        public ZD_INIT()
        {
            ZD_INIT_YDQKs = new List<ZD_INIT_YDQK>();
            INIT_CFWCRQ = DateTime.UtcNow;
            INIT_PZSJ = DateTime.UtcNow;
        }

        public string INIT_GUID { get; set; }

        public string INIT_XMMC { get; set; }

        public DateTime INIT_PZSJ { get; set; }

        public string INIT_XZQDM { get; set; }

        public string INIT_XZQMC { get; set; }

        public int INIT_XMLX { get; set; }

        public int INIT_PZJG { get; set; }

        public string INIT_PFWH { get; set; }

        public string INIT_PFWH1 { get; set; }

        public string INIT_PFWH2 { get; set; }

        public string INIT_PFWH3 { get; set; }

        public int INIT_ISCFWC { get; set; }

        public decimal INIT_ZMJ { get; set; }

        public decimal INIT_ZFY { get; set; }

        public int INIT_NYAZ_ZRK { get; set; }

        public int INIT_NYAZ_NY { get; set; }

        public int INIT_NYAZ_HB { get; set; }

        public int INIT_NYAZ_SB { get; set; }

        public int INIT_NYAZ_LD { get; set; }

        public int INIT_NYAZ_NZF { get; set; }

        public int INIT_NYAZ_QT { get; set; }

        public int INIT_CQH { get; set; }

        public int INIT_CQRK { get; set; }

        public DateTime INIT_CFWCRQ { get; set; }

        public decimal INIT_CFWCRY { get; set; }

        public IList<ZD_INIT_YDQK> ZD_INIT_YDQKs { get; set; }
    }
}
