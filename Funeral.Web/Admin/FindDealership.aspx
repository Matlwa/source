<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="FindDealership.aspx.cs" Inherits="Funeral.Web.Admin.FindDealership" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">
        #MainContent_Button1 {
            background-color: cornflowerblue;
            float:inherit;
        }

        #MainContent_hrLink {
            text-size-adjust:25%;
        }

        em {
            color: red;
        }
        #MainContent_Button2 {
            background-color: rosybrown;
            float:left;
        }

        em {
            color: red;
        }
        #MainContent_Button3 {
            background-color: red;
            float:right;
        }

        em {
            color: red;
        }
        #MainContent_buttonSubmit {
            background-color: red;
            float:left;
            
        }
         #MainContent_btnSearch {
            background-color: green;
            float:right;
            
        }
           #MainContent_btnSubmit {
            background-color: green;
            float:left;
            
        }
           #MainContent_ddlPageSize {           
            float:left;
        }
    </style>
 <script type="text/javascript">
        $(document).ready(function () {
            $('#tblDealerSales').dataTable({
                "oLanguage": { "Search": "Search DealerSales:" },
                "iDisplayLength": 5,
                "sPaginationType": "full_numbers",
                "aaSorting": [[0, "asc"]]
            });
        });     
 document.getElementById('<%=txtKeyword.ClientID%>').setAttribute("onkeyup", "runScript(event);return false;");
    function runScript(e) {
        if (e.keyCode == 13) {
            document.getElementById('<%=btnSearch.ClientID%>').click();
            return false;
        }
    }
</script>
    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ibox">
        <div class="ibox-content">
             <div class="row">  
                 <div class="col-sm-6">
                    <div class="form-group">
                        <div class="input-group">
                            <label>Show Entries</label>
                            <asp:DropDownList AutoPostBack="true" ID="ddlPageSize" CssClass="form-control" runat="server" >                              
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                                <asp:ListItem>200</asp:ListItem>
                                <asp:ListItem>250</asp:ListItem>
                                <asp:ListItem>500</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>                     
            <div class="col-sm-6">
                    <div class="form-group">
                        <label>Search Dealership:</label>
                        <asp:Panel ID="pnlSearch" CssClass="input-group" DefaultButton="btnSearch" OnClick="btnSearch_Click" runat="server">
                            <asp:TextBox runat="server" ID="txtKeyword" MaxLength="50" CssClass="form-control" placeholder="Search Dealership"></asp:TextBox>
                            <span class="input-group-btn">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Find Dealership" CssClass="btn btn-w-m btn-primary" OnClick="btnSearch_Click" />
                            </span>
                        </asp:Panel>
                    </div>
                </div>

                 <div class="col-sm-12">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 ">
                    <div class="table-responsive">
                        <asp:GridView ID="gvDealerships" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="There are no dealerships found." OnPageIndexChanging="gvDealerships_PageIndexChanging">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:BoundField DataField="DealershipName" HeaderText="Dealership Name" SortExpression="DealershipName" />
                                <asp:BoundField DataField="Landline" HeaderText="Dealership Landline" SortExpression="DealershipLandline" />
                                </Columns>
                                </asp:GridView>
                        </div>
            </div>
                </div>
            
            </div>
        </div>
 </asp:Content>