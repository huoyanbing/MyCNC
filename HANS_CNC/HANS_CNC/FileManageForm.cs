using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HANS_CNC.UIClass;

namespace HANS_CNC
{
    public partial class FileManageForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        string Ex2path;
        public FileManageForm()
        {
            InitializeComponent();
            FolderForm.pathsChanged += FolderForm_pathsChanged;
        }

        private void FolderForm_pathsChanged(object sender, UserEventArgs e)
        {
            Ex2path = e.Ex2Path;
            MainForm._mainForm.CNCShowForm(FormName.Form_FileManage);
        }

        private void FileManageForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void FileManageForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this, 1);
        }

    }
}
