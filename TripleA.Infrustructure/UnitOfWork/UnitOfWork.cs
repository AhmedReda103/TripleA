using Microsoft.AspNetCore.Identity;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure.Context;

namespace TripleA.Infrustructure.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; set; }
        public UserManager<User> _userManager { get; }

        public RoleManager<IdentityRole> _roleManager { get; }


        public UnitOfWork(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
