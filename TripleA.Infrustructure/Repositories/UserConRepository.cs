using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class UserConRepository : GenericRepository<UserCon>, IUserConRepository
    {
        private readonly DbSet<UserCon> _UsersCons;
        public UserConRepository(ApplicationDbContext context) : base(context)
        {
            _UsersCons = context.Set<UserCon>();
        }
    }
}
