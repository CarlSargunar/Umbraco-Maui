using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoCMS.Models;

namespace UmbracoCMS.Controllers
{
    public class ProductController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IUmbracoContextAccessor umbracoContextAccessor, ILogger<ProductController> logger)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            // Accessable from /umbraco/api/product/getallproducts

            if (_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext? context) == false)
            {
                _logger.LogCritical("Unable to get context");
            }

            if (context.Content == null)
            {
                _logger.LogCritical("Content Cache is null");
            }
            
            var productType = context.Content.GetContentType("product");
            var rootNode = context.Content.GetAtRoot();
            Debug.WriteLine($"RootNode : {productType.Alias}");
            var tmp = new List<Product>();
            
            
            
            tmp.Add(new Product
            {
                Name = "Table",
                Price = 100,
                SKU = "TBL-001",
                Image = "https://via.placeholder.com/150",
                Description = "A table",
                Category = new[] {"Table", "Furniture"}
            });

            tmp.Add(new Product
            {
                Name = "Chair",
                Price = 50,
                SKU = "CHR-001",
                Image = "https://via.placeholder.com/150",
                Description = "A chair",
                Category = new[] {"Chair", "Furniture"}
            });

            tmp.Add(new Product
            {
                Name = "Desk",
                Price = 200,
                SKU = "DSK-001",
                Image = "https://via.placeholder.com/150",
                Description = "A desk",
                Category = new[] {"Desk", "Furniture"}
            });

            return tmp;
        }


    }
}
