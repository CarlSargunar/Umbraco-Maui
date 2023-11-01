using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoCMS.Models;
using UmbracoCMS.Services;

namespace UmbracoCMS.Controllers
{
    public class BasketController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger<ProductController> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly IBasketService _basketService;

        public BasketController(IUmbracoContextAccessor umbracoContextAccessor, 
            ILogger<ProductController> logger, 
            IPublishedValueFallback publishedValueFallback, 
            IBasketService basketService)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
            _basketService = basketService;
        }

        // POST api/basket/add
        [HttpPost("add")]
        public IActionResult AddToBasket([FromBody] BasketItem basketItem)
        {
            _basketService.AddToBasket(basketItem);
            return Ok();
        }

        // GET api/basket
        [HttpGet]
        public IActionResult GetBasket()
        {
            var items = _basketService.GetBasketItems();
            return Ok(items);
        }

        // PUT api/basket/update
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] BasketItem basketItem)
        {
            var updated = _basketService.UpdateItem(basketItem);
            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
