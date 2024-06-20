using AutoMapper;
using TripleA.Core.Features.Comment.Models;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Comments
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<EditCommentCommand, Comment>();
        }
    }
}
