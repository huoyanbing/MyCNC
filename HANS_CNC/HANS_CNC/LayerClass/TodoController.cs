using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public class TodoController : ITodoListController
    {
        ITodoListModel todoModel;

        public TodoController()
        {
            this.todoModel = new TodoListModel();
        }
        public int AddTodo()
        {
            return todoModel.AddTodoListItem();
        }

        public DataSet GetTodoList()
        {
            return todoModel.GetTodoList();
        }

        public bool RemoveTodo(int recordID)
        {
            return todoModel.RemoveTodoListItem(recordID);
        }

        public void UpdateTodoList(DataSet newTodoListDataSet)
        {
            todoModel.UpdateXMLDoc(newTodoListDataSet);
        }

        public void UPDATEListItem()
        {
            todoModel.UPDATEListItem();
        }
        public void start()
        {
            //throw new NotImplementedException();
        }

        public void stop()
        {
            //throw new NotImplementedException();
        }
    }
}
