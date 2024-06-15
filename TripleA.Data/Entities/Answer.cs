using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleA.Data.Entities.Identity;

namespace TripleA.Data.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int? Votes { get; set; } = 0;
        public DateTime? CreatedIn { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? QuestionId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question? Question { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        [ForeignKey("UserId")]
        public virtual User user { get; set; }


    }
}
