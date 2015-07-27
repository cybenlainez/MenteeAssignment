using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenteeAssignment.MasterPage
{
    public partial class MenteeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Homepage.aspx");
        }

        protected void lnkbtnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Maintenance/Customer.aspx");
        }

        protected void lnkbtnTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Transactions/Transactions.aspx");
        }
    }
}