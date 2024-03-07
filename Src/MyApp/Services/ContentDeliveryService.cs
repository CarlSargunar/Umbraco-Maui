using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class ContentDeliveryService
    {
        HttpClient httpClient;
        public ContentDeliveryService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Article>> GetArticles()
        {
            //var articleList = await FetchProductsFromContentDeliveryApi();
            var articleList = await FetchLocalArticles();
            return articleList;
        }

        public async Task<List<Podcast>> GetPodcasts()
        {
            //var articleList = await FetchProductsFromContentDeliveryApi();
            var podcastList = await FetchLocalPodcasts();
            return podcastList;
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

        private async Task<List<Article>> FetchLocalArticles()
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Name = "Article 1",
                    MainImage = "https://via.placeholder.com/150",
                    Author = "Author 1",
                    Summary = "Summary 1"
                },
                new Article
                {
                    Name = "Article 2",
                    MainImage = "https://via.placeholder.com/150",
                    Author = "Author 2",
                    Summary = "Summary 2"
                },
                new Article
                {
                    Name = "Article 3",
                    MainImage = "https://via.placeholder.com/150",
                    Author = "Author 3",
                    Summary = "Summary 3"
                }
            };
            return articles;
        }
    }
}
