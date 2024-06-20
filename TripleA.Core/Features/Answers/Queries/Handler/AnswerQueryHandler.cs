using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Answers.Queries.Dtos;
using TripleA.Core.Features.Answers.Queries.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Answers.Queries.Handler
{
    public class AnswerQueryHandler : ResponseHandler,
                                       IRequestHandler<GetAnswerByIdQuery, Response<GetAnswerByIdDto>>
    {
        private readonly IMapper mapper;
        private readonly IAnswerService answerService;
        public AnswerQueryHandler(IMapper mapper, IAnswerService answerService)
        {
            this.mapper = mapper;
            this.answerService = answerService;
        }

        public async Task<Response<GetAnswerByIdDto>> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await answerService.GetAnswerByIdAsync(request.Id);
            if (answer == null) return NotFound<GetAnswerByIdDto>();
            var answerMapper = mapper.Map<GetAnswerByIdDto>(answer);
            var result = Success(answerMapper);
            return result;
        }
    }
}
