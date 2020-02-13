using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HANS_CNC
{
    public enum FormName
    {
        Form_File,
        Form_ZPlanes,
        Form_WorkStatus,
        Form_PCBSetup,
        Form_AxisVersion,
        Form_SafetyZone,
        Form_JogKeys,
        Form_Positions,
        Form_Input,
        Form_Output,
        Form_AxisCheck,
        Form_FileManage,
        Form_UserFlag,
    }

    public class ZPostion
    {
        public double[] CurZPos;
        public double[] PFootPos;
        public ZPostion()
        {
            CurZPos = new double[6];
            PFootPos = new double[6];
        }
    }
    public class UserEventArgs : EventArgs
    {
        public int nFV { get; set; }
        public string Ex2Path { get; set; }
        public ZPostion zPostion;

    }

    public class ConfigData
    {
        public static NameValueCollection myCol = new NameValueCollection();
        public ConfigData()
        {
            myCol.Add("TodoXMLFilePath", Application.StartupPath);
        }
    }

}
