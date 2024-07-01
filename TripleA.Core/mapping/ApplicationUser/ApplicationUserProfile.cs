using AutoMapper;
using TripleA.Core.Features.ApplicationUser.Commands.Models;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;

namespace TripleA.Core.mapping.ApplicationUser
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<AddUserCommand, TripleA.Data.Entities.Identity.User>();
            CreateMap<TripleA.Data.Entities.Identity.User, UserDto>();
            CreateMap<TripleA.Data.Entities.Identity.User, UserProfileDto>();
            CreateMap<TripleA.Data.Entities.Identity.User, GetUserListDto>();
        }
    }
}
