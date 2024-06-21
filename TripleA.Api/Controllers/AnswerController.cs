using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Answers.Queries.Model;

namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : AppControllerBase
    {
        [HttpPost("/AddAnswer")]
        //[Authorize]
        public async Task<IActionResult> Create([FromForm] AddAnswerCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }


        [HttpPost("upvote/{answerId}")]
        [Authorize]
        public async Task<IActionResult> UpVote(int answerId)
        {
            return NewResult(await Mediator.Send(new UpVoteAnswerCommand { AnswerId = answerId }));
        }

        [HttpPost("downvote/{answerId}")]
        [Authorize]
        public async Task<IActionResult> DownVote(int answerId)
        {
            return NewResult(await Mediator.Send(new DownVoteAnswerCommand { AnswerId = answerId }));
        }

        [HttpDelete("/deleteAnswer")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return NewResult(await Mediator.Send(new DeleteAnswerCommand(id)));
        }


        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var response = await Mediator.Send(new GetAnswerByIdQuery { Id = id });

            if (!response.Succeeded)
            {
                return NotFound(response);
            }

            return NewResult(response);
        }
        [HttpPut("/editAnswer")]
        public async Task<IActionResult> Edit(EditAnswerCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
