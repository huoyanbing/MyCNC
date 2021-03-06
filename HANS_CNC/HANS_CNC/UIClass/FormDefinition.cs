﻿using System;
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

    public enum OutIOName
    {
        LaserZ1 = 1,
        LaserZ2 ,
        LaserZ3 ,
        LaserZ4 ,
        LaserZ5 ,
        LaserZ6 ,
        M36 ,
        Collet,
        CNCCalarm,
        CNCStop,
        CNCRun,
        Beeper,
    }

    public enum TableName:int
    {
        Table_ZPosition,
        Table_ZCompensation,
    }


    public class UserEventArgs : EventArgs
    {
        public int nFV { get; set; }
        public string Ex2Path { get; set; }
        public KeyValuePair<OutIOName,bool> outio ;

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
