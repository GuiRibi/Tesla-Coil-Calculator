using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla_Coil_Calculator
{
    public class GraphCalc
    {
        public double V;
        public double T;
        public double DeltaT;
        public GraphCalc(double v, double t, double deltat)
        { 
            V = v;
            T = t;
            DeltaT = deltat;
        }

        //Capacitor Changing(Constant voltage)
        public void TimeWindow(double C, double I, double U1, double U2)
        {
            T = (U2 - U1) * C / I;
        }

        public void Capacitor_Charging(double C, double I, double U1, double t)
        {
            DeltaT = t;
            V = U1 + (t * I / C);
        }
    }
}
