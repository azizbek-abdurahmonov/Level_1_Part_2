using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T2.Models
{
    public struct Circle
    {
        public decimal Radius { get; set; }
        public Point Point { get; set; }

        public Circle(decimal radius, Point point)
        {
            Radius = radius;
            Point = point;
        }
    }
}
