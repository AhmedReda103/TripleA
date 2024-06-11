using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        ApplicationDbContext _context { get; }

        Task SaveChangesAsync();
    }


}
