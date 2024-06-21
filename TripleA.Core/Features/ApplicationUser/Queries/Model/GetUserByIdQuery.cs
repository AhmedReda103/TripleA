using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;
using TripleA.Data.Entities.Identity;

namespace TripleA.Core.Features.ApplicationUser.Queries.Model
{
    public class GetUserByIdQuery :IRequest<Response<UserDto>>
    {
        public string UserId { get; set; }
    }
}
