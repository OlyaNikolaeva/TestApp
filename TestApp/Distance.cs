using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Distance
    {
        public double TimeA { get; set; }
        public double TimeB { get; set; }
        public double TimeC { get; set; }
        public double V = 1000000;

        public Distance() { }

        public Distance(double TimeA, double TimeB, double TimeC)
        {
            this.TimeA = TimeA;
            this.TimeB = TimeB;
            this.TimeC = TimeC;
        }

        public double[] GetDis()
        {
            var d1 = TimeA * V;
            var d2 = TimeB * V;
            var d3 = TimeC * V;
            double[] d = { d1, d2, d3 };
            return d;
        }
    }
}
