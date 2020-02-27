using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    interface ITableViewUI
    {
        void UpdataParams(string type, params object[] list);
        object[] GetValue(string type);
        void InputIO(string type, bool blactive);

        event EventHandler<UserEventArgs> OutPutChanged;
    }
}
