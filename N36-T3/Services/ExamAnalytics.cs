using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T3.Services
{
    public class ExamAnalytics
    {
        private UserService _userService;
        private ExamScoreService _scoreService;

        public ExamAnalytics(UserService userService, ExamScoreService scoreService)
        {
            _userService = userService;
            _scoreService = scoreService;
        }

        public IEnumerable<(string FullName, int Score)> GetScores()
        {
            return _userService.GetUsers().Select(user =>
            {
                var fullName = $"{user.FirstName} {user.LastName}";
                var score = _scoreService.GetExamScore(user.Id).Score;
                return (fullName, score);
            });
        }
    }
}
