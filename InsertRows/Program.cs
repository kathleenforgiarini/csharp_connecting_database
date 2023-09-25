using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsertRows
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

            try
            {
                cmd.Transaction = con.BeginTransaction();
                cmd.CommandText = "INSERT INTO COMPANY (ID, NAME, AGE, ADDRESS, SALARY) " +
                    "VALUES (2, 'Allen', 25, 'Texas', 15000.00)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO COMPANY (ID, NAME, AGE, ADDRESS, SALARY) " +
                    "VALUES (1, 'Paul', 32, 'California', 20000.00 )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO COMPANY (ID, NAME, AGE, ADDRESS, SALARY) " +
                    "VALUES (3, 'Teddy', 23, 'Norway', 20000.00 )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO COMPANY (ID, NAME, AGE, ADDRESS, SALARY) " +
                    "VALUES (4, 'Mark', 25, 'Richmond', 65000.00 )";
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();
                Console.WriteLine("Data successfully inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine("Data not inserted");
                Console.WriteLine(e.Message);
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
