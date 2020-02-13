using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    interface ITodoListModel
    {
        DataSet GetTodoList();
        int AddTodoListItem();
        bool RemoveTodoListItem(int recordID);
        void UpdateXMLDoc(DataSet newTodoListDataSet);
        void UPDATEListItem();


    }
}
