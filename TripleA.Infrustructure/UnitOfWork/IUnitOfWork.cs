using Microsoft.AspNetCore.Identity;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.unitOfWork
{

    public interface IUnitOfWork
    {
        public UserManager<User> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }


        ApplicationDbContext _context { get; }

        Task SaveChangesAsync();
    }


}
