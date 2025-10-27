using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionToy"].ConnectionString;
            Console.WriteLine("Создана строка подключения!");
            string selectString = "select * from Tovar";
            Console.WriteLine("Создана строка СЕЛЕКТА!");
            conn = new SqlConnection(connString);

            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                Console.WriteLine("Подключение открыто!");

                cmd = new SqlCommand(selectString, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr[0]}\t|\t");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex}");
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }*/
            SqlConnection conn = null;
            SqlCommandBuilder cmd = null;
            SqlDataAdapter adapter = null;
            DataSet dataSet = null;
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionToy"].ConnectionString;
            string selectString = "select * from Tovar";


            try
            {
                dataSet = new DataSet();
                adapter = new SqlDataAdapter(selectString, connString);
                cmd = new SqlCommandBuilder(adapter);
                adapter.Fill(dataSet, "Stud");
                
                for (int i = 0; i < dataSet.Tables["Stud"].Columns.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables["Stud"].Rows.Count; j++)
                    {
                        Console.WriteLine($"{dataSet.Tables[j]}")
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex}");
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }
        }
    }
}
