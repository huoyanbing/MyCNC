using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HANS_CNC.UIClass
{
    public class XmlOperate
    {
        private string _filePath = string.Empty;
        private XmlDocument myXmlDoc;
        private XmlElement _element;
        public XmlOperate(string xmlFilePath)
        {
            //获取XML文件的绝对路径
            _filePath = xmlFilePath;
        }
        public  void GenerateXMLFile(string[] xmlRows, string[] xmlColumns)
        {
            try
            {
                if (File.Exists(_filePath) == false)
                {
                    using (File.Create(_filePath)) //新建文件
                    { }
                }
                myXmlDoc = new XmlDocument(); //初始化一个xml实例
                XmlElement rootElement = myXmlDoc.CreateElement("CNCbody");   //创建xml的根节点
                myXmlDoc.AppendChild(rootElement);     //将根节点加入到xml文件中（AppendChild）
                foreach (var a in xmlRows)
                {
                    XmlElement firstLevelElement = myXmlDoc.CreateElement(a); //初始化第一层的第一个子节点
                   // firstLevelElement.SetAttribute("Name", a); //填充第一层的第一个子节点的属性值（SetAttribute）
                    rootElement.AppendChild(firstLevelElement); //将第一层的第一个子节点加入到根节点下
                    foreach (var b in xmlColumns)
                    {
                        XmlElement xmlElement = myXmlDoc.CreateElement(b);
                        xmlElement.InnerText = "0.00";
                        firstLevelElement.AppendChild(xmlElement);
                    }
                }
                _element = myXmlDoc.DocumentElement;
                myXmlDoc.Save(_filePath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public  void GetXMLInformation(string xmlFilePath)
        {
            try
            {
                myXmlDoc.Load(xmlFilePath); //加载xml文件（参数为xml文件的路径）
                XmlNode rootNode = myXmlDoc.FirstChild;  //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点   
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes; //获得该节点的子节点（即：该节点的第一层子节点）
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    XmlAttributeCollection attributeCol = node.Attributes;
                    foreach (XmlAttribute attri in attributeCol)
                    {
                        //获取属性名称与属性值
                        string name = attri.Name;
                        string value = attri.Value;
                    }
                    if (node.HasChildNodes)  //判断此节点是否还有子节点
                    {
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            string name = node.ChildNodes[i].Name;  //获取该节点的名字
                            string innerText = node.ChildNodes[i].InnerText; //获取该节点的值（即：InnerText）

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetXMLValue(string TableName,string ColName)
        {
            //myXmlDoc.Load(_filePath);
            XmlNode tableNode = myXmlDoc.DocumentElement.SelectSingleNode(TableName);
            XmlNode colNode = tableNode.SelectSingleNode(ColName);
            return colNode.InnerText;
        }
        public void SetXMLValue(string TableName, string ColName,string strVal)
        {
            XmlNode tableNode = myXmlDoc.DocumentElement.SelectSingleNode(TableName);
            XmlElement TableElement = (XmlElement)tableNode;
            TableElement[ColName].InnerText = strVal;
            myXmlDoc.Save(_filePath);
        }
        public void DelXMLInfo(string RowName)
        {
            XmlNode tableNode = myXmlDoc.DocumentElement.SelectSingleNode(RowName);
            //tableNode.RemoveAll();
            myXmlDoc.DocumentElement.RemoveChild(tableNode);
            myXmlDoc.Save(_filePath);
        }


    }
}
