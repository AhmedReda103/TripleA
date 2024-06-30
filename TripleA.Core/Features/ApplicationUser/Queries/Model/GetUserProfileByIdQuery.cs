using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;

namespace TripleA.Core.Features.ApplicationUser.Queries.Model
{
    public class GetUserProfileByIdQuery : IRequest<Response<UserProfileDto>>
    {
        public string UserId { get; set; }
    }
}
