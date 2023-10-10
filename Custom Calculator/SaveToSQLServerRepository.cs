using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Calculator
{
    public class SaveToSQLServerRepository : IRepository
    {
        // ovde ide impelemntacija koju si gurnuo u formu, onako grubo :D
        public string connStr = ConfigurationManager.ConnectionStrings["CustomCalculatorString"].ConnectionString;

        //public void SaveHistory(string text) // prouci sql injection i videces zasto ovo nije dobra praksa, POPORAVI!!
        //{
        //    SqlConnection conn = new SqlConnection(connStr);
        //    conn.Open();

        //    string sqlTxt = "INSERT INTO History(Logs) VALUES ('" + text + "')";
        //    SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);

        //    cmdInsert.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public void SaveHistory(string text) //PARAMETARISED QUERIE!
        //{
        //    SqlConnection conn = new SqlConnection(connStr);
        //    conn.Open();

        //    string sqlTxt = "INSERT INTO History(Logs) VALUES (@Logs)";
        //    SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);
        //    cmdInsert.Parameters.AddWithValue("@Logs", text);

        //    cmdInsert.ExecuteNonQuery();
        //    conn.Close();
        //    //Proverio i radi
        //}

        public void SaveHistory(string text) //STORED PROCEDURE
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlTxt = "calculatorLogs";
            SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@Logs", text);

            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
    }
}
