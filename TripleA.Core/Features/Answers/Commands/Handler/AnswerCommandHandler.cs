using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Commands.Models;
using TripleA.Core.Resources;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Core.Features.Answers.Commands.Handler
{
    public class AnswerCommandHandler : ResponseHandler,
                                        IRequestHandler<AddAnswerCommand, Response<string>>,
                                        IRequestHandler<UpVoteAnswerCommand, Response<string>>,
                                        IRequestHandler<DownVoteAnswerCommand, Response<string>>,
                                        IRequestHandler<DeleteAnswerCommand, Response<string>>,
                                        IRequestHandler<EditAnswerCommand, Response<string>>


    {
        private readonly IMapper mapper;
        private readonly IAnswerService answerService;
        private readonly IApplicationUserService applicationUserService;
        private readonly INotificationService notificationService;
        private readonly IQuestionService questionService;
        private readonly IHubContext<RealTimeService> realTimeService;
        private readonly IFileService fileService;

        public AnswerCommandHandler(IMapper mapper,
                                    IAnswerService answerService,
                                    IApplicationUserService applicationUserService,
                                    IHubContext<RealTimeService> realTimeService,
                                    IFileService fileService,
                                    INotificationService notificationService,
                                    IQuestionService questionService)
        {
            this.mapper = mapper;
            this.answerService = answerService;
            this.applicationUserService = applicationUserService;
            this.realTimeService = realTimeService;
            this.fileService = fileService;
            this.notificationService = notificationService;
            this.questionService = questionService;
        }


        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = mapper.Map<TripleA.Data.Entities.Answer>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            AnswerMapper.UserId = UserId;

            AnswerMapper.CreatedIn = DateTime.Now;
            var result = await answerService.AddAnswer(AnswerMapper, request.Image);

            var AskerId = questionService.GetByIDAsync(request.QuestionId).Result.UserId;
            //var AskerId = AnswerMapper?.Question?.user.Id;
            //var AskerId2 = AnswerMapper?.Question?.UserId;

            var ResponderName = applicationUserService.getUserByIdAsync(UserId).Result.UserName;
            if (result == "Added")
            {
                var notification = new Notification()
                {
                    CreatedIn = DateTime.Now,
                    Message = SharedResourcesKeys.notificationMessage + $" : {AnswerMapper.Description}",
                    UserId = AskerId,
                    Responder = ResponderName

                };
                await notificationService.addNotificationAsync(notification);
                await realTimeService.Clients.User(AskerId).SendAsync("ReceiveNotification", notification);
                return Created("");
            }
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpVoteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.getAnswerById(request.AnswerId);
            var replyerId = await answerService.getReplyerIdOfAnswer(request.AnswerId);
            await applicationUserService.upUser(replyerId);
            await answerService.Upvote(answer);

            return Success("");
        }

        public async Task<Response<string>> Handle(DownVoteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.getAnswerById(request.AnswerId);
            var replyerId = await answerService.getReplyerIdOfAnswer(request.AnswerId);
            await applicationUserService.DownUser(replyerId);
            await answerService.DownVote(answer);
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.getAnswerById(request.Id);
            //return NotFound
            if (answer == null) return NotFound<string>();
            //Call service that make Delete
            var result = await answerService.DeleteAsync(answer);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var answer = await answerService.GetAnswerByIdAsync(request.Id);
            //return NotFound
            if (answer == null) return NotFound<string>();

            if (request.Image != null)
            {
                string imagePath = answer.Image;
                var deleted = fileService.DeleteFile(imagePath);
                if (deleted)
                {
                    var fileUrl = await fileService.UploadFile("Answer", request.Image);
                    if (fileUrl != "FailedToUploadFile")
                    {
                        request.ImagePath = fileUrl;
                    }
                    else
                    {
                        request.ImagePath = null;
                    }
                }
            }

            //mapping Between request and question
            var questionMapper = mapper.Map(request, answer);
            //Call service that make Edit
            var result = await answerService.EditAsync(questionMapper);
            //return response
            if (result == "Success") return Success("Updated");
            else return BadRequest<string>();
        }
    }
}
