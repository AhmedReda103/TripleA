using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Answers.Commands.Models
{
    public class AddAnswerCommand :  IRequest<Response<String>>
    {
        //public string Image { get; set; }
        public string Description { get; set; }
     //   public DateTime CreatedIn { get; set; }
        public int QuestionId { get; set; }
    }
}
