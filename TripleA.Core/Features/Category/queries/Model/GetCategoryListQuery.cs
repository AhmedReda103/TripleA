using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Category.queries.Dtos;

namespace TripleA.Core.Features.Category.queries.Model
{
    public class GetCategoryListQuery : IRequest<Response<List<GetCategoryListDto>>>
    {
    }
}
