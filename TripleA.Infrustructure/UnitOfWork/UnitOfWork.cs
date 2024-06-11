using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; set; }


        public UnitOfWork(
          ApplicationDbContext context
        )
        {
            _context = context;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
