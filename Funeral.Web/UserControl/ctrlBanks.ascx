<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlBanks.ascx.cs" Inherits="Funeral.Web.UserControl.ctrlBanks" %>
<div class="col-sm-12">
    
        <div class="form-group">
            <label>Bank Name  <em>*</em> </label>
            <asp:TextBox MaxLength="100" runat="server" ID="txtBankname" name="name" type="text" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtBankname" ValidationGroup="AddBank" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please enter Bank name"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="AddBank" runat="server" ErrorMessage="Bank Name Enter Only characters" ControlToValidate="txtBankName" ValidationExpression="[a-zA-Z ]*$" />
        </div>
        <div class="form-group">
            <label>Branch Code  <em>*</em> </label>
            <asp:TextBox MaxLength="50" runat="server" ID="txtBankBranchCode" name="name" type="text" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtBankBranchCode" ValidationGroup="AddBank" ID="RequiredFieldValidator7" ForeColor="red" runat="server" ErrorMessage="Please enter Branch Code"></asp:RequiredFieldValidator>
        </div>

        <div class="btn-group">
            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="True" ValidationGroup="AddBank" ID="btnBankAdd" runat="server" Text="Save" OnClick="btnSaveBank_Click" />
        </div>

        <div class="col-sm-12">
            <div class="table-responsive">
                <asp:GridView ID="gvBanks" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                    <%-- OnRowDataBound="gvBanks_OnRowDataBound" 
                    AllowPaging="true" PageSize="25" OnPageIndexChanging="gvBanks_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="There are no Banks."
                    OnRowCommand="gvBanks_RowCommand">--%>
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="BankId" HeaderText="ID" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                        <asp:BoundField DataField="BankName" HeaderText="BAnk Name" ReadOnly="True" />
                        <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                &nbsp;
                                 <asp:LinkButton runat="server" ID="LinkButton1" ToolTip="Click here  " CommandArgument='<%#Eval("BankId") %>' CommandName="EditBank"><i class="glyphicon glyphicon-print"></i></asp:LinkButton>

                                <%--<asp:LinkButton runat="server" ID="LinkButton2" ToolTip="Click here Print " CommandArgument='<%#Eval("InvoiceID") %>' CommandName="PrintFullPremium"><i class="glyphicon glyphicon-export"></i></asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</div>