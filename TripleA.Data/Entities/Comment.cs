using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleA.Data.Entities.Identity;

namespace TripleA.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Content { get; set; }
        public int? AnswerId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual Answer? Answer { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
    }
}
