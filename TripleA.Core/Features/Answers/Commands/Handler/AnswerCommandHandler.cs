using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Core.Features.Answers.Commands.Handler
{
    public class AnswerCommandHandler : ResponseHandler,
                                          IRequestHandler<AddAnswerCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IAnswerService answerService;
        private readonly IApplicationUserService applicationUserService;

        public AnswerCommandHandler(IMapper mapper,
                                    IAnswerService answerService,
                                    IApplicationUserService applicationUserService)
        {
            this.mapper = mapper;
            this.answerService = answerService;
            this.applicationUserService = applicationUserService;
        }
        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = mapper.Map<TripleA.Data.Entities.Answer>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            AnswerMapper.UserId = UserId;
            var result = await answerService.AddAnswer(AnswerMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }
    }
}
