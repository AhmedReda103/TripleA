using AutoMapper;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Category.queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Answers
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AddAnswerCommand, Answer>();
            CreateMap<EditAnswerCommand, Answer>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}
