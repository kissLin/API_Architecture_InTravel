using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PayEasyApi.Utility.Extensions.SerializerSettings
{
    public static class XmlUtility
    {
        public static void WriteXml(string FileName, string[] Header, string[] NodeName, string[] NodeValue)
        {
            if (!File.Exists(FileName)) 
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode node = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                xmlDoc.AppendChild(node);
                List<XmlElement> HeaderNode = new List<XmlElement>();
                for (int j = 0; j < Header.Length; j++)
                {
                    HeaderNode.Add(xmlDoc.CreateElement(Header[j]));
                    if (j == 0) xmlDoc.AppendChild(HeaderNode[j]);
                    else HeaderNode[j - 1].AppendChild(HeaderNode[j]);
                }
                for (int i = 0; i < NodeName.Length; i++)
                {
                    XmlElement temp = xmlDoc.CreateElement(NodeName[i]);
                    temp.InnerText = NodeValue[i];
                    HeaderNode[Header.Length - 1].AppendChild(temp);
                }
                xmlDoc.Save(FileName);
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                string SelectNode = string.Empty;
                if (Header.Length == 1)
                    SelectNode = "/" + Header[0].ToString();
                else
                {
                    for (int q = 0; q < Header.Length - 1; q++)
                        SelectNode += "/" + Header[q].ToString();
                }
                XmlNode node = xmlDoc.SelectSingleNode(SelectNode);
                XmlElement xmlFinalNode = xmlDoc.CreateElement(Header[Header.Length - 1].ToString());
                node.AppendChild(xmlFinalNode);
                for (int i = 0; i < NodeName.Length; i++)
                {
                    XmlElement temp = xmlDoc.CreateElement(NodeName[i]);
                    temp.InnerText = NodeValue[i];
                    xmlFinalNode.AppendChild(temp);
                }
                xmlDoc.Save(FileName);
            }
        }

         /// <summary>
        /// 寫入xml檔案，檔案存在則新增.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="Header">The header.</param>
        /// <param name="NodeName">Name of the node.</param>
        /// <param name="NodeValue">The node value.</param>
            public static void AppendXml(string FileName, string[] Header, string[] NodeName, string[] NodeValue)
            {
               if (!File.Exists(FileName))
               {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode node = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    xmlDoc.AppendChild(node);
                    List<XmlElement> HeaderNode = new List<XmlElement>();
                    for (int j = 0; j < Header.Length; j++)
                    {
                        HeaderNode.Add(xmlDoc.CreateElement(Header[j]));
                        if (j == 0) xmlDoc.AppendChild(HeaderNode[j]);
                        else HeaderNode[j - 1].AppendChild(HeaderNode[j]);
                    }
                    for (int i = 0; i < NodeName.Length; i++)
                    {
                        XmlElement temp = xmlDoc.CreateElement(NodeName[i]);
                        temp.InnerText = NodeValue[i];
                        HeaderNode[Header.Length - 1].AppendChild(temp);
                    }
                    xmlDoc.Save(FileName);
               }
              else
              {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(FileName);
                    string SelectNode = string.Empty;
    
                    if (Header.Length == 1)
                    SelectNode = "/" + Header[0].ToString();
                    else
                    {
                        for (int q = 0; q < Header.Length - 1; q++)
                        SelectNode += "/" + Header[q].ToString();
                    }
                    XmlNode node = xmlDoc.SelectSingleNode(SelectNode);
                    XmlElement[] Result = new XmlElement[NodeName.Length];
                    for (int j = 0; j < Result.Length; j++)
                    {
                        XmlElement xmlFinalNode = xmlDoc.CreateElement(NodeName[j].ToString());
                        xmlFinalNode.InnerText = NodeValue[j].ToString();
                        node.AppendChild(xmlFinalNode);
                    }
                    xmlDoc.Save(FileName);
              }
           }

            public static DataSet SetXmlStringToDataSet(string XmlString)
            {
                StringReader reader = new StringReader(XmlString);
                DataSet AuthorsDataSet = new DataSet();
                AuthorsDataSet.ReadXml(reader);
                return AuthorsDataSet;
            }

            public static DataSet SetXmlToDataSet(string XmlFile)
            {
                DataSet AuthorsDataSet = new DataSet();
                AuthorsDataSet.ReadXml(XmlFile);
                return AuthorsDataSet;
            }

            public static void SetDataTableToXmlFile(string FileName, DataTable dt)
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                dt.WriteXml(FileName);
            }

            public static string SetDataTableToXmlString(DataTable dt)
            {
                StringWriter sw = new StringWriter();
                dt.WriteXml(sw);
                return sw.ToString();
            }

            public static void SetDataSetToXmlFile(string FileName, DataSet dt)
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                dt.WriteXml(FileName);
            }

            public static string SetDataTableToXmlString(DataSet dt)
            {
                StringWriter sw = new StringWriter();
                dt.WriteXml(sw);
                return sw.ToString();
            }


    }
}
