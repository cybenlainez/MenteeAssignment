using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using DL;
using Model;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFCustomer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFCustomer.svc or WCFCustomer.svc.cs at the Solution Explorer and start debugging.
    public class WCFCustomer : IWCFCustomer
    {
        #region Retrieve Data
        [OperationBehavior]
        public DataTable getAllCustomer(string strWhere, string strOrderBy)
        {
            return new DLCustomer().getAllCustomer(strWhere, strOrderBy);
        }
        public ModelCustomer getCustomerByID(string ID)
        {
            DLCustomer DC = new DLCustomer();
            return DC.getCustomerByID(ID);
        }
        public string determineHeader(string lbl, string txt)
        {
            DLCustomer DC = new DLCustomer();
            return DC.getHeader(lbl, txt);
        }

        public string determineSort(string lbl, string SortDirection)
        {
            DLCustomer DC = new DLCustomer();
            return DC.getSort(lbl, SortDirection);
        }
        #endregion

        #region Data Manipulation
        public void add(ModelCustomer MC)
        {
            if (MC == null) return;

            DLCustomer DC = new DLCustomer();
            DC.add(MC);
        }
        public void update(ModelCustomer MC)
        {
            if (MC == null) return;

            DLCustomer DC = new DLCustomer();
            DC.update(MC);
        }
        public void delete(string ID)
        {
            DLCustomer DC = new DLCustomer();
            DC.delete(ID);
        }
        public int updateFlag(string ID)
        {
            DLCustomer DC = new DLCustomer();
            return DC.updateFlag(ID);
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
