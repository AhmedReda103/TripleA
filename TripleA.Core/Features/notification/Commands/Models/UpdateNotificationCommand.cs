using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.notification.Commands.Models
{
    public class UpdateNotificationCommand : IRequest<Response<string>>
    {
    }
}
