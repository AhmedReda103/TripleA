using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Core.wrappers;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Queries.Handler
{
    public class QuestionQueryHandler : ResponseHandler,
                                        IRequestHandler<GetQuestionsByIdQuery, Response<GetQuestionByIdDto>>,

                                       IRequestHandler<GetQuestionsListPaginatedQuery, Response<PaginatedResult<GetQuestionsListPaginatedResponse>>>


    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;

        public QuestionQueryHandler(IMapper mapper,
                                    IQuestionService questionService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
        }

        public Task<Response<GetQuestionByIdDto>> Handle(GetQuestionsByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<PaginatedResult<GetQuestionsListPaginatedResponse>>> Handle(GetQuestionsListPaginatedQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = questionService.FilliterQuestionsPaginatedQuerable(request.Search);

            if (FilterQuery.IsNullOrEmpty()) return NotFound<PaginatedResult<GetQuestionsListPaginatedResponse>>();
            var PaginatedList = await mapper.ProjectTo<GetQuestionsListPaginatedResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Success(PaginatedList);
        }
    }
}
