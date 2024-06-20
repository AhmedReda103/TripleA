using MediatR;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Answers.Commands.Models
{
    public class DeleteAnswerCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        public DeleteAnswerCommand(int id)
        {
            Id = id;
        }
    }
}
