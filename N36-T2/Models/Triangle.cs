using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T2.Models
{
    public struct Triangle
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }

        public Triangle(decimal a, decimal b, decimal c)
        {
            A = a; B = b; C = c;
        }
    }
}
