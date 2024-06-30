using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.notification.Commands.Models;
using TripleA.Core.Features.Question.Queries.Model;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : AppControllerBase
    {
        //[Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetNotifications([FromQuery] string userId)
        {
            return NewResult(await Mediator.Send(new GetNotificationsByIdQuery { AskerId = userId }));
        }

        [HttpPatch()]
        public async Task<IActionResult> SetNotificationsRead()
        {
            return NewResult(await Mediator.Send(new UpdateNotificationCommand()));
        }

    }
}
