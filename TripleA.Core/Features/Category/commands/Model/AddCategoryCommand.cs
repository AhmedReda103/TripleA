using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Category.commands.Model
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string? Name { get; set; }
    }
}
