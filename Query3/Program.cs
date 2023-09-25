using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Query3
{
    internal class Program
    {
        public static class Connection
        {
            private static String singleton = null;
            public static String GetConnString()
            {
                if (singleton == null)
                {
                    SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                    cs.DataSource = "(local)";
                    cs.InitialCatalog = "EMP";
                    cs.UserID = "sa";
                    cs.Password = "sysadm";
                    singleton = cs.ConnectionString;
                }
                return singleton;
            }
        }
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Connection.GetConnString();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM COMPANY";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id = {0}; Name = {1}", reader.GetInt32(0), reader.GetString(1));
                Console.WriteLine("Age = {0}", reader.GetInt32(2));
                Console.WriteLine("Address = {0}", reader.GetString(3));
                Console.WriteLine("Salary = {0:F2}", reader.GetFloat(4));
                Console.WriteLine("Salary = {0:N2}", reader.GetFloat(4));
                Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("F2"));
                Console.WriteLine("Salary = {0}", reader.GetFloat(4).ToString("N2"));
                Console.WriteLine();

            }
            reader.Close();

            con.Close();
            Console.ReadKey();
        }
    }
}
