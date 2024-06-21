namespace TripleA.Core.Features.Question.Queries.Dtos
{
    public class GetQuestionByTitlePaginatedResponse
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? CategoryName { get; set; }
        // public string? UserName { get; set; }
        public string? UserId { get; set; }

        // public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
