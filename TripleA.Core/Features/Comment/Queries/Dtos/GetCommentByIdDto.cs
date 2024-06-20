namespace TripleA.Core.Features.Comment.Queries.Dtos
{
    public class GetCommentByIdDto
    {
        public int Id { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Content { get; set; }
        public int? AnswerId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
