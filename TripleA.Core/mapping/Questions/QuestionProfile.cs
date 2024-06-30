using AutoMapper;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AddQuestionCommand, Question>();

            CreateMap<EditQuestionCommand, Question>()
                .ForMember(des => des.Image, opt => opt.MapFrom(src => src.ImagePath));


            CreateMap<Question, GetQuestionsListPaginatedResponse>()
                 .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.user.UserName));
            ;
            CreateMap<Question, GetQuestionByTitlePaginatedResponse>()
                .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.user.UserName));


            CreateMap<DeleteQuestionCommand, Question>();

            CreateMap<Question, GetQuestionByIdDto>();


        }

    }
}
