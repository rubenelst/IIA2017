namespace Control_System.Classes
{
    public class Filter
    {
        public double yk; // Previous y
        public double T_s = 0.01; // Sampling time
        public double T_f = 0.2; // Period time (s)
        public double LowPassFilter(double yFromDaq)
        {
            double a;
            double yFiltered;
            a = T_s / (T_s + T_f);
            yFiltered = (1 - a) * yk + a * yFromDaq;
            yk = yFiltered;
            return yFiltered;
        }
    }
}
