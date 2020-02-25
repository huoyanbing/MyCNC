using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC.LayerClass
{
    public class TableContainer: ITableViewUI
    {
         string[] str1 = { "ZPos", "FootPos" };
         string[] str2 = { "ZModifier", "Qoffset" };
         string[] str3 = { "AbCoord", "DeskCoord", "PCBCoord", "Servocomp" };
        private volatile static TableContainer uniqueInstance;
        private static object syncRoot = new Object();
        public List<TableModel> LTableModel;
        List<List<string>> LTableName;
        private TableContainer()
        { 
            LTableModel = new List<TableModel>();
            LTableName = new List<List<string>>();
            ArrangeTableName();
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

        private void ArrangeTableName()
        {
            LTableName.Add(new List<string>(str1));
            LTableName.Add(new List<string>(str2));
            LTableName.Add(new List<string>(str3));
            LTableName.Add(new List<string>(str3));
        }
        private int[] GetNameId(string _type)
        {
            int index1 = LTableName.FindIndex(a => a.Contains(_type));
            int index2 = LTableName.FindLastIndex(a => a.Contains(_type));
            int[] index = new int[index2 - index1 + 1];
            int j = 0;
            if (index1 == index2)
            {
                index[j] = index1;
            }
            else
            {
                for (int i= index1;i<=index2;i++)
                {
                    index[j] = i;
                    j++;
                }
            }
            return index;
        }

        public void UpdataParams(string type, params object[] list)
        {
            int [] index = GetNameId(type);
            if(index.Length==1)
            {
                LTableModel[index[0]].UpdateTable(type, list);
            }
            else
            {
                if(list.Length==3)
                {
                    object[] _list1 = { list[0], list[1] };
                    object[] _list2 = { list[2] };
                    LTableModel[index[0]].UpdateTable(type, _list1);
                    LTableModel[index[1]].UpdateTable(type, _list2);
                }
            }
        }

        public object[] GetValue(string type)
        {
            int[] index = GetNameId(type);
            object[] obj=null;
            if (index.Length == 1)
            {
                FromTableClass fromTableClass=  LTableModel[index[0]].GetTableInfo(type);
                if(fromTableClass is SixZAttri)
                {
                        SixZAttri _sixZAttri = fromTableClass as SixZAttri;
                        Type myType = typeof(SixZAttri);
                        PropertyInfo[] myProperty = myType.GetProperties();
                        obj = new object[myProperty.Length];
                        for (int i = 0; i < myProperty.Length; i++)
                        {
                            obj[i] = myProperty[i].GetValue(_sixZAttri);
                        }
                    
                }
            }
            else 
            {
                List<object> Lobj = new List<object>();
                for (int j= 0; j<index.Length;j++)
                {
                    FromTableClass fromTableClass = LTableModel[index[j]].GetTableInfo(type);
                    if (fromTableClass is TwoXAttri)
                    {
                        TwoXAttri _sixZAttri = fromTableClass as TwoXAttri;
                        Type myType = typeof(TwoXAttri);
                        PropertyInfo[] myProperty = myType.GetProperties();
                        for (int i = 0; i < myProperty.Length; i++)
                        {
                            Lobj.Add(myProperty[i].GetValue(_sixZAttri));
                        }
                    }
                    else if (fromTableClass is YAttri)
                    {
                        YAttri _sixZAttri = fromTableClass as YAttri;
                        Type myType = typeof(YAttri);
                        PropertyInfo[] myProperty = myType.GetProperties();
                        for (int i = 0; i < myProperty.Length; i++)
                        {
                            Lobj.Add(myProperty[i].GetValue(_sixZAttri));
                        }
                    }
                }
                obj = Lobj.ToArray();
            }
            return obj;
        }
    }
}
