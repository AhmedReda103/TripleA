using TripleA.Core.Features.Answers.Queries.Dtos;

namespace TripleA.Core.Features.Category.queries.Dtos
{
    public class GetQuestionsByCategoryIdPaginatedResponse
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedIn { get; set; }
       // public virtual ICollection<AnswerDto> Answers { get; set; } = new HashSet<AnswerDto>();

    }
}
