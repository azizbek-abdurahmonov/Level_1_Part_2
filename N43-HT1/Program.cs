using N43_HT1.Models;
using N43_HT1.Services;

var user1 = new User("Azizbek", "Abdurahmonov", true);

var userService = new UserService();
userService.Create(user1);
var employeeService = new EmployeeService(userService);
var performanceService = new PerformanceService(userService);
var accountService = new AccountService(employeeService, performanceService);

await accountService.CreateReportAsync(user1.Id);