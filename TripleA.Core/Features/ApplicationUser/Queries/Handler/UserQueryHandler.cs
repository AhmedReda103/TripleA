using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Model;
using TripleA.Data.Entities.Identity;

namespace TripleA.Core.Features.ApplicationUser.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
                                    IRequestHandler<GetUserByIdQuery, Response<User>>
    {
        public Task<Response<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
