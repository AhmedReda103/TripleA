using AutoMapper;
using TripleA.Core.Features.advertisement.Commands.Models;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.advertisement
{
    public class AdvertismentProfile : Profile
    {

        public AdvertismentProfile()
        {
            CreateMap<AddAdvertisementCommand, Advertisement>();
        }

    }
}
