using N36_T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T3.Services
{
    public class ExamScoreService
    {
        private List<ExamScore> _examScores;

        public ExamScoreService()
        {
            _examScores = new List<ExamScore>();
        }

        public void CreateExamScore(ExamScore examScore)
        {
            _examScores.Add(examScore);
        }

        public List<ExamScore> GetExamScores() => _examScores;

        public ExamScore GetExamScore(Guid userId) => _examScores.FirstOrDefault(score => score.UserId == userId);

        public void UpdateExamScore(ExamScore updatedExamScore)
        {
            var foundedExamScore = _examScores.FirstOrDefault(score => score.Id == updatedExamScore.Id);

            if (foundedExamScore != null)
            {
                foundedExamScore.UserId = updatedExamScore.UserId;
                foundedExamScore.Score = updatedExamScore.Score;
            }
        }

        public void DeleteExamScore(Guid Id)
        {
            var foundedExamScore = GetExamScore(Id);

            if (foundedExamScore != null)
                _examScores.Remove(foundedExamScore);
        }
    }
}
