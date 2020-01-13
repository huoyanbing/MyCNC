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
    public partial class PCBSetupForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public PCBSetupForm()
        {
            InitializeComponent();
        }

        private void PCBSetupForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PCBSetupForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
        }
    }
}
