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
    public partial class AxisVersionForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        List<Image> imgFV;
        public static event EventHandler<FVEventArgs> FVChanged;
        public AxisVersionForm()
        {
            InitializeComponent();                        
        }

        private void AxisVersionForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            imgFV = new List<Image>();
            imgFV.Add(Properties.Resources.SetupUser_XY_FV1);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV2);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV3);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV4);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV5);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV6);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV7);
            imgFV.Add(Properties.Resources.SetupUser_XY_FV8);
        }

        private void AxisVersionForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
        }

        private void btnFV1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int a = StringTool.ExtractNum(bt.Name);
            pictureBoxFV.BackgroundImage = imgFV[a - 1];
          //  ReadFVRun(a - 1);
            SendFVData(a - 1);
        }     
        private void SendFVData(int n)
        {
            OnFVChanged(new FVEventArgs(n));
        }
        protected virtual void OnFVChanged(FVEventArgs e)
        {
            EventHandler<FVEventArgs> handler = FVChanged;
            if(handler!=null)
            {
                handler(this, e);
            }
        }

    }
}
