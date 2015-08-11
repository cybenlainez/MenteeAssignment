using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml.Linq;
using Model;
using DL;
using System.Web.Services;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFTransactions" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFTransactions.svc or WCFTransactions.svc.cs at the Solution Explorer and start debugging.
    public class WCFTransactions : IWCFTransactions
    {
        #region Retrieve Data
        public DataTable getAllTransaction(string strWhere, string strOrderBy)
        {
            return new DLTransactions().getAllTransaction(strWhere, strOrderBy);
        }
        public static ModelTransactions getTransactionByID(string ID)
        {
            DLTransactions DT = new DLTransactions();
            return DT.getTransactionByID(ID);
        }
        public static string determineHeader(string lbl, string txt)
        {
            DLTransactions DT = new DLTransactions();
            return DT.getHeader(lbl, txt);
        }
        public static string determineSort(string lbl, string SortDirection)
        {
            DLTransactions DT = new DLTransactions();
            return DT.getSort(lbl, SortDirection);
        }
        #endregion

        #region Data Manipulation
        public static void add(ModelTransactions MT)
        {
            if (MT == null) return;

            DLTransactions DT = new DLTransactions();
            DT.add(MT);
        }
        public static void update(ModelTransactions MT)
        {
            if (MT == null) return;

            DLTransactions DT = new DLTransactions();
            DT.update(MT);
        }
        public static void delete(string ID)
        {
            DLTransactions DT = new DLTransactions();
            DT.delete(ID);
        }
        public static int updateFlag(string ID)
        {
            DLTransactions DT = new DLTransactions();
            return DT.updateFlag(ID);
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