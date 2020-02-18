using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public class TableContainer
    {
        public List<FormTableModel> LTableModel;
        public TableContainer()
        {
            LTableModel = new List<FormTableModel>();
        }
        public void AddTable(FormTableModel s)
        {
            LTableModel.Add(s);
            s.TableInitial();
        }
         
    }
}
