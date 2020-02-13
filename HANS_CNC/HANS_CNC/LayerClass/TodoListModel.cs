using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HANS_CNC.LayerClass
{
    class TodoListModel : ITodoListModel
    {
        DataSet dataSet = new DataSet("Entry");
        ZPostion zPos = new ZPostion();
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
            dataSet.Clear();
            dataSet.ReadXml(ConfigurationClass.ReadSetting("TodoXMLFilePath"));
            DataTable table = dataSet.Tables[0];
            return dataSet;
        }
        
        public void UPDATEListItem()
        {
            DataSet ds = this.GetTodoList();
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        row[column]=100.000;
                    }
                }
            }
            ds.WriteXml(ConfigurationClass.ReadSetting("TodoXMLFilePath"));
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
