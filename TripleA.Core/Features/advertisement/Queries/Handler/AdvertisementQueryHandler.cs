using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.advertisement.Queries.Models;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.advertisement.Queries.Handler
{
    public class AdvertisementQueryHandler : ResponseHandler,
                                        IRequestHandler<GetAdvertisementListQuery, Response<List<Advertisement>>>
    {
        private readonly IMapper mapper;
        private readonly IAdvertisementsService advertismentService;

        public AdvertisementQueryHandler(IMapper mapper,
                                    IAdvertisementsService advertismentService)
        {
            this.mapper = mapper;
            this.advertismentService = advertismentService;
        }

        public async Task<Response<List<Advertisement>>> Handle(GetAdvertisementListQuery request, CancellationToken cancellationToken)
        {
            var advertisements = await advertismentService.GetAdvertisementListAsync();
            if (advertisements != null)
            {
                return Success(advertisements);
            }
            return NotFound<List<Advertisement>>("there is no Advertisment now ");
        }
    }
}

