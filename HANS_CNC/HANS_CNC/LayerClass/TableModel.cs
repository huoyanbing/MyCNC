using HANS_CNC.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC.LayerClass
{
    public abstract class TableModel
    {
        protected Dictionary<string, SixZAttri> _DSixZAttri;
        protected Dictionary<string, TwoXAttri> _DTwoXAttri;
        protected Dictionary<string, YAttri> _DYAttri;
        protected string[] SixZ =  { "Z1", "Z2", "Z3", "Z4", "Z5", "Z6" };
        protected string[] TowX = { "X1", "X2" };
        protected string[] Y = {"Y"};
        protected string[] Zpos =  { "ZPos", "FootPos" };
        protected string[] ZComp = { "ZModifier", "Qoffset" };
        protected string[] XYpos = { "AbCoord", "DeskCoord", "PCBCoord", "Servocomp" };
        protected XmlOperate xmlOperate;

        public Dictionary<string, SixZAttri> DSixZAttri
        {
            get { return _DSixZAttri; }
            set { _DSixZAttri = value; }
        }
        public Dictionary<string, TwoXAttri> DTwoXAttri
        {
            get { return _DTwoXAttri; }
            set { _DTwoXAttri = value; }
        }
        public Dictionary<string, YAttri> DYAttri
        {
            get { return _DYAttri; }
            set { _DYAttri = value; }
        }
        public abstract BindingSource TableInitial();
        public abstract void UpdateTable(string TName, FromTableClass TClass);
    }
}
