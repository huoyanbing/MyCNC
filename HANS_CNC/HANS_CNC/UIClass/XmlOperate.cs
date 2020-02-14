using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HANS_CNC.UIClass
{
    public class XmlOperate
    {
        private string _filePath = string.Empty;
        private XmlDocument _xml;
        private XmlElement _element;
        public XmlOperate(string xmlFilePath)
        {
            //获取XML文件的绝对路径
            _filePath = xmlFilePath;
        }
    }
}
