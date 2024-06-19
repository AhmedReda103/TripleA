
using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using TripleA.Core.Bases;
using TripleA.Core.Features.Category.queries.Dtos;
using TripleA.Core.Features.Category.queries.Model;
using TripleA.Core.wrappers;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Category.queries.Handler
{
    public class CategoryQueryHandler : ResponseHandler,
                                                    IRequestHandler<GetQuestionsByCategoryIdPaginatedQuery, Response<PaginatedResult<GetQuestionsByCategoryIdPaginatedResponse>>>

    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IQuestionService questionService;

        public CategoryQueryHandler(IMapper mapper, ICategoryService categoryService, IQuestionService questionService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.questionService = questionService;
        }
        public async Task<Response<PaginatedResult<GetQuestionsByCategoryIdPaginatedResponse>>> Handle(GetQuestionsByCategoryIdPaginatedQuery request, CancellationToken cancellationToken)
        {
            var JoinQueryRes = categoryService.GetQuestionByCategoryIdPaginatedQuerable(request.CategoryId);

            if (JoinQueryRes.IsNullOrEmpty()) return NotFound<PaginatedResult<GetQuestionsByCategoryIdPaginatedResponse>>();

            var PaginatedList = await mapper.ProjectTo<GetQuestionsByCategoryIdPaginatedResponse>(JoinQueryRes).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Success(PaginatedList);
        }
    }
}
