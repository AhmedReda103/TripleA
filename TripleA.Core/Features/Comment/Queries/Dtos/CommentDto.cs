using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Core.Features.Comment.Queries.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string? Content { get; set; }
        public int? AnswerId { get; set; }
        public string? UserId { get; set; }

    }
}
