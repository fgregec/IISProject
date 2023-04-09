using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using API.Model;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Linq;
using Commons.Xml.Relaxng;
using SOAPReference;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XMLController : ControllerBase
    {
        string filePathXML = "../Tasty.xml";
        string filePathXSD = "../Tasty.xsd";
        string filePathRNG = "../TastyRNG.rng";

        [HttpGet("XSD")]
        public string ValidateAgainstXSD() 
        {
            GenerateXML();
            string valid = "XML valid";

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("", filePathXSD);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemaSet;
            settings.ValidationEventHandler += (sender, e) => { valid = "XML not valid"; };


            using (XmlReader reader = XmlReader.Create(filePathXML, settings))
            {
                while (reader.Read()) { }
            }

            return valid;
        }

        [HttpGet("RELAX")]
        public string ValidateAgainstRNG()
        {
            GenerateXML();

            try
            {
                using (XmlReader xml = XmlReader.Create(filePathXML))
                using (XmlReader relax = XmlReader.Create(filePathRNG))
                using (var validator = new RelaxngValidatingReader(xml, relax))
                {
                    XDocument doc = XDocument.Load(validator);
                    return "XML valid";
                }
            }
            catch (Exception e)
            {
                return "XML not valid";
            }
        }

        [HttpGet("soap")]
        public string RatingCheck(string rating)
        {
            SOAPSoapClient klijent = new SOAPSoapClient(SOAPSoapClient.EndpointConfiguration.SOAPSoap);
            return klijent.Query(rating);
        }


        public void GenerateXML() 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Recipe));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(filePathXML, settings))
            {
                serializer.Serialize(writer, Repository.GetRecipe());
            }
        }
    }
}