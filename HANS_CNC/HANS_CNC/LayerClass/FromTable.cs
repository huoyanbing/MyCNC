using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public abstract class FromTableClass
    {

    }

    public class SixZAttri: FromTableClass
    {
        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double Z3 { get; set; }
        public double Z4 { get; set; }
        public double Z5 { get; set; }
        public double Z6 { get; set; }
    }

    public class TwoXAttri : FromTableClass
    {
        public double  X1{ get; set; }
        public double  X2 { get; set; }
    }
    public class YAttri : FromTableClass
    {
        public double Y { get; set; }
    }




}
