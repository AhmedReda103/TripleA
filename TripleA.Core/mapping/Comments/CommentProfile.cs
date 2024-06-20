using AutoMapper;
using TripleA.Core.Features.Comment.Models;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Comments
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<EditCommentCommand, TripleA.Data.Entities.Comment>();
            CreateMap<TripleA.Data.Entities.Comment, CommentDto>();
            CreateMap<TripleA.Data.Entities.Comment, GetCommentByIdDto>()
               .ForMember(des => des.AnswerId, opt => opt.MapFrom(src => src.Answer.Id))
              .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.user.UserName));
        }
    }
}
