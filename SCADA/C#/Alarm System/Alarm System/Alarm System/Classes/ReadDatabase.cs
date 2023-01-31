using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Alarm_System.Classes
{
    class ReadDatabase
    {
        public int AlarmId {get; set;}
        public int TagId {get; set;}
        public string AlarmName {get; set;}
        public string AlarmDescription {get; set;}
        public int Severity {get; set;}
        public int AckStatus {get; set;}
        public string Ack {get; set;}

        public int GetAlarmId(int i)
        {
            try
            {
                int _AlarmId;
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sqlQuery = "SELECT TOP(1) AlarmId FROM ALARM WHERE AckStatus = 0 ORDER BY AlarmId DESC";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                _AlarmId = Convert.ToInt32(rd[0])-i;
                con.Close();
                return _AlarmId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ReadDatabase> GetGraphData()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                var GraphDataList = new List<ReadDatabase>();
                SqlConnection con = new SqlConnection(connectionString);
                string sqlQuery = "SELECT TOP(10) * FROM ALARM WHERE AckStatus = 0 ORDER BY AlarmId DESC";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                var dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        var ReadDatabase = new ReadDatabase();
                        ReadDatabase.AlarmId = Convert.ToInt32(dr["AlarmId"]);
                        ReadDatabase.TagId = Convert.ToInt32(dr["TagId"]);
                        ReadDatabase.AlarmName = Convert.ToString(dr["AlarmName"]);
                        ReadDatabase.AlarmDescription = Convert.ToString(dr["AlarmDescription"]);
                        ReadDatabase.Severity = Convert.ToInt32(dr["Severity"]);
                        ReadDatabase.AckStatus = Convert.ToInt32(dr["AckStatus"]);
                        ReadDatabase.Ack = "";
                        GraphDataList.Add(ReadDatabase);
                    }
                }
                con.Close();
                return GraphDataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
