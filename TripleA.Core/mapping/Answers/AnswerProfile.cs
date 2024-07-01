using AutoMapper;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Answers
{
    public class AdvertismentProfile : Profile
    {
        public AdvertismentProfile()
        {
            CreateMap<AddAnswerCommand, Answer>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<Answer, GetAnswerByIdDto>()
             .ForMember(des => des.QuestionId, opt => opt.MapFrom(src => src.Question.Id))
            .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.user.UserName));

            CreateMap<EditAnswerCommand, Answer>()
                .ForMember(des => des.Image, opt => opt.MapFrom(src => src.ImagePath));

            CreateMap<Answer, AnswerDtoForQuestionById>();

            CreateMap<Answer, UserProfileAnswersDto>()
           .ForMember(dest => dest.answerId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.questionId, opt => opt.MapFrom(src => src.QuestionId))
           .ForMember(dest => dest.votes, opt => opt.MapFrom(src => src.Votes))
           .ForMember(dest => dest.questionTitle, opt => opt.MapFrom(src => src.Question.Title))
           .ForMember(dest => dest.answerContent, opt => opt.MapFrom(src => src.Description));

            CreateMap<Answer, GetAnswerListDto>()
                    .ForMember(des => des.QuestionId, opt => opt.MapFrom(src => src.Question.Id));
        }
    }
}
