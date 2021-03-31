<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Funeral.Web.Admin.Dashboard" %>

<%@ Register Src="../UserControl/ctrDashboardChart.ascx" TagPrefix="uc1" TagName="ctrDashboardChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Policy Admin</h5>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <div class="ibox-content">

                    <%--<div class="col-sm-6">
                            <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            <asp:Image ID="Image1" runat="server" />
                        </div>--%>

                    <uc1:ctrDashboardChart runat="server" ID="ContactUC" Header="User Contact Us Page" />

                </div>
            </div>
            <div id="HideData" runat="server" class="ibox ">
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12">
                        <div class="pull-right">
                                 <asp:DropDownList  ID="ddlCompanyList" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChangeCompanydata"></asp:DropDownList>
                             </div>
                            </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <label>Show</label>
                                    <asp:DropDownList AutoPostBack="true" ID="ddlPageSize" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                        <asp:ListItem>200</asp:ListItem>
                                        <asp:ListItem>250</asp:ListItem>
                                        <asp:ListItem>500</asp:ListItem>
                                    </asp:DropDownList>
                                    entries
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Search Service :</label>

                                <asp:Panel ID="pnlSearch" CssClass="input-group" DefaultButton="btnSearch" runat="server">
                                    <asp:TextBox runat="server" ID="txtKeyword" MaxLength="50" CssClass="form-control" placeholder="Search by keyword"></asp:TextBox>
                                    <span class="input-group-btn">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-w-m btn-primary" OnClick="btnSearch_Click" />
                                        <br />
                                    </span>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label runat="server" ID="Label1"></asp:Label>
                        </div>
                        <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 ">
                            <div class="table-responsive">
                                <asp:GridView ID="gvPolicyPremium" OnRowDataBound="gvPolicyPremium_RowDataBound" OnPageIndexChanging="gvPolicyPremium_PageIndexChanging"
                                     OnSorting="gvPolicyPremium_Sorting" AllowSorting="true" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                     AutoGenerateColumns="False" AllowPaging="True" PageSize="25" EmptyDataText="There are no Services  added.">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:BoundField DataField="DatePaid" HeaderText="Date Paid " SortExpression="DatePaid" ReadOnly="True" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                        <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" ReadOnly="True" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                        <asp:BoundField DataField="RecievedBy" HeaderText="RecievedBy" ReadOnly="True" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                        <asp:BoundField DataField="PaymentBranch" HeaderText="Payment Branch" ReadOnly="True" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />                                      
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">
</asp:Content>
