using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Queries.Dtos;

namespace TripleA.Core.Features.Question.Queries.Model
{
    public class GetQuestionsByIdQuery : IRequest<Response<GetQuestionByIdDto>>
    {
        public int QuestionId;
        public int answersLimit =5;
        public int commentsLimit =3;

    }
}
