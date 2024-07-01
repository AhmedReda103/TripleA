using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; } = false;
        public string UserId { get; set; }
        public string Responder { get; set; }
        public DateTime? CreatedIn { get; set; }

        public int QuestionId { get; set; }
    }
}
