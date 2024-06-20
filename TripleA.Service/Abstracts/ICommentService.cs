using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface ICommentService
    {
        Task<string> AddComment(Comment content);

        public Task<string> DeleteAsync(Comment comment);
        public Task<Comment> GetCommentByIDAsync(int id);
        public Task<string> EditAsync(Comment comment);
    }
}
