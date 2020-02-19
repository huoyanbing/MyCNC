using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC.LayerClass
{
    public class TableContainer
    {
        public List<TableModel> LTableModel;
        public List<BindingSource> Lbs;
        
        public TableContainer()
        { 
            LTableModel = new List<TableModel>();
            Lbs = new List<BindingSource>();
        }
        public void AddTable(TableModel s)
        {
            LTableModel.Add(s);
            Lbs.Add( s.TableInitial());
        }
         
    }
}
