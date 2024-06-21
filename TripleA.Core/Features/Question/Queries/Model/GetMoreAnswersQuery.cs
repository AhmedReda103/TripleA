using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.wrappers;
using TripleA.Data.Entities;

namespace TripleA.Core.Features.Question.Queries.Model
{
    public class GetMoreAnswersQuery : IRequest<Response<PaginatedResult<AnswerDtoForQuestionById>>>
    {
        public int questionId;
        public int PageNum;
        public int limit;
    }
}
