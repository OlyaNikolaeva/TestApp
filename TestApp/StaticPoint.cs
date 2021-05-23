using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class StaticPoint
    {
        public int N { get; set; }
        public double X1, Y1, X2, Y2, X3, Y3;

        public StaticPoint() { }

        public StaticPoint(int N, double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            this.N = N;
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
            this.X3 = X3;
            this.Y3 = Y3;
        }

    }
}
