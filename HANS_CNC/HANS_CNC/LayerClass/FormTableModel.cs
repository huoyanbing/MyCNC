using HANS_CNC.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC.LayerClass
{
    public class ZPostionModel: TableModel
    {
        public ZPostionModel()
        {
            _DSixZAttri = new Dictionary<string, SixZAttri>();
            _LSixZAttri = new List<SixZAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlzPotion"));
        }
        public override void  TableInitial()
        {
             bs = new BindingSource();
            _DSixZAttri.Clear();
            _LSixZAttri.Clear();
            for(int i=0;i< Zpos.Length;i++)
            {
                _LSixZAttri.Add(new SixZAttri());
            }
            string[,] strTable = xmlOperate.GenerateXMLFile(Zpos, SixZ);
            if(strTable!=null)
            {
                Type myType = typeof(SixZAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for(int i=0;i< myProperty.Length;i++)
                {
                    for(int j=0;j< _LSixZAttri.Count;j++ )
                    {
                        myProperty[i].SetValue(_LSixZAttri[j], Convert.ToDouble(strTable[j, i]));
                    }
                }
            }
            for (int i = 0; i < Zpos.Length; i++)
            {
                _DSixZAttri.Add(Zpos[i], _LSixZAttri[i]);
            }            
            bs.DataSource = _DSixZAttri.Values;
        }
        public override void UpdateTable(string TName, FromTableClass TClass)
        {
            bs = new BindingSource();
            SixZAttri _sixZAttri = TClass as SixZAttri;
            _DSixZAttri[TName] = _sixZAttri;
            bs.DataSource = _DSixZAttri.Values;
            Type myType = typeof(SixZAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow=new string[myProperty.Length];
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_sixZAttri).ToString();
            }
            xmlOperate.SetXMLRowValue(TName, strRow);
        }
        public override void LoadTable()
        {
            List<string> Lkeys = new List<string>(_DSixZAttri.Keys);
            Type myType = typeof(SixZAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[,] strTable = new string[Lkeys.Count, myProperty.Length];
            for (int i = 0; i < Lkeys.Count; i++)
            {
                for (int j = 0; j < myProperty.Length; j++)
                {
                    strTable[i, j] = myProperty[j].GetValue(_DSixZAttri[Lkeys[i]]).ToString();
                }
            }
            xmlOperate.UpdataXML(strTable);
        }

        public override FromTableClass GetTableInfo(string TName)
        {
            SixZAttri _sixZAttri = _DSixZAttri[TName];
            return _sixZAttri;
        }

        public override void UpdateTable(string TName, params object[] list)
        {
            try
            {
                bs = new BindingSource();
                SixZAttri _sixZAttri = new SixZAttri();
                _sixZAttri = _DSixZAttri[TName];
                Type myType = typeof(SixZAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                string[] strRow = new string[myProperty.Length];
                for (int i = 0; i < list.Length; i++)
                {
                    if(!list[i].Equals(-1))
                    {
                        myProperty[i].SetValue(_sixZAttri, list[i]);
                    }
                }
                for (int i = 0; i < myProperty.Length; i++)
                {
                    strRow[i] = myProperty[i].GetValue(_sixZAttri).ToString();
                }
                _DSixZAttri[TName] = _sixZAttri;
                bs.DataSource = _DSixZAttri.Values;
                xmlOperate.SetXMLRowValue(TName, strRow);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
    public class ZCompensation: TableModel
    {
        public ZCompensation()
        {
            _DSixZAttri = new Dictionary<string, SixZAttri>();
            _LSixZAttri = new List<SixZAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlzComp"));
        }
        public override void TableInitial()
        {
            bs = new BindingSource();
            _DSixZAttri.Clear();
            _LSixZAttri.Clear();
            for (int i = 0; i < ZComp.Length; i++)
            {
                _LSixZAttri.Add(new SixZAttri());
            }
            string[,] strTable = xmlOperate.GenerateXMLFile(ZComp, SixZ);
            if (strTable != null)
            {
                Type myType = typeof(SixZAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for (int i = 0; i < myProperty.Length; i++)
                {
                    for (int j = 0; j < _LSixZAttri.Count; j++)
                    {
                        myProperty[i].SetValue(_LSixZAttri[j], Convert.ToDouble(strTable[j, i]));
                    }
                }
            }
            for (int i = 0; i < ZComp.Length; i++)
            {
                _DSixZAttri.Add(ZComp[i], _LSixZAttri[i]);
            }
            bs.DataSource = _DSixZAttri.Values;
        }

        public override void UpdateTable(string TName, FromTableClass TClass)
        {
            bs = new BindingSource();
            SixZAttri _sixZAttri = TClass as SixZAttri;
            _DSixZAttri[TName] = _sixZAttri;
            bs.DataSource = _DSixZAttri.Values;
            Type myType = typeof(SixZAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_sixZAttri).ToString();
            }
            xmlOperate.SetXMLRowValue(TName, strRow);
        }

        public override void LoadTable()
        {
            List<string> Lkeys = new List<string>(_DSixZAttri.Keys);
            Type myType = typeof(SixZAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[,] strTable = new string[Lkeys.Count, myProperty.Length];
            for (int i=0;i< Lkeys.Count;i++)
            {
                for (int j = 0; j < myProperty.Length; j++)
                {
                    strTable[i, j] = myProperty[j].GetValue(_DSixZAttri[Lkeys[i]]).ToString();
                }
            }
            xmlOperate.UpdataXML(strTable);
        }

        public override FromTableClass GetTableInfo(string TName)
        {
            SixZAttri _sixZAttri = _DSixZAttri[TName];
            return _sixZAttri;
        }

        public override void UpdateTable(string TName, params object[] list)
        {
            bs = new BindingSource();
            SixZAttri _sixZAttri = new SixZAttri();
            Type myType = typeof(SixZAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < myProperty.Length; i++)
            {
                myProperty[i].SetValue(TName, list[i]);
                strRow[i] = list[i].ToString();
            }
            _DSixZAttri[TName] = _sixZAttri;
            bs.DataSource = _DSixZAttri.Values;
            xmlOperate.SetXMLRowValue(TName, strRow);
        }
    }
    public class XPosition : TableModel
    {
        public XPosition()
        {
            _DTwoXAttri = new Dictionary<string, TwoXAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlxPosition"));
        }

        public override void  TableInitial()
        {
            bs = new BindingSource();
            _DTwoXAttri.Clear();
            TwoXAttri t1 = new TwoXAttri();
            TwoXAttri t2 = new TwoXAttri();
            TwoXAttri t3 = new TwoXAttri();
            TwoXAttri t4 = new TwoXAttri();
            string[,] strTable = xmlOperate.GenerateXMLFile(XYpos, TowX);
            if (strTable != null)
            {
                Type myType = typeof(TwoXAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for (int i = 0; i < myProperty.Length; i++)
                {
                    myProperty[i].SetValue(t1, Convert.ToDouble(strTable[0, i]));
                    myProperty[i].SetValue(t2, Convert.ToDouble(strTable[1, i]));
                    myProperty[i].SetValue(t3, Convert.ToDouble(strTable[2, i]));
                    myProperty[i].SetValue(t4, Convert.ToDouble(strTable[3, i]));
                }
            }
            _DTwoXAttri.Add(XYpos[0], t1);
            _DTwoXAttri.Add(XYpos[1], t2);
            _DTwoXAttri.Add(XYpos[2], t3);
            _DTwoXAttri.Add(XYpos[3], t4);       
            bs.DataSource = _DTwoXAttri.Values;
        }

        public override void UpdateTable(string TName, FromTableClass TClass)
        {
            bs = new BindingSource();
            TwoXAttri _twoXAttri = TClass as TwoXAttri;
            _DTwoXAttri[TName] = _twoXAttri;
            bs.DataSource = _DTwoXAttri.Values;
            Type myType = typeof(TwoXAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_twoXAttri).ToString();
            }
            xmlOperate.SetXMLRowValue(TName, strRow);
        }

        public override void LoadTable()
        {
            List<string> Lkeys = new List<string>(_DTwoXAttri.Keys);
            Type myType = typeof(TwoXAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[,] strTable = new string[Lkeys.Count, myProperty.Length];
            for (int i = 0; i < Lkeys.Count; i++)
            {
                for (int j = 0; j < myProperty.Length; j++)
                {
                    strTable[i, j] = myProperty[j].GetValue(_DTwoXAttri[Lkeys[i]]).ToString();
                }
            }
            xmlOperate.UpdataXML(strTable);
        }

        public override FromTableClass GetTableInfo(string TName)
        {
            TwoXAttri _twoXAttri = _DTwoXAttri[TName];
            return _twoXAttri;
        }

        public override void UpdateTable(string TName, params object[] list)
        {
            bs = new BindingSource();
            TwoXAttri _twoZAttri = new TwoXAttri();
            Type myType = typeof(TwoXAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < list.Length; i++)
            {
                if (!list[i].Equals(-1))
                {
                    myProperty[i].SetValue(_twoZAttri, list[i]);
                }
            }
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_twoZAttri).ToString();
            }          
            _DTwoXAttri[TName] = _twoZAttri;
            bs.DataSource = _DTwoXAttri.Values;
            xmlOperate.SetXMLRowValue(TName, strRow);
        }
    }
    public class YPosition : TableModel
    {
        public YPosition()
        {
            _DYAttri = new Dictionary<string, YAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlyPosition"));
        }

        public override void  TableInitial()
        {
             bs = new BindingSource();
            _DYAttri.Clear();
            YAttri t1 = new YAttri();
            YAttri t2 = new YAttri();
            YAttri t3 = new YAttri();
            YAttri t4 = new YAttri();
            string[,] strTable = xmlOperate.GenerateXMLFile(XYpos, Y);
            if (strTable != null)
            {
                Type myType = typeof(YAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for (int i = 0; i < myProperty.Length; i++)
                {
                    myProperty[i].SetValue(t1, Convert.ToDouble(strTable[0, i]));
                    myProperty[i].SetValue(t2, Convert.ToDouble(strTable[1, i]));
                    myProperty[i].SetValue(t3, Convert.ToDouble(strTable[2, i]));
                    myProperty[i].SetValue(t4, Convert.ToDouble(strTable[3, i]));
                }
            }
            _DYAttri.Add(XYpos[0], t1);
            _DYAttri.Add(XYpos[1], t2);
            _DYAttri.Add(XYpos[2], t3);
            _DYAttri.Add(XYpos[3], t4);
            
            bs.DataSource = _DYAttri.Values;
        }

        public override void UpdateTable(string TName, FromTableClass TClass)
        {
            bs = new BindingSource();
            YAttri _yAttri = TClass as YAttri;
            _DYAttri[TName] = _yAttri;
            bs.DataSource = _DYAttri.Values;
            Type myType = typeof(YAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_yAttri).ToString();
            }
            xmlOperate.SetXMLRowValue(TName, strRow);
        }

        public override void LoadTable()
        {
            List<string> Lkeys = new List<string>(_DYAttri.Keys);
            Type myType = typeof(YAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[,] strTable = new string[Lkeys.Count, myProperty.Length];
            for (int i = 0; i < Lkeys.Count; i++)
            {
                for (int j = 0; j < myProperty.Length; j++)
                {
                    strTable[i, j] = myProperty[j].GetValue(_DYAttri[Lkeys[i]]).ToString();
                }
            }
            xmlOperate.UpdataXML(strTable);
        }

        public override FromTableClass GetTableInfo(string TName)
        {
            YAttri _YAttri = _DYAttri[TName];
            return _YAttri;
        }

        public override void UpdateTable(string TName, params object[] list)
        {
            bs = new BindingSource();
            YAttri _YAttri = new YAttri();
            Type myType = typeof(YAttri);
            PropertyInfo[] myProperty = myType.GetProperties();
            string[] strRow = new string[myProperty.Length];
            for (int i = 0; i < list.Length; i++)
            {
                if (!list[i].Equals(-1))
                {
                    myProperty[i].SetValue(_YAttri, list[i]);
                }
            }
            for (int i = 0; i < myProperty.Length; i++)
            {
                strRow[i] = myProperty[i].GetValue(_YAttri).ToString();
            }
            _DYAttri[TName] = _YAttri;
            bs.DataSource = _DYAttri.Values;
            xmlOperate.SetXMLRowValue(TName, strRow);
        }
    }
}
