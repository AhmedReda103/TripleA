using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Data.Entities;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : AppControllerBase
    {
        [HttpPost("/AddQuestion")]                      
        [Authorize]                                                                     
        public async Task<IActionResult> Create([FromBody] AddQuestionCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
