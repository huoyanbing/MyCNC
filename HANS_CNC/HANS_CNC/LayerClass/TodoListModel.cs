using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HANS_CNC.LayerClass
{
    class TodoListModel : ITodoListModel
    {
        public int AddTodoListItem()
        {
            DataSet ds = this.GetTodoList();
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["Title"] = "Place New Todo Title Here";
            newRow["Text"] = "Place New Todo Text Here";
            ds.Tables[0].Rows.Add(newRow);
            ds.WriteXml(ConfigurationClass.ReadSetting("TodoXMLFilePath"));
            return ds.Tables[0].Rows.Count - 1;
        }

        public DataSet GetTodoList()
        {
            return new DataSet();        
        }   

        public bool RemoveTodoListItem(int recordID)
        {
            bool removeSuccessful = false;

            DataSet ds = this.GetTodoList();
            DataRow row = ds.Tables[0].Rows[recordID];
            try
            {
                row.Delete();
                removeSuccessful = true;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error Deleting Todo Item: " + e.Message + "\n" +
                    e.StackTrace);
            }
            ds.WriteXml(ConfigurationClass.ReadSetting("TodoXMLFilePath"));

            return removeSuccessful;
        }

        public void UpdateXMLDoc(DataSet newTodoListDataSet)
        {
            newTodoListDataSet.WriteXml(ConfigurationClass.ReadSetting("TodoXMLFilePath"));
        }
    }
}
