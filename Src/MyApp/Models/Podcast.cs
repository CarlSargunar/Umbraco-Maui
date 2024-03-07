using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Podcast
    {
        // Hard coded for demo
        private static readonly CultureInfo CultureInfo = new("en-GB");
        public string Name { get; set; }
        public string Image { get; set; }
        public string AudioFile { get; set; }
        public string Author { get; set; }
    }

    [JsonSerializable(typeof(List<Podcast>))]
    internal sealed partial class PodcastContext : JsonSerializerContext
    {

    }
}
