using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedIn { get; set; }

    }
}
