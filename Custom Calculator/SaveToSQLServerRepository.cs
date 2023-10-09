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

        //public object RtBoxDisplayHistory { get; private set; }

        public void SaveHistory(string text) // prouci sql injection i videces zasto ovo nije dobra praksa, POPORAVI!!
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlTxt = "INSERT INTO History(Logs) VALUES ('" + text + "')";
            SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);

            //cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
    }
}
