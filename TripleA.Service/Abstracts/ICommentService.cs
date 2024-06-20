using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface ICommentService
    {
        public Task<string> DeleteAsync(Comment comment);
        public Task<Comment> GetCommentByIDAsync(int id);
        public Task<string> EditAsync(Comment comment);
    }
}
