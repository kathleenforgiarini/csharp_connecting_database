using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTables
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
            con.ConnectionString= cs.ConnectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "CREATE TABLE COMPANY" +
                "(ID        INT     PRIMARY KEY     NOT NULL," +
                " NAME      VARCHAR(50)             NOT NULL," +
                " AGE       INT                     NOT NULL," +
                " ADDRESS   VARCHAR(100)," +
                " SALARY    REAL)";

            try
            {
                cmd.ExecuteNonQuery(); // cmd.ExecuteReader for selects, anything else we use NonQuery
                Console.WriteLine("Tables successfully created");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tables not created");
                Console.WriteLine(ex.Message);
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
