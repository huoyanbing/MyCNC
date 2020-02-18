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

    public class TwoXAttri : FromTableClass
    {
        public double  X1{ get; set; }
        public double  X2 { get; set; }
        public TwoXAttri(double n1, double n2)
        {
            X1 = n1;
            X2 = n2;
        }
    }
    public class YAttri : FromTableClass
    {
        public double Y { get; set; }
        public YAttri(double n)
        {
            Y = n;
        }
    }




}
