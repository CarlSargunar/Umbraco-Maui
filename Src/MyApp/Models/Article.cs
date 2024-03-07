using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Article
    {
        // Hard coded for demo
        private static readonly CultureInfo CultureInfo = new("en-GB");
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
    }

    [JsonSerializable(typeof(List<Article>))]
    internal sealed partial class ArticleContext : JsonSerializerContext
    {

    }
}
