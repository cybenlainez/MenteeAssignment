using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFTransactions" in both code and config file together.
    [ServiceContract]
    public interface IWCFTransactions
    {
        [OperationContract]
        DataTable getAllTransaction(string strWhere, string strOrderBy);
    }
}
