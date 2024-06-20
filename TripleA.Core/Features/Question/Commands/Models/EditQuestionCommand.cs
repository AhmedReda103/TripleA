using MediatR;
using Microsoft.AspNetCore.Http;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Question.Commands.Models
{
    public class EditQuestionCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Image { get; set; }
    }
}
