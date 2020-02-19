using HANS_CNC.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{

    public class ZPostionModel: TableModel
    {
        public ZPostionModel()
        {
            _DSixZAttri = new Dictionary<string, SixZAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlzPotion"));
        }
        public override void TableInitial()
        {
            _DSixZAttri.Clear();
            SixZAttri CurZPos = new SixZAttri();
            SixZAttri CurFootPos = new SixZAttri();
            _DSixZAttri.Add(Zpos[0], CurZPos);
            _DSixZAttri.Add(Zpos[1], CurFootPos);
            xmlOperate.GenerateXMLFile(Zpos, SixZ);
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
            _DSixZAttri.Clear();
            SixZAttri ZModifier = new SixZAttri();
            SixZAttri Qoffset = new SixZAttri();
            _DSixZAttri.Add(ZComp[0], ZModifier);
            _DSixZAttri.Add(ZComp[1], Qoffset);
            xmlOperate.GenerateXMLFile(ZComp, SixZ);
        }

    }
    public class XPosition : TableModel
    {
        public XPosition()
        {
            _DTwoXAttri = new Dictionary<string, TwoXAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlxPosition"));
        }

        public override void TableInitial()
        {
            _DTwoXAttri.Clear();
            TwoXAttri t1 = new TwoXAttri();
            TwoXAttri t2 = new TwoXAttri();
            TwoXAttri t3 = new TwoXAttri();
            TwoXAttri t4 = new TwoXAttri();
            _DTwoXAttri.Add(XYpos[0], t1);
            _DTwoXAttri.Add(XYpos[1], t2);
            _DTwoXAttri.Add(XYpos[2], t3);
            _DTwoXAttri.Add(XYpos[3], t4);
            xmlOperate.GenerateXMLFile(XYpos, TowX);
        }

    }

    public class YPosition : TableModel
    {
        public YPosition()
        {
            _DYAttri = new Dictionary<string, YAttri>();
            xmlOperate = new XmlOperate(ConfigurationClass.ReadSetting("xmlyPosition"));
        }

        public override void TableInitial()
        {
            _DYAttri.Clear();
            YAttri t1 = new YAttri();
            YAttri t2 = new YAttri();
            YAttri t3 = new YAttri();
            YAttri t4 = new YAttri();
            _DYAttri.Add(XYpos[0], t1);
            _DYAttri.Add(XYpos[1], t2);
            _DYAttri.Add(XYpos[2], t3);
            _DYAttri.Add(XYpos[3], t4);
            xmlOperate.GenerateXMLFile(XYpos, Y);
        }

    }

}
