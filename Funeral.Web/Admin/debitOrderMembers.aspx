<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="debitOrderMembers.aspx.cs" Inherits="Funeral.Web.Admin.debitOrderMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">
        #MainContent_btnSaveDebitOrder {
            background-color: red;
        }

        em {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ibox ">
        <div class="ibox-content">
             <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="input-group">
                            <asp:ValidationSummary runat="server" ID="ValidationSummary" ValidationGroup="debitOrder" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label>Name  <em>*</em> </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtName" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtName" ID="RequiredFieldValidator1" ForeColor="red" runat="server" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="None" ID="RegExp1" ValidationGroup="debitOrder" runat="server" ErrorMessage="Name Enter Only characters" ControlToValidate="txtName" ValidationExpression="[a-zA-Z ]*$" />
                    </div>
                    <div class="form-group">
                        <label>Surname  <em>*</em>  </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtSurname" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtSurname" ID="RequiredFieldValidator2" ForeColor="red" runat="server" ErrorMessage="Please enter Surname"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />
                    </div>
                    <div class="form-group">
                        <label>ID Number <em>*</em>  </label>
                        <asp:TextBox MaxLength="50" runat="server" ID="txtIdNumber" name="name" type="text" class="form-control" onkeyup="DateComparisionJavascriptFun();"></asp:TextBox>

                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtIdNumber" ID="rfvIdnumber" ForeColor="red" runat="server" ErrorMessage="Please enter id number"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ErrorMessage="Invalid Id Number" ID="cvIdvalidation" OnServerValidate="cvIdvalidation_ServerValidate" ControlToValidate="txtIdNumber" ValidationGroup="debitOrder" runat="server" />

                    </div>
                    <div class="form-group">
                        <label>Date of Birth </label>
                        <asp:TextBox MaxLength="30" runat="server" ID="txtBirthDay" name="name" type="text" class="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Passport</label>
                        <asp:TextBox MaxLength="30" runat="server" ID="txtPassport" name="txtPassport" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="debitOrder" ControlToValidate="txtPassport" ID="rfvPassport" ForeColor="red" runat="server" ErrorMessage="Enter Passport Number"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Policy Number</label>
                        <asp:TextBox MaxLength="30" runat="server" ID="txtPolicyNumber" name="txtPolicyNumber" type="text" class="form-control" ReadOnly="false"></asp:TextBox>                   
                    </div>
                    <div class="form-group">
                        <asp:CheckBox ID="chkIdORPass" runat="server" Text="Either Allow Passport Number Or ID Number" AutoPostBack="true" OnCheckedChanged="IdorPass_chkEvent" />
                    </div>
                </div>
                <div class="col-lg-6">
                   <%-- <div class="form-group">
                        <label>Account Holder <em>*</em></label>
                        <asp:TextBox MaxLength="50" runat="server" ID="txtAccountholder" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtAccountholder" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please enter Account Holder"></asp:RequiredFieldValidator>

                    </div>--%>
                     <div class="form-group">
                        <label>Premium <em>*</em></label>
                        <asp:TextBox MaxLength="50" runat="server" ID="txtPremium" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtPremium" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please enter Premium Amount"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Bank Name <em>*</em></label>

                        <asp:DropDownList ID="ddlBank" InitialValue="-1" runat="server" DataTextField="BankName" DataValueField="BranchCode" CssClass="form-control m-b">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" InitialValue="-1" ValidationGroup="debitOrder" ControlToValidate="ddlBank" ID="RequiredFieldValidator35" ForeColor="red" runat="server" ErrorMessage="Please Select Bank"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Branch Code <em>*</em></label>
                        <asp:TextBox MaxLength="50" runat="server" ID="txtBranchcode" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtBranchcode" ID="RequiredFieldValidator3" ForeColor="red" runat="server" ErrorMessage="Please enter Branch Code"></asp:RequiredFieldValidator>
                        <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                    </div>
                    <div class="form-group">
                        <label>Account Number <em>*</em></label>
                        <asp:TextBox MaxLength="50" runat="server" ID="txtAccountno" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtAccountno" ID="RequiredFieldValidator7" ForeColor="red" runat="server" ErrorMessage="Please enter Account Number"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Account Type <em>*</em></label>
                        <asp:DropDownList runat="server" ID="ddlAccountType" InitialValue="-1" DataTextField="AccountType" DataValueField="AccountTypeID" class="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" InitialValue="-1" ValidationGroup="debitOrder" ControlToValidate="ddlAccountType" ID="RequiredFieldValidator8" ForeColor="red" runat="server" ErrorMessage="Please select Account Type"></asp:RequiredFieldValidator>

                    </div>
                     <div class="form-group">
                    <%-- <label class="" >First Debit Date </label>--%>
                     <%--<asp:RequiredFieldValidator ValidationGroup="pnlPolicyStatus" ID="RequiredFieldValidator30" ForeColor="Red" ControlToValidate="txtPolicyDateTo" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                     <%--<asp:TextBox CssClass="form-control datepicker" placeholder="DD/MM/YYYY" ID="txtDebitDate1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" InitialValue="-1" ValidationGroup="debitOrder" ControlToValidate="txtDebitDate1" ID="RequiredFieldValidator9" ForeColor="red" runat="server" ErrorMessage="Please select Debit Date"></asp:RequiredFieldValidator>
                          </div>--%>
                   <div class="form-group">
                       <asp:TextBox MaxLength="30" runat="server" ID="txtDebitdate" name="name" type="text" class="form-control" Enabled="False" Visible="False"></asp:TextBox>
                        <%--<label>Debit Date <em>*</em> </label>--%>
                       <label>First Debit Date<em>*</em> </label>
                        <asp:DropDownList ID="ddlDebitDate" class="form-control" runat="server">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">1st</asp:ListItem>
                            <asp:ListItem Value="15">15th</asp:ListItem>
                             <asp:ListItem Value="23">23rd</asp:ListItem>
                            <asp:ListItem Value="25">25th</asp:ListItem>
                             <asp:ListItem Value="26">26th</asp:ListItem>
                             <asp:ListItem Value="28">28th</asp:ListItem>
                        </asp:DropDownList>
                       
                        <asp:RequiredFieldValidator Display="None" InitialValue="0" ValidationGroup="debitOrder" ControlToValidate="ddlDebitDate" ID="RequiredFieldValidator10" ForeColor="red" runat="server" ErrorMessage="Please select Debit Date"></asp:RequiredFieldValidator>
                   </div>
                </div>
                    
                            </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="btn-group">
                            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" OnClick="btnSaveDebitOrder_Click" ID="btnSaveDebitOrder" ValidationGroup="debitOrder" runat="server" Text="Submit" />
                        </div> 
                        <%--<div class="btn-group">
                            <asp:Button class="btn btn-sm btn-primary pull-left m-t-n-xs" OnClick="CancelPolicy" ID="BtnCancelPolicy" runat="server" Text="Cancel Policy" />
                        </div>--%>                       
                    </div>
                </div>

            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <div class="input-group">
                            <label>Show entries</label>
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
                            
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Search Clients:</label>
                        <asp:Panel ID="pnlSearch" CssClass="input-group" DefaultButton="btnSearch" runat="server">
                            <asp:TextBox runat="server" ID="txtKeyword" MaxLength="50" CssClass="form-control" placeholder="Search by keyword"></asp:TextBox>
                            <span class="input-group-btn">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-w-m btn-primary" OnClick="btnSearch_Click" />
                            </span>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 ">
                    <div class="table-responsive">
                        <asp:GridView ID="gvDebitOrderMembers" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="25" OnPageIndexChanging="gvDebitOrderMembers_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="There are no member found.">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:BoundField DataField="FullNames" HeaderText="Name" ReadOnly="True" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" ReadOnly="True" />
                                <asp:BoundField DataField="IDNumber" HeaderText="ID Number" ReadOnly="True" />
                                <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" ReadOnly="True" />
                                <asp:BoundField DataField="Bank" HeaderText="Bank" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" ReadOnly="True" />
                                <%--<asp:BoundField DataField="Premium" HeaderText="Premium" ReadOnly="True" />--%>
                                <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" ReadOnly="True" />
                                <asp:BoundField DataField="AccountType" HeaderText="Account Type" ReadOnly="True" />
                                <asp:BoundField DataField="DebitDate" HeaderText="Debit Date" ReadOnly="True" />
                                <asp:ButtonField ButtonType="Link" HeaderText="Policy Details" runat="server" Text="Edit" CommandName="Edit_Policy"/>

                                 <%--<asp:TemplateField HeaderText="Policy Status">
                                            <ItemTemplate>
                                               <%if (this.HasEditRight)
                                                    { %>
                                                <a href="#" id="aChangeStatus" class="cssStatus" onclick="OpenStatusPopup(this)" title="Click here to change status" data-parlourid='<%#Eval("parlourid") %>' data-id='<%#Eval("pkiMemberID")%>' data-status="<%#Eval("PolicyStatus")%>"><%#(Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %></a>
                                                <%}
                                                    else
                                                    { %>
                                                <asp:HyperLink runat="server" ID="hlPolicyStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/debitOrderMembers.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                <%}  %>
                                            </ItemTemplate>
                                    <%-- <ItemTemplate>
                                         <asp:LinkButton ID="ButtonCancel" runat="server" Text="Cancel" />
                                     </ItemTemplate>--%>
                                           <%--<ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hlPolicyStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/ManageMembersPayment.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                            </ItemTemplate>--%>
                                       <%-- </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
         <%--<asp:HiddenField runat="server" ID="hdnMemberId" />
    <asp:HiddenField runat="server" ID="hdnOldStatus" />
    <asp:HiddenField runat="server" ID="hdnParlourId" />--%>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">
    <script>
        $('#').find("tr:gt(0)").remove();
        $("#<%=txtBirthDay.ClientID %>").datepicker({ format: 'dd MM yyyy' });
        debugger;
        <%--$("#<%=txtDebitDate1.ClientID %>").datepicker({ format: 'dd MM yyyy' });--%>
        $("#<%=ddlBank.ClientID%>").change(function () {
            $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());
        });
        function FillBankAjaxdata() {
            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("~/admin/ManageMember.aspx/ddlbank_Changed")%>',
                data: '{"id":"' + $('#<%=ddlBank.ClientID%>').val() + '"}',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var lbl = $(this).val();
                    if (lbl == "-1") {
                        openModal();
                        FillBankAjaxdata();
                        $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());
                    }
                    else {
                        $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());
                        // alert(lbl.val());
                    }
                    alert("good");
                    <%--$('#<%=txtPremium.ClientID%>').val(data.d);--%>
                    <%--  $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());--%>
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
</asp:Content>
