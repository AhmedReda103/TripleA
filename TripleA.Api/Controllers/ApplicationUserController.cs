using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.ApplicationUser.Commands.Models;
using TripleA.Core.Features.ApplicationUser.Queries.Model;
using TripleA.Data.AppMetaData;

namespace TripleA.Api.Controllers
{
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await Mediator.Send(new LogoutCommand());
            return NewResult(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return NewResult(await Mediator.Send(new GetUserByIdQuery { UserId = id }));
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return NewResult(await Mediator.Send(new GetUserByIdQuery { UserId = id }));

        }
    }
}
