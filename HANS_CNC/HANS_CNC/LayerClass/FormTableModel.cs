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
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlzPotion"));
        }
        public override void  TableInitial()
        {
             bs = new BindingSource();
            _DSixZAttri.Clear();
            SixZAttri CurZPos = new SixZAttri() { Z1=100};
            SixZAttri CurFootPos = new SixZAttri();
            string[,] strTable = xmlOperate.GenerateXMLFile(Zpos, SixZ);
            if(strTable!=null)
            {
                Type myType = typeof(SixZAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for(int i=0;i< myProperty.Length;i++)
                {
                    myProperty[i].SetValue(CurZPos, Convert.ToDouble( strTable[0, i]));
                    myProperty[i].SetValue(CurFootPos, Convert.ToDouble(strTable[1, i]));
                }
            }         
            _DSixZAttri.Add(Zpos[0], CurZPos);
            _DSixZAttri.Add(Zpos[1], CurFootPos);
            
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
    }
    public class ZCompensation: TableModel
    {
        public ZCompensation()
        {
            _DSixZAttri = new Dictionary<string, SixZAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlzComp"));
        }
        public override void TableInitial()
        {
             bs = new BindingSource();
            _DSixZAttri.Clear();
            SixZAttri ZModifier = new SixZAttri();
            SixZAttri Qoffset = new SixZAttri();
            string[,] strTable = xmlOperate.GenerateXMLFile(ZComp, SixZ);
            if (strTable != null)
            {
                Type myType = typeof(SixZAttri);
                PropertyInfo[] myProperty = myType.GetProperties();
                for (int i = 0; i < myProperty.Length; i++)
                {
                    myProperty[i].SetValue(ZModifier, Convert.ToDouble(strTable[0, i]));
                    myProperty[i].SetValue(Qoffset, Convert.ToDouble(strTable[1, i]));
                }
            }
            _DSixZAttri.Add(ZComp[0], ZModifier);
            _DSixZAttri.Add(ZComp[1], Qoffset);
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
    }
}
