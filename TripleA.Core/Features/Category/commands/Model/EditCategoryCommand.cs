using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Category.commands.Model
{
    public class EditCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
