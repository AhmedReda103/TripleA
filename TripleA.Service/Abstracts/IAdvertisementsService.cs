using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IAdvertisementsService
    {
        public Task<string> AddAdvertisements(Advertisement advertisement, IFormFile? file = null);
        public Task<List<Advertisement>> GetAdvertisementListAsync();
    }
}
