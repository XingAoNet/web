using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XingAo.Networks.CMS.DbHelper;

namespace XingAo.Networks.CMS.Imp
{
    public class ScratchCardImp
    {
        public static string CreateScratchCard(string Guid,string openid, string name, string tel)
        {
            SqlParameter[] parameters = { 
                     new SqlParameter("@ScratchCardID", SqlDbType.VarChar,50),
                     new SqlParameter("@WeiXingID",SqlDbType.VarChar,80),
                     new SqlParameter("@Name",SqlDbType.VarChar,50),
                     new SqlParameter("@Tel",SqlDbType.VarChar,50)};
            parameters[0].Value = Guid;
            parameters[1].Value = openid;
            parameters[2].Value = name;
            parameters[3].Value = tel;
            DataSet ds = MSSQLImp.RunProcedure("CreateScratchCard", parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return string.Empty;
        }
    }
}
