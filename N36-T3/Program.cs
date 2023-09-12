using N36_T3.Models;
using N36_T3.Services;

var user1 = new User("Azizbek", "Abdurahmonov");
var user2 = new User("Abdurahmon", "Satriddinov");
var user3 = new User("Ilxom", "Karimjanov");

var score1 = new ExamScore(user1.Id, 39);
var score2 = new ExamScore(user2.Id, 40);
var score3 = new ExamScore(user3.Id, 48);

var userService = new UserService();
var scoreService = new ExamScoreService();
userService.CreateUser(user1);
userService.CreateUser(user2);
userService.CreateUser(user3);

scoreService.CreateExamScore(score1);
scoreService.CreateExamScore(score2);
scoreService.CreateExamScore(score3);


var examAnalytics = new ExamAnalytics(userService, scoreService);
examAnalytics.GetScores().ToList().ForEach(result => Console.WriteLine($"{result.FullName} {result.Score}"));