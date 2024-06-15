using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class QuestionRepository : GenericRepository<Question>,IQuestionRepository 
    {
        private readonly DbSet<Question> _Questions;
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
            _Questions = context.Set<Question>();
        }

        
    }
}
