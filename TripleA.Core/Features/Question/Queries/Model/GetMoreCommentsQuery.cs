using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Core.wrappers;

namespace TripleA.Core.Features.Question.Queries.Model
{
    public class GetMoreCommentsQuery : IRequest<Response<PaginatedResult<CommentDto>>>
    {
        public int answerId;
        public int PageNum;
        public int Commentlimit=3;

    }
}
