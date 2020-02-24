using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC.UIClass
{
    public class ControlTool
    {
        public static void DataGridViewInitial(DataGridView dataGridView, string[] strRow)
        {
            int width = (dataGridView.Width - dataGridView.RowHeadersWidth) / dataGridView.ColumnCount;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Width = width;
            }
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.RowTemplate.Height = 28;
            dataGridView.Height = dataGridView.ColumnHeadersHeight + dataGridView.RowTemplate.Height * strRow.Length;
            dataGridView.AllowUserToAddRows = false;
            for (int i = 0; i < strRow.Length; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = strRow[i];
            }
        }
        public static void DataGridViewControInitial(DataGridView dataGridView)
        {
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.RowTemplate.Height = 28;
            dataGridView.AllowUserToAddRows = false;
        }
        public static void DataGridViewTitle(DataGridView dataGridView, string[] strRow)
        {
            for(int i=0;i< dataGridView.RowCount;i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = strRow[i];
            }
        }
        public static void TabControlDrawItem(TabControl tabControl, DrawItemEventArgs e)
        {
            try
            {
                SolidBrush backgroundBlack;
                if (e.Index == tabControl.SelectedIndex) //当前Tab页的样式
                {
                    backgroundBlack = new SolidBrush(Color.DodgerBlue);//Tab整体背景颜色
                }
                else
                {
                    backgroundBlack = new SolidBrush(Color.FromArgb(64, 128, 128));//Tab整体背景颜色
                }

                Rectangle myTabRect = tabControl.GetTabRect(e.Index);
                e.Graphics.FillRectangle(backgroundBlack, myTabRect);
                backgroundBlack.Dispose();
                StringFormat sftTab = new StringFormat();
                sftTab.LineAlignment = StringAlignment.Center;
                sftTab.Alignment = StringAlignment.Center;
                RectangleF recTab = (RectangleF)tabControl.GetTabRect(e.Index);//绘制区域
                using (Font font = new System.Drawing.Font("微软雅黑", 11F))
                using (SolidBrush bruFont = new SolidBrush(Color.White))// 标签字体颜色
                {
                    e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, font, bruFont, recTab, sftTab);
                }
                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
