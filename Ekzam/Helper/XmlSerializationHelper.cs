using Ekzam.Dictionaries;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ekzam.Helper
{
    public class XmlSerializationHelper
    {
        private static readonly XmlWriterSettings Settings;
        private static readonly string _path;

        static XmlSerializationHelper()
        {
            Settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            _path = "Dictionary.txt";
        }

        public void Serializing(Object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Object));

            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
            }
        }

        public Tvalue Deserializing<Tvalue>(Object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Object));

            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                return (Tvalue)xmlSerializer.Deserialize(fs);
            }
        }
    }
}