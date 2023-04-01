using Repository;
using Repository.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SOAP
{
    /// <summary>
    /// Summary description for SOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAP : System.Web.Services.WebService
    {
        private List<SimpleRecipe> recipeList = Repository.SOAPGenerator.GetRecipes();

        [WebMethod]
        public string Query(string query)
        {
            XElement xElement = SOAPGenerator.GenerateXML();
            
            string value = xElement.XPathSelectElement("Recipe/Id[text()='" + query + "']/parent::Recipe").ToString();

            return value;
        }



    }
}
