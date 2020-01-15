using HANS_CNC.UIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC
{
    public partial class FolderForm : Form
    {
        FileOperate baseFileOperate = new FileOperate();
        public static event EventHandler<UserEventArgs> pathsChanged;
        string folderFullPath;
        public FolderForm()
        {
            InitializeComponent();
        }

        private void FolderForm_Load(object sender, EventArgs e)
        {
            comboBoxFliter.SelectedIndex = 0;
            folderFullPath = String.Empty;
            baseFileOperate.AllPath = Application.StartupPath + "\\";
            baseFileOperate.CreateFileDir("HansConfig", 1);
            baseFileOperate.AllPath = baseFileOperate.AllPath + "HansConfig" + "\\";
            baseFileOperate.CreateFileDir("HansFile.INI", 0);
            baseFileOperate.IniFileName = baseFileOperate.AllPath + "HansFile.INI";
            FileOperate.inipath = baseFileOperate.ReadIniData("HANSCNC", "DataPath", String.Empty);
            if (FileOperate.inipath == String.Empty)
            {
                baseFileOperate.WriteIniData("HANSCNC", "DataPath", "D:\\");
                FileOperate.inipath = baseFileOperate.ReadIniData("HANSCNC", "DataPath", String.Empty);
            }
            tBoxPath.Text= FileOperate.inipath;
            tVfolder.BeginUpdate();
            string[] strFolder = baseFileOperate.GetFolderNames(FileOperate.inipath);
            foreach (string strDir in strFolder)
            {
                string strtemp = baseFileOperate.GetDirectoryNames(strDir);
                if (strtemp == "RECYCLER" || strtemp == "RECYCLED" || strtemp == "Recycled" || strtemp == "System Volume Information" || strtemp == "$RECYCLE.BIN")
                { }
                else
                {
                    TreeNode tnMyDrives = new TreeNode(strtemp);
                    tVfolder.Nodes.Add(tnMyDrives);
                }
                tVfolder.ImageList = imageList1;
                tVfolder.ImageIndex = 0;
                tVfolder.SelectedImageIndex = 1;

            }
            tVfolder.EndUpdate();
        }

        private void btnChangeDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择文件夹";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tVfolder.Nodes.Clear();
                baseFileOperate.WriteIniData("HANSCNC", "DataPath", folderBrowserDialog1.SelectedPath);
                FileOperate.inipath = baseFileOperate.ReadIniData("HANSCNC", "DataPath", String.Empty);
                tBoxPath.Text = FileOperate.inipath;
                tVfolder.BeginUpdate();
                string[] strFolder = baseFileOperate.GetFolderNames(FileOperate.inipath);
                foreach (string strDir in strFolder)
                {
                    string strtemp = baseFileOperate.GetDirectoryNames(strDir);
                    if (strtemp == "RECYCLER" || strtemp == "RECYCLED" || strtemp == "Recycled" || strtemp == "System Volume Information" || strtemp == "$RECYCLE.BIN")
                    { }
                    else
                    {
                        TreeNode tnMyDrives = new TreeNode(strtemp);
                        tVfolder.Nodes.Add(tnMyDrives);
                    }
                    tVfolder.ImageList = imageList1;
                    tVfolder.ImageIndex = 0;
                    tVfolder.SelectedImageIndex = 1;

                }
                tVfolder.EndUpdate();
            }
        }

        private void tVfolder_DoubleClick(object sender, EventArgs e)
        {
            tBoxfolder.Text = tVfolder.SelectedNode.FullPath;
            folderFullPath = FileOperate.inipath + "\\" + tVfolder.SelectedNode.FullPath;
            string str0 = comboBoxFliter.SelectedItem.ToString();
            string str = StringTool.ExtractFliter(str0);
            baseFileOperate.GetListViewItemOpt(folderFullPath, imageList2, listView1, str);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                return;
            string fileFullPath = folderFullPath + "\\" + listView1.SelectedItems[0].Text;
            SendPathData(fileFullPath);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxFliter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str0 = comboBoxFliter.SelectedItem.ToString();
            string str = StringTool.ExtractFliter(str0);
            baseFileOperate.GetListViewItemOpt(folderFullPath, imageList2, listView1, str);
        }

        private void SendPathData(string strPath)
        {
            UserEventArgs userEventArgs = new UserEventArgs();
            userEventArgs.Ex2Path = strPath;
            OnPathsChanged(userEventArgs);
        }
        protected virtual void OnPathsChanged(UserEventArgs e)
        {
            EventHandler<UserEventArgs> handler = pathsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                return;
            string fileFullPath = folderFullPath + "\\" + listView1.SelectedItems[0].Text;
            SendPathData(fileFullPath);
            this.Close();
        }

        private void tVfolder_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                tVfolder.SelectedNode = tVfolder.GetNodeAt(e.X, e.Y);
                tBoxfolder.Text = tVfolder.SelectedNode.FullPath;
                folderFullPath = FileOperate.inipath + "\\" + tVfolder.SelectedNode.FullPath;
                string str0 = comboBoxFliter.SelectedItem.ToString();
                string str = StringTool.ExtractFliter(str0);
                baseFileOperate.GetListViewItemOpt(folderFullPath, imageList2, listView1, str);
            }
        }
    }
}
