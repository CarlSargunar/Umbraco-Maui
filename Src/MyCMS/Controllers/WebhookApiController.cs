using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
namespace MyCMS.Controllers;

public class EventsController : UmbracoApiController
{
    public ILogger<EventsController> Logger { get; }

    public EventsController(ILogger<EventsController> logger)
    {
        Logger = logger;
    }

    public IActionResult WebhookTest([FromBody] WebhookPayload payload)
    {
        // https://localhost:44316/Umbraco/Api/events/WebhookTest
        Logger.LogInformation($"WebhookTest called with payload : {payload}");
        return Ok(payload);
    }


    public IActionResult Publish([FromBody] WebhookPayload payload)
    {
        // WARNING! This is demo code - you should not call a webhook into the same 
        // website that is calling it in production code. You want to consider your own 
        // standalone API, or an Azure Function, or similar.

        // https://localhost:44316/Umbraco/Api/events/Publish
        Logger.LogInformation($"WebhookTest called with payload : {payload}");
        return Ok(payload);
    }

}
