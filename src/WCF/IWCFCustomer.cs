using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Model;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFCustomer" in both code and config file together.
    [ServiceContract]
    public interface IWCFCustomer
    {
        #region Retrieve Data
        [OperationContract]
        DataTable getAllCustomer(string strWhere, string strOrderBy);
        [OperationContract]
        ModelCustomer getCustomerByID(string ID);
        [OperationContract]
        string determineHeader(string lbl, string txt);
        [OperationContract]
        string determineSort(string lbl, string SortDirection);
        #endregion

        #region Data Manipulation
        [OperationContract]
        void add(ModelCustomer MC);
        [OperationContract]
        void update(ModelCustomer MC);
        [OperationContract]
        void delete(string ID);
        [OperationContract]
        int updateFlag(string ID);
        #endregion
    }
}
