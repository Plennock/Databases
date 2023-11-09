using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Client1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=users;port=3306;password=L3tM31n ";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL--- users database");
                conn.Open();
                /* Perform database operations
                string sql = "INSERT INTO User VALUES ('heb57', 'pass', 'killian', 'Mr', '260296', 'Office')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                */

                string sql = "SELECT Surname FROM User WHERE Title = 'Mr'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();//results have been obtained in a MySqlReader object and can be processed
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
                rdr.Close();

                sql = "SELECT COUNT(*) FROM User";
                cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of users in the database is: " +
                    r);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close(); // close the connection
            Console.WriteLine("Done the job");
            Console.ReadLine();
        }
    }
}
