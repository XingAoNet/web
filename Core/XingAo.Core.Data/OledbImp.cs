using System;
using System.Data;
using System.Data.OleDb;

namespace XingAo.Core.Data
{
    public class OledbImp
    {
        public static DataTable GetTable(string dbPath, string TableName)
        {
            return GetTable(dbPath, TableName,0);
        }

        public static DataTable GetTable(string dbPath, string TableName, int Num)
        {
            string selectSQL = "SELECT @top * FROM [" + TableName + "$]";
            if (Num > 0)
                selectSQL = selectSQL.Replace("@top", "top " + Num);
            else
                selectSQL = selectSQL.Replace("@top", "");
            return GetTableForSQL(dbPath,selectSQL);
        }

        public static DataTable GetTableForSQL(string dbPath, string SQL)
        {
            #region Microsoft.Jet.OLEDB.4.0
            string excelPath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            OleDbConnection myConn = new OleDbConnection(excelPath);
            DataTable thisDataSet = new DataTable();
            try
            {
                myConn.Open();
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(SQL, myConn);
                thisAdapter.Fill(thisDataSet);
                myConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
            return thisDataSet;
            #endregion
        }

    }
}
