using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Category.queries.Model;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Core.Features.Question.Queries.Model;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : AppControllerBase
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return NewResult(await Mediator.Send(new GetQuestionsById {QuestionId=id }));
        }


        [HttpPost("/AddQuestion")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] AddQuestionCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPost("/deleteQuestion")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return NewResult(await Mediator.Send(new DeleteQuestionCommand(id)));
        }
    }
}
