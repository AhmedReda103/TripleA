using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Data.Entities.Identity;

namespace TripleA.Infrustructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Answer)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.AnswerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
               .HasOne(c => c.Question)
               .WithMany(p => p.Answers)
               .HasForeignKey(c => c.QuestionId)
               .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserCon> UserCons { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

    }
}
