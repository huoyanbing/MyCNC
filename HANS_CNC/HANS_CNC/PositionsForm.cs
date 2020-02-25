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
using HANS_CNC.LayerClass;

namespace HANS_CNC
{
    public partial class PositionsForm : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        string[] Zpos,ZSet,XYpos;
        bool blone;
        ITodoListController controller ;
        TableContainer tableContainer;
        ITableViewUI tableUI;

        //public static event EventHandler<UserEventArgs> ZPositionChanged;
        public PositionsForm()
        {
            InitializeComponent();
            controller = new TodoController();
            tableContainer = TableContainer.GetInstance();
            tableUI = TableContainer.GetInstance();
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
            ControlTool.TabControlDrawItem(tabControlPos, e);
        }

        private void PositionsForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this,1);
            if(blone)
            {
               // ControlTool.DataGridViewInitial(dataGridViewZ, Zpos);
                ControlTool.DataGridViewControInitial(dataGridViewZ);
                ControlTool.DataGridViewControInitial(dataGridViewZSet);
                ControlTool.DataGridViewControInitial(dataGridViewX);
                ControlTool.DataGridViewControInitial(dataGridViewY);
                blone = false;
                LoadDataListTab();

            }           
        }

        private DataSet GetTodoListDataSet()
        {
            return controller.GetTodoList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //controller.UPDATEListItem();
            //FromTableClass a = new SixZAttri() { Z1 = 100, Z2 = 59.35, Z3 = 25.07, Z4 = 90.58, Z5 = 456, Z6 = 85 };
            //FromTableClass a1 = new SixZAttri() { Z1 = 500, Z2 = 658.35, Z3 = 2548.236, Z4 = 21469.325, Z5 = 25412.365, Z6 = 254893.365 };
            //FromTableClass b1 = new TwoXAttri() { X1 = 9000, X2 = 632.31 };
            //FromTableClass b2 = new YAttri() { Y = 5860 };
            //tableContainer.LTableModel[0].UpdateTable("ZPos", a);
            //tableContainer.LTableModel[0].UpdateTable("FootPos", a);
            //tableContainer.LTableModel[1].UpdateTable("ZModifier", a1);
            //tableContainer.LTableModel[2].UpdateTable("AbCoord", b1);
            //tableContainer.LTableModel[3].UpdateTable("AbCoord", b2);
            object[] a = { 582, 325 ,90};
            tableUI.UpdataParams("AbCoord", a);
            object[] b = tableUI.GetValue("AbCoord");
            //tableContainer.LTableModel[0].UpdateTable("ZPos", a);
            //LoadDataList();
            //dataGridViewZ.Rows[1].Cells[1].Style.BackColor = Color.Red;
            //dataGridViewZ.Rows[1].Cells[1].Style.SelectionBackColor= Color.Red;
        }

        private void LoadDataGrid()
        {
            dataGridViewZ.DataSource = GetTodoListDataSet();
            dataGridViewZ.DataMember = "Entry";
        }

        private void tabControlPos_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    UpdateDGVZPos();
                    break;
                case 1:
                    UpdateDGVZComp();
                    break;
                case 2:
                    UpdateDGVXYPos();
                    break;
                default:
                    break;
            }
         }

        private void dgvZposInitial()
        {
            controller.AddTodo();
        }

        private void LoadDataListTab()
        {
            dataGridViewZ.DataSource = tableContainer.LTableModel[0].BS;
            dataGridViewZSet.DataSource = tableContainer.LTableModel[1].BS;
            dataGridViewX.DataSource = tableContainer.LTableModel[2].BS;
            dataGridViewY.DataSource = tableContainer.LTableModel[3].BS;
            ControlTool.DataGridViewTitle(dataGridViewZ, Zpos);
            tabControlPos.SelectedIndex = 1;
            ControlTool.DataGridViewTitle(dataGridViewZSet, ZSet);
            tabControlPos.SelectedIndex = 2;
            ControlTool.DataGridViewTitle(dataGridViewX, XYpos);
            ControlTool.DataGridViewTitle(dataGridViewY, XYpos);
            tabControlPos.SelectedIndex = 0;
        }
        private void LoadDataList()
        {
            dataGridViewZ.DataSource = tableContainer.LTableModel[0].BS;
            dataGridViewZSet.DataSource = tableContainer.LTableModel[1].BS;
            dataGridViewX.DataSource = tableContainer.LTableModel[2].BS;
            dataGridViewY.DataSource = tableContainer.LTableModel[3].BS;
            ControlTool.DataGridViewTitle(dataGridViewZ, Zpos);
            ControlTool.DataGridViewTitle(dataGridViewZSet, ZSet);
            ControlTool.DataGridViewTitle(dataGridViewX, XYpos);
            ControlTool.DataGridViewTitle(dataGridViewY, XYpos);
            
        }
        private void UpdateDGVZPos()
        {
            dataGridViewZ.DataSource = tableContainer.LTableModel[0].BS;
            ControlTool.DataGridViewTitle(dataGridViewZ, Zpos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableContainer.LTableModel[1].LoadTable();
        }

        private void UpdateDGVZComp()
        {
            dataGridViewZSet.DataSource = tableContainer.LTableModel[1].BS;
            ControlTool.DataGridViewTitle(dataGridViewZSet, ZSet);
        }

        private void UpdateDGVXYPos()
        {
            dataGridViewX.DataSource = tableContainer.LTableModel[2].BS;
            dataGridViewY.DataSource = tableContainer.LTableModel[3].BS;
            ControlTool.DataGridViewTitle(dataGridViewX, XYpos);
            ControlTool.DataGridViewTitle(dataGridViewY, XYpos);
        }
    }
}
