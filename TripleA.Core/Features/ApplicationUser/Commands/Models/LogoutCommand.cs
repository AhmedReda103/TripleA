using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.ApplicationUser.Commands.Models
{
    public class LogoutCommand : IRequest<Response<string>>
    {
    }
}
