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
    public partial class SafetyZoneForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        List<Image> imgSZ;
        public SafetyZoneForm()
        {
            InitializeComponent();
            imgSZ = new List<Image>();
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV1);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV2);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV3);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV4);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV5);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV6);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV7);
            imgSZ.Add(Properties.Resources.SetupUser_XYSafe_FV8);
            AxisVersionForm.FVChanged += AxisVersionForm_FVChanged;
        }

        private void SafetyZoneForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);                       
        }

        private void AxisVersionForm_FVChanged(object sender, FVEventArgs e)
        {
            pictureBoxSZ.BackgroundImage = imgSZ[e.nFV];
        }

        private void SafetyZoneForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
        }
    }
}
