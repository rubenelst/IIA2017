using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Opc.UaFx.Client;
using System.Data.SqlClient;
using System.Configuration;



namespace Datalogger
{
    public partial class Datalogger : Form
    {
        double PV;
        double SP;
        double u;
        double Kp;
        double Ti;
        double d;
        double z;

        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        public Datalogger()
        {
            InitializeComponent();

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OpcRead();
            TemperatureChart.Series["ProcessValue [°C]"].Points.AddY(PV);
            TemperatureChart.Series["SetPoint [°C]"].Points.AddY(SP);
            ControlValueChart.Series["ControlValue [V]"].Points.AddY(u);
            txtPV.Text = PV.ToString("0.##");
            txtSP.Text = SP.ToString("0.##");
            txtu.Text = u.ToString("0.##");
            DatabaseWrite();
        }

        private void OpcRead()
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
            var _PV = client.ReadNode(Tag1);
            var _SP = client.ReadNode(Tag2);
            var _u = client.ReadNode(Tag3);
            var _Kp = client.ReadNode(Tag4);
            var _Ti = client.ReadNode(Tag5);
            var _d = client.ReadNode(Tag6);
            var _z = client.ReadNode(Tag7);
            PV = Convert.ToDouble(_PV.Value);
            SP = Convert.ToDouble(_SP.Value);
            u = Convert.ToDouble(_u.Value);
            Kp = Convert.ToDouble(_Kp.Value);
            Ti = Convert.ToDouble(_Ti.Value);
            d = Convert.ToDouble(_d.Value);
            z = Convert.ToDouble(_z.Value);
            client.Disconnect();
        }

        public void DatabaseWrite()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("LogData", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TagName", "PV"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", PV));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "SP"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", SP));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "u"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", u));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "Kp"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", Kp));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "Ti"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", Ti));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "d"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", d));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TagName", "z"));
                    cmd.Parameters.Add(new SqlParameter("@TagValue", z));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Set interval on timer1 and start it
            timer1.Interval = Convert.ToInt32(100);
            timer1.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
