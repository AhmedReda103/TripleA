using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;

namespace TripleA.Core.Features.Answers.Queries.Model
{
    public class GetAnswerByIdQuery : IRequest<Response<GetAnswerByIdDto>>
    {
        public int Id { get; set; }
    }
}
