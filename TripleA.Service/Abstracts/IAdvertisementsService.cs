using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IAdvertisementsService
    {
        public Task<string> AddAdvertisements(Advertisement advertisement, IFormFile? file = null);
        public Task<List<Advertisement>> GetAdvertisementListAsync();
        public Task<Advertisement> GetAdvertisementByIdAsync(int id);
        public Task<string> DeleteAdvertisementAsync(Advertisement advertisement);
    }
}
