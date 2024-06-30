using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class UserCon
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserConnection { get; set; }
        public DateTime? LoginIn { get; set; }
    }
}
