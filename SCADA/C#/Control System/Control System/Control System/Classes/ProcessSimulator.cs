using System;

namespace Control_System.Classes
{
    public class ProcessSimulator
    {
        public double Theta_t = 22;
        public double K_h = 3.35;
        public double T_env = 24;
        public double T_s = 0.1;
        double[] u_d = new double[21];

        public double Simulation(double u, double T_out)
        {

            for (int i = 1; i < u_d.Length; i++)
            {
                u_d[i - 1] = u_d[i];
            }
            u_d[20] = u;
            double T_out1 = T_out + T_s*(-T_out + (K_h * u_d[0] + T_env)) / Theta_t;
            return T_out1;
        }
    }
}
