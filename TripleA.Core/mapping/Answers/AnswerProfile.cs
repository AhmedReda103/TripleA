using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Answers.Queries;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Answers
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AddAnswerCommand, Answer>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}
