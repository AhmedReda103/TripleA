using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface ICategoryService
    {
        //   Task<List<Question>> GetQuestionsByCategoryId(int categoryId);

        public Task<List<Category>> GetCategoryListAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<string> AddCategoryAsync(Category category);

        public IQueryable<Category> GetCategoriesQuerable();

        public IQueryable<Question> GetQuestionByCategoryIdPaginatedQuerable(int categoryId);

        public IQueryable<Category> FilliterCategoriesPaginatedQuerable(string search);
    }
}
