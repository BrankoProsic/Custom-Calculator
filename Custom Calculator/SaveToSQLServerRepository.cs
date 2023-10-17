using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Custom_Calculator
{
    public class SaveToSQLServerRepository : IRepository
    {
        public string connStr = ConfigurationManager.ConnectionStrings["CustomCalculatorString"].ConnectionString;

        public void SaveHistory(string text) 
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlTxt = "INSERT INTO DateHistory(Date, Logs) VALUES (@Date, @Logs)";
                SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);
                cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@Logs", text);

                cmdInsert.ExecuteNonQuery();
            }
            #region catch
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion catch
            finally
            {
                conn.Close();
            }
        }
    }
}
