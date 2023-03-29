using System.IO;
using System;
using System.Xml.Serialization;
using Repository.Model;
using System.Xml.Schema;
using System.Xml;
using System.Text;

namespace Zadatak01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Recipe));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;

            string filePath = "../../Tasty.xml";

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, Repository.Repository.GetRecipe());
                string xml = writer.ToString();
                Console.WriteLine(xml);
            }

            Console.WriteLine(ValidateXmlAgainstXsd(filePath, "../../Tasty.xsd"));

        }

        public static bool ValidateXmlAgainstXsd(string xmlFilePath, string xsdFilePath)
        {
            bool isValid = true;

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("", xsdFilePath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemaSet;
            settings.ValidationEventHandler += (sender, e) => { isValid = false; };
            

            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                while (reader.Read()) { }
            }

            return isValid;
        }



    }
}
