using MediatR;
using TripleA.Core.Bases;
using TripleA.Domain.Results;

namespace TripleA.Core.Features.ApplicationUser.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
