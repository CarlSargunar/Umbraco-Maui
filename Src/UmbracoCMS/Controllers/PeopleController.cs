using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoCMS.Models;

namespace UmbracoCMS.Controllers
{
    public class PeopleController : UmbracoApiController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger<PeopleController> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private string peopleDoctype = "person";

        public PeopleController(IUmbracoContextAccessor umbracoContextAccessor, ILogger<PeopleController> logger, IPublishedValueFallback publishedValueFallback)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }

        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            // Accessible from /umbraco/api/people/getallpeople

            if (_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext? context) == false)
            {
                _logger.LogCritical("Unable to get context");
            }

            if (context.Content == null)
            {
                _logger.LogCritical("Content Cache is null");
            }

            var rootNode = context.Content.GetAtRoot().FirstOrDefault();
            var peopleNodes = rootNode.DescendantsOfType(peopleDoctype);


            var prods = new List<Person>();

            foreach (var p in peopleNodes)
            {
                if (p == null) continue;
                var item = new Person
                {
                    Id = p.Id,
                    Name = p.Name
                };

                var image = p.Value<IPublishedContent>(_publishedValueFallback, "photos");
                if (image != null)
                {
                    item.Image = image.Url();
                }

                var items = p.Value<IEnumerable<string>>(_publishedValueFallback, "department");
                if (items != null) item.Department = items.ToArray();
                prods.Add(item);
            }


            return prods;
        }
    }
}
