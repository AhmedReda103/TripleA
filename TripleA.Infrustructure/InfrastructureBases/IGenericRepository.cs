using System.Linq.Expressions;

namespace TripleA.Infrustructure.InfrastructureBases
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string Guid);
        IQueryable<T> GetTableNoTracking();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllPaginationAsync(int? pageNumber, int? itemNumber);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, int pageNumber, int itemNumber);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, int? pageNumber, int? itemNumber,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC");
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        int Count();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
    }
}
