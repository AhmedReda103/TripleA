using AutoMapper;
using MediatR;
using System.Net;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler,
                                          IRequestHandler<AddQuestionCommand, Response<string>>
                                          , IRequestHandler<DeleteQuestionCommand, Response<string>>
                                          , IRequestHandler<EditQuestionCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;
        private readonly IApplicationUserService applicationUserService;
        private readonly IFileService fileService;
        private readonly IPhotoService photoService;



        public QuestionCommandHandler(IMapper mapper,
                                      IQuestionService questionService,
                                      IApplicationUserService applicationUserService,
                                      IFileService fileService,
                                      IPhotoService photoService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
            this.applicationUserService = applicationUserService;
            this.fileService = fileService;
            this.photoService = photoService;
        }

        public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var QuestionMapper = mapper.Map<TripleA.Data.Entities.Question>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            QuestionMapper.UserId = UserId;

            QuestionMapper.CreatedIn = DateTime.Now;
            string? result = null;
            if (request?.Image != null)
            {
                result = await questionService.AddQuestion(QuestionMapper, request.Image);
            }
            else
            {
                result = await questionService.AddQuestion(QuestionMapper);
            }

            if (result == "Added")
                return Created("");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetByIDAsync(request.Id);
            if (question == null)
                return NotFound<string>();
            // Call service that make Delete

            if (question.Image != null || question.Image == "NoFile")
                await photoService.DeletePhotoAsync(question.Image);
            var result = await questionService.DeleteAsync(question);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var question = await questionService.GetByIDAsync(request.Id);
            //return NotFound
            if (question == null) return NotFound<string>();

            if (request.Image != null)
            {
                string imagePath = question.Image;
                // var deleted = fileService.DeleteFile(imagePath);
                var deleted = await photoService.DeletePhotoAsync(imagePath);

                if (deleted.StatusCode == HttpStatusCode.OK)
                {
                    //var fileUrl = await fileService.UploadFile("Question", request.Image);
                    var resultURL = await photoService.AddPhotoAsync(request.Image);
                    var fileUrl = resultURL.Url.ToString();
                    if (resultURL.StatusCode == HttpStatusCode.OK)
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
            var questionMapper = mapper.Map(request, question);
            //Call service that make Edit
            var result = await questionService.EditAsync(questionMapper);
            //return response
            if (result == "Success") return Success("Updated");
            else return BadRequest<string>();
        }
    }
}
