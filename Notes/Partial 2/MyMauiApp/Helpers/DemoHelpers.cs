using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Helpers
{
	internal static class DemoHelpers
	{
		internal static string BaseUrl = "https://maui.carlcod.es/";
		internal static string ContentDeliveryApiUrl = $"{BaseUrl}umbraco/delivery/api/v1/content?filter=contentType%3Aproduct";
		internal static string ApiUrl = $"{BaseUrl}umbraco/api/product/getallproducts";

		internal static string ImagePath(string path)
		{
			if (string.IsNullOrEmpty(path))
				return string.Empty;

			return $"{BaseUrl}{path}?width=200";
		}


	}
}
