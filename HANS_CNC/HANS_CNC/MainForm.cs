using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HANS_CNC.UIClass;

namespace HANS_CNC
{
    public partial class MainForm : Form
    {
         AutoSizeFormClass asc = new AutoSizeFormClass();
       // public static MainForm _mainForm = null;
        Bitmap[] tabImages ;
        List<UserControl> userControls;
        List<Image> imgFV;
        string[] strFV;
        public MainForm()
        {
            InitializeComponent();
            //_mainForm = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            Rectangle rect = SystemInformation.WorkingArea;
            this.Height = rect.Height;
            this.Width = rect.Width;
            this.MaximizedBounds = new Rectangle(rect.X, rect.Y, rect.Width-2, rect.Height-2);
            MyTabs();
            MyWorkPanel();
            MyStatusPanel();
            CNCShowForm(FormName.Form_WorkStatus);
            tLPJogKye.Visible = false;
            ControlBufferAll();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
                asc.controlAutoSize(this,2);
            /*
            if (Workpanel.Controls.Count != 0)
                Workpanel.Controls.Clear();
            switch (MaintabControl.SelectedIndex)
            {
                case 0:
                    CNCShowForm(FormName.Form_File);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    CNCShowForm(FormName.Form_WorkStatus);
                    break;
                case 6:
                    break;
                default:
                    break;
            }*/
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            TabOffset();
        }

        private void ControlBufferAll()
        {
            foreach(Control c in userControls)
            {
                ControlBuffer(c);
            }
            foreach(Control c in StatusErrorpanel.Controls)
            {
                ControlBuffer(c);
            }
        }

        private void ControlBuffer( Control c)
        {
            if (c.Controls.Count > 0)
            {
                foreach (Control d in c.Controls)
                {
                    if (d is PictureBox || d is GroupBox||d is DataGridView)
                    {
                        Renderer.SetDoubleBuffer(d);
                    }
                    ControlBuffer(d);
                }             
            }                       
        }

        private void TabOffset()
        {
            List<int> lbt = new List<int>();
            foreach (Control c in MaintabControl.Controls)
            {
                int TPright = 0, btRightMax = 0, btRightMin=0,btwidth=0;
                if (c is TabPage)
                {
                    TPright = c.Right;
                    if(c.Controls.Count!=0)
                    {
                        foreach (Control d in c.Controls)
                        {
                            if (d is Button)
                            {
                                lbt.Add(d.Right);
                                btwidth = d.Width;
                            }
                        }
                        btRightMax = lbt.Max();
                        btRightMin = lbt.Min();
                        lbt.Clear();                      
                        int valx = (TPright - btRightMax- btwidth) / 3;
                        foreach (Control d in c.Controls)
                        {
                            if (d.Right == btRightMin&& d.Right!= btRightMax)
                            {
                                    d.Left += valx;
                            }
                            else
                            {
                                    d.Left += 2 * valx;
                            }
                        }
                        
                    }
                    
                }                            
            }
        }
        private void MyTabs()
        {
            tabLoadImage();
            this.MaintabControl.SelectedIndex = 5;
            this.MaintabControl.Alignment = TabAlignment.Left;
            this.MaintabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.MaintabControl.SizeMode = TabSizeMode.Fixed;          
        }
        private void MyWorkPanel()
        {
            userControls = new List<UserControl>();
            userControls.Add(new CNCFileForm());
            userControls.Add(new ZPlanesForm());
            userControls.Add(new WorkStatusForm());
            userControls.Add(new PCBSetupForm());
            userControls.Add(new AxisVersionForm());
            userControls.Add(new SafetyZoneForm());
            userControls.Add(new JogKeysForm());
            userControls.Add(new PositionsForm());
            userControls.Add(new InputIOForm());
            userControls.Add(new OutputIOForm());
            userControls.Add(new AxisCheckForm());
            userControls.Add(new FileManageForm());
            userControls.Add(new UserFlagForm());
        }
        private void MyStatusPanel()
        {
            imgFV = new List<Image>();
            imgFV.Add(Properties.Resources.dashboardFV1);
            imgFV.Add(Properties.Resources.dashboardFV2);
            imgFV.Add(Properties.Resources.dashboardFV3);
            imgFV.Add(Properties.Resources.dashboardFV4);
            imgFV.Add(Properties.Resources.dashboardFV5);
            imgFV.Add(Properties.Resources.dashboardFV6);
            imgFV.Add(Properties.Resources.dashboardFV7);
            imgFV.Add(Properties.Resources.dashboardFV8);
            strFV = new string[8] { "FV1", "FV2", "FV3", "FV4", "FV5", "FV6", "FV7", "FV8" };
        }
        private void tabLoadImage()
        {
            Bitmap image1 = new Bitmap(Properties.Resources.cssFiles);
            Bitmap image2 = new Bitmap(Properties.Resources.cssProgram);
            Bitmap image3 = new Bitmap(Properties.Resources.cssCommands);
            Bitmap image4 = new Bitmap(Properties.Resources.cssDiagnostics);
            Bitmap image5 = new Bitmap(Properties.Resources.cssTools);
            Bitmap image6 = new Bitmap(Properties.Resources.cssWork);
            Bitmap image7 = new Bitmap(Properties.Resources.cssSystem);
            Bitmap image8 = new Bitmap(Properties.Resources.cssHelp);
            tabImages = new Bitmap[8]{ image1, image2, image3, image4, image5, image6, image7, image8 };
            //List<Bitmap> list = new List<Bitmap>(images);
        }
        private void MaintabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                SolidBrush backgroundBlack;
                if (e.Index == this.MaintabControl.SelectedIndex) //当前Tab页的样式
                {
                     backgroundBlack = new SolidBrush(Color.DodgerBlue);//Tab整体背景颜色
                }
                else
                {
                     backgroundBlack = new SolidBrush(Color.FromArgb(64, 128, 128));//Tab整体背景颜色
                }
                Rectangle myTabRect = this.MaintabControl.GetTabRect(e.Index);
                e.Graphics.FillRectangle(backgroundBlack, myTabRect);
                StringFormat sftTab = new StringFormat();
                sftTab.LineAlignment = StringAlignment.Far;
                sftTab.Alignment = StringAlignment.Center;
                RectangleF recTab = (RectangleF)MaintabControl.GetTabRect(e.Index);//绘制区域
                // Font font = new System.Drawing.Font("微软雅黑", 12F);
                SolidBrush bruFont = new SolidBrush(Color.White);// 标签字体颜色

                e.Graphics.DrawString(this.MaintabControl.TabPages[e.Index].Text , this.Font, bruFont, recTab, sftTab);

                Point p5 = new Point(myTabRect.X + 2, myTabRect.Y + 10);
                e.Graphics.DrawImage(tabImages[e.Index], p5);
                  
                e.Graphics.Dispose();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnJogkey_Click(object sender, EventArgs e)
        {
            tLPJogKye.Visible = true;
            tLPJogKye.BringToFront();
            tLPJogKye.Location = new Point(btnJogkey.Location.X, btnJogkey.Location.Y);
        }
        private void btnJogLock_Click(object sender, EventArgs e)
        {
            tLPJogKye.SendToBack();
            tLPJogKye.Visible = false;
        }
        private void MaintabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch(e.TabPageIndex)
            {
                case 0:                
                    CNCShowForm(FormName.Form_File);
                    break;
                case 1:
                    break;
                case 2:
                    panelCommPosition();
                    break;
                case 3:
                    CNCShowForm(FormName.Form_Positions);
                    break;
                case 4:
                    break;
                case 5:                 
                    CNCShowForm(FormName.Form_WorkStatus);
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        private void panelCommPosition()
        {
            panelComm.BringToFront();
            panelComm.Width = Workpanel.Width;
            panelComm.Location = new Point(0, Workpanel.Bottom-panelComm.Height);
        }
        private void btnZPlane_Click(object sender, EventArgs e)
        {         
            CNCShowForm(FormName.Form_PCBSetup);
        }
        private void btnPCBSetup_Click(object sender, EventArgs e)
        {           
            CNCShowForm(FormName.Form_ZPlanes);
        }
        private void btnWorkStatus_Click(object sender, EventArgs e)
        {           
            CNCShowForm(FormName.Form_WorkStatus);
        }
        private void CNCShowForm(FormName formname)
        {
            int num = (int)formname;
            if (userControls!=null && userControls.Count>0)
            {
                UserControl thisUserControl = userControls[num];
                if (Workpanel.Controls.Contains(thisUserControl))
                {
                    thisUserControl.BringToFront();
                }
                else
                {
                    this.Workpanel.Controls.Add(thisUserControl);
                    thisUserControl.Dock = DockStyle.Fill;
                    thisUserControl.BringToFront();
                }
            }          
        }
        private void btnAxixVer_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_AxisVersion);
            AxisVersionForm.FVChanged += AxisVersionForm_FVChanged;
        }
        private void AxisVersionForm_FVChanged(object sender, FVEventArgs e)
        {
            pictureBoxFV.BackgroundImage = imgFV[e.nFV];
            groupBoxFV.Text = strFV[e.nFV];
        }
        private void btnSaftyZone_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_SafetyZone);            
        }
        private void btnJog_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_JogKeys);
        }
        private void btnCommOK_Click(object sender, EventArgs e)
        {
            comboBoxInput.Items.Add(comboBoxInput.Text);
        }
        private void comboBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if(!StringTool.IsLettersOrNum(e.KeyChar.ToString()))
            {
                MessageBox.Show(e.KeyChar.ToString() + " 非法字符！");
            }

        }
        private void btnPosition_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_Positions);
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_Input);
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_Output);
        }
        private void btnAxisCheck_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_AxisCheck);
        }
        private void btnFileManage_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_FileManage);
        }

        private void btnUserFlag_Click(object sender, EventArgs e)
        {
            CNCShowForm(FormName.Form_UserFlag);
        }
    }
}
