using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{

    public class UserConService : IUserConService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserConService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddUserConAsync(UserCon userCon)
        {

            await unitOfWork.userCons.AddAsync(userCon);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<string> DeleteAsync(UserCon userCon)
        {
            var trans = unitOfWork.userCons.BeginTransaction();
            try
            {
                unitOfWork.userCons.Delete(userCon);
                await unitOfWork.SaveChangesAsync();
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }


        public async Task<List<UserCon>> GetAll()
        {
            var users = await unitOfWork.userCons.GetAllAsync();
            if (users != null)
            {
                return users.ToList();
            }
            return new List<UserCon>();
        }


    }
}
