using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.unitOfWork
{
    public interface IUnitOfWork
    {
        ApplicationDbContext _context { get; }

        Task SaveChangesAsync();
    }


}
