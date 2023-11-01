using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoCMS.Models;

namespace UmbracoCMS.Controllers
{
    public class BlogController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger<BlogController> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private string blogDocType = "blogpost";


        public BlogController(IUmbracoContextAccessor umbracoContextAccessor, ILogger<BlogController> logger, IPublishedValueFallback publishedValueFallback)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }


        [HttpGet]
        public IEnumerable<Blog> GetAllBlogPosts()
        {
            // Accessible from /umbraco/api/blog/getallblogposts

            if (_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext? context) == false)
            {
                _logger.LogCritical("Unable to get context");
            }

            if (context.Content == null)
            {
                _logger.LogCritical("Content Cache is null");
            }

            var rootNode = context.Content.GetAtRoot().FirstOrDefault();
            var peopleNodes = rootNode.DescendantsOfType(blogDocType);


            var prods = new List<Blog>();

            foreach (var p in peopleNodes)
            {
                if (p == null) continue;
                var item = new Blog
                {
                    Id = p.Id,
                    Name = p.Name
                };


                var items = p.Value<IEnumerable<string>>(_publishedValueFallback, "categories");
                if (items != null) item.Category = items.ToArray();
                prods.Add(item);
            }


            return prods;
        }
    }
}
