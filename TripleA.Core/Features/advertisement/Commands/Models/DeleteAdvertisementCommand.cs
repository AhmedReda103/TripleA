using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.advertisement.Commands.Models
{
    public class DeleteAdvertisementCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteAdvertisementCommand(int id)
        {
            this.Id = id;
        }
    }
}
