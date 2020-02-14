using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public class SixZAttri
    {
        public double Z1 { get; set;  }
        public double Z2 { get; set; }
        public double Z3 { get; set; }
        public double Z4 { get; set; }
        public double Z5 { get; set; }
        public double Z6 { get; set; }

        public SixZAttri(double n1, double n2, double n3, double n4, double n5, double n6)
        {
            Z1 = n1;
            Z2 = n2;
            Z3 = n3;
            Z4 = n4;
            Z5 = n5;
            Z6 = n6;
        }
    }
    public class ZPostionModel
    {
        public Dictionary<String, SixZAttri> DsixZAttri;
        public ZPostionModel()
        {
            DsixZAttri = new Dictionary<string, SixZAttri>();
        }
            
        public void ZPostionInitial()
        {
            DsixZAttri.Clear();
            SixZAttri CurZPos = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            SixZAttri CurFootPos = new SixZAttri(0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
            DsixZAttri.Add("ZPos", CurZPos);
            DsixZAttri.Add("FootPos", CurFootPos);
        }
    }
}
