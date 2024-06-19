using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Resources;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Core.Features.Answers.Commands.Handler
{
    public class AnswerCommandHandler : ResponseHandler,
                                        IRequestHandler<AddAnswerCommand, Response<string>>,
                                        IRequestHandler<UpVoteAnswerCommand, Response<string>>,
                                        IRequestHandler<DownVoteAnswerCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IAnswerService answerService;
        private readonly IApplicationUserService applicationUserService;
        private readonly IHubContext<RealTimeService> realTimeService;

        public AnswerCommandHandler(IMapper mapper,
                                    IAnswerService answerService,
                                    IApplicationUserService applicationUserService,
                                    IHubContext<RealTimeService> realTimeService)
        {
            this.mapper = mapper;
            this.answerService = answerService;
            this.applicationUserService = applicationUserService;
            this.realTimeService = realTimeService;
        }
        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = mapper.Map<TripleA.Data.Entities.Answer>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            AnswerMapper.UserId = UserId;

            var result = await answerService.AddAnswer(AnswerMapper, request.Image);

            AnswerMapper.CreatedIn = DateTime.Now;
            var AskerId = AnswerMapper?.Question?.UserId;
            if (result == "Added")
            {
                await realTimeService.Clients.User(AskerId).SendAsync("ReceiveNotification", SharedResourcesKeys.notificationMessage + $" : {AnswerMapper.Description}");
                return Created("");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpVoteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.getAnswerById(request.AnswerId);
            answerService.Upvote(answer);
            return Success("");
        }

        public async Task<Response<string>> Handle(DownVoteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.getAnswerById(request.AnswerId);
            answerService.DownVote(answer);
            return Success("");
        }
    }
}
