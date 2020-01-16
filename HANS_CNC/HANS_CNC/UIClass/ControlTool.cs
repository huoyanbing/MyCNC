using System;
using System.Collections.Generic;
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
        public static void DataGridViewComoInitial(DataGridView dataGridView, string[] strRow)
        {
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Columns[0].Width = 50;
            dataGridView.RowTemplate.Height = 28;
            dataGridView.Height = dataGridView.ColumnHeadersHeight + dataGridView.RowTemplate.Height * strRow.Length;
            dataGridView.AllowUserToAddRows = false;
            for (int i = 0; i < strRow.Length; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[1].Value = strRow[i];
            }


        }
    }
}
