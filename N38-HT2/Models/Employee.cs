using System.Diagnostics;
using System.Globalization;

namespace N38_HT2.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Department : {Department}, Salary: {Salary.ToString()}";
    }
}