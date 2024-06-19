﻿using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{

    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddAnswer(Answer answer)
        {
            await unitOfWork.Answers.AddAsync(answer);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<Answer> getAnswerById(int answerId)
        {
            return await unitOfWork.Answers.GetByIdAsync(answerId);
        }

        public async Task Upvote(Answer answer)
        {
            answer.Votes++;
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DownVote(Answer answer)
        {
            answer.Votes--;
            await unitOfWork.SaveChangesAsync();
        }


        public async Task<string> DeleteAsync(Answer answer)
        {
            var trans = unitOfWork.Answers.BeginTransaction();
            try
            {
                unitOfWork.Answers.Delete(answer);
                await unitOfWork.SaveChangesAsync();
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }


    }
}
