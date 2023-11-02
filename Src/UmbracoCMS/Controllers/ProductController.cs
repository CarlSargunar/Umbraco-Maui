using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;
using UmbracoCMS.Models;

namespace UmbracoCMS.Controllers
{
    public class ProductController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger<ProductController> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private string productDoctype = "product";

        public ProductController(IUmbracoContextAccessor umbracoContextAccessor, ILogger<ProductController> logger, IPublishedValueFallback publishedValueFallback)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            // Accessible from /umbraco/api/product/getallproducts

            if (_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext? context) == false)
            {
                _logger.LogCritical("Unable to get context");
            }

            if (context.Content == null)
            {
                _logger.LogCritical("Content Cache is null");
            }

            var rootNode = context.Content.GetAtRoot().FirstOrDefault();
            var nodes = rootNode.DescendantsOfType(productDoctype);


            var prods = new List<Product>();

            foreach (var p in nodes)
            {
                if (p == null) continue;
                var item = new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Value<string>(_publishedValueFallback, "description") ?? string.Empty,
                    Price = p.Value<decimal>(_publishedValueFallback, "price"),
                    SKU = p.Value<string>(_publishedValueFallback, "sku") ?? string.Empty,
                };

                var image = p.Value<IPublishedContent>(_publishedValueFallback, "photos");
                if (image != null)
                {
                    item.Image = image.Url();
                }

                var items = p.Value<IEnumerable<string>>(_publishedValueFallback, "category");
                if (items != null) item.Category = items.ToArray();
                prods.Add(item);
            }


            return prods;
        }


    }
}
