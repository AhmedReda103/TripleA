using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Comment.Queries.Dtos;

namespace TripleA.Core.Features.Comment.Queries.Model
{
    public class GetCommentByIdQuery : IRequest<Response<GetCommentByIdDto>>
    {
        public int Id { get; set; }
    }
}
