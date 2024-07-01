using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.ApplicationUser.Queries.Dtos;

namespace TripleA.Core.Features.ApplicationUser.Queries.Model
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListDto>>>
    {
    }
}
