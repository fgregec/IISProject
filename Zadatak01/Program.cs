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
            Console.WriteLine();
            Console.WriteLine("XSD VALIDATION: ");
            Console.WriteLine(ValidateXmlAgainstXsd(filePath, "../../Tasty.xsd"));
            Console.WriteLine();
            Console.WriteLine("RNG VALIDATION");
            ValidateXmlAgainstRng(filePath, "../../TastyRNG.rng");

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

        public static void ValidateXmlAgainstRng(string xmlFilePath, string rbgFilePath)
        {
            // Load the XML document to be validated
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFilePath);

            // Load the RNG schema
            XmlSchema rngSchema = XmlSchema.Read(new XmlTextReader(rbgFilePath),null);

            // Create an XML schema set containing the RNG schema
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, rbgFilePath);

            // Create a validation settings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemaSet;

            // Attach a validation event handler
            settings.ValidationEventHandler += (sender, e) => {
                Console.WriteLine($"Validation error: {e.Message}");
            };

            // Create an XML reader with the validation settings
            XmlReader reader = XmlReader.Create(xmlFilePath, settings);

            // Read the XML document and validate it against the RNG schema
            try
            {
                while (reader.Read()) { }
                Console.WriteLine("XML document is valid!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("XML document is not valid!");
                Console.WriteLine(ex);
            }
            
        }

    }
}
