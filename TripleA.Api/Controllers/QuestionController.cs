using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
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
        public async Task<IActionResult> Get(int id,int answerLimit,int commentLimit)
        {
            return NewResult(await Mediator.Send(new GetQuestionsByIdQuery { QuestionId = id ,answersLimit = answerLimit, commentsLimit= commentLimit }));
        }


        [HttpPost("/AddQuestion")]
        //[Authorize]
        public async Task<IActionResult> Create([FromForm] AddQuestionCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpDelete("/deleteQuestion")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return NewResult(await Mediator.Send(new DeleteQuestionCommand(id)));
        }

        [HttpPut("/editQuestion")]
        public async Task<IActionResult> Edit(EditQuestionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet("/GetQuestionsPaginated")]
        [Authorize]
        public async Task<IActionResult> GetQuestionsPaginated([FromQuery] GetQuestionsListPaginatedQuery query)
        {

            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet("/moreAnswers")]
        public async Task<IActionResult> GetMoreAnswers(int questionId, int PageIndex, int Limit)
        {
            return NewResult(await Mediator.Send(new GetMoreAnswersQuery {questionId=questionId, PageNum = PageIndex,limit=Limit }));
        }




        [HttpGet("/GetQuestionByTitlePagenated")]
        //[Authorize]
        public async Task<IActionResult> GetQuestionsByTitlePagenated([FromQuery] GetQuestionByTitlePaginatedQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
