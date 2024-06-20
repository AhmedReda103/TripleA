using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Queries.Dtos;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Question.Queries.Handler
{
    public class QuestionQueryHandler : ResponseHandler,
                                        IRequestHandler<GetQuestionsById, Response<GetQuestionByIdDto>>
    {
        private readonly IMapper mapper;
        private readonly IQuestionService questionService;

        public QuestionQueryHandler(IMapper mapper,
                                    IQuestionService questionService)
        {
            this.mapper = mapper;
            this.questionService = questionService;
        }

        public Task<Response<GetQuestionByIdDto>> Handle(GetQuestionsById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
