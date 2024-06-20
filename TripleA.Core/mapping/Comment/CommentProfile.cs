using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Features.Comment.Commands.Models;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Comment
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AddCommentCommand, TripleA.Data.Entities.Comment>();
        }
    }
}
