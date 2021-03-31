<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDealers.aspx.cs" Inherits="Funeral.Web.Admin.DealershipList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">
        #MainContent_Button1 {
            background-color: cornflowerblue;
            float:inherit;
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
            $('#DealerSales').dataTable({
                "oLanguage": { "sSearch": "Search Dealers:" },
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
                <div class="col-sm-12">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </div>
            </div>
    <div class="col-lg-6">
                    <div class="form-group">
                        <label>Name  <em>*</em> </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtName" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="debitOrder" ControlToValidate="txtName" ID="RequiredFieldValidator1" ForeColor="red" runat="server" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="None" ID="RegExp1" ValidationGroup="debitOrder" runat="server" ErrorMessage="Name Enter Only characters" ControlToValidate="txtName" ValidationExpression="[a-zA-Z ]*$" />
                    </div>
        <div class="form-group">
                        <label>Surname  <em>*</em>  </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtSurname" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="debitOrder" ControlToValidate="txtSurname" ID="RequiredFieldValidator2" ForeColor="red" runat="server" ErrorMessage="Please enter Surname"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />
                    </div>
        <div class="form-group">
                        <label>Landline <em>*</em> </label>
                        <asp:TextBox MaxLength="10" runat="server" ID="txtLandline" name="name" type="Integer" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtLandline" ID="RequiredFieldValidator3" ForeColor="red" runat="server" ErrorMessage="Please Enter LandLine"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>Cell Number <em>*</em> </label>
                        <asp:TextBox MaxLength="10" runat="server" ID="txtCellNumber" name="name" type="Integer" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtCellNumber" ID="RequiredFieldValidator4" ForeColor="red" runat="server" ErrorMessage="Please Enter Cell Number"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtEmail" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="debitOrder" ControlToValidate="txtEmail" ID="RequiredFieldValidator5" ForeColor="red" runat="server" ErrorMessage="Please Enter Email"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator4" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
      <%--  <div class="form-group">

                        <div class="btn-group">                        
                            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="Button3" ValidationGroup="debitOrder" runat="server" Text="Not Available" />
                         </div>
                        <div class="btn-group"> 
                            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="Button1" ValidationGroup="debitOrder" runat="server" Text="Spoke to Dealer" />
                            </div>
                            <div class="btn-group"> 
                            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="Button2" ValidationGroup="debitOrder" runat="server" Text="Call Later" />                                                        
                             </div>
                                
                            </div>--%>
        </div>

        <div class="col-lg-6">
        <div class="form-group">
                        <label>Dealership Name <em>*</em> </label>
                        <%--<asp:TextBox MaxLength="25" runat="server" ID="txtDealershipName" name="name" type="text" class="form-control"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="ddlDealershipName" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please Enter Dealership Name"></asp:RequiredFieldValidator>--%>
                       <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator5" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                   
            <asp:DropDownList ID="ddlDealerships" runat="server" CssClass="form-control"> </asp:DropDownList>
        </div>
        <div class="form-group">
         <label>Dealer Type </label>
                        <asp:DropDownList ID="ddlDealerType" class="form-control" runat="server">
                           <%-- <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="1">Salesman</asp:ListItem>
                            <asp:ListItem Value="2">FNI</asp:ListItem>
                             <asp:ListItem Value="3">Spotter</asp:ListItem>--%>
                        </asp:DropDownList>
            </div>
            <div class="form-group">
         <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                           <%-- <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Silver</asp:ListItem>
                            <asp:ListItem Value="2">Gold</asp:ListItem>
                             <asp:ListItem Value="3">Platinum</asp:ListItem>--%>
                        </asp:DropDownList>
       </div>
            <div class="form-group">
         <label>Province</label>
                        <%--<asp:DropDownList ID="ddlProvince" class="form-control" runat="server">
                            <asp:ListItem Value="-1">Select Province</asp:ListItem>
                            <asp:ListItem Value="0">Gauteng</asp:ListItem>
                            <asp:ListItem Value="1">Mpumalanga</asp:ListItem>
                            <asp:ListItem Value="2">North West</asp:ListItem>
                            <asp:ListItem Value="3">Northern Cape</asp:ListItem>
                            <asp:ListItem Value="4">KwaZulu-Natal</asp:ListItem>
                            <asp:ListItem Value="5">Western Cape</asp:ListItem>
                            <asp:ListItem Value="6">Limpopo</asp:ListItem>
                            <asp:ListItem Value="7">Eastern Cape</asp:ListItem>
                            <asp:ListItem Value="8">Free State</asp:ListItem>
                        </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlProvince" class="form-control" runat="server"></asp:DropDownList>
       </div>
            <div class="form-group">
             <label>Comment Here</label>
        <div class="form-group">          
        <asp:TextBox ID="txtComment" runat="server" Height="200px" TextMode="MultiLine" Width="500px"></asp:TextBox>
        </div>
                <div class="btn-group">                                  
                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="btnEnter" ValidationGroup="debitOrder" runat="server" Text="Save" OnClick="btnEnter_Click" style="height: 29px" />
                    </div>
                </div>
        </div>
   
       
            <%--<div class="btn-class">     
        <asp:Button ID="btn_Submit" runat="server" Text="Save Comment" CssClass="buttonSubmit" background-color="green"/>     
        </div>--%>
        


    <%--<div class="row">

        <div class="col-lg-13">

                    
                </div>
            </div>  
            <br /><br />--%>

            <div class="row">  
                 <div class="col-sm-6">
                    <div class="form-group">
                        <div class="input-group">
                            <label>Show Entries</label>
                            <asp:DropDownList AutoPostBack="true" ID="ddlPageSize" CssClass="form-control" runat="server" >
                                <asp:ListItem>5</asp:ListItem>
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
                        <label>Search Clients:</label>
                        <asp:Panel ID="pnlSearch" CssClass="input-group" DefaultButton="btnSearch" runat="server">
                            <asp:TextBox runat="server" ID="txtKeyword" MaxLength="50" CssClass="form-control" placeholder="Search by keyword"></asp:TextBox>
                            <span class="input-group-btn">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-w-m btn-primary" />
                            </span>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 ">
                    <div class="table-responsive">
                        <asp:GridView ID="gvDealerSales" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="25" AutoGenerateColumns="False" EmptyDataText="There are no member found." DataSourceID="SqlDataSource1" OnSelectedIndexChanged="gvDealerSales_SelectedIndexChanged">
                            <PagerStyle CssClass="pagination-ys" />
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
                              <%--  <asp:TemplateField HeaderText="Call Status">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="Spoke_To_Dealer" ForeColor="Green" runat="server" Text="Spoke To Dealer" CommandName="Spoke_To_Dealer"/>
                                        <br />

                                    <asp:LinkButton ID="Not_Available" ForeColor="Red" runat="server" Text="Not Availabe" CommandName="Not_Available"/>
                                    <br />

                                    <asp:LinkButton ID="Call_Later" runat="server" ForeColor="Blue"  Text="Call Later" CommandName="Call_Later"/>
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <asp:BoundField DataField="Comment" HeaderText="Comment" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" SortExpression="Comment" />                                                              
                                <%--<asp:TemplateField HeaderText="Edit Dealer">--%>
                                   <%--<ItemTemplate><asp:Button ID="btnEdit" OnClick="gvDealerSales_SelectedIndexChanged" runat="server" Text="Edit" /></ItemTemplate>--%>
                                <%--</asp:TemplateField>--%>
                                <%--<asp:CommandField ShowSelectButton="True" HeaderText="Edit Dealer"/>--%> <%--uncomment later--%> 
                                <%--<asp:TemplateField HeaderText="Actions">--%>
                                     <%--<ItemTemplate>
                                      <asp:LinkButton ID="EditButton" CausesValidation="False" CommandName="Edit" runat="server" <%--CommandArgument='<%# Eval("Name") %>'--%>
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
                            </Columns>
                                </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShortTremDevConnectionString %>" SelectCommand="SELECT [Name], [Surname], [DealershipName], [DealerType], [Comment], [Status], [CellphoneNumber], [Email],[Landline],[Province] FROM [DealerSales]"></asp:SqlDataSource>
                        </div>
                     </div>
                 </div>
                </div>        
        </div>   
    <script>
      <%--   function OpenStatusPopup(ctrl) {
            $("#<%=ddlStatus.ClientID%>").val($(ctrl).data("status"))
            $("#<%=hdnMemberId.ClientID%>").val($(ctrl).data("id"))
            $("#<%=hdnOldStatus.ClientID%>").val($(ctrl).data("status"));
             $("#<%=hdnParlourId.ClientID%>").val($(ctrl).data("parlourid"));
            $('#dvChangeStatusModel').modal('show');
        }--%>
    </script>                   
</asp:Content>