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

        //Capacitor Changing(Constant Current)
        public void TimeWindow(double C, double I, double U1, double U2)
        {
            T = (U2 - U1) * C / I;
        }

        public void Capacitor_Charging(double C, double I, double U1, double t)
        {
            DeltaT = t;
            V = U1 + (t * I / C);
        }

        //Capacitor Discharging (Constant Current)
        public void Capacitor_Discharging(double C, double I, double U1, double t)
        {
            DeltaT = t;
            V = U1 + (t * (-I) / C);
        }

        //Capacitor Resistive Discharging (Constant Resistance)
        public void TimeWindow_RC(double C, double R, double U1, double U2)
        {
            T = R * C * Math.Log(U1 / U2);
        }

        public void Resistive_Discharging(double C, double R, double U1, double t)
        {
            DeltaT = t;
            V = U1 / Math.Pow(Math.E, (t / (R * C)));
        }
    }
}
