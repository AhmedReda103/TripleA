using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DbSet<Comment> _Comments;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _Comments = context.Set<Comment>();
        }
    }
}
