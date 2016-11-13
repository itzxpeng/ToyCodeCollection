namespace SyncTdzzData
{
    partial class SyncDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.btnExportPath = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImportPath = new System.Windows.Forms.Button();
            this.txtImportPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.FolderBrowser_Export = new System.Windows.Forms.FolderBrowserDialog();
            this.FolderBrowser_Import = new System.Windows.Forms.FolderBrowserDialog();
            this.l_Process = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "导出时间：";
            // 
            // DateTimePicker_Begin
            // 
            this.DateTimePicker_Begin.Location = new System.Drawing.Point(96, 23);
            this.DateTimePicker_Begin.Name = "DateTimePicker_Begin";
            this.DateTimePicker_Begin.Size = new System.Drawing.Size(147, 21);
            this.DateTimePicker_Begin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "至";
            // 
            // DateTimePicker_End
            // 
            this.DateTimePicker_End.Location = new System.Drawing.Point(272, 23);
            this.DateTimePicker_End.Name = "DateTimePicker_End";
            this.DateTimePicker_End.Size = new System.Drawing.Size(147, 21);
            this.DateTimePicker_End.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "导出目录：";
            // 
            // txtExportPath
            // 
            this.txtExportPath.Location = new System.Drawing.Point(96, 76);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(282, 21);
            this.txtExportPath.TabIndex = 3;
            // 
            // btnExportPath
            // 
            this.btnExportPath.Location = new System.Drawing.Point(378, 76);
            this.btnExportPath.Name = "btnExportPath";
            this.btnExportPath.Size = new System.Drawing.Size(41, 23);
            this.btnExportPath.TabIndex = 4;
            this.btnExportPath.Text = "...";
            this.btnExportPath.UseVisualStyleBackColor = true;
            this.btnExportPath.Click += new System.EventHandler(this.btnExportPath_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(344, 126);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImportPath
            // 
            this.btnImportPath.Location = new System.Drawing.Point(378, 181);
            this.btnImportPath.Name = "btnImportPath";
            this.btnImportPath.Size = new System.Drawing.Size(41, 23);
            this.btnImportPath.TabIndex = 8;
            this.btnImportPath.Text = "...";
            this.btnImportPath.UseVisualStyleBackColor = true;
            this.btnImportPath.Click += new System.EventHandler(this.btnImportPath_Click);
            // 
            // txtImportPath
            // 
            this.txtImportPath.Location = new System.Drawing.Point(96, 181);
            this.txtImportPath.Name = "txtImportPath";
            this.txtImportPath.Size = new System.Drawing.Size(282, 21);
            this.txtImportPath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "导出目录：";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(344, 229);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // l_Process
            // 
            this.l_Process.AutoSize = true;
            this.l_Process.Location = new System.Drawing.Point(182, 277);
            this.l_Process.Name = "l_Process";
            this.l_Process.Size = new System.Drawing.Size(0, 12);
            this.l_Process.TabIndex = 9;
            // 
            // SyncDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 316);
            this.Controls.Add(this.l_Process);
            this.Controls.Add(this.btnImportPath);
            this.Controls.Add(this.txtImportPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnExportPath);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateTimePicker_End);
            this.Controls.Add(this.DateTimePicker_Begin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SyncDataForm";
            this.ShowIcon = false;
            this.Text = "征地数据同步";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker_Begin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateTimePicker_End;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button btnExportPath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImportPath;
        private System.Windows.Forms.TextBox txtImportPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser_Export;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser_Import;
        private System.Windows.Forms.Label l_Process;
    }
}

