using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TripleA.Core.Bases;

namespace TripleA.Core.Features.advertisement.Commands.Models
{
    public class AddAdvertisementCommand : IRequest<Response<String>>
    {
        [Required]
        public string title { get; set; }
        public string? companyLink { get; set; }
        public string? companyName { get; set; }
        public IFormFile? image { get; set; }
    }
}
