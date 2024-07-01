using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;

namespace TripleA.Core.Features.Answers.Queries.Model
{
    public class GetAnswerListQuery : IRequest<Response<List<GetAnswerListDto>>>
    {
    }
}
