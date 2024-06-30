using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;
using TripleA.Core.Features.ApplicationUser.Queries.Model;
using TripleA.Data.Entities.Identity;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.ApplicationUser.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
                                    IRequestHandler<GetUserByIdQuery, Response<UserDto>>,
                                    IRequestHandler<GetUserProfileByIdQuery, Response<UserProfileDto>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationUserService applicationUserService;
        private readonly IAnswerService answerService;

        public UserQueryHandler(IMapper mapper,
                                IApplicationUserService applicationUserService,
                                IAnswerService answerService)
        {
            this.mapper = mapper;
            this.applicationUserService = applicationUserService;
            this.answerService = answerService;
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

            userProfileMapper.UserProfileAnswers = mapper.Map<List<UserProfileAnswersDto>>(answers);

            return Success(userProfileMapper);

        }
    }
}
