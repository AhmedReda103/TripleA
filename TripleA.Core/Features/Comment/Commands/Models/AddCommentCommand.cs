using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Comment.Commands.Models
{
    public class AddCommentCommand : IRequest<Response<String>>
    {
        public string Content { get; set; }
        public int AnswerId { get; set; }
    }
}
