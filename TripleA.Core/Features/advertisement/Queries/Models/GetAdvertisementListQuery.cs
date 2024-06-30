using MediatR;
using TripleA.Core.Bases;
using TripleA.Data.Entities;

namespace TripleA.Core.Features.advertisement.Queries.Models
{
    public class GetAdvertisementListQuery : IRequest<Response<List<Advertisement>>>
    {
    }
}
