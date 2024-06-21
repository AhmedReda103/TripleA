using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.Features.Category.queries.Dtos;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Core.wrappers;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;
using TripleA.Service.implementations;

namespace TripleA.Core.Features.Question.Queries.Handler
{
    public class QuestionQueryHandler : ResponseHandler,
                                        IRequestHandler<GetQuestionsByIdQuery, Response<GetQuestionByIdDto>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
        private readonly ICommentService commentService;

        public QuestionQueryHandler(IMapper mapper,
                                    IQuestionService questionService,
                                    IAnswerService answerService,
                                    ICommentService commentService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
            this.answerService = answerService;
            this.commentService = commentService;
        }

        public async Task<Response<GetQuestionByIdDto>> Handle(GetQuestionsByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetByIDAsync(request.QuestionId);
            if (question == null)
                return NotFound<GetQuestionByIdDto>();
            else
            {
                var questionMapper = mapper.Map<GetQuestionByIdDto>(question);

                var joinQueryResForAnswers = answerService.getAnswersByQuestionIdPaginatedQuerable(request.QuestionId);
                var AnswersPaginatedList = await mapper.ProjectTo<AnswerDtoForQuestionById>(joinQueryResForAnswers).ToPaginatedListAsync(1, request.answersLimit);
                questionMapper.AnswersDto = AnswersPaginatedList;



                foreach (var answerDto in AnswersPaginatedList.Data)
                {
                    var joinQueryResForComments = commentService.getCommentsByAnswerIdPaginatedQuerable(answerDto.Id);
                    var CommentsPaginatedList = await mapper.ProjectTo<CommentDto>(joinQueryResForComments).ToPaginatedListAsync(1, request.commentsLimit);
                    answerDto.CommentsDto = CommentsPaginatedList;

                }

                return Success(questionMapper);
            }
           
        }
    }
}
