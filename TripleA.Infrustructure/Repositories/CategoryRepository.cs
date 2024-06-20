using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public readonly DbSet<Category> _Categories;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _Categories = context.Set<Category>();

        }
    }
}
