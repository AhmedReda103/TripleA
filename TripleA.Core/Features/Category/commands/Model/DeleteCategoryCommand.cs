using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Category.commands.Model
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
