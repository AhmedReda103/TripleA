using AutoMapper;
using MediatR;
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


        public QuestionCommandHandler(IMapper mapper,
                                      IQuestionService questionService,
                                      IApplicationUserService applicationUserService,
                                      IFileService fileService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
            this.applicationUserService = applicationUserService;
            this.fileService = fileService;
        }

        public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var QuestionMapper = mapper.Map<TripleA.Data.Entities.Question>(request);
            var UserId = await applicationUserService.getUserIdAsync();  //ADD two roles then use ord. userid
            QuestionMapper.UserId = UserId;

            QuestionMapper.CreatedIn = DateTime.Now;

            var result = await questionService.AddQuestion(QuestionMapper, request.Image);

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
                var deleted = fileService.DeleteFile(imagePath);
                if (deleted)
                {
                    var fileUrl = await fileService.UploadFile("Question", request.Image);
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
            var questionMapper = mapper.Map(request, question);
            //Call service that make Edit
            var result = await questionService.EditAsync(questionMapper);
            //return response
            if (result == "Success") return Success("Updated");
            else return BadRequest<string>();
        }
    }
}
