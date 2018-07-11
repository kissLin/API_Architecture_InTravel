using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace PayEasyApi.Utility.Extensions.SerializerSettings
{
    public class SerializeTool
    {
        /// <summary>
        /// 以UTF-8編碼將XML物件序列化成字串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeXml<T>(T value)
        {
            if (value == null) { return null; }

            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.Default;
            settings.Encoding = Encoding.UTF8;

            XmlSerializerNamespaces nspace = new XmlSerializerNamespaces();
            nspace.Add("", "");
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
            {
                ser.Serialize(xmlWriter, value, nspace);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 將XML字串反序列化成指定型別物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeXml<T>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer ser = new XmlSerializer(typeof(T));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)ser.Deserialize(xmlReader);
                }
            }
        }
    }
}
