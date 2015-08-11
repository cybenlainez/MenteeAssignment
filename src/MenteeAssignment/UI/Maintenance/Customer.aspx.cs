using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BL;
using Model;

namespace MenteeAssignment.UI.Maintenance
{
    public partial class Customer : System.Web.UI.Page
    {
        //GLOBAL
        //////////////////////////////////////////////////////////////////////////////////////////////////

        #region Global - Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPageDataSourceCustomer("");
                BindPageDataSourceTransaction("");
                ManageFieldsCustomer(false, true);
                ManageFieldsTransaction(false, true);
            }
            else
            {
                string eventtarget = Request.Form["__EVENTTARGET"];
                string eventargument = Request.Form["__EVENTARGUMENT"];

                if (eventtarget == updCustomer.ClientID) SelectItemCustomer(eventargument);
                else if (eventtarget == updTransaction.ClientID) SelectItemTransaction(eventargument);
            }
        }
        #endregion

        #region Global - Methods
        private string LastSortDirection()
        {
            string str = Convert.ToString(ViewState["LastSortDirectionCustomer"]);
            if (str == "ASC")
            {
                ViewState["LastSortDirectionCustomer"] = "DESC";
                return " DESC";
            }
            else
            {
                ViewState["LastSortDirectionCustomer"] = "ASC";
                return " ASC";
            }
        }
        private void SetToUpperCase(Control Page)
        {
            foreach (Control ctrl in Page.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Attributes.Add("style", "text-transform:uppercase");
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        SetToUpperCase(ctrl);
                    }
                }
            }
        }
        #endregion

        //CUSTOMER
        //////////////////////////////////////////////////////////////////////////////////////////////////

        #region Customer Property
        private DataTable DataTableCustomer
        {
            get
            {
                if (ViewState["WhereCustomer"] == null) { ViewState["WhereCustomer"] = string.Empty; }
                if (ViewState["OrderByCustomer"] == null) { ViewState["OrderByCustomer"] = string.Empty; }
                if (ViewState["DT_Customer"] == null)
                {
                    BLCustomer BC = new BLCustomer();
                    ViewState["DT_Customer"] = BC.getAllCustomer(ViewState["WhereCustomer"].ToString(), ViewState["OrderByCustomer"].ToString());
                }
                return (DataTable)ViewState["DT_Customer"];
            }
            set { ViewState["DT_Customer"] = value; }
        }
        private int mPageNumberCustomer;
        private int PageNumberCustomer
        {
            get { return mPageNumberCustomer; }
            set { mPageNumberCustomer = value; }
        }
        private List<string> SQLListCustomer { get; set; }
        #endregion

        #region Customer - Events
        protected void rptCustomer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        protected void rptCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    FillFieldsCustomer(BLCustomer.getCustomerByID(Convert.ToString(e.CommandArgument)));
                    ManageFieldsCustomer(true, false);

                    imgbtnAddCustomer.Visible = false;
                    imgbtnSaveCustomer.Visible = true;
                    imgbtnCancelCustomer.Visible = true;

                    pnlCustomer.Enabled = false;
                    break;
                case "Delete":
                    BLCustomer.delete(Convert.ToString(e.CommandArgument));
                    imgbtnAddCustomer.Visible = true;
                    imgbtnSaveCustomer.Visible = false;
                    imgbtnCancelCustomer.Visible = false;
                    break;
            }

            ViewState.Remove("DT_Customer");
            BindPageDataSourceCustomer("");
        }
        protected void imgbtnAddCustomer_Clicked(object sender, EventArgs e)
        {
            txtName.Focus();

            imgbtnAddCustomer.Visible = false;
            imgbtnSaveCustomer.Visible = true;
            imgbtnCancelCustomer.Visible = true;

            ManageFieldsCustomer(true, true);

            pnlCustomer.Enabled = false;
        }
        protected void imgbtnSaveCustomer_Clicked(object sender, EventArgs e)
        {
            bool UpdateFlag = Convert.ToBoolean(BLCustomer.updateFlag(txtID.Text));

            if (UpdateFlag == true)
            {
                BLCustomer.update(GetFieldValuesCustomer());
                ViewState.Remove("DT_Customer");
                BindPageDataSourceCustomer("");
            }
            else
            {
                BLCustomer.add(GetFieldValuesCustomer());
                ViewState.Remove("DT_Customer");
                BindPageDataSourceCustomer("");
            }

            imgbtnSaveCustomer.Visible = false;
            imgbtnCancelCustomer.Visible = false;
            imgbtnAddCustomer.Visible = true;

            ManageFieldsCustomer(false, true);

            pnlCustomer.Enabled = true;
        }
        protected void imgbtnCancelCustomer_Clicked(object sender, EventArgs e)
        {
            imgbtnSaveCustomer.Visible = false;
            imgbtnCancelCustomer.Visible = false;
            imgbtnAddCustomer.Visible = true;

            ManageFieldsCustomer(false, true);

            pnlCustomer.Enabled = true;
        }
        protected void ddlPageNumberCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageNumberCustomer = ddlPageNumberCustomer.SelectedIndex;
            BindPageDataSourceCustomer("");
        }
        protected void imgbtnFirstCustomer_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberCustomer.SelectedIndex > 0)
            {
                PageNumberCustomer = 0;
                BindPageDataSourceCustomer("");

                ManageFieldsCustomer(false, true);
            }
        }
        protected void imgbtnPreviousCustomer_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberCustomer.SelectedIndex > 0)
            {
                PageNumberCustomer = ddlPageNumberCustomer.SelectedIndex - 1;
                BindPageDataSourceCustomer("");

                ManageFieldsCustomer(false, true);
            }
        }
        protected void imgbtnNextCustomer_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberCustomer.Items.Count > Convert.ToInt32(ddlPageNumberCustomer.Text))
            {
                PageNumberCustomer = ddlPageNumberCustomer.SelectedIndex + 1;
                BindPageDataSourceCustomer("");

                ManageFieldsCustomer(false, true);
            }
        }
        protected void imgbtnLastCustomer_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberCustomer.Items.Count > Convert.ToInt32(ddlPageNumberCustomer.Text))
            {
                PageNumberCustomer = ddlPageNumberCustomer.Items.Count - 1;
                BindPageDataSourceCustomer("");

                ManageFieldsCustomer(false, true);
            }
        }
        #endregion

        #region Customer - Methods
        private void BindPageDataSourceCustomer(string CommandName)
        {
            PagedDataSource PDS = new PagedDataSource();
            DataView DV = new DataView(DataTableCustomer);

            if (ViewState["OrderByCustomer"].ToString() != "")
            {
                DV.Sort = ViewState["OrderByCustomer"].ToString();
                ViewState.Remove("OrderByCustomer");
            }

            PDS.DataSource = DV;
            PDS.AllowPaging = true;
            PDS.PageSize = 3;

            PDS.CurrentPageIndex = PageNumberCustomer;

            rptCustomer.DataSource = PDS;
            rptCustomer.DataBind();

            ddlPageNumberCustomer.Items.Clear();
            for (int indx = 1; indx <= PDS.PageCount; indx++)
                ddlPageNumberCustomer.Items.Add(indx.ToString());

            ddlPageNumberCustomer.SelectedIndex = PageNumberCustomer;

            ManagePagingCustomer();
        }
        private void SelectItemCustomer(string ID)
        {
            if (pnlCustomer.Enabled)
            {
                imgbtnAddCustomer.Visible = true;
                imgbtnSaveCustomer.Visible = false;
                imgbtnCancelCustomer.Visible = false;

                foreach (RepeaterItem itm in rptCustomer.Items)
                {
                    HtmlTableRow row;
                    row = (HtmlTableRow)itm.FindControl("row");

                    Label lblCustomerID = (Label)itm.FindControl("lblCustomerID");
                    string CustomerID = lblCustomerID.Text.Replace(" ", string.Empty);

                    if (row != null && CustomerID == ID)
                    {
                        row.Attributes.Add("class", "tr-row");
                    }
                    else
                    {
                        row.Attributes.Add("class", "");
                    }
                }

                ViewState["CustomerID"] = "";
                ViewState["CustomerID"] = ID;
            }
        }
        private void FillFieldsCustomer(ModelCustomer MC)
        {
            txtID.Text = MC.Id.ToString();
            txtName.Text = MC.Name;
            txtAddress.Text = MC.Address;
        }
        private ModelCustomer GetFieldValuesCustomer()
        {
            string ErrMsg = "";
            ModelCustomer MC = new ModelCustomer();

            try
            {
                if (txtID.Text != "") MC.Id = Convert.ToInt32(txtID.Text);                
                MC.Name = txtName.Text;
                MC.Address = txtAddress.Text;

                return MC;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message.ToString();
                ViewState["WithErrorCustomer"] = true;
                return null;
            }
            finally
            {
                MC.Dispose();
            }
        }
        private void ManageFieldsCustomer(bool isEnable, bool isClear)
        {
            txtID.Enabled = isEnable;
            txtName.Enabled = isEnable;
            txtAddress.Enabled = isEnable;

            if (isClear == true)
            {
                txtID.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
            }
        }
        private void ManagePagingCustomer()
        {
            imgbtnFirstCustomer.Enabled = true;
            imgbtnPreviousCustomer.Enabled = true;
            imgbtnFirstCustomer.ImageUrl = "~/images/button-first.png";
            imgbtnPreviousCustomer.ImageUrl = "~/images/button-previous.png";

            imgbtnLastCustomer.Enabled = true;
            imgbtnNextCustomer.Enabled = true;
            imgbtnLastCustomer.ImageUrl = "~/images/button-last.png";
            imgbtnNextCustomer.ImageUrl = "~/images/button-next.png";

            if ((ddlPageNumberCustomer.SelectedIndex == 0) && (ddlPageNumberCustomer.Items.Count > 1))
            {
                imgbtnFirstCustomer.Enabled = false;
                imgbtnPreviousCustomer.Enabled = false;
                imgbtnFirstCustomer.ImageUrl = "~/images/button-first-gray.png";
                imgbtnPreviousCustomer.ImageUrl = "~/images/button-previous-gray.png";
            }

            if ((ddlPageNumberCustomer.SelectedIndex == ddlPageNumberCustomer.Items.Count - 1) && (ddlPageNumberCustomer.Items.Count > 1))
            {
                imgbtnLastCustomer.Enabled = false;
                imgbtnNextCustomer.Enabled = false;
                imgbtnLastCustomer.ImageUrl = "~/images/button-last-gray.png";
                imgbtnNextCustomer.ImageUrl = "~/images/button-next-gray.png";
            }

            if ((ddlPageNumberCustomer.SelectedIndex == 0) && (ddlPageNumberCustomer.Items.Count == 1))
            {
                imgbtnFirstCustomer.Enabled = false;
                imgbtnPreviousCustomer.Enabled = false;
                imgbtnFirstCustomer.ImageUrl = "~/images/button-first-gray.png";
                imgbtnPreviousCustomer.ImageUrl = "~/images/button-previous-gray.png";

                imgbtnLastCustomer.Enabled = false;
                imgbtnNextCustomer.Enabled = false;
                imgbtnLastCustomer.ImageUrl = "~/images/button-last-gray.png";
                imgbtnNextCustomer.ImageUrl = "~/images/button-next-gray.png";
            }
        }
        #endregion

        #region Customer - Search
        protected void imgbtnSearchCustomer_Clicked(object sender, EventArgs e)
        {
            ViewState.Remove("WhereCustomer");

            if (txtSearchCustomer.Text.Trim().Length > 0)
                ViewState["WhereCustomer"] = BLCustomer.determineHeader(lblSearchCustomer.Text, txtSearchCustomer.Text);

            ViewState.Remove("DT_Customer");
            BindPageDataSourceCustomer("");

            ManageFieldsCustomer(false, true);
        }
        #endregion

        #region Customer - Sorting
        protected void lnkBtnSortCustomer_Clicked(object sender, CommandEventArgs e)
        {
            lblSearchCustomer.Text = e.CommandArgument.ToString();

            ViewState["OrderByCustomer"] = "";
            ViewState["OrderByCustomer"] = BLCustomer.determineSort(lblSearchCustomer.Text, LastSortDirection());

            BindPageDataSourceCustomer("");

            ManageFieldsCustomer(false, true);
        }
        #endregion

        //TRANSACTIONS
        //////////////////////////////////////////////////////////////////////////////////////////////////

        #region Transaction Property
        private DataTable DataTableTransaction
        {
            get
            {
                if (ViewState["WhereTransaction"] == null) { ViewState["WhereTransaction"] = string.Empty; }
                if (ViewState["OrderByTransaction"] == null) { ViewState["OrderByTransaction"] = string.Empty; }
                if (ViewState["DT_Transaction"] == null)
                {
                    BLTransactions BT = new BLTransactions();
                    ViewState["DT_Transaction"] = BT.getAllTransaction(ViewState["WhereTransaction"].ToString(), ViewState["OrderByTransaction"].ToString());
                }
                return (DataTable)ViewState["DT_Transaction"];
            }
            set { ViewState["DT_Transaction"] = value; }
        }
        private int mPageNumberTransaction;
        private int PageNumberTransaction
        {
            get { return mPageNumberTransaction; }
            set { mPageNumberTransaction = value; }
        }
        private List<string> SQLListTransaction { get; set; }
        #endregion

        #region Transaction - Events
        protected void rptTransaction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        protected void rptTransaction_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    FillFieldsTransaction(BLTransactions.getTransactionByID(Convert.ToString(e.CommandArgument)));
                    ManageFieldsTransaction(true, false);

                    imgbtnAddTransaction.Visible = false;
                    imgbtnSaveTransaction.Visible = true;
                    imgbtnCancelTransaction.Visible = true;

                    pnlTransaction.Enabled = false;
                    break;
                case "Delete":
                    BLTransactions.delete(Convert.ToString(e.CommandArgument));
                    imgbtnAddTransaction.Visible = true;
                    imgbtnSaveTransaction.Visible = false;
                    imgbtnCancelTransaction.Visible = false;
                    break;
            }

            ViewState.Remove("DT_Transaction");
            BindPageDataSourceTransaction("");
        }
        protected void imgbtnAddTransaction_Clicked(object sender, EventArgs e)
        {
            txtDate.Focus();

            imgbtnAddTransaction.Visible = false;
            imgbtnSaveTransaction.Visible = true;
            imgbtnCancelTransaction.Visible = true;

            ManageFieldsTransaction(true, true);

            pnlTransaction.Enabled = false;
        }
        protected void imgbtnSaveTransaction_Clicked(object sender, EventArgs e)
        {
            bool UpdateFlag = Convert.ToBoolean(BLTransactions.updateFlag(txtTransactionID.Text));

            if (UpdateFlag == true)
            {
                BLTransactions.update(GetFieldValuesTransaction());
                ViewState.Remove("DT_Transaction");
                BindPageDataSourceTransaction("");
            }
            else
            {
                BLTransactions.add(GetFieldValuesTransaction());
                ViewState.Remove("DT_Transaction");
                BindPageDataSourceTransaction("");
            }

            imgbtnSaveTransaction.Visible = false;
            imgbtnCancelTransaction.Visible = false;
            imgbtnAddTransaction.Visible = true;

            ManageFieldsTransaction(false, true);

            pnlTransaction.Enabled = true;
        }
        protected void imgbtnCancelTransaction_Clicked(object sender, EventArgs e)
        {
            imgbtnSaveTransaction.Visible = false;
            imgbtnCancelTransaction.Visible = false;
            imgbtnAddTransaction.Visible = true;

            ManageFieldsTransaction(false, true);

            pnlTransaction.Enabled = true;
        }
        protected void ddlPageNumberTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageNumberTransaction = ddlPageNumberTransaction.SelectedIndex;
            BindPageDataSourceTransaction("");
        }
        protected void imgbtnFirstTransaction_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberTransaction.SelectedIndex > 0)
            {
                PageNumberTransaction = 0;
                BindPageDataSourceTransaction("");

                ManageFieldsTransaction(false, true);
            }
        }
        protected void imgbtnPreviousTransaction_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberTransaction.SelectedIndex > 0)
            {
                PageNumberTransaction = ddlPageNumberTransaction.SelectedIndex - 1;
                BindPageDataSourceTransaction("");

                ManageFieldsTransaction(false, true);
            }
        }
        protected void imgbtnNextTransaction_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberTransaction.Items.Count > Convert.ToInt32(ddlPageNumberTransaction.Text))
            {
                PageNumberTransaction = ddlPageNumberTransaction.SelectedIndex + 1;
                BindPageDataSourceTransaction("");

                ManageFieldsTransaction(false, true);
            }
        }
        protected void imgbtnLastTransaction_Clicked(object sender, EventArgs e)
        {
            if (ddlPageNumberTransaction.Items.Count > Convert.ToInt32(ddlPageNumberTransaction.Text))
            {
                PageNumberTransaction = ddlPageNumberTransaction.Items.Count - 1;
                BindPageDataSourceTransaction("");

                ManageFieldsTransaction(false, true);
            }
        }
        #endregion

        #region Transaction - Methods
        private void BindPageDataSourceTransaction(string CommandName)
        {
            PagedDataSource PDS = new PagedDataSource();
            DataView DV = new DataView(DataTableTransaction);

            if (ViewState["OrderByTransaction"].ToString() != "")
            {
                DV.Sort = ViewState["OrderByTransaction"].ToString();
                ViewState.Remove("OrderByTransaction");
            }

            PDS.DataSource = DV;
            PDS.AllowPaging = true;
            PDS.PageSize = 3;

            PDS.CurrentPageIndex = PageNumberTransaction;

            rptTransaction.DataSource = PDS;
            rptTransaction.DataBind();

            ddlPageNumberTransaction.Items.Clear();
            for (int indx = 1; indx <= PDS.PageCount; indx++)
                ddlPageNumberTransaction.Items.Add(indx.ToString());

            ddlPageNumberTransaction.SelectedIndex = PageNumberTransaction;

            ManagePagingTransaction();
        }
        private void SelectItemTransaction(string ID)
        {
            if (pnlTransaction.Enabled)
            {
                imgbtnAddTransaction.Visible = true;
                imgbtnSaveTransaction.Visible = false;
                imgbtnCancelTransaction.Visible = false;

                foreach (RepeaterItem itm in rptTransaction.Items)
                {
                    HtmlTableRow row;
                    row = (HtmlTableRow)itm.FindControl("row");

                    Label lblTransactionID = (Label)itm.FindControl("lblTransactionID");
                    string TransactionID = lblTransactionID.Text.Replace(" ", string.Empty);

                    if (row != null && TransactionID == ID)
                    {
                        row.Attributes.Add("class", "tr-row");
                    }
                    else
                    {
                        row.Attributes.Add("class", "");
                    }
                }

                ViewState["TransactionID"] = "";
                ViewState["TransactionID"] = ID;
            }
        }
        private void FillFieldsTransaction(ModelTransactions MT)
        {
            txtTransactionID.Text = MT.Transaction_ID.ToString();
            txtDate.Text = MT.Date.ToString();
            txtCustomerID.Text = MT.Customer_ID;
        }
        private ModelTransactions GetFieldValuesTransaction()
        {
            string ErrMsg = "";
            ModelTransactions MT = new ModelTransactions();

            try
            {
                if (txtTransactionID.Text != "") MT.Transaction_ID = Convert.ToInt32(txtTransactionID.Text);
                MT.Date = Convert.ToDateTime(txtDate.Text);
                MT.Customer_ID = txtCustomerID.Text;

                return MT;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message.ToString();
                ViewState["WithErrorTransaction"] = true;
                return null;
            }
            finally
            {
                MT.Dispose();
            }
        }
        private void ManageFieldsTransaction(bool isEnable, bool isClear)
        {
            txtTransactionID.Enabled = isEnable;
            txtDate.Enabled = isEnable;
            txtCustomerID.Enabled = isEnable;

            if (isClear == true)
            {
                txtTransactionID.Text = "";
                txtDate.Text = "";
                txtCustomerID.Text = "";
            }
        }
        private void ManagePagingTransaction()
        {
            imgbtnFirstTransaction.Enabled = true;
            imgbtnPreviousTransaction.Enabled = true;
            imgbtnFirstTransaction.ImageUrl = "~/images/button-first.png";
            imgbtnPreviousTransaction.ImageUrl = "~/images/button-previous.png";

            imgbtnLastTransaction.Enabled = true;
            imgbtnNextTransaction.Enabled = true;
            imgbtnLastTransaction.ImageUrl = "~/images/button-last.png";
            imgbtnNextTransaction.ImageUrl = "~/images/button-next.png";

            if ((ddlPageNumberTransaction.SelectedIndex == 0) && (ddlPageNumberTransaction.Items.Count > 1))
            {
                imgbtnFirstTransaction.Enabled = false;
                imgbtnPreviousTransaction.Enabled = false;
                imgbtnFirstTransaction.ImageUrl = "~/images/button-first-gray.png";
                imgbtnPreviousTransaction.ImageUrl = "~/images/button-previous-gray.png";
            }

            if ((ddlPageNumberTransaction.SelectedIndex == ddlPageNumberTransaction.Items.Count - 1) && (ddlPageNumberTransaction.Items.Count > 1))
            {
                imgbtnLastTransaction.Enabled = false;
                imgbtnNextTransaction.Enabled = false;
                imgbtnLastTransaction.ImageUrl = "~/images/button-last-gray.png";
                imgbtnNextTransaction.ImageUrl = "~/images/button-next-gray.png";
            }

            if ((ddlPageNumberTransaction.SelectedIndex == 0) && (ddlPageNumberTransaction.Items.Count == 1))
            {
                imgbtnFirstTransaction.Enabled = false;
                imgbtnPreviousTransaction.Enabled = false;
                imgbtnFirstTransaction.ImageUrl = "~/images/button-first-gray.png";
                imgbtnPreviousTransaction.ImageUrl = "~/images/button-previous-gray.png";

                imgbtnLastTransaction.Enabled = false;
                imgbtnNextTransaction.Enabled = false;
                imgbtnLastTransaction.ImageUrl = "~/images/button-last-gray.png";
                imgbtnNextTransaction.ImageUrl = "~/images/button-next-gray.png";
            }
        }
        #endregion

        #region Transaction - Search
        protected void imgbtnSearchTransaction_Clicked(object sender, EventArgs e)
        {
            ViewState.Remove("WhereTransaction");

            if (txtSearchTransaction.Text.Trim().Length > 0)
                ViewState["WhereTransaction"] = BLTransactions.determineHeader(lblSearchTransaction.Text, txtSearchTransaction.Text);

            ViewState.Remove("DT_Transaction");
            BindPageDataSourceTransaction("");

            ManageFieldsTransaction(false, true);
        }
        #endregion

        #region Transaction - Sorting
        protected void lnkBtnSortTransaction_Clicked(object sender, CommandEventArgs e)
        {
            lblSearchTransaction.Text = e.CommandArgument.ToString();

            ViewState["OrderByTransaction"] = "";
            ViewState["OrderByTransaction"] = BLCustomer.determineSort(lblSearchTransaction.Text, LastSortDirection());

            BindPageDataSourceTransaction("");

            ManageFieldsTransaction(false, true);
        }
        #endregion
    }
}