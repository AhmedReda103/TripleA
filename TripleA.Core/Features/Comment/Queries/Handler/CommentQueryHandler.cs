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
        public CommentQueryHandler(IMapper mapper, ICommentService commentService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
        }

        public async Task<Response<GetCommentByIdDto>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await commentService.GetCommentByIDAsync(request.Id);
            if (comment == null) return NotFound<GetCommentByIdDto>();
            var commentMapper = mapper.Map<GetCommentByIdDto>(comment);
            var result = Success(commentMapper);
            return result;

        }
    }
}
