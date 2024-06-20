using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Category.commands.Model;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.Category.commands.Handler
{
    public class CategoryCommandHandler : ResponseHandler,
                                                    IRequestHandler<AddCategoryCommand, Response<string>>,
                                                    IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoryCommandHandler(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;

        }
        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryMapper = mapper.Map<TripleA.Data.Entities.Category>(request);
            var result = await categoryService.AddCategoryAsync(categoryMapper);
            if (result == "Added")
                return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetCategoryByIdAsync(request.Id);
            if (category == null) return NotFound<string>("category is Not Found");

            var result = await categoryService.DeleteCategoryAsync(category);
            if (result == "Success") return Deleted<string>($"Delete Successfully {request.Id}");
            else return BadRequest<string>();


        }
    }
}
