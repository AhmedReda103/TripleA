using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Question.Commands.Models
{
    public class DeleteQuestionCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        public DeleteQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
