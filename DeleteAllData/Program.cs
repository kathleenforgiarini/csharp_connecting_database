using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DeleteAllData
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
            cmd.CommandText = "DELETE from COMPANY";

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("All data successfully deleted");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not deleted");
                Console.WriteLine(ex.Message);
            }
            con.Close();
            Console.ReadKey();
        }
    }
}
