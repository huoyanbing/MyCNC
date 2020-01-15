using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    class TodoListModel : ITodoListModel
    {
        public int AddTodoListItem()
        {
            throw new NotImplementedException();
        }

        public DataSet GetTodoList(string strData)
        {
            return new DataSet(strData);        
        }   

        public bool RemoveTodoListItem(int recordID)
        {
            throw new NotImplementedException();
        }

        public void UpdateXMLDoc(DataSet newTodoListDataSet)
        {
            throw new NotImplementedException();
        }
    }
}
