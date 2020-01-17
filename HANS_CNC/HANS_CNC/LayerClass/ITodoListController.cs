using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public interface ITodoListController
    {
        DataSet GetTodoList();
        int AddTodo();
        bool RemoveTodo(int recordID);
        void UpdateTodoList(DataSet newTodoListDataSet);
        void start();
        void stop();
    }
}
