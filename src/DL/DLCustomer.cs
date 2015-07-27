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
    public class DLCustomer
    {
        #region Retrieve Data
        public DataTable getAllCustomer(string strWhere, string strOrderBy)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                if (strOrderBy == "") { strOrderBy = " ORDER BY Id"; }

                string[,] param =   {
                                        { "@strWhere", strWhere },
                                        { "@strOrderBy", strOrderBy }
                                    };
                using (SqlDataReader rdr = db.ExecuteReader("sprSelectAllCustomer", param))
                {
                    DataTable DT = new DataTable();
                    DT.Load(rdr);
                    return DT;
                }
            }
        }
        public ModelCustomer getCustomerByID(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param = { { "@Id", ID } };
                using (SqlDataReader rdr = db.ExecuteReader("sprSelectCustomerByID", param))
                {
                    ModelCustomer item = new ModelCustomer();
                    while (rdr.Read())
                    {
                        item.Id = Convert.ToInt32(rdr["Id"]);
                        item.Name = rdr["Name"].ToString();
                        item.Address = rdr["Address"].ToString();
                    }
                    return item;
                }
            }
        }
        public int updateFlag(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param = { { "@ID", ID } };
                int UpdateFlag = Convert.ToInt32(db.ExecuteScalar("sprCustomerFlag", param));
                return UpdateFlag;
            }
        }
        public string getHeader(string lbl, string txt)
        {
            string scriptWhere = "";

            if (lbl == "Search by ID")
                scriptWhere = " WHERE Id LIKE '%" + txt + "%'";
            else if (lbl == "Search by name")
                scriptWhere = " WHERE name LIKE '%" + txt + "%'";
            else if (lbl == "Search by address")
                scriptWhere = " WHERE address LIKE '%" + txt + "%'";

            return scriptWhere;
        }
        public string getSort(string lbl, string SortDirection)
        {
            string scriptOrderBy = "";

            if (lbl == "Search by ID")
                scriptOrderBy = " Id" + SortDirection;
            else if (lbl == "Search by name")
                scriptOrderBy = " name" + SortDirection;
            else if (lbl == "Search by address")
                scriptOrderBy = " address" + SortDirection;

            return scriptOrderBy;
        }
        #endregion

        #region Data Manipulation
        public void add(ModelCustomer MC)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@NAME", MC.Name},
                                        {"@ADDRESS", MC.Address}
                                    };
                db.ExecuteNonQuery("sprInsertCustomer", param);
            }
        }
        public void update(ModelCustomer MC)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@ID", MC.Id.ToString()},
                                        {"@NAME", MC.Name},
                                        {"@ADDRESS", MC.Address}
                                    };
                db.ExecuteNonQuery("sprUpdateCustomer", param);
            }
        }
        public void delete(string ID)
        {
            using (DBAccess.DBAccess db = new DBAccess.DBAccess())
            {
                string[,] param =   {
                                        {"@ID", ID}
                                    };
                db.ExecuteNonQuery("sprDeleteCustomer", param);
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
