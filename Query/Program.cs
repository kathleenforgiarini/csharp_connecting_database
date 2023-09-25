using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "sa";
            cs.Password = "sysadm";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;
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

            Console.WriteLine("==============================================");
            Console.WriteLine();

            cmd.CommandText = "SELECT ID, NAME, AGE FROM COMPANY WHERE AGE > 30";
            reader = cmd.ExecuteReader();
            while(reader.Read()){
                Console.WriteLine("Id = {0}; Name = {1}", reader.GetInt32(0), reader.GetString(1));
                Console.WriteLine("Age = {0}", reader.GetInt32(2));
                Console.WriteLine();
            }
            reader.Close();


            Console.WriteLine("==============================================");
            Console.WriteLine();

            cmd.CommandText = "SELECT * FROM COMPANY";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id = {0}; Name = {1}", (int)reader["ID"], (string)reader["Name"]);
                Console.WriteLine("Age = {0}", (int)reader["Age"]);
                Console.WriteLine("Address = {0}", (string)reader["Address"]);
                Console.WriteLine("Salary = {0:F2}", (float)reader["Salary"]);
                Console.WriteLine("Salary = {0:N2}", (float)reader["Salary"]);
                Console.WriteLine("Salary = {0}", ((float)reader["Salary"]).ToString("F2"));
                Console.WriteLine("Salary = {0}", ((float)reader["Salary"]).ToString("N2"));
                Console.WriteLine();
            }
            reader.Close();

            con.Close();
            Console.ReadKey();
        }
    }
}
