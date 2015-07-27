using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace DBAccess
{
    public class DBAccess : IDisposable
    {
        #region IDisposable Members
        private SqlConnection adoSqlCon;

        public DBAccess()
        {
            try
            {
                string ConnectionString = ConfigurationSettings.AppSettings["DBConnectionString"].ToString();
                adoSqlCon = new SqlConnection(ConnectionString);
                adoSqlCon.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Upload(string excelConString, string query, string tblName)
        {
            using (OleDbConnection connection =
                         new OleDbConnection(excelConString))
            {
                OleDbCommand command = new OleDbCommand
                        (query, connection);

                connection.Open();

                // Create DbDataReader to Data Worksheet 
                using (DbDataReader dr = command.ExecuteReader())
                {
                    // Bulk Copy to SQL Server 
                    using (SqlBulkCopy bulkCopy =
                               new SqlBulkCopy(adoSqlCon))
                    {
                        bulkCopy.DestinationTableName = tblName;
                        bulkCopy.BulkCopyTimeout = 3600;
                        bulkCopy.WriteToServer(dr);
                    }
                }
            }
        }

        public void BulkCopy(DbDataReader dr, string tblName, int startCol)
        {
            using (SqlBulkCopy bulkCopy =
                                   new SqlBulkCopy(adoSqlCon))
            {
                bulkCopy.DestinationTableName = tblName;
                while (startCol > 0)
                {
                    dr.Read();
                    startCol--;
                }
                bulkCopy.BulkCopyTimeout = 3600;
                bulkCopy.WriteToServer(dr);
            }
        }

        public SqlDataReader ExecuteReader(string SpName, string[,] Param)
        {
            SqlCommand sqlCmd = new SqlCommand(SpName, adoSqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < (Param.Length / 2); i++)
            {
                sqlCmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
            }
            sqlCmd.CommandTimeout = 3600;
            return sqlCmd.ExecuteReader();
        }

        public string ExecuteScalar(string SpName, string[,] Param)
        {
            SqlCommand sqlCmd = new SqlCommand(SpName, adoSqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction sqlTrn;
            sqlTrn = adoSqlCon.BeginTransaction(IsolationLevel.ReadCommitted, "adoTransaction");
            sqlCmd.Transaction = sqlTrn;

            try
            {
                for (int i = 0; i < (Param.Length / 2); i++)
                {
                    sqlCmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
                }

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch
            {
                sqlTrn.Rollback("adoTransaction");
                return false.ToString();
            }
        }

        public string ExecuteScalarReturnScript(string SpName, string[,] Param)
        {
            SqlCommand sqlCmd = new SqlCommand(SpName, adoSqlCon);
            sqlCmd.CommandType = CommandType.Text;
            SqlTransaction sqlTrn;
            sqlTrn = adoSqlCon.BeginTransaction(IsolationLevel.ReadCommitted, "adoTransaction");
            sqlCmd.Transaction = sqlTrn;

            try
            {
                for (int i = 0; i < (Param.Length / 2); i++)
                {
                    sqlCmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
                }

                return sqlCmd.ExecuteScalar().ToString();
            }
            catch
            {
                sqlTrn.Rollback("adoTransaction");
                return false.ToString();
            }
        }

        public bool ExecuteNonQuery(string groupQuery)
        {
            string[,] Param = { { } };
            return ExecuteNonQuery(string.Empty, Param, groupQuery);
        }

        public bool ExecuteNonQuery(string SpName, string[,] Param)
        {
            return ExecuteNonQuery(SpName, Param, string.Empty);
        }

        public bool ExecuteNonQuery(string SpName, string[,] Param, string groupQuery)
        {
            SqlCommand sqlCmd = new SqlCommand(SpName, adoSqlCon);

            if (string.IsNullOrEmpty(groupQuery))
            {
                sqlCmd.CommandTimeout = 3600;
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            SqlTransaction sqlTrn;
            sqlTrn = adoSqlCon.BeginTransaction(IsolationLevel.ReadCommitted, "adoTransaction");
            sqlCmd.Transaction = sqlTrn;

            try
            {
                if (string.IsNullOrEmpty(groupQuery))
                {
                    for (int i = 0; i < (Param.Length / 2); i++)
                    {
                        sqlCmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
                    }
                }
                sqlCmd.ExecuteNonQuery();
                sqlTrn.Commit();
                return true;
            }
            catch
            {
                sqlTrn.Rollback("adoTransaction");
                return false;
            }
        }

        public void ExecuteNonQueryList(List<string> list)
        {
            foreach (string str in list)
            {
                SqlCommand sqlCmd = new SqlCommand(str, adoSqlCon);
                sqlCmd.CommandType = CommandType.Text;
                SqlTransaction sqlTrn;
                sqlTrn = adoSqlCon.BeginTransaction(IsolationLevel.ReadCommitted, "adoTransaction");
                sqlCmd.Transaction = sqlTrn;

                try
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlTrn.Commit();
                }
                catch
                {
                    sqlTrn.Rollback("adoTransaction");
                }
            }
        }

        public void Dispose()
        {
            adoSqlCon.Close();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
