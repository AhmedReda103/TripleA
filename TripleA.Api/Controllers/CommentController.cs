using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Comment.Models;
using TripleA.Core.Features.Comment.Queries.Model;

namespace TripleA.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : AppControllerBase
    {

        [HttpPost("/deleteComment")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return NewResult(await Mediator.Send(new DeleteCommentCommand(id)));
        }

        [HttpPut("/editComment")]
        public async Task<IActionResult> Edit([FromBody] EditCommentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var response = await Mediator.Send(new GetCommentByIdQuery { Id = id });

            if (!response.Succeeded)
            {
                return NotFound(response);
            }

            return NewResult(response);
        }

    }
}
