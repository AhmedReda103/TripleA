using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;
using Microsoft.IdentityModel.Tokens;

namespace TripleA.Service.implementations
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<string> AddComment(Comment comment)
        {
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return "Added";
        }


        public async Task<string> DeleteAsync(Comment comment)
        {
            var trans = _unitOfWork.Comments.BeginTransaction();
            try
            {
                _unitOfWork.Comments.Delete(comment);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<string> EditAsync(Comment comment)
        {
            try
            {
                _unitOfWork.Comments.Update(comment);
                await _unitOfWork.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }

        public async Task<Comment> GetCommentByIDAsync(int id)
        {
            var comment = await _unitOfWork.Comments.GetByIdAsync(id);
            return comment;
        }

        public IQueryable<Comment> getCommentsByAnswerIdPaginatedQuerable(int answerId)
        {
            var Answer = _unitOfWork.Answers.GetTableNoTracking().AsQueryable().Where(v => v.Id == answerId);
            var comments = _unitOfWork.Comments.GetTableNoTracking().AsQueryable();
            if (!Answer.IsNullOrEmpty() && !comments.IsNullOrEmpty())
            {
                var query = from a in Answer
                            join b in comments on a.Id equals b.AnswerId
                            select new Comment
                            {
                                Id = b.Id,
                                Content=b.Content,
                                CreatedIn = b.CreatedIn,
                                AnswerId =b.AnswerId,
                                UserId = b.UserId


                            };
                return query;
            }
            return Enumerable.Empty<Comment>().AsQueryable();
        }
    }
}
