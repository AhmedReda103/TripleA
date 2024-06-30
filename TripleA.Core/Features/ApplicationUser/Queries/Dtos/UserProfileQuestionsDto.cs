using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Core.Features.ApplicationUser.Queries.Dtos
{
    public class UserProfileQuestionsDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedIn { get; set; } 
    }
}
