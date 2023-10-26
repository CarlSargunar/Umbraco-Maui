using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp
{
    internal static class Helpers
    {
        internal static string APIURL = "https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct";
        internal static string MediaUrlBase = "https://maui.carlcod.es/";

        internal static string ImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            return $"{MediaUrlBase}{path}?width=200";
        }


    }

}
