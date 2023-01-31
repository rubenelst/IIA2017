namespace Control_System.Classes
{
    public class PidController
    {
        public double Kp = 0.8; // Gain
        public double Ti = 3; // Integral time (s)
        public double r = 32; // setpoint (reference value)
        public double z = 10; // Help value "z" related to integral time
        public double d = 0;
        public double u = 1; // Control value
        public double T_s = 0.01; // Sampling time (s)


        public double Control(double y)
        {
            // Main calculations
            double uk;
            double e = r - y;
            uk = Kp * e + (Kp / Ti) * z;
            z += T_s * e;

            // Limit uk between 0 and 5 (volts)
            if (uk > 5)
            {
                uk = 5;
            }
            else if (uk < 0)
            {
                uk = 0;
            }

            // Anti windup for z
            if (z > 20)
            {
                z = 20;
            }
            else if (z < -5)
            {
                z = -5;
            }


            return uk;
        }
    }
}
