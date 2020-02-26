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
    public partial class InputIOForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public List<PictureBox> lpBoxs;
        public List<Label> Lplabel;
        List<GroupBox> lgbs;
        bool blone = true;
        string[] strInput = new string[] {"刀长测量器Z1", "刀长测量器Z2", "刀长测量器Z3", "刀长测量器Z4", "刀长测量器Z5", "刀长测量器Z6", "夹头上升", "QIC limit alarm" ,"PRESS PCB SENSOR",
                                                            "COOLING UNIT","SPINDLE AIR","光电栅栏","位置停止","机器停止"};
        public InputIOForm()
        {
            InitializeComponent();
            lpBoxs = new List<PictureBox>();
            Lplabel = new List<Label>();
            LabelRename();
            MyGroupBox();
            for (int i = 0; i < strInput.Length; i++)
            {
                inputControl(i + 1, strInput[i]);
            }
        }

        private void InputIOForm_Load(object sender, EventArgs e)
        {
            //MyGroupBox();
            asc.controllInitializeSize(this);
            tabControlInput.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlInput.SizeMode = TabSizeMode.Fixed;
           
        }
        private void MyGroupBox()
        {
            lgbs = new List<GroupBox>();
            lgbs.Add(groupBox1);
            lgbs.Add(groupBox2);
            lgbs.Add(groupBox3);
            lgbs.Add(groupBox4);
            lgbs.Add(groupBox5);
            lgbs.Add(groupBox6);
        }
        private void InputIOForm_SizeChanged(object sender, EventArgs e)
        {         
            asc.controlAutoSize(this, 1);
            if(blone)
            {
                //for(int i=0;i<strInput.Length;i++)
                //{
                //    inputControl(i+1, strInput[i]);
                //}
               
                blone = false;
            }
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ControlTool.TabControlDrawItem(tabControlInput, e);
        }
        private  void LabelRename()
        {
            foreach (Control c in tabControlInput.Controls)
            {
                foreach (Control c1 in c.Controls)
                {
                    foreach (Control c2 in c1.Controls)
                    {
                        if (c2 is Label)
                        {
                            c2.Name = "Label_" + c2.Text;
                        }
                    }
                }
            }
            
        }
        private Label FindLabel(int n)
        {
            string LabelName = "Label_" + n.ToString();
            Label label = null;
            foreach (Control c in tabControlInput.Controls)
            {
                foreach(Control c1 in c.Controls )
                {
                    foreach (Control c2 in c1.Controls)
                    {
                        if (c2 is Label)
                        {
                            if (c2.Name == LabelName)
                            {
                                label = c2 as Label;
                            }
                        }
                    }   
                }
            }
            return label;
        }
        public void inputControl(int nindex,string Ltext)
        {
            string name = "pBox_",Lname="Label";
            int[] nNum = new int[2];
            nNum[0]= 2 * nindex - 1;
            nNum[1] = 2 * nindex;
            for (int i=0;i<2;i++)
            {
                PictureBox pBox = new PictureBox();
                pBox.Name = name + nNum[i].ToString();
                pBox.Size = new Size(12, 15);
                pBox.BackColor = Color.Silver;
                pBox.BackgroundImageLayout = ImageLayout.Zoom;
                lpBoxs.Add(pBox);               
            }
            PictureBox pBox1 = lpBoxs[lpBoxs.Count - 2] as PictureBox;
            PictureBox pBox2 = lpBoxs.Last() as PictureBox;
            Label label = new Label();
            label.AutoSize = true;
            label.Name = Lname + nindex.ToString();
            label.Font = new Font("微软雅黑", 12F);
            label.Text = Ltext;
            Lplabel.Add(label);
            Label labelHead = FindLabel(nindex);
            pBox1.Location = new Point(labelHead.Location.X + 20, labelHead.Location.Y);
            pBox2.Location = new Point(labelHead.Location.X + 40, labelHead.Location.Y);
            label.Location = new Point(labelHead.Location.X + 60, labelHead.Location.Y);
            int ngb = nindex / 17;
            GroupBox groupBox = lgbs[ngb] as GroupBox;
            groupBox.Controls.Add(pBox1);
            groupBox.Controls.Add(pBox2);
            groupBox.Controls.Add(label);          
        }
    }
}
