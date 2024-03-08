using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Helpers
{
	internal static class DemoHelpers
	{
		//internal static string BaseUrl = "https://maui.carlcod.es/";
		internal static string BaseUrl = "https://localhost:44331/";

		internal static string ContentDeliveryApiUrl = $"{BaseUrl}umbraco/delivery/api/v2/content?filter=contentType%3Aproduct";

		internal static string ImagePath(string path)
		{
			if (string.IsNullOrEmpty(path))
				return string.Empty;

			return $"{BaseUrl}{path}?width=200";
		}

        // Service Bus
        public const string ServiceBusConnectionString = "<TODO : REPLACE WITH YOUR BUS CONNECTIONSTRING>";
        public const string ServiceBusQueueName = "<TODO : REPLACE WITH YOUR BUS QUEUE NAME>";
    }
}
