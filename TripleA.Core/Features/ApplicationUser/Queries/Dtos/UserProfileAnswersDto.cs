using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Core.Features.ApplicationUser.Queries.Dtos
{
    public class UserProfileAnswersDto
    {
        public int answerId {  get; set; }
        public int questionId {  get; set; }
        public int votes {  get; set; }

        public string questionTitle { get; set; }
        public string answerContent { get; set; }
    }
}
