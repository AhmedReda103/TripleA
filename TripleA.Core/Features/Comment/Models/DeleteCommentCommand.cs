using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Comment.Models
{
    public class DeleteCommentCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
