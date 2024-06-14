using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Question.Commands.Models;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : AppControllerBase
    {
        [HttpPost("/AddAnswer")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddAnswerCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
