using MediatR;
using TripleA.Core.Bases;
using TripleA.Data.Entities;

namespace TripleA.Core.Features.Question.Queries.Model
{
    public class GetNotificationsByIdQuery : IRequest<Response<List<Notification>>>
    {
        public string AskerId;
    }
}
