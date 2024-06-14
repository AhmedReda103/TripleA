using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Question.Commands.Models
{
    public class AddQuestionCommand : IRequest<Response<String>>
    {
    }
}
