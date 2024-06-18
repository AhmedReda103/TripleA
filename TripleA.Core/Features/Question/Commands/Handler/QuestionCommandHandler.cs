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
using TripleA.Data.Entities;

namespace TripleA.Core.Features.Question.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler,
                                          IRequestHandler<AddQuestionCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;
        private readonly IApplicationUserService applicationUserService;

        public QuestionCommandHandler(IMapper mapper,
                                      IQuestionService questionService,
                                      IApplicationUserService applicationUserService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
            this.applicationUserService = applicationUserService;
        }
        public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var QuestionMapper = mapper.Map<TripleA.Data.Entities.Question>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            QuestionMapper.UserId = UserId;
            QuestionMapper.CreatedIn= DateTime.Now;
            var result = await questionService.AddQuestion(QuestionMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();

        }
    }
}
