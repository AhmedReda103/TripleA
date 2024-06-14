using Microsoft.AspNetCore.Identity;
using TripleA.Data.Entities;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.unitOfWork
{

    public interface IUnitOfWork : IDisposable
    {
        public UserManager<User> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }

        public IQuestionRepository Questions { get; }
        ApplicationDbContext _context { get; }

        Task SaveChangesAsync();
    }


}
