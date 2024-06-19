using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Comment.Models;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Comment.Commands.Handler
{
    public class CommentCommandHandler : ResponseHandler, IRequestHandler<DeleteCommentCommand, Response<string>>
    {

        private readonly IMapper mapper;
        private readonly ICommentService commentService;

        public CommentCommandHandler(IMapper mapper,
                                      ICommentService commentService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
        }


        public async Task<Response<string>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await commentService.GetCommentByIDAsync(request.Id);
            //return NotFound
            if (comment == null) return NotFound<string>();
            //Call service that make Delete
            var result = await commentService.DeleteAsync(comment);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
