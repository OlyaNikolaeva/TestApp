using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class DynamicPoint
    {
        public double X0 { get; set; }
        public double Y0 { get; set; }

        public DynamicPoint() { }

        public DynamicPoint(double X0, double Y0)
        {
            this.X0 = X0;
            this.Y0 = Y0;
        }

        public double[] GetDynamic()
        {
            double[] vs = { X0, Y0 };
            return vs;
        }
    }
}
