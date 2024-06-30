using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IUserConService
    {

        Task<string> AddUserConAsync(UserCon userCon);
        public Task<string> DeleteAsync(UserCon userCon);
        public Task<List<UserCon>> GetAll();

    }
}
