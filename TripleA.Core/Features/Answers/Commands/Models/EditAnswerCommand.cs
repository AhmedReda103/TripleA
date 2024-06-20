using MediatR;
using Microsoft.AspNetCore.Http;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Answers.Commands.Models
{
    public class EditAnswerCommand : IRequest<Response<String>>
    {

        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
