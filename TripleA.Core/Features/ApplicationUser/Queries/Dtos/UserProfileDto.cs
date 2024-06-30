using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Core.Features.ApplicationUser.Queries.Dtos
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public int Votes { get; set; }
        public string UserName { get; set; }
        
        public List<UserProfileAnswersDto> UserProfileAnswers { get; set; }
        public List<UserProfileQuestionsDto> UserProfileQuestions { get; set; }
    }

    
}
