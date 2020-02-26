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
    public partial class OutputIOForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public List<PictureBox> lpBoxs;
        List<GroupBox> lgbs;
        bool blone = true;
        string[] strOutput = new string[] {"镭射选择Z1", "镭射选择Z2", "镭射选择Z3", "镭射选择Z4", "镭射选择Z5", "镭射选择Z6", "M36", "打开主轴夹头" ,"机器故障报警",
                                                            "机器停止","机器运行中","活塞向上","GRIPPER CLOSE","PRESS FOOT","QIC CLOSE","PRESS PCB","AIR","CNC RPM到达","CNC RPM 0",
                                                              "Spindle Air","AIR CHECK TOOL","CLAMPING FOR PRESSPCB"};
        public OutputIOForm()
        {           
            InitializeComponent();
            lpBoxs = new List<PictureBox>();
            LabelRename();
            MyGroupBox();
            for (int i = 0; i < strOutput.Length; i++)
            {
                OutputControl(i + 1, strOutput[i]);
            }
        }
      
        private void OutputIOForm_Load(object sender, EventArgs e)
        {
            
            asc.controllInitializeSize(this);
            tabControlOutput.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlOutput.SizeMode = TabSizeMode.Fixed;
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

        private void OutputIOForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this, 1);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ControlTool.TabControlDrawItem(tabControlOutput, e);
        }

        private void LabelRename()
        {
            foreach (Control c in tabControlOutput.Controls)
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
            foreach (Control c in tabControlOutput.Controls)
            {
                foreach (Control c1 in c.Controls)
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
        public void OutputControl(int nindex, string Ltext)
        {
            string name = "pBox_", Lname = "Label";
           
            PictureBox pBox = new PictureBox();
            pBox.Name = name + nindex.ToString();
            pBox.Size = new Size(12, 15);
            pBox.BackColor = Color.Silver;
            pBox.BackgroundImageLayout = ImageLayout.Zoom;
            lpBoxs.Add(pBox);
            Label label = new Label();
            label.AutoSize = true;
            label.Name = Lname + nindex.ToString();
            label.Font = new Font("微软雅黑", 12F);
            label.Text = Ltext;
            label.Click += Label_Click;
            Label labelHead = FindLabel(nindex);
            lpBoxs.Last().Location = new Point(labelHead.Location.X + 25, labelHead.Location.Y);
            label.Location = new Point(labelHead.Location.X + 45, labelHead.Location.Y);
            int ngb = nindex / 17;
            GroupBox groupBox = lgbs[ngb] as GroupBox;
            groupBox.Controls.Add(lpBoxs.Last());
            groupBox.Controls.Add(label);
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string a = label.Name;
            if(label.BackColor==Color.Transparent)
                label.BackColor = Color.Yellow;
            else
                label.BackColor = Color.Transparent;
        }
    }
}
