using System.ComponentModel.DataAnnotations;

namespace TripleA.Data.Entities
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        public string? image { get; set; }
        public string? title { get; set; }
        public string? companyLink { get; set; }
        public string? companyName { get; set; }


    }
}
