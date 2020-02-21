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
        private volatile static TableContainer uniqueInstance;
        private static object syncRoot = new Object();
        public List<TableModel> LTableModel;
        private TableContainer()
        { 
            LTableModel = new List<TableModel>();
        }
        public static TableContainer GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (syncRoot)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new TableContainer();
                    }
                }
            }
            return uniqueInstance;
        }
        public void AddTable(TableModel s)
        {
            LTableModel.Add(s);
            s.TableInitial();
        }
         
    }
}
