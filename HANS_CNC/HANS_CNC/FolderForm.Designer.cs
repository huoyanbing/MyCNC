namespace HANS_CNC
{
    partial class FolderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxPath = new System.Windows.Forms.TextBox();
            this.btnChangeDir = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxFliter = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tVfolder = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tBoxfolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "目录：";
            // 
            // tBoxPath
            // 
            this.tBoxPath.BackColor = System.Drawing.SystemColors.Control;
            this.tBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBoxPath.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxPath.Location = new System.Drawing.Point(122, 28);
            this.tBoxPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tBoxPath.Multiline = true;
            this.tBoxPath.Name = "tBoxPath";
            this.tBoxPath.ReadOnly = true;
            this.tBoxPath.Size = new System.Drawing.Size(1016, 46);
            this.tBoxPath.TabIndex = 3;
            // 
            // btnChangeDir
            // 
            this.btnChangeDir.Location = new System.Drawing.Point(1168, 190);
            this.btnChangeDir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnChangeDir.Name = "btnChangeDir";
            this.btnChangeDir.Size = new System.Drawing.Size(210, 116);
            this.btnChangeDir.TabIndex = 5;
            this.btnChangeDir.Text = "更改目录";
            this.btnChangeDir.UseVisualStyleBackColor = true;
            this.btnChangeDir.Click += new System.EventHandler(this.btnChangeDir_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1168, 478);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(210, 80);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1168, 610);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(210, 80);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxFliter
            // 
            this.comboBoxFliter.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxFliter.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxFliter.FormattingEnabled = true;
            this.comboBoxFliter.Items.AddRange(new object[] {
            "(*.ROU)",
            "(*.*)"});
            this.comboBoxFliter.Location = new System.Drawing.Point(484, 118);
            this.comboBoxFliter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxFliter.Name = "comboBoxFliter";
            this.comboBoxFliter.Size = new System.Drawing.Size(652, 41);
            this.comboBoxFliter.TabIndex = 7;
            this.comboBoxFliter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFliter_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.ico");
            this.imageList1.Images.SetKeyName(1, "2.ico");
            // 
            // tVfolder
            // 
            this.tVfolder.BackColor = System.Drawing.SystemColors.Control;
            this.tVfolder.Location = new System.Drawing.Point(24, 190);
            this.tVfolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tVfolder.Name = "tVfolder";
            this.tVfolder.Size = new System.Drawing.Size(444, 720);
            this.tVfolder.TabIndex = 8;
            this.tVfolder.DoubleClick += new System.EventHandler(this.tVfolder_DoubleClick);
            this.tVfolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tVfolder_MouseDown);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(484, 190);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(652, 720);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 244;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 80;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tBoxfolder
            // 
            this.tBoxfolder.BackColor = System.Drawing.SystemColors.Control;
            this.tBoxfolder.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxfolder.Location = new System.Drawing.Point(24, 118);
            this.tBoxfolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tBoxfolder.Multiline = true;
            this.tBoxfolder.Name = "tBoxfolder";
            this.tBoxfolder.ReadOnly = true;
            this.tBoxfolder.Size = new System.Drawing.Size(444, 44);
            this.tBoxfolder.TabIndex = 3;
            this.tBoxfolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 960);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tVfolder);
            this.Controls.Add(this.comboBoxFliter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnChangeDir);
            this.Controls.Add(this.tBoxfolder);
            this.Controls.Add(this.tBoxPath);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FolderForm";
            this.Text = "目录选择";
            this.Load += new System.EventHandler(this.FolderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxPath;
        private System.Windows.Forms.Button btnChangeDir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBoxFliter;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tVfolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox tBoxfolder;
        private System.Windows.Forms.ImageList imageList2;
    }
}