using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public DeleteUserCommand(string id)
        {
            this.Id = id;
        }
    }
}
