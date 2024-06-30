using AutoMapper;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Answers.Queries.Dtos;
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

            CreateMap <Answer, AnswerDtoForQuestionById>();
        }
    }
}
