using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace JourneyJoy.Database
{
    //Code for Database Connection
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

        //Execution of SQL
        public static DataTable ExeSql(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

        public static DataSet ExecuteDataset(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = 666;
                        var ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }

        public DataRow ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }

        public object ParseColumnValue(DataRow row, string ColumnName)
        {
            if (row == null || string.IsNullOrEmpty(ColumnName))
                return null;
            else
            {
                if (row.Table.Columns.Contains(ColumnName))
                    return row[ColumnName];
                else
                    return null;
            }
        }

        public CommonModel ParseCommonDbResponse(string sql)
        {
            return ParseCommonDbResponse(ExecuteDataTable(sql));
        }

        public CommonModel ParseCommonDbResponse(DataTable dt)
        {
            var res = new CommonModel();
            if (dt != null)
                if (dt.Rows.Count > 0)
                {
                    string Code = dt.Rows[0][0].ToString();
                    string Message = dt.Rows[0][1].ToString();
                    string Extra1 = "", Extra2 = "", Extra3 = "";
                    if (dt.Columns.Count > 2)
                    {
                        Extra1 = dt.Rows[0][2].ToString();
                    }
                    if (dt.Columns.Count > 3)
                    {
                        Extra2 = dt.Rows[0][3].ToString();
                    }
                    if (dt.Columns.Count > 4)
                    {
                        Extra3 = dt.Rows[0][4].ToString();
                    }
                    res.SetMessages(Code, Message, Extra1, Extra2, Extra3, dt);
                    if (dt.Columns.Contains("id"))
                    {
                        res.ID = dt.Rows[0]["id"].ToString();
                    }
                }
            return res;
        }

        public String FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str.TrimEnd().TrimStart();
        }

        private String FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "''");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = str.Replace(" select ", "");
                str = str.Replace(" insert ", "");
                str = str.Replace(" update ", "");
                str = str.Replace(" delete ", "");

                str = str.Replace(" drop ", "");
                str = str.Replace(" truncate ", "");
                str = str.Replace(" create ", "");

                str = str.Replace(" begin ", "");
                str = str.Replace(" end ", "");
                str = str.Replace(" char(", "");

                str = str.Replace(" exec ", "");
                str = str.Replace(" xp_cmd ", "");

                str = str.Replace(" sp_help ", "");
                str = str.Replace(" sproc_ ", "");

                str = str.Replace("<script", "");
            }
            else
            {
                str = "null";
            }
            return str;
        }
    }
}