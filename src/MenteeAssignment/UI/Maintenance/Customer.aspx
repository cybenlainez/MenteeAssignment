<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenteeMaster.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="MenteeAssignment.UI.Maintenance.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function GetRepeaterRowID(obj) {
            var objid = obj.id;
            var objlen = objid.length - 5;
            return objid.substring(0, objlen);
        }
        function SelectCustomer(obj)
        {
            var rowid = GetRepeaterRowID(obj) + 'lblCustomerID';
            var CustomerID = document.getElementById(rowid);
            
            __doPostBack('<%= updCustomer.ClientID %>', CustomerID.innerHTML)
        }
        function SelectTransaction(obj) {
            var rowid = GetRepeaterRowID(obj) + 'lblTransactionID';
            var TransactionsID = document.getElementById(rowid);

            __doPostBack('<%= updTransaction.ClientID %>', TransactionsID.innerHTML)
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrap">
        <asp:UpdatePanel ID="updCustomer" runat="server">
            <ContentTemplate>

        <table width="100%" align="center">
            <tr>
                <td>
                    <asp:Panel id="pnlCustomer" runat="server">
                        <table align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                            <tr style="background-color: #404040; color: #ffffff; vertical-align: middle;">
                                <td align="left" style="padding: 7px 0px 7px 7px;">
                                    <table align="left" style="font-family: tahoma; font-size: 11px; border-spacing: 0px;">
                                        <tr style="color: #ffffff;">
                                            <td align="left">
                                                <asp:Label ID="lblSearchCustomer" runat="server" Text="Search by name" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
                                                <asp:TextBox ID="txtSearchCustomer" runat="server" Font-Names="Tahoma" Font-Size="11px"></asp:TextBox>
                                            </td>
                                            <td align="left" style="padding-left: 7px;">
                                                <asp:ImageButton ID="imgbtnSearchCustomer" runat="server" ImageUrl="~/Images/button-search.png" 
                                                    ToolTip="Search" OnClick="imgbtnSearchCustomer_Clicked"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" style="padding: 7px 7px 7px 0px;">
                                    <table align="right" style="font-family: tahoma; font-size: 11px; border-spacing: 0px;">
                                        <tr style="color: #ffffff;">
                                            <td align="left">
                                                <asp:ImageButton ID="imgbtnFirstCustomer" runat="server" ImageUrl="~/images/button-first.png"
                                                    ToolTip="First Page" Height="17px" Width="17px" OnClick="imgbtnFirstCustomer_Clicked"/>
                                                <asp:ImageButton ID="imgbtnPreviousCustomer" runat="server" ImageUrl="~/images/button-previous.png"
                                                    ToolTip="Previous Page" Height="17px" Width="17px" OnClick="imgbtnPreviousCustomer_Clicked"/>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label6" runat="server" Text="Page " 
                                                    Font-Names="Tahoma" Font-Size="11px" ForeColor="White"></asp:Label>
                                                <asp:DropDownList ID="ddlPageNumberCustomer" runat="server" OnSelectedIndexChanged="ddlPageNumberCustomer_SelectedIndexChanged"
                                                    Font-Names="Tahoma" Font-Size="11px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:ImageButton ID="imgbtnNextCustomer" runat="server" ImageUrl="~/images/button-next.png"
                                                    ToolTip="Next Page" Height="17px" Width="17px" OnClick="imgbtnNextCustomer_Clicked"/>
                                                <asp:ImageButton ID="imgbtnLastCustomer" runat="server" ImageUrl="~/images/button-last.png"
                                                    ToolTip="Last Page" Height="17px" Width="17px" OnClick="imgbtnLastCustomer_Clicked"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:Repeater ID="rptCustomer" runat="server" OnItemCommand="rptCustomer_ItemCommand" OnItemDataBound="rptCustomer_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table-items" align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                                    <tr style="background-color: #cccccc; color: #555555; height: 25px;">
                                        <th></th>
                                        <th><asp:LinkButton ID="lnkbtnID" runat="server" CssClass="header" Text="ID" CommandArgument="Search by ID" OnCommand="lnkBtnSortCustomer_Clicked"></asp:LinkButton></th>
                                        <th><asp:LinkButton ID="lnkbtnName" runat="server" CssClass="header" Text="Name" CommandArgument="Search by name" OnCommand="lnkBtnSortCustomer_Clicked"></asp:LinkButton></th>
                                        <th><asp:LinkButton ID="lnkbtnAddress" runat="server" CssClass="header" Text="Address" CommandArgument="Search by address" OnCommand="lnkBtnSortCustomer_Clicked"></asp:LinkButton></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tr id="row" runat="server" onclick="SelectCustomer(this);">
                                        <td valign="middle" style="width: 45px;">
                                            <table class="table-buttons" style="border-spacing: 0; width: 100%; text-align: center;">
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        <asp:ImageButton ID="imgbtnEditCustomer" runat="server" ImageUrl="~/Images/button-edit.png" 
                                                            ToolTip="Edit" CommandName="Edit" CommandArgument='<%# Eval("Id") %>'/>
                                                        <asp:ImageButton ID="imgbtnDeleteCustomer" runat="server" ImageUrl="~/Images/button-delete.png" 
                                                            ToolTip="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                                            OnClientClick="return confirm('Are you sure you want to delete this item?');"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <table align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                        <tr style="background-color: #eaeaea; height: 20px;" align="center">
                            <td colspan="3" align="left" style="padding: 10px;" valign="top">
                                <asp:Textbox ID="txtID" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" Visible="false"></asp:Textbox><br />
                                Name<asp:Label ID="Label1" runat="server" Text=" *" Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label><br />
                                <asp:Textbox ID="txtName" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" TabIndex="1"></asp:Textbox><br />
                                Address<asp:Label ID="Label10" runat="server" Text=" *" Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label><br />
                                <asp:Textbox ID="txtAddress" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" TabIndex="2"></asp:Textbox>
                            </td>
                        </tr>
                        <tr style="background-color: #eaeaea; height: 20px;" align="center">
                            <td colspan="2" align="left" valign="bottom" style="padding: 10px;">
                                <asp:Label ID="Label19" runat="server" Text="* Denotes required fields" 
                                    Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" valign="middle" style="padding: 10px;">
                                <asp:ImageButton ID="imgbtnAddCustomer" runat="server" ImageUrl="~/images/button-add.png"
                                    ToolTip="Add" OnClick="imgbtnAddCustomer_Clicked"/>
                                <asp:ImageButton ID="imgbtnSaveCustomer" runat="server" ImageUrl="~/images/button-update.png"
                                    ToolTip="Save" Visible="False" OnClick="imgbtnSaveCustomer_Clicked"/>
                                <asp:ImageButton ID="imgbtnCancelCustomer" runat="server" ImageUrl="~/images/button-cancel.png"
                                    ToolTip="Cancel" Visible="False" OnClick="imgbtnCancelCustomer_Clicked"/>                                             
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
            
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <br />
        
        <asp:UpdatePanel ID="updTransaction" runat="server">
            <ContentTemplate>
        
        <table width="100%" align="center">
            <tr>
                <td>
                    <asp:Panel id="pnlTransaction" runat="server">
                        <table align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                            <tr style="background-color: #404040; color: #ffffff; vertical-align: middle;">
                                <td align="left" style="padding: 7px 0px 7px 7px;">
                                    <table align="left" style="font-family: tahoma; font-size: 11px; border-spacing: 0px;">
                                        <tr style="color: #ffffff;">
                                            <td align="left">
                                                <asp:Label ID="lblSearchTransaction" runat="server" Text="Search by transaction ID" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
                                                <asp:TextBox ID="txtSearchTransaction" runat="server" Font-Names="Tahoma" Font-Size="11px"></asp:TextBox>
                                            </td>
                                            <td align="left" style="padding-left: 7px;">
                                                <asp:ImageButton ID="imgbtnSearchTransaction" runat="server" ImageUrl="~/Images/button-search.png" 
                                                    ToolTip="Search" OnClick="imgbtnSearchTransaction_Clicked"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" style="padding: 7px 7px 7px 0px;">
                                    <table align="right" style="font-family: tahoma; font-size: 11px; border-spacing: 0px;">
                                        <tr style="color: #ffffff;">
                                            <td align="left">
                                                <asp:ImageButton ID="imgbtnFirstTransaction" runat="server" ImageUrl="~/images/button-first.png"
                                                    ToolTip="First Page" Height="17px" Width="17px" OnClick="imgbtnFirstTransaction_Clicked"/>
                                                <asp:ImageButton ID="imgbtnPreviousTransaction" runat="server" ImageUrl="~/images/button-previous.png"
                                                    ToolTip="Previous Page" Height="17px" Width="17px" OnClick="imgbtnPreviousTransaction_Clicked"/>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label8" runat="server" Text="Page " 
                                                    Font-Names="Tahoma" Font-Size="11px" ForeColor="White"></asp:Label>
                                                <asp:DropDownList ID="ddlPageNumberTransaction" runat="server" OnSelectedIndexChanged="ddlPageNumberTransaction_SelectedIndexChanged"
                                                    Font-Names="Tahoma" Font-Size="11px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:ImageButton ID="imgbtnNextTransaction" runat="server" ImageUrl="~/images/button-next.png"
                                                    ToolTip="Next Page" Height="17px" Width="17px" OnClick="imgbtnNextTransaction_Clicked"/>
                                                <asp:ImageButton ID="imgbtnLastTransaction" runat="server" ImageUrl="~/images/button-last.png"
                                                    ToolTip="Last Page" Height="17px" Width="17px" OnClick="imgbtnLastTransaction_Clicked"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:Repeater ID="rptTransaction" runat="server" OnItemCommand="rptTransaction_ItemCommand" OnItemDataBound="rptTransaction_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table-items" align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                                    <tr style="background-color: #cccccc; color: #555555; height: 25px;">
                                        <th></th>
                                        <th><asp:LinkButton ID="lnkbtnTransactionID" runat="server" CssClass="header" Text="Transaction ID" CommandArgument="Search by transaction ID" OnCommand="lnkBtnSortTransaction_Clicked"></asp:LinkButton></th>
                                        <th><asp:LinkButton ID="lnkbtnDate" runat="server" CssClass="header" Text="Date" CommandArgument="Search by date" OnCommand="lnkBtnSortTransaction_Clicked"></asp:LinkButton></th>
                                        <th><asp:LinkButton ID="lnkbtnCustomerID" runat="server" CssClass="header" Text="Customer ID" CommandArgument="Search by customer ID" OnCommand="lnkBtnSortTransaction_Clicked"></asp:LinkButton></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tr id="row" runat="server" onclick="SelectTransaction(this);">
                                        <td valign="middle" style="width: 45px;">
                                            <table class="table-buttons" style="border-spacing: 0; width: 100%; text-align: center;">
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        <asp:ImageButton ID="imgbtnEditTransaction" runat="server" ImageUrl="~/Images/button-edit.png" 
                                                            ToolTip="Edit" CommandName="Edit" CommandArgument='<%# Eval("Transaction_ID") %>'/>
                                                        <asp:ImageButton ID="imgbtnDeleteTransaction" runat="server" ImageUrl="~/Images/button-delete.png" 
                                                            ToolTip="Delete" CommandName="Delete" CommandArgument='<%# Eval("Transaction_ID") %>'
                                                            OnClientClick="return confirm('Are you sure you want to delete this item?');"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTransactionID" runat="server" Text='<%# Eval("Transaction_ID") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("Customer_ID") %>'></asp:Label>
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <table align="center" style="font-family: tahoma; font-size: 11px; width: 100%; border-spacing: 0;">
                        <tr style="background-color: #eaeaea; height: 20px;" align="center">
                            <td colspan="3" align="left" style="padding: 10px;" valign="top">
                                <asp:Textbox ID="txtTransactionID" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" Visible="false"></asp:Textbox><br />
                                Date<asp:Label ID="Label12" runat="server" Text=" *" Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label><br />
                                <asp:Textbox ID="txtDate" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" TabIndex="1"></asp:Textbox><br />
                                Customer ID<asp:Label ID="Label14" runat="server" Text=" *" Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label><br />
                                <asp:Textbox ID="txtCustomerID" runat="server" Font-Names="Tahoma" Font-Size="11px" Width="210px" TabIndex="2"></asp:Textbox>
                            </td>
                        </tr>
                        <tr style="background-color: #eaeaea; height: 20px;" align="center">
                            <td colspan="2" align="left" valign="bottom" style="padding: 10px;">
                                <asp:Label ID="Label16" runat="server" Text="* Denotes required fields" 
                                    Font-Names="Tahoma" Font-Size="11px" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" valign="middle" style="padding: 10px;">
                                <asp:ImageButton ID="imgbtnAddTransaction" runat="server" ImageUrl="~/images/button-add.png"
                                    ToolTip="Add" OnClick="imgbtnAddTransaction_Clicked"/>
                                <asp:ImageButton ID="imgbtnSaveTransaction" runat="server" ImageUrl="~/images/button-update.png"
                                    ToolTip="Save" Visible="False" OnClick="imgbtnSaveTransaction_Clicked"/>
                                <asp:ImageButton ID="imgbtnCancelTransaction" runat="server" ImageUrl="~/images/button-cancel.png"
                                    ToolTip="Cancel" Visible="False" OnClick="imgbtnCancelTransaction_Clicked"/>                                             
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
            
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
