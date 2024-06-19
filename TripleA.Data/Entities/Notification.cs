using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime? CreatedIn { get; set; }
    }
}
