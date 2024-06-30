using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Core.Features.Comment.Queries.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Comment.Queries.Handler
{
    public class CommentQueryHandler : ResponseHandler,
                                       IRequestHandler<GetCommentByIdQuery, Response<GetCommentByIdDto>>
    {
        private readonly IMapper mapper;
        private readonly ICommentService commentService;
        // private readonly ICashingService cashingService;
        public CommentQueryHandler(IMapper mapper, ICommentService commentService /*ICashingService cashingService*/)
        {
            this.mapper = mapper;
            this.commentService = commentService;
            //this.cashingService = cashingService;
        }

        public async Task<Response<GetCommentByIdDto>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var key = "GetQuestionsByIdQuery" + request.Id;
            // var cashingData = await cashingService.GetData<GetCommentByIdDto>(key);
            /* if (cashingData != null)
             {
                 return Success(cashingData);
             }*/
            var comment = await commentService.GetCommentByIDAsync(request.Id);
            if (comment == null) return NotFound<GetCommentByIdDto>();
            var commentMapper = mapper.Map<GetCommentByIdDto>(comment);
            //cashingService.setData(key, commentMapper, TimeSpan.FromMinutes(1));
            var result = Success(commentMapper);
            return result;

        }
    }
}
