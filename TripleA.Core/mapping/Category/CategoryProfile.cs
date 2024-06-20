using AutoMapper;
using TripleA.Core.Features.Category.commands.Model;
using TripleA.Core.Features.Category.queries.Dtos;
using TripleA.Data.Entities;

namespace TripleA.Core.mapping.Category
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {


            CreateMap<Question, GetQuestionsByCategoryIdPaginatedResponse>();
            CreateMap<TripleA.Data.Entities.Category, GetCategoryListDto>();
            CreateMap<AddCategoryCommand, TripleA.Data.Entities.Category>();
            CreateMap<EditCategoryCommand, TripleA.Data.Entities.Category>();

        }
    }
}
