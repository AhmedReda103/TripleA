using Microsoft.AspNetCore.Identity;
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
        public ICommentRepository Comments { get; }


        public ICategoryRepository Categories { get; }

        public IUserRepository Users { get; }

        public INotificationRepository Notifications { get; }

        public IUserConRepository userCons { get; }

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
            Categories = new CategoryRepository(_context);
            Users = new UserRepository(_context);
            Comments = new CommentRepository(_context);
            Notifications = new NotificationRepository(_context);
            userCons = new UserConRepository(_context);

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
