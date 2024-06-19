using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Question.Commands.Models;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : AppControllerBase
    {
        [HttpPost("/AddQuestion")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] AddQuestionCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
