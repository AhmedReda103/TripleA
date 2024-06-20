using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Comment.Commands.Models;
using TripleA.Core.Resources;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Core.Features.Comment.Commands.Handler
{
    public class CommentCommandHandler : ResponseHandler,
                                                         IRequestHandler<AddCommentCommand, Response<String>>
    {
        private readonly IMapper mapper;
        private readonly ICommentService commentService;

        public CommentCommandHandler(IMapper mapper,
                                    ICommentService commentService
                                    )
        {
            this.mapper = mapper;
            this.commentService = commentService;          
        }

        public async Task<Response<string>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var CommentMapper = mapper.Map<TripleA.Data.Entities.Comment>(request);            
            CommentMapper.CreatedIn = DateTime.Now;
            var result = await commentService.AddComment(CommentMapper);            
            if (result == "Added")
            {               
                return Created("");
            }
            else return BadRequest<string>();
            throw new NotImplementedException();
        }
    }
}
