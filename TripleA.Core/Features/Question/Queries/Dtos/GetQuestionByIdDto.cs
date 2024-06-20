using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.Features.Question.Queries.Dtos
{
    public class GetQuestionByIdDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedIn { get; set; }
        public int? CategoryId { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<AnswerDto> Answers { get; set; } = new HashSet<AnswerDto>();
       
    }
}
