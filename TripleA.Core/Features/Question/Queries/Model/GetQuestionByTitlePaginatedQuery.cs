using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.wrappers;

namespace TripleA.Core.Features.Question.Queries.Model
{
    public class GetQuestionByTitlePaginatedQuery : IRequest<Response<PaginatedResult<GetQuestionByTitlePaginatedResponse>>>
    {
        public string QuestionTitle { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        //public string[]? OrderBy { get; set; }
        //public string? Search { get; set; }
    }
}
