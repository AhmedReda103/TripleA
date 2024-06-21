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
                                    IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationUserService applicationUserService;

        public UserQueryHandler(IMapper mapper,
                                IApplicationUserService applicationUserService)
        {
            this.mapper = mapper;
            this.applicationUserService = applicationUserService;
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
    }
}
