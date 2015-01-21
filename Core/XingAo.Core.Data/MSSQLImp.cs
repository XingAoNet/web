using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace XingAo.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class MSSQLImp
    {
        /// <summary>
        /// SQL 特殊字符过滤,防SQL注入
        /// </summary>
        /// <param name="Contents"></param>
        /// <returns></returns>
        public static string SqlFilter(string Contents)
        {
            string _pattern = "exec|insert|select|delete|'|update|chr|mid|master|truncate|char|declare|and|--";
            if (Regex.IsMatch(Contents.ToLower(), _pattern, RegexOptions.IgnoreCase))
            {
                Contents = Regex.Replace(Contents.ToLower(), _pattern, " ", RegexOptions.IgnoreCase);
            }
            return Contents;
        }

        private static string connstr = ConfigOption.GetConfigString("ConnectionString");

        
        public static int ExecSQL(string _sql)
        {
            return ExecSQL(connstr, _sql);
        }

        public static int ExecSQL(string _conn,string _sql)
        {
            SqlConnection conn = new SqlConnection(_conn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = _sql;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static  DataTable GetTable(string _sql)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataAdapter apt = new SqlDataAdapter(_sql, conn);
                DataTable dt = new DataTable();
                apt.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet GetList(int PageSize, int PageIndex, bool IsReCount, bool OrderType, string strWhere, string tableName,string showColounm)
        {
            SqlParameter[] parameters = {              
            new SqlParameter("@PageSize", SqlDbType.Int),
            new SqlParameter("@PageIndex", SqlDbType.Int),
            new SqlParameter("@IsReCount", SqlDbType.Bit),
             new SqlParameter("@strWhere", SqlDbType.VarChar,1000), 
            new SqlParameter("@OrderType", SqlDbType.Bit),             
            new SqlParameter("@tblName", SqlDbType.VarChar,255),  
            new SqlParameter("@fldName", SqlDbType.VarChar,255),
            };
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = IsReCount?1:0;
            parameters[3].Value = strWhere;
            parameters[4].Value = OrderType?1:0;
            parameters[5].Value = tableName;
            parameters[6].Value = showColounm;
            return RunProcedure("UP_GetRecordByPage", parameters);
        }

        public static DataSet RunProcedure(string ProcedureName, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ProcedureName;
                cmd.Parameters.Clear();
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                        cmd.Parameters.Add(param);
                }

               
                SqlDataAdapter apt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                apt.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
