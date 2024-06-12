using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.ApplicationUser.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
