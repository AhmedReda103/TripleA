using TripleA.Data.Entities.Identity;
using TripleA.Domain.Results;

namespace TripleA.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
        public Task<JwtAuthResult> GetJWTToken(User user);
        public Task<string> getUserIdAsync();
    }
}
