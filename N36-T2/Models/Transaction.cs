using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T2.Models
{
    public record Transaction(int Id, DateTime Date, decimal Amount);
}
