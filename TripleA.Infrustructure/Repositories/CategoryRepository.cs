using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public readonly DbSet<Category> _Categories;
        //public readonly DbSet<Question> _Questions;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _Categories = context.Set<Category>();
            //_Questions = context.Set<Question>();
        }

        //public async Task<List<Question>> GetQuestionsByCategoryId(int categoryId)
        //{
        //    var questionId = await _Categories
        //                                     .Where(m => m.Id == categoryId)
        //                                     .Select(m => m.Id)
        //                                     .ToListAsync();
        //    var questions = await _Questions
        //                                .Where(a => questionId.Contains(a.Id))
        //                                .ToListAsync();
        //    return questions;
        //}
    }
}
