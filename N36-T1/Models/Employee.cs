using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T1.Models
{
    public record Employee(string FirstName, string LastName, int Age, string EmailAddress, decimal Salary) : Person(FirstName, LastName, Age);
}
