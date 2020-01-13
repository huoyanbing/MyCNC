using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HANS_CNC.UIClass
{
    public class StringTool
    {
        public static bool IsNumberId(string _value)
        {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }

        public static bool QuickValidate(string _express, string _value)
        {
            if (_value == null) return false;
            Regex myRegex = new Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
        }

        public static uint ExtractNum_u(string sourceString)
        {
            string result = Regex.Replace(sourceString, "[^0-9]+", String.Empty);
            if (IsNumberId(result))
                return uint.Parse(result);
            else
                throw new FormatException("ExtractNum_u"); 
        }

        public static int ExtractNum(string sourceString)
        {
            //  string result = Regex.Replace(sourceString, "[^+-][^0-9]+", "");
            string result = Regex.Replace(sourceString, "[^0-9]+", String.Empty);
            try
            {
                return int.Parse(result);
            }
            catch (FormatException )
            {
                throw;
            }
        }

        public static bool IsLettersOrNum(string _value)
        {
            return QuickValidate(@"^[A-Z0-9\s\b]*$", _value);
        }

    }
}
