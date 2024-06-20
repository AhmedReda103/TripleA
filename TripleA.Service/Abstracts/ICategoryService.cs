using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface ICategoryService
    {

        public Task<List<Category>> GetCategoryListAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<string> AddCategoryAsync(Category category);
        public Task<string> EditCategoryAsync(Category category);
        public Task<string> DeleteCategoryAsync(Category category);

        public IQueryable<Category> GetCategoriesQuerable();

        public IQueryable<Question> GetQuestionByCategoryIdPaginatedQuerable(int categoryId);

        public IQueryable<Category> FilliterCategoriesPaginatedQuerable(string search);
    }
}
