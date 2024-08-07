﻿using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddCategoryAsync(Category category)
        {
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {

            var trans = unitOfWork.Categories.BeginTransaction();
            try
            {
                unitOfWork.Categories.Delete(category);
                await unitOfWork.SaveChangesAsync();
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditCategoryAsync(Category category)
        {
            unitOfWork.Categories.Update(category);
            await unitOfWork.SaveChangesAsync();
            return "Success";
        }

        public IQueryable<Category> FilliterCategoriesPaginatedQuerable(string search)
        {
            var querable = unitOfWork.Categories.GetTableNoTracking().AsQueryable();
            if (querable.IsNullOrEmpty())
            {
                return Enumerable.Empty<Category>().AsQueryable();
            }
            if (search != null)
            {
                querable = querable.Where(x => x.Name.Contains(search));
            }
            return querable;
        }

        public IQueryable<Category> GetCategoriesQuerable()
        {
            return unitOfWork.Categories.GetTableNoTracking().AsQueryable();

        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            var result = await unitOfWork.Categories.GetAllAsync();
            return result.ToList();
        }

        public IQueryable<Question> GetQuestionByCategoryIdPaginatedQuerable(int categoryId)
        {
            var categories = unitOfWork.Categories.GetTableNoTracking().AsQueryable().Where(v => v.Id == categoryId);
            var questions = unitOfWork.Questions.GetTableNoTracking().AsQueryable();
            if (!questions.IsNullOrEmpty() && !categories.IsNullOrEmpty())
            {
                var query = from a in categories
                            join b in questions on a.Id equals b.CategoryId
                            select new Question
                            {
                                Id = b.Id,
                                Description = b.Description,
                                Title = b.Title,
                                Image = b.Image,
                                CreatedIn = b.CreatedIn,
                                Answers = b.Answers,
                                UserId = b.UserId


                            };
                return query;
            }
            return Enumerable.Empty<Question>().AsQueryable();
        }

    }
}
