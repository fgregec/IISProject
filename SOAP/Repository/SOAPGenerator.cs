using SOAP.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SOAP
{
    public static class SOAPGenerator
    {

        public static XElement GenerateXML()
        {
            XElement xElement = new XElement("Recipes");

            List<SimpleRecipe> recipes = GetRecipes();

            foreach (var item in recipes)
            {
                xElement.Add(
                    new XElement("Recipe",
                    new XElement("Id", item.Id),
                    new XElement("Description", item.Description),
                    new XElement("Country", item.Country),
                    new XElement("PrepTimeMinutes", item.PrepTimeMinutes),
                    new XElement("Language", item.Language),
                    new XElement("NumServings", item.NumServings),
                    new XElement("VideoUrl", item.VideoUrl),
                    new XElement("ThumbnailUrl", item.ThumbnailUrl),
                    new XElement("Rating", item.Rating)
                ));
            }

            return xElement;
        }


        public static List<SimpleRecipe> GetRecipes()
        {
            List<SimpleRecipe> recipes = new List<SimpleRecipe>
            {
                new SimpleRecipe
                {
                    Id = 1,
                    Description = "Very good",
                    Country = "Croatia",
                    PrepTimeMinutes = 50,
                    Language = "Croatian",
                    NumServings = 10,
                    VideoUrl = "videourl",
                    ThumbnailUrl = "thumbnailurl",
                    Rating = 5
                },
                new SimpleRecipe
                {
                    Id = 2,
                    Description = "Good",
                    Country = "Germany",
                    PrepTimeMinutes = 20,
                    Language = "German",
                    NumServings = 5,
                    VideoUrl = "videourl",
                    ThumbnailUrl = "thumbnailurl",
                    Rating = 3
                },
                new SimpleRecipe
                {
                    Id = 3,
                    Description = "Simple",
                    Country = "Poland",
                    PrepTimeMinutes = 10,
                    Language = "Polish",
                    NumServings = 1,
                    VideoUrl = "videourl",
                    ThumbnailUrl = "thumbnailurl",
                    Rating = 3
                }
            };


            return recipes;
        }
    }
}
