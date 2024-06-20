using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Comment.Models;

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
    }
}
