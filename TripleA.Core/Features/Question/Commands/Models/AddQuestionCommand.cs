using MediatR;
using Microsoft.AspNetCore.Http;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.Question.Commands.Models
{
    public class AddQuestionCommand : IRequest<Response<String>>
    {
        public string Description { get; set; }
        public string Title { get; set; }
        //public string Image { get; set; }
       // public DateTime CreatedIn { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
