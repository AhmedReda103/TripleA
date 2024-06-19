using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface ICommentService
    {
        public Task<string> DeleteAsync(Comment question);
        public Task<Comment> GetCommentByIDAsync(int id);
    }
}
