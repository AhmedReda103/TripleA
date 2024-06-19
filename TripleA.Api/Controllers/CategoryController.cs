using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripleA.Api.Base;
using TripleA.Core.Features.Category.queries.Model;


namespace TripleA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : AppControllerBase
    {
        [HttpGet("/GetQuestionsByCategoryIdPagenated")]
        [Authorize]
        public async Task<IActionResult> GetQuestionsByCategoryIdPagenated([FromQuery] GetQuestionsByCategoryIdPaginatedQuery query)
        {
            var response = await Mediator.Send(query);
            //  Log.Information("Response data: {@Response}", response);
            return NewResult(response);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await Mediator.Send(new GetCategoryListQuery());
            return NewResult(response);
        }
    }
}
