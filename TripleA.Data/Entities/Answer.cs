using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int? Votes { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }




    }
}
