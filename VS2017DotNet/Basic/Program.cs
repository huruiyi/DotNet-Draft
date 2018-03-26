using System;
using System.Data;
using System.Data.SqlClient;

namespace Basic
{
    internal class Program
    {
        public static void StoredProcedureDemo()
        {
            string conString = "Data Source=.;Initial Catalog=Demo;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string cmdText = "pro_GetLast";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int);
                    parameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameter);
                    cmd.CommandType = CommandType.StoredProcedure;
                    object result = cmd.ExecuteNonQuery();
                    Console.WriteLine(result + "  " + parameter.SqlValue);
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}