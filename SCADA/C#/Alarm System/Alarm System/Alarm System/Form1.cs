using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using Alarm_System.Classes;
using System.Data.SqlClient;
using System.Drawing;

namespace Alarm_System
{
    public partial class AlarmSystem : Form
    {
        ReadDatabase rd = new ReadDatabase();
        public AlarmSystem()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var GraphDataList = ReadDatabase.GetGraphData();
            gridGraphDataList.DataSource = GraphDataList;
            DataGridViewColumn column = gridGraphDataList.Columns[0];
            column.Width = 60;
            column = gridGraphDataList.Columns[1];
            column.Width = 50;
            column = gridGraphDataList.Columns[2];
            column.Width = 90;
            column = gridGraphDataList.Columns[3];
            column.Width = 280;
            column = gridGraphDataList.Columns[4];
            column.Width = 60;
            column = gridGraphDataList.Columns[5];
            column.Width = 60;
            column = gridGraphDataList.Columns[6];
            column.Width = 60;
        }
        public void AckAlarm(int i)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AckAlarm", con);
                    ReadDatabase db = new ReadDatabase();
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AlarmId", i));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void gridGraphDataList_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex==4 && e.Value != null)
            {
                int severity = Convert.ToInt32(e.Value);
                switch (severity)
                {
                    case 1:
                    e.CellStyle.BackColor = Color.Yellow;
                        break;
                    case 2:
                    e.CellStyle.BackColor = Color.Orange;
                        break;
                    case 3:
                    e.CellStyle.BackColor = Color.Red;
                        break;
                }
            }
        }

        private void ack1_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(0));
        }

        private void ack2_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(1));
        }

        private void ack3_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(2));
        }

        private void ack4_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(3));
        }

        private void ack5_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(4));
        }

        private void ack6_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(5));
        }

        private void ack7_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(6));
        }

        private void ack8_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(7));
        }

        private void ack9_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(8));
        }

        private void ack10_Click(object sender, EventArgs e)
        {
            AckAlarm(rd.GetAlarmId(9));
        }
    }
}
