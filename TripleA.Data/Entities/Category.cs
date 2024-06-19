using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
