using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Commons.Xml.Relaxng;
using SOAPReference;


namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class XMLController : ControllerBase
    {
        string filePathXML = "../../Tasty.xml";
        string filePathXSD = "../../Tasty.xsd";
        string filePathRNG = "../../TastyRNG.rng";



        [HttpGet]
        public bool CheckAgainstXsd()
        {
            PrepareXML();

            try
            {
                bool isValid = true;

                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add("", filePathXSD);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                settings.ValidationEventHandler += (sender, e) => { isValid = false; };


                using (XmlReader reader = XmlReader.Create(filePathXML, settings))
                {
                    while (reader.Read()) { }
                }

                return isValid;
            } catch(Exception ex)
            {

            }
            return false;
        }


        [HttpGet]
        public bool CheckAgainstRNG()
        {
            PrepareXML();

            try
            {
                XmlReader xml = XmlReader.Create(filePathXML);
                XmlReader relax = XmlReader.Create(filePathRNG);

                var validator = new RelaxngValidatingReader(xml, relax);
                XDocument doc = XDocument.Load(validator);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        [HttpGet]
        public string CheckSoap(string query)
        {
            try
            {
                SOAPReference.SOAPSoapClient klijent = new SOAPReference.SOAPSoapClient(SOAPReference.SOAPSoapClient.EndpointConfiguration.SOAPSoap);
                return klijent.Query(query);
            } catch(Exception ex)
            {
                return "Error";
            }

        }


        private void PrepareXML()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Recipe));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;

                using (XmlWriter writer = XmlWriter.Create(filePathXML, settings))
                {
                    serializer.Serialize(writer, Repository.Repository.GetRecipe());
                }
            }catch(Exception ex){
                
            }
        }
    }
}
