using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using Control_System.Classes;
using System.Drawing;
using Opc.UaFx.Client;

namespace Control_System
{
    public partial class Form1 : Form
    {
        // Create objects to access content in the relevant classes
        PidController pid = new PidController();
        RealProcess proc = new RealProcess();
        Filter flt = new Filter();
        ProcessSimulator sim = new ProcessSimulator();

        double T_out = 26;
        double T_out1;

        public Form1()
        {
            InitializeComponent();

            // Fill textboxes with content from pid
            txtKp.Text = pid.Kp.ToString(); 
            txtTi.Text = pid.Ti.ToString();
            txtR.Text = pid.r.ToString();

            // Initialize TemperatureChart
            TemperatureChart.Series.Clear();
            TemperatureChart.Series.Add("ProcessValue [°C]");
            TemperatureChart.Series.Add("SetPoint [°C]");
            TemperatureChart.Series["ProcessValue [°C]"].ChartType = SeriesChartType.Spline;
            TemperatureChart.Series["ProcessValue [°C]"].Color = Color.DarkCyan;
            TemperatureChart.Series["ProcessValue [°C]"].BorderWidth = 2;            
            TemperatureChart.Series["SetPoint [°C]"].ChartType = SeriesChartType.Spline;
            TemperatureChart.Series["SetPoint [°C]"].Color = Color.LightBlue;
            TemperatureChart.Series["SetPoint [°C]"].BorderWidth = 2;
            ChartArea area1 = TemperatureChart.ChartAreas[0];
            area1.AxisY.Minimum = 20;
            area1.AxisY.Maximum = 40;

            // Initialize ControlValueChart
            ControlValueChart.Series.Clear();
            ControlValueChart.Series.Add("ControlValue [V]");
            ControlValueChart.Series["ControlValue [V]"].ChartType = SeriesChartType.Spline;
            ControlValueChart.Series["ControlValue [V]"].Color = Color.Magenta;
            ControlValueChart.Series["ControlValue [V]"].BorderWidth = 2;
            ChartArea area2 = ControlValueChart.ChartAreas[0];
            area2.AxisY.Minimum = 0;
            area2.AxisY.Maximum = 5;

            // Initialize ZChart
            ZChart.Series.Clear();
            ZChart.Series.Add("ZValue");
            ZChart.Series["ZValue"].ChartType = SeriesChartType.Spline;
            ZChart.Series["ZValue"].Color = Color.Blue;
            ZChart.Series["ZValue"].BorderWidth = 2;
            ChartArea area3 = ZChart.ChartAreas[0];
            area3.AxisY.Minimum = -35;
            area3.AxisY.Maximum = 35;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (SimulationToggle.Checked)
            {
                case true:
                    pid.u = pid.Control(T_out);
                    T_out1 = sim.Simulation(pid.u, T_out);
                    T_out = T_out1;

                    output.Text = T_out1.ToString("0.##");
                    input.Text = pid.u.ToString("0.##");
                    TemperatureChart.Series["ProcessValue [°C]"].Points.AddY(T_out1);
                    TemperatureChart.Series["SetPoint [°C]"].Points.AddY(pid.r);
                    ControlValueChart.Series["ControlValue [V]"].Points.AddY(pid.u);
                    ZChart.Series["ZValue"].Points.AddY(pid.z);
                    OpcWrite(T_out, pid.r, pid.u);
                    break;

                case false:
                    proc.T_out = flt.LowPassFilter(proc.T_out);
                    pid.u = pid.Control(proc.T_out);
                    proc.ControlProcess(pid.u);
                    proc.T_out = proc.ReadProcess();

                    output.Text = proc.T_out.ToString("0.##");
                    input.Text = pid.u.ToString("0.##");
                    TemperatureChart.Series["ProcessValue [°C]"].Points.AddY(proc.T_out);
                    TemperatureChart.Series["SetPoint [°C]"].Points.AddY(pid.r);
                    ControlValueChart.Series["ControlValue [V]"].Points.AddY(pid.u);
                    ZChart.Series["ZValue"].Points.AddY(pid.z);
                    OpcWrite(T_out, pid.r, pid.u);
                    break;
            }
        }

        // Necessary unknown method for the form
        private void Form1_Load(object sender, EventArgs e){}

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (SimulationToggle.Checked == false)
            {
                proc.ControlProcess(0);
            }
            this.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Set interval on timer1 and start it
            timer1.Interval = Convert.ToInt32(100);
            timer1.Start();
        }

        private void OpcWrite(double PV, double SP, double u)
        {
            string opcUrl = "opc.tcp://localhost:62640/";
            var Tag1 = "ns=2;s=PV";
            var Tag2 = "ns=2;s=SP";
            var Tag3 = "ns=2;s=u";
            var Tag4 = "ns=2;s=Kp";
            var Tag5 = "ns=2;s=Ti";
            var Tag6 = "ns=2;s=d";
            var Tag7 = "ns=2;s=z";
            var client = new OpcClient(opcUrl);
            client.Connect();
            client.WriteNode(Tag1, PV);
            client.WriteNode(Tag2, SP);
            client.WriteNode(Tag3, u);
            client.WriteNode(Tag4, pid.Kp);
            client.WriteNode(Tag5, pid.Ti);
            client.WriteNode(Tag6, pid.d);
            client.WriteNode(Tag7, pid.z);
            client.Disconnect();
        }

        // Apply PID parameters in text boxes
        private void ApplyPidParams_Click(object sender, EventArgs e)
        {
            pid.Kp = Convert.ToDouble(txtKp.Text);
            pid.Ti = Convert.ToDouble(txtTi.Text); 
            pid.r = Convert.ToDouble(txtR.Text); 
        }
    }
}
