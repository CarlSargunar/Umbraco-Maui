using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Helpers
{
    internal class DemoHelpers
    {
        internal static string BaseUrl = "https://localhost:44316/";

        internal static string ArticleUrl = $"{BaseUrl}umbraco/delivery/api/v2/content?filter=contentType%3Aarticle";
        internal static string PodcastUrl = $"{BaseUrl}umbraco/delivery/api/v2/content?filter=contentType%3Apodcast";

        internal static string ImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            return $"{BaseUrl}{path}?width=200";
        }
    }
}
