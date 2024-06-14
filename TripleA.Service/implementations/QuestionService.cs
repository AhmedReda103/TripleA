using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;


namespace TripleA.Service.implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddQuestion(Question question)
        {
           await _unitOfWork.Questions.AddAsync(question);
           await _unitOfWork.SaveChangesAsync();
           return "Added";
        }
    }
}
