using N36_T1.Models;

var person1 = new Person("John", "Doe", 17);

var employee1 = new Employee("Jonibek", "Qodiraliyev", 23, "johny@example.com", 1_500);
var employee2 = new Employee("Odil", "Gishtmat", 27, "gishtmatOfficial@example.com", 2_250);


var manager = new Manager("Mark", "Zuckerberg", 36, "mark@facebook.com", "MarkVsElon", new List<Employee> { employee1, employee2 });