using API.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Repository
    {
        public static Recipe GetRecipe()
        {
            var client = new RestClient("https://tasty.p.rapidapi.com/recipes/list?from=1&size=1&tags=under_30_minutes");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "dc92cf1035msh873c4d1f18b6181p100e8bjsn3431b43ef718");
            request.AddHeader("X-RapidAPI-Host", "tasty.p.rapidapi.com");
            RestResponse response = client.Execute(request);
            Recipe recipe = JsonConvert.DeserializeObject<Recipe>(response.Content);
            return recipe;
        }
    }
}
