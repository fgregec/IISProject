using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace UI.Controllers
{
    public class MachineController : Controller
    {
        public async Task<ActionResult> Index(string request)
        {
            switch (request)
            {
                case "xsd":
                    ViewBag.Result = await RequestXSD();
                    break;
                case "relax":
                    ViewBag.Result = await RequestRelax();
                    break;
                case "soap":
                    ViewBag.Soap = 1;
                    break;
                default:
                    break;
            }
            return View();
        }
        public async Task<string> RequestXSD()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = "http://localhost:5250/api/xml/xsd";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        public async Task<string> RequestRelax()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = "http://localhost:5250/api/xml/relax";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }

        public async Task<ActionResult> RequestSoap(string rating)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = $"http://localhost:5250/api/xml/soap?rating={rating}";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                ViewBag.Result = responseContent;
            }
            return View("Index");
        }

    }
}