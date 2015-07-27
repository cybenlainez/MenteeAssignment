using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBAccess;

namespace DL
{
    public class DLTransactions
    {
        #region Retrieve Data
        public DataTable getAllTransaction(string strWhere, string strOrderBy)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                if (strOrderBy == "") { strOrderBy = " ORDER BY Transaction_ID"; }

                string[,] param =   {
                                        { "@strWhere", strWhere },
                                        { "@strOrderBy", strOrderBy }
                                    };
                using (SqlDataReader rdr = db.ExecuteReader("sprSelectAllTransaction", param))
                {
                    DataTable DT = new DataTable();
                    DT.Load(rdr);
                    return DT;
                }
            }
        }
        public ModelTransactions getTransactionByID(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param = { { "@Transaction_ID", ID } };
                using (SqlDataReader rdr = db.ExecuteReader("sprSelectTransactionByID", param))
                {
                    ModelTransactions item = new ModelTransactions();
                    while (rdr.Read())
                    {
                        item.Transaction_ID = Convert.ToInt32(rdr["Transaction_ID"]);
                        item.Date = Convert.ToDateTime(rdr["Date"]);
                        item.Customer_ID = rdr["Customer_ID"].ToString();
                    }
                    return item;
                }
            }
        }
        public int updateFlag(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param = { { "@Transaction_ID", ID } };
                int UpdateFlag = Convert.ToInt32(db.ExecuteScalar("sprTransactionFlag", param));
                return UpdateFlag;
            }
        }
        public string getHeader(string lbl, string txt)
        {
            string scriptWhere = "";

            if (lbl == "Search by transaction ID")
                scriptWhere = " WHERE Transaction_ID LIKE '%" + txt + "%'";
            else if (lbl == "Search by date")
                scriptWhere = " WHERE Date LIKE '%" + txt + "%'";
            else if (lbl == "Search by customer ID")
                scriptWhere = " WHERE Customer_ID LIKE '%" + txt + "%'";

            return scriptWhere;
        }
        public string getSort(string lbl, string SortDirection)
        {
            string scriptOrderBy = "";

            if (lbl == "Search by transaction ID")
                scriptOrderBy = " Transaction_ID" + SortDirection;
            else if (lbl == "Search by date")
                scriptOrderBy = " Date" + SortDirection;
            else if (lbl == "Search by customer ID")
                scriptOrderBy = " Customer_ID" + SortDirection;

            return scriptOrderBy;
        }
        #endregion

        #region Data Manipulation
        public void add(ModelTransactions MT)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@Date", MT.Date.ToString()},
                                        {"@Customer_ID", MT.Customer_ID}
                                    };
                db.ExecuteNonQuery("sprInsertTransaction", param);
            }
        }
        public void update(ModelTransactions MT)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@Transaction_ID", MT.Transaction_ID.ToString()},
                                        {"@Date", MT.Date.ToString()},
                                        {"@Customer_ID", MT.Customer_ID}
                                    };
                db.ExecuteNonQuery("sprUpdateTransaction", param);
            }
        }
        public void delete(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@Transaction_ID", ID}
                                    };
                db.ExecuteNonQuery("sprDeleteTransaction", param);
            }
        }
        #endregion

        #region IDisposable
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: free managed resources when explicitly called
                }

                // TODO: free shared unmanaged resources
            }
            this.disposedValue = true;
        }
        #region " IDisposable Support "
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
