using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Answers.Commands.Models
{
    public class UpVoteAnswerCommand : IRequest<Response<string>>
    {
        public int AnswerId;
    }
}
