using TripleA.Core.Features.Comment.Queries.Dtos;

namespace TripleA.Core.Features.Answers.Queries.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public int? Votes { get; set; } = 0;
        public DateTime? CreatedIn { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? QuestionId { get; set; }
        public string? UserId { get; set; }

        public virtual ICollection<CommentDto> CommentsDto { get; set; } = new HashSet<CommentDto>();
    }
}
