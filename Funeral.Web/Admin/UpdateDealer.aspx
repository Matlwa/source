<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDealer.aspx.cs" Inherits="Funeral.Web.Admin.UpdateDealer1" MasterPageFile="~/Admin/Admin.Master" %>

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
    <div class="ibox ">
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
                        <label>Search Dealers:</label>
                        <asp:Panel ID="pnlSearch" CssClass="input-group" DefaultButton="btnSearch" OnClick="btnSearch_Click" runat="server">
                            <asp:TextBox runat="server" ID="txtKeyword" MaxLength="50" CssClass="form-control" placeholder="Search Dealer"></asp:TextBox>
                            <span class="input-group-btn">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Find Dealer" CssClass="btn btn-w-m btn-primary" OnClick="btnSearch_Click" />
                            </span>
                        </asp:Panel>
                    </div>
                </div>
            </div>
<div class="row">
                <div class="col-lg-12 ">
                    <div class="table-responsive">
                        <asp:GridView ID="gvDealerSales" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="There are no dealers found." OnPageIndexChanging="gvDealerSales_PageIndexChanging" OnLoad="Page_Load" >
                            <PagerStyle CssClass="pagination-ys"/>
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                                <asp:BoundField DataField="DealershipName" HeaderText="Dealership Name" SortExpression="DealershipName" />
                                <asp:BoundField DataField="DealerType" HeaderText="Dealer Type" SortExpression="DealerType" />
                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                <asp:BoundField DataField="CellphoneNumber" HeaderText="Cellphone Number" SortExpression="Cellphone" />
                                <asp:BoundField DataField="LandLine" HeaderText="LandLine" SortExpression="LandLine" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:BoundField DataField="Province" HeaderText="Province" SortExpression="Province" />
                                <%--<asp:BoundField DataField="QuotesPerMonth" HeaderText="Monthly Quotes" SortExpression="QuotesPerMonth" />--%>
                               <%-- <asp:TemplateField HeaderText="Quotes Status">
                                <ItemTemplate>
                                    <asp:Button ID="BtnQuote" runat="server" CausesValidation="false" CommandName="GotQuote"
                                        Text="Got Quote" CommandArgument='<%# Eval("DealerId") %>' /> 
                                </ItemTemplate>
                                </asp:TemplateField>
   --%>                             
<%--                                <asp:TemplateField ShowHeader="True"  HeaderText="Call Status">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Status"
                                            Text="Call Later" CommandArgument='<%# Eval("Status") %>' />
                                        <br>
                                        <br>
                                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandName="Status"
                                    Text="Not Available" CommandArgument='<%# Eval("Status") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Availability Status">
                                    
                                            <ItemTemplate>
                                                <%if (this.HasEditRight)
                                                    { %>
                                                <a href="#" id="aChangeStatus" class="cssStatus" onclick="OpenStatusPopup(this)" title="Click here to change status" data-parlourid='<%#Eval("parlourid") %>' data-id='<%#Eval("pkiMemberID")%>' data-status="<%#Eval("PolicyStatus")%>"><%#(Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %></a>
                                                <%}
                                                    else
                                                    { %>
                                                <asp:HyperLink runat="server" ID="hlPolicyStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/ManageMembersPayment.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                <%}  %>
                                            </ItemTemplate>--%>
                                 <%--<ItemTemplate>--%>
                                     <%--<asp:Button ID="Not_Available" ForeColor="Red" CssClass="Content2" runat="server" Text="Not Available" CommandName="Not_Available" />--%>
                                     <%--<br>--%>
                                     <%--<br>--%>
                                     <%--<asp:Button ID="Call_Later" runat="server" ForeColor="Blue" Text="Call Later" CommandName="Call_Later"/>--%>
                                 <%--</ItemTemplate>--%>
                                 <%--</asp:TemplateField>--%>
                                                 <%--<asp:TemplateField HeaderText="Availability Status">--%>
                                    <%--<ItemTemplate>--%>
                                    <%--<asp:LinkButton ID="Spoke_To_Dealer" ForeColor="Green" runat="server" Text="Spoke To Dealer" CommandName="Spoke_To_Dealer"/>
                                       <br />--%>
                                    <%--<asp:LinkButton ID="Not_Available" ForeColor="Red" runat="server" Text="Not Available" CommandName="Not_Available"/>--%>
                                        <%--<br>--%>
                                        <%--<br>--%>
                                    <%--<asp:LinkButton ID="Call_Later" runat="server" ForeColor="Blue" Text="Call Later" CommandName="Call_Later"/>--%>
                                    <%--</ItemTemplate>--%>
                                    <%--</asp:TemplateField>--%>
                                <asp:BoundField DataField="Comment" HeaderText="Comment" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" SortExpression="Comment" > 
                                                                                             
<HeaderStyle CssClass="visible-lg"></HeaderStyle>

<ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>
                                                                                             
                              <asp:TemplateField HeaderText="Edit Dealer">
                                            <ItemTemplate>
                                                <%if (!this.HasEditRight)
                                                { %>
                                                <asp:HyperLink runat="server" ToolTip='Click to edit dealer - ' ID="hrLink" NavigateUrl='<%#Eval("DealerId","~/Admin/ManageDealers.aspx?DealerId={0}")%>'><i class='fa fa-edit' style='font-size:48px;color:dodgerblue'></i></asp:HyperLink>
                                                &nbsp;
                                                <%}
                                                    //if (this.HasDeleteRight)
                                                    //{ %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                <%--<asp:CommandField ShowSelectButton="True" HeaderText="Edit Dealer" SelectText="Edit" />--%>
                                              
                                  <%--<asp:TemplateField HeaderText="Edit Dealer">--%>
                    <%--<ItemTemplate>--%>
                        <%--if (this.HasEditRight)
                                                //{ %>
                                               <%--<asp:HyperLink runat="server" ID="hyperLink" NavigateUrl='<%#Eval("DealerId", "~/Admin/ManageDealers.aspx?Id={0}") %>' Text="Edit">Edit</asp:HyperLink>--%>
                                               <%--&nbsp;--%>
                                               <%--<%}--%>


                                                   <%--{ %>--%>
                                                        <%--<asp:LinkButton runat="server" ID="linkBtn" OnClick="gvDealerSales_SelectedIndexChanged" Text='<%#Eval("DealerId","~/Admin/ManageDealers.aspx?Id={0}") %>' OnClientClick="gvDealerSales_SelectedIndexChanged">Edit</asp:LinkButton>--%>
                                                     <%--<%}--%>
                                                     <%--<asp:HyperLink Target = "_self" ID = "HyperLink1" runat = "server" NavigateUrl = "~/Admin/ManageDealers.aspx" Text = "Edit" Onclick="gvDealerSales_SelectedIndexChanged"> </asp:HyperLink>--%>
                        <%--<asp:LinkButton ID="linkbtn" runat="server" Text="Edit" OnClick="gvDealerSales_SelectedIndexChanged" NavigateUrl="~/Admin/ManageDealers.aspx" ></asp:LinkButton>--%>
                        <%--<asp:LinkButton runat="server" ID="linkBtn" PostBackUrl='<%#"~/Admin/ManageDealers.aspx?DealerId=" + Container.DataItemIndex %>'>Edit</asp:LinkButton>--%>
                    <%--</ItemTemplate>--%>
                <%--</asp:TemplateField>--%>

                                <%-- Commented by Gift 23Aug2019  --%>
                               <%--<asp:CommandField ShowSelectButton="True" HeaderText="Edit Dealer"  SelectText="Edit" />--%> 
                                <%--<asp:TemplateField HeaderText="Actions">--%>
                                     <%--<ItemTemplate>--%>
                                      <%-- %><asp:LinkButton ID="EditButton" CausesValidation="False" CommandName="Edit" runat="server" <%--CommandArgument='<%# Eval("Name") %>'--%>
                                            <%--CssClass="genericControl" Text="Edit"  <%--OnClick="EditButton_Click"--%>
                                         <%--</ItemTemplate>--%>
                                            <%--<ItemTemplate>--%>
                                                <%--<%if (this.HasEditRight)--%>
                                                <%--//{ %>--%>
                                                <%--<asp:HyperLink runat="server" ToolTip='Click here to Edit Dealer' ID="hrLink" NavigateUrl='<%#Eval("DealerId", "~/Admin/ManageDealers.aspx?Id={0}") %>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                <%--&nbsp;--%>
                                                <%--<%}--%>
                                                    <%--//if (this.HasDeleteRight)--%>
                                                    <%--//{ %>--%>
                                                        <%-- &nbsp;--%>
                                               <%-- <asp:LinkButton runat="server" ID="lbtnDelete" OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%#Eval("pkiMemberID")%>' CommandName="deleteMemeber"><i class="fa fa-trash-o"></i></asp:LinkButton>--%>
                                                <%--<asp:LinkButton runat="server" ID="lbtnDeleteDependatn" ToolTip="Click here To Delete Member" OnClientClick="return confirm('Are you sure you want to delete it?')" CommandArgument='<%#Eval("pkiMemberID") %>' CommandName="deleteMemeber"><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                               <%-- <%} %>--%>
                                            <%--</ItemTemplate>--%>
                                        <%--</asp:TemplateField>--%>
                                
                                 <%-- <asp:TemplateField HeaderText="Edit Dealer">
                                          <%--  <ItemTemplate>
                                                <%if (this.HasEditRight)
                                                    { %>
                                                <a href="#" id="aChangeStatus" class="cssStatus" onclick="OpenStatusPopup(this)" title="Click here to edit" data-parlourid='<%#Eval("parlourid") %>' data-id='<%#Eval("pkiMemberID")%>' data-status="<%#Eval("PolicyStatus")%>"><%#(Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %></a>
                                                <%}
                                                    else
                                                    { %>
                                                <asp:HyperLink runat="server" ID="hlDealerStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/ManageMembersPayment.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                <%}  %>
                                            </ItemTemplate>--%>
                                <%--</asp:TemplateField> --%>
                                <asp:BoundField DataField="DealerId" HeaderText="">
                                <ControlStyle ForeColor="White" />
                                <HeaderStyle Width="0px" />
                                <ItemStyle Width="0px" Font-Size="XX-Small" ForeColor="white" />
                                </asp:BoundField>
                            </Columns>
                                </asp:GridView>
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShortTremDevConnectionString %>" SelectCommand="SELECT [Name], [Surname], [DealershipName], [DealerType], [Comment], [Status], [CellphoneNumber], [Email],[Landline],[Province] FROM [DealerSales]"></asp:SqlDataSource>--%>
                        </div>
                     </div>
                 </div>
             </div>
           </div>
    </asp:Content>
