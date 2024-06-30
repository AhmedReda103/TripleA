using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.advertisement.Commands.Models;
using TripleA.Core.Features.advertisement.Queries.Models;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertismentController : AppControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAdvertisments()
        {
            return NewResult(await Mediator.Send(new GetAdvertisementListQuery()));
        }

        [HttpPost("/AddAdvertismet")]
        public async Task<IActionResult> Create([FromForm] AddAdvertisementCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
