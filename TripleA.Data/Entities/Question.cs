using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleA.Data.Entities.Identity;

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
        public int? CategoryId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
    }
}
