using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Content { get; set; }
    }
}
