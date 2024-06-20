using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Commands.Models;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler,
                                          IRequestHandler<AddQuestionCommand, Response<string>>,
                                          IRequestHandler<DeleteQuestionCommand, Response<string>>
                                       
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

            QuestionMapper.CreatedIn = DateTime.Now;

            var result = await questionService.AddQuestion(QuestionMapper, request.Image);

            if (result == "Added")
                return Created("");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetByIDAsync(request.Id);
            return NotFound<string>();
            if (question == null) return NotFound<string>();
            // Call service that make Delete
            var result = await questionService.DeleteAsync(question);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }

      
    }
}
