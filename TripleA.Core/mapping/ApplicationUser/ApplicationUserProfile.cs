using AutoMapper;
using TripleA.Core.Features.ApplicationUser.Commands.Models;
using TripleA.Data.Entities.Identity;

namespace TripleA.Core.mapping.ApplicationUser
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
