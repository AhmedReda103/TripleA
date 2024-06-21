﻿using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;

using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.Features.Comment.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Core.wrappers;

using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Queries.Handler
{
    public class QuestionQueryHandler : ResponseHandler,
                                        IRequestHandler<GetQuestionsByIdQuery, Response<GetQuestionByIdDto>>,

                                        IRequestHandler<GetQuestionsListPaginatedQuery, Response<PaginatedResult<GetQuestionsListPaginatedResponse>>>,
                                        IRequestHandler<GetQuestionByTitlePaginatedQuery, Response<PaginatedResult<GetQuestionByTitlePaginatedResponse>>>,


                                        IRequestHandler<GetMoreAnswersQuery, Response<PaginatedResult<AnswerDtoForQuestionById>>>,
                                        IRequestHandler<GetMoreCommentsQuery, Response<PaginatedResult<CommentDto>>>

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
                var AnswersPaginatedList = await mapper.ProjectTo<AnswerDtoForQuestionById>(joinQueryResForAnswers).ToPaginatedListAsync(1, request.answersLimit = 5);
                questionMapper.AnswersDto = AnswersPaginatedList;



                foreach (var answerDto in AnswersPaginatedList.Data)
                {
                    var joinQueryResForComments = commentService.getCommentsByAnswerIdPaginatedQuerable(answerDto.Id);
                    var CommentsPaginatedList = await mapper.ProjectTo<CommentDto>(joinQueryResForComments).ToPaginatedListAsync(1, request.commentsLimit = 3);
                    answerDto.CommentsDto = CommentsPaginatedList;

                }

                return Success(questionMapper);
            }

        }

        public async Task<Response<PaginatedResult<AnswerDtoForQuestionById>>> Handle(GetMoreAnswersQuery request, CancellationToken cancellationToken)
        {
            var JoinQueryRes = answerService.getAnswersByQuestionIdPaginatedQuerable(request.questionId);
            if (JoinQueryRes.IsNullOrEmpty()) return NotFound<PaginatedResult<AnswerDtoForQuestionById>>();

            var AnswersPaginatedList = await mapper.ProjectTo<AnswerDtoForQuestionById>(JoinQueryRes).ToPaginatedListAsync(request.PageNum, request.Answerlimit = 5);
            foreach (var answerDto in AnswersPaginatedList.Data)
            {
                var joinQueryResForComments = commentService.getCommentsByAnswerIdPaginatedQuerable(answerDto.Id);
                var CommentsPaginatedList = await mapper.ProjectTo<CommentDto>(joinQueryResForComments).ToPaginatedListAsync(1, request.Commentlimit = 3);
                answerDto.CommentsDto = CommentsPaginatedList;

            }
            return Success(AnswersPaginatedList);
        }

        public async Task<Response<PaginatedResult<CommentDto>>> Handle(GetMoreCommentsQuery request, CancellationToken cancellationToken)
        {
            var joinQueryResForComments = commentService.getCommentsByAnswerIdPaginatedQuerable(request.answerId);
            var CommentsPaginatedList = await mapper.ProjectTo<CommentDto>(joinQueryResForComments).ToPaginatedListAsync(request.PageNum, request.Commentlimit = 3);
            return Success(CommentsPaginatedList);
        }

        public async Task<Response<PaginatedResult<GetQuestionsListPaginatedResponse>>> Handle(GetQuestionsListPaginatedQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = questionService.FilliterQuestionsPaginatedQuerable(request.Search);

            if (FilterQuery.IsNullOrEmpty()) return NotFound<PaginatedResult<GetQuestionsListPaginatedResponse>>();
            var PaginatedList = await mapper.ProjectTo<GetQuestionsListPaginatedResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Success(PaginatedList);
        }

        public async Task<Response<PaginatedResult<GetQuestionByTitlePaginatedResponse>>> Handle(GetQuestionByTitlePaginatedQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = questionService.GetQuestionByTitleQuerable(request.QuestionTitle);

            if (FilterQuery.IsNullOrEmpty()) return NotFound<PaginatedResult<GetQuestionByTitlePaginatedResponse>>();

            var PaginatedList = await mapper.ProjectTo<GetQuestionByTitlePaginatedResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Success(PaginatedList);
        }


    }
}
