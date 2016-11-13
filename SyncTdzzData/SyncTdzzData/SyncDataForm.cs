using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teleware.SyncData;
using Teleware.SyncData.Export;

namespace SyncTdzzData
{
    public partial class SyncDataForm : Form
    {
        public SyncDataForm()
        {
            InitializeComponent();
        }

        private void btnExportPath_Click(object sender, EventArgs e)
        {
            if (FolderBrowser_Export.ShowDialog() == DialogResult.OK)
            {
                this.txtExportPath.Text = FolderBrowser_Export.SelectedPath;
            }
        }

        private void btnImportPath_Click(object sender, EventArgs e)
        {
            if (FolderBrowser_Import.ShowDialog() == DialogResult.OK)
            {
                this.txtImportPath.Text = FolderBrowser_Import.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            this.l_Process.Text = "开始导出！";
            string beginDate = this.DateTimePicker_Begin.Value.ToString("yyyy-MM-dd");  //ToString("yyyy-MM-dd HH:mm:ss")
            string endDate = this.DateTimePicker_End.Value.ToString("yyyy-MM-dd");
            string exportPath = this.txtExportPath.Text;

            Task task = new Task(r => ExportData(beginDate, endDate, exportPath), null);
            task.Start();
            
            if(task.IsCompleted)
                this.l_Process.Text = "导出完成！";
        }

        private static void ExportData(string beginDate, string endDate, string exportPath)
        {
            int totleCounter = 0, successCounter = 0;
            SyncData syncData = new SyncData(Teleware.SyncData.OperateType.Export, exportPath);
            try
            {
                syncData.SyncTdzzData((totle, success) => { totleCounter = totle; successCounter = success; }, beginDate, endDate);

                MessageBox.Show("操作成功！共有项目" + totleCounter + ",导出项目" + successCounter + "个.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败！失败原因：" + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.l_Process.Text = "开始导入！";

            string importPath = this.txtImportPath.Text;
            Task task = new Task(r => ImportData(importPath), null);
            task.Start();

            if (task.IsCompleted)
                this.l_Process.Text = "导入完成！";
        }

        private static void ImportData(string importPath)
        {
            int totleCounter = 0, successCounter = 0;

            SyncData syncData = new SyncData(Teleware.SyncData.OperateType.Import, importPath);
            try
            {
                syncData.SyncTdzzData((totle, success) => { totleCounter = totle; successCounter = success; });
                MessageBox.Show("操作成功！共有项目" + totleCounter + ",导入项目" + successCounter + "个.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入失败！失败原因：" + ex.Message);
            }
        }

    }
}
