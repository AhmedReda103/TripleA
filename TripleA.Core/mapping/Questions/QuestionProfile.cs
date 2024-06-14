using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities.Identity;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AddQuestionCommand, Question>();
        }
       
    }
}
