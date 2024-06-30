using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
    {
        private readonly DbSet<Advertisement> _Advertisement;
        public AdvertisementRepository(ApplicationDbContext context) : base(context)
        {
            _Advertisement = context.Set<Advertisement>();
        }
    }
}
