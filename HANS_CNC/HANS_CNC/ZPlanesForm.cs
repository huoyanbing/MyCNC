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
    public partial class ZPlanesForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public ZPlanesForm()
        {
            InitializeComponent();
        }

        private void ZPlanesForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void ZPlanesForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
        }
    }
}
