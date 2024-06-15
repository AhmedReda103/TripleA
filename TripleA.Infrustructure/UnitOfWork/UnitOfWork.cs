using Microsoft.AspNetCore.Identity;
using TripleA.Data.Entities;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.Repositories;

namespace TripleA.Infrustructure.unitOfWork
{
    public class UnitOfWork : IUnitOfWork   //Be aware to intialize every abstraction here into the constractor
    {
        public ApplicationDbContext _context { get; set; }
        public UserManager<User> _userManager { get; }

        public RoleManager<IdentityRole> _roleManager { get; }

        public IQuestionRepository Questions { get; }

        public IAnswerRepository Answers { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            Questions = new QuestionRepository(_context);
            Answers = new AnswerRepository(_context);
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
