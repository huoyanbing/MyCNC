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
    public partial class PositionsForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        string[] Zpos,ZSet,XYpos;
        bool blone;
        public PositionsForm()
        {
            InitializeComponent();     
        }
        private void PositionsForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            Zpos = new string[15] { "当前位置[mm]", "压力脚位置[mm]", "刀具接触位置[mm]", "压力脚表面[mm]", "刀具接触表面[mm]", "最低Z[mm]", "最低K[mm]", "第二次测量系统[mm]",
             "刀长偏差[mm]", "直径[mm]", "偏摆[mm]", "TLM位置[mm]", "压力脚-刀具[mm]", "快速表面的FIFO[mm]", "TOTO表面的FIFO[mm]"
            };
            ZSet = new string[4] { "测量绝对刀长Z的修正值[mm]", "Q平面的偏移[mm]", "测量相对刀长Z的修正值[mm]", "插入深度校正值[mm]" };
            XYpos = new string[4] { "绝对坐标[mm]","桌面坐标[mm]","PCB[mm]","伺服轴移动补偿[mm]"};
            blone = true;
           tabControlPos.DrawMode = TabDrawMode.OwnerDrawFixed;
           tabControlPos.SizeMode = TabSizeMode.Fixed;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                SolidBrush backgroundBlack;
                if (e.Index == tabControlPos.SelectedIndex) //当前Tab页的样式
                {
                    backgroundBlack = new SolidBrush(Color.DodgerBlue);//Tab整体背景颜色
                }
                else
                {
                    backgroundBlack = new SolidBrush(Color.FromArgb(64, 128, 128));//Tab整体背景颜色
                }
                Rectangle myTabRect = tabControlPos.GetTabRect(e.Index);
                e.Graphics.FillRectangle(backgroundBlack, myTabRect);
                StringFormat sftTab = new StringFormat();
                sftTab.LineAlignment = StringAlignment.Center;
                sftTab.Alignment = StringAlignment.Center;
                RectangleF recTab = (RectangleF)tabControlPos.GetTabRect(e.Index);//绘制区域
                 Font font = new System.Drawing.Font("微软雅黑", 11F);
                SolidBrush bruFont = new SolidBrush(Color.White);// 标签字体颜色
                e.Graphics.DrawString(tabControlPos.TabPages[e.Index].Text, font, bruFont, recTab, sftTab);    
                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PositionsForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
            if(blone)
            {
                ControlTool.DataGridViewInitial(dataGridViewZ, Zpos);
                ControlTool.DataGridViewInitial(dataGridViewZSet, ZSet);
                ControlTool.DataGridViewInitial(dataGridViewX, XYpos);
                ControlTool.DataGridViewInitial(dataGridViewY, XYpos);
                blone = false;
            }           
        }

    }
}
