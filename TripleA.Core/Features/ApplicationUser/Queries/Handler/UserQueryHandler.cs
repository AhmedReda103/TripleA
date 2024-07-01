using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;
using TripleA.Core.Features.ApplicationUser.Queries.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.ApplicationUser.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
                                    IRequestHandler<GetUserByIdQuery, Response<UserDto>>,
                                    IRequestHandler<GetUserProfileByIdQuery, Response<UserProfileDto>>,
                                     IRequestHandler<GetUserListQuery, Response<List<GetUserListDto>>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationUserService applicationUserService;
        private readonly IAnswerService answerService;
        private readonly IQuestionService questionService;

        public UserQueryHandler(IMapper mapper,
                                IApplicationUserService applicationUserService,
                                IAnswerService answerService,
                                IQuestionService questionService)
        {
            this.mapper = mapper;
            this.applicationUserService = applicationUserService;
            this.answerService = answerService;
            this.questionService = questionService;
        }
        public async Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await applicationUserService.GetUserByIdAsync(request.UserId);
            if (user == null)
                return NotFound<UserDto>();
            else
            {
                var userMapper = mapper.Map<UserDto>(user);
                return Success(userMapper);
            }
        }

        public async Task<Response<UserProfileDto>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await applicationUserService.GetUserByIdAsync(request.UserId);
            if (user == null)
                return NotFound<UserProfileDto>();
            var userProfileMapper = mapper.Map<UserProfileDto>(user);

            var answers = await answerService.GetAnswersOfUser(user.Id);

            var questions = await questionService.GetQuestionsOfUser(user.Id);

            userProfileMapper.UserProfileAnswers = mapper.Map<List<UserProfileAnswersDto>>(answers);
            userProfileMapper.UserProfileQuestions = mapper.Map<List<UserProfileQuestionsDto>>(questions);

            return Success(userProfileMapper);

        }

        public async Task<Response<List<GetUserListDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await applicationUserService.GetUsersListAsync();
            var userMapper = mapper.Map<List<GetUserListDto>>(userList);
            var result = Success(userMapper);
            return result;
        }
    }
}
