<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CarTrackSetup.aspx.cs" Inherits="Funeral.Web.Tools.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Car Track Setup</p>

        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Make&nbsp; </label>
                                <asp:TextBox MaxLength="25" runat="server" ID="makeTextBox" name="BranchName" type="text" class="form-control"></asp:TextBox>
                                <br />                                
                                <label>Model </label>
                                <asp:TextBox MaxLength="25" runat="server" ID="modelTextBox" name="line4" type="text" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Year&nbsp; </label>
                                <asp:TextBox MaxLength="15" runat="server" ID="yearTextBox" name="Phone" type="text" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Colour </label>
                                <asp:TextBox MaxLength="15" runat="server" ID="colourTextBox" name="CellPhone" type="text" class="form-control"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator Display="None" ValidationGroup="BranchSetup" ControlToValidate="txtCellPhone" ID="RequiredFieldValidator4" ForeColor="red" runat="server" ErrorMessage="Please enter cell number"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="btn-group">
                    <asp:Button runat="server" ID="saveButton" ValidationGroup="" CssClass="btn btn-sm btn-primary" Text="Save" />
                </div>
            </div>
        </div>
    <p>
        <asp:GridView ID="carSetupGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" EmptyDataText="There are no jobs to display." Width="100%">
            <PagerStyle CssClass="pagination-ys" />
            <Columns>
                                                        <%--<asp:BoundField DataField="pkiProductID" HeaderText="ID" ReadOnly="True" />--%>
                                                        <asp:BoundField DataField="ProductName" HeaderText="ProductName Name" ReadOnly="True" />
                <asp:BoundField DataField="ProductCost" HeaderText="Product Cost" ReadOnly="True" />
                <asp:BoundField DataField="ProductDesc" HeaderText="Descriptions" ReadOnly="True" />
                <asp:BoundField DataField="ModifiedUser" HeaderText="Modified User" ReadOnly="True" />
                <asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HeaderStyle-CssClass="visible-lg" HeaderText="Modified date" ItemStyle-CssClass="visible-lg" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%#Eval("pkiProductID")%>' CommandName="EditAddon" ToolTip="Click here to Edit - "><i class="fa fa-edit"></i></asp:LinkButton>
                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%#Eval("pkiProductID")%>' CommandName="deleteAddon" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="fa fa-trash-o"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">
</asp:Content>
