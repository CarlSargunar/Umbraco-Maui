using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MyMauiApp.Helpers;
using MyMauiApp.Models;
using MyMauiApp.Services.Models;

namespace MyMauiApp.Services
{
	public class ContentService
	{

		HttpClient httpClient;
		public ContentService()
		{
			this.httpClient = new HttpClient();
		}
		

		public async Task<List<Podcast>> GetPodcasts()
		{
			// Load Podcasts from from the Content Delivery API
			//var PodcastList = await FetchPodcastsFromContentDeliveryApi();
			var PodcastList = await FetchLocalPodcasts();
			return PodcastList;
		}

        private async Task<List<Podcast>> FetchPodcastsFromContentDeliveryApi()
        {
            var Podcasts = new List<Podcast>();
            var apiResponse = await httpClient.GetAsync(DemoHelpers.ContentDeliveryApiUrl);
            if (apiResponse.IsSuccessStatusCode)
            {
                var contentDeliveryResponse = await apiResponse.Content.ReadFromJsonAsync<ContentDeliveryResponse>();

                foreach (var item in contentDeliveryResponse.items)
                {
                    var Podcast = new Podcast
                    {
                        //    Name = item.properties.productName,
                        //    Price = item.properties.price,
                        //    Sku = item.properties.sku,
                        //    Description = item.properties.description,
                        //    Category = item.properties.category,
                        //    Image = DemoHelpers.ImagePath(item.properties.photos[0].url)
                    };
                    Podcasts.Add(Podcast);
                }
            }

            return Podcasts;
        }

		private async Task<List<Podcast>> FetchLocalPodcasts()
		{
            var podcasts = new List<Podcast>
            {
                new Podcast
                {
                    Name = "Podcast 1",
                    MainImage = "https://via.placeholder.com/150",
                    AudioFile = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",
                    Author = "Author 1"
                },
                new Podcast
                {
                    Name = "Podcast 2",
                    MainImage = "https://via.placeholder.com/150",
                    AudioFile = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",
                    Author = "Author 2"
                },
                new Podcast
                {
                    Name = "Podcast 3",
                    MainImage = "https://via.placeholder.com/150",
                    AudioFile = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",
                    Author = "Author 3"
                }
            };
            return podcasts;
		}

	}
}
