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
    public partial class UserFlagForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        List<GroupBox> lgbs;
        public List<CheckBox> lCheckBoxs;
        bool blone = true;
        string[] strOutput = new string[] {"刀具错误时退回刀库", "刀具长度/直径/偏摆错误时自动取下一把刀", "换刀时检测主轴夹头是否有刀具", "打开检测直径", "只对新刀打开检测直径", "模拟换刀", "生产程序运行结束后主轴退刀", "生产程序运行结束后执行零点校正功能" ,"零点校正时超5~10um则自动回零",
                                                            "SEQUENCE提示文本显示","退刀时执行刀具长度检查","按ESC键或手动开主轴夹头后执行刀具长度检查","换刀时清洁刀具","换刀时清洁刀具镭射","声音报警","安全线路换刀","T0时检查BBD断刀器","断刀退入刀库","断刀时拿下一把刀",
                                                              "程序结束后自动顶料"};
        public UserFlagForm()
        {
            InitializeComponent();
            lCheckBoxs = new List<CheckBox>();
            LabelRename();
        }

        private void UserFlagForm_Load(object sender, EventArgs e)
        {
            MyGroupBox();
            asc.controllInitializeSize(this);
            tabControlUerFlag.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlUerFlag.SizeMode = TabSizeMode.Fixed;
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

        private void UserFlagForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this, 1);
            if (blone)
            {
                for (int i = 0; i < strOutput.Length; i++)
                {
                    OutputControl(i + 1, strOutput[i]);
                }

                blone = false;
            }
        }

        private void tabControlUerFlag_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                SolidBrush backgroundBlack;
                if (e.Index == tabControlUerFlag.SelectedIndex) //当前Tab页的样式
                {
                    backgroundBlack = new SolidBrush(Color.DodgerBlue);//Tab整体背景颜色
                }
                else
                {
                    backgroundBlack = new SolidBrush(Color.FromArgb(64, 128, 128));//Tab整体背景颜色
                }
                Rectangle myTabRect = tabControlUerFlag.GetTabRect(e.Index);
                e.Graphics.FillRectangle(backgroundBlack, myTabRect);
                StringFormat sftTab = new StringFormat();
                sftTab.LineAlignment = StringAlignment.Center;
                sftTab.Alignment = StringAlignment.Center;
                RectangleF recTab = (RectangleF)tabControlUerFlag.GetTabRect(e.Index);//绘制区域
                Font font = new System.Drawing.Font("微软雅黑", 11F);
                SolidBrush bruFont = new SolidBrush(Color.White);// 标签字体颜色
                e.Graphics.DrawString(tabControlUerFlag.TabPages[e.Index].Text, font, bruFont, recTab, sftTab);
                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LabelRename()
        {
            foreach (Control c in tabControlUerFlag.Controls)
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
            foreach (Control c in tabControlUerFlag.Controls)
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
            string name = "CheckBox_", Lname = "Label";

            CheckBox pBox = new CheckBox();
            pBox.Name = name + nindex.ToString();
            pBox.AutoSize = false;
            pBox.Size = new Size(20, 20);
            lCheckBoxs.Add(pBox);
            Label label = new Label();
            label.AutoSize = true;
            label.Name = Lname + nindex.ToString();
            label.Font = new Font("微软雅黑", 12F);
            label.Text = Ltext;
            Label labelHead = FindLabel(nindex);
            lCheckBoxs.Last().Location = new Point(labelHead.Location.X + 40, labelHead.Location.Y);
            label.Location = new Point(labelHead.Location.X + 70, labelHead.Location.Y);
            int ngb = nindex / 17;
            GroupBox groupBox = lgbs[ngb] as GroupBox;
            groupBox.Controls.Add(lCheckBoxs.Last());
            groupBox.Controls.Add(label);
        }
    }
}
