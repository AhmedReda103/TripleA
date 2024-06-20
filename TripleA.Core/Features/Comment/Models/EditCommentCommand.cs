using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Comment.Models
{
    public class EditCommentCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Content { get; set; }
    }
}
