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
    public class AnswerRepository : GenericRepository<Answer> ,IAnswerRepository
    {
        private readonly DbSet<Answer> _Answers;
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
            _Answers = context.Set<Answer>();
        }
    }
}
