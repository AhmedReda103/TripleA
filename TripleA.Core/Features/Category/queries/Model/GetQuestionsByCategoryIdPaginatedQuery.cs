using MediatR;
using TripleA.Core.Features.Category.queries.Dtos;
using TripleA.Core.wrappers;

namespace TripleA.Core.Features.Category.queries.Model
{
    public class GetQuestionsByCategoryIdPaginatedQuery : IRequest<Bases.Response<PaginatedResult<GetQuestionsByCategoryIdPaginatedResponse>>>
    {
        public int CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
