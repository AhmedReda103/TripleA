using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler//,
                                     //     IRequestHandler<AddQuestionCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;

        public QuestionCommandHandler(IMapper mapper,IQuestionService questionService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
        }
        //public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        //{
            
        //}
    }
}
