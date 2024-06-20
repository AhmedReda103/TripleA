using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddComment(Comment comment)
        {
            await unitOfWork.Comments.AddAsync(comment);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }


        public async Task<string> DeleteAsync(Comment comment)
        {
            var trans = _unitOfWork.Questions.BeginTransaction();
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
    }
}
