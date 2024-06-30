using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.advertisement.Commands.Models;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.advertisement.Commands.Handler
{
    public class AdvertisementCommandHandler : ResponseHandler,
                                        IRequestHandler<AddAdvertisementCommand, Response<string>>
    {

        private readonly IMapper mapper;
        private readonly IAdvertisementsService advertisementService;
        private readonly IFileService fileService;
        private readonly IPhotoService photoService;

        public AdvertisementCommandHandler(IMapper mapper,
                                    IAdvertisementsService advertisementService,
                                    IFileService fileService,
                                    IPhotoService photoService)
        {
            this.mapper = mapper;
            this.advertisementService = advertisementService;
            this.fileService = fileService;
            this.photoService = photoService;

        }



        public async Task<Response<string>> Handle(AddAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var AdvertisementMapper = mapper.Map<TripleA.Data.Entities.Advertisement>(request);
            string? result = null;
            if (request?.image != null)
            {
                result = await advertisementService.AddAdvertisements(AdvertisementMapper, request.image);
            }
            else
            {
                result = await advertisementService.AddAdvertisements(AdvertisementMapper);
            }
            if (result == "Added")
            {
                return Created("");
            }
            return BadRequest<string>();
        }


    }
}
