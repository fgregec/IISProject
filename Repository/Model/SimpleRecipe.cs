using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    [Serializable]
    public class SimpleRecipe
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public int PrepTimeMinutes { get; set; }
        public string Language { get; set; }
        public int NumServings { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Rating { get; set; }
    }
}
