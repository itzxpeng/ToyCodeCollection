using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Teleware.SyncData.Util;

namespace SyncTdzzData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogUtil.logger = new Teleware.SyncData.Loggers.Logger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SyncDataForm());
        }
    }
}
