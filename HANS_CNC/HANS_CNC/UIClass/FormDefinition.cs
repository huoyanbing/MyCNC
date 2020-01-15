﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class UserEventArgs : EventArgs
    {
        public int nFV { get; set; }
        public string Ex2Path { get; set; }
    }

}
