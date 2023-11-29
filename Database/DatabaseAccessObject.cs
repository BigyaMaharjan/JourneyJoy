using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JourneyJoy.Database
{
    public class DatabaseAccessObject
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception exe)
                {
                    throw exe;
                }
            }
            return con;
        }

        public static DataTable ExeSql(string sql)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = 666;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}