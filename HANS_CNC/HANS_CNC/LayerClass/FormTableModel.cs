using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public abstract class FormTableModel
    {
        public abstract void TableInitial();
    }
    public class ZPostionModel: FormTableModel
    {
        public Dictionary<String, SixZAttri> DsixZAttri;
        public ZPostionModel()
        {
            DsixZAttri = new Dictionary<string, SixZAttri>();
        }

        public override void TableInitial()
        {
            DsixZAttri.Clear();
            SixZAttri CurZPos = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            SixZAttri CurFootPos = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            DsixZAttri.Add("ZPos", CurZPos);
            DsixZAttri.Add("FootPos", CurFootPos);
        }

    }
    public class ZCompensation: FormTableModel
    {
        public Dictionary<String, SixZAttri> DzCompAttri;
        public ZCompensation()
        {
            DzCompAttri = new Dictionary<string, SixZAttri>();
        }

        public override void TableInitial()
        {
            DzCompAttri.Clear();
            SixZAttri ZModifier = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            SixZAttri Qoffset = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            DzCompAttri.Add("ZModifier", ZModifier);
            DzCompAttri.Add("Qoffset", Qoffset);
        }

    }

}
