using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Core.wrappers;

namespace TripleA.Core.Features.Answers.Queries.Dtos
{
    public class AnswerDtoForQuestionById
    {
        public int Id { get; set; }
        public int? Votes { get; set; } = 0;
        public DateTime? CreatedIn { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? QuestionId { get; set; }
        public string? UserId { get; set; }

        public virtual PaginatedResult<CommentDto> Comments { get; set; } 
    }
}
