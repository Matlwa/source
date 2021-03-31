<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="ResetPassword.aspx.cs" Inherits="Funeral.Web.Admin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ibox ">
        <div class="ibox-content">
            <div class="row">
                <label>User Name</label>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                 </div>
            <div class="form-group">
                        <div class="btn-group">
                <asp:Button runat="server" Text="Reset Password"></asp:Button>
                            </div>
                </div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                  
            </div>
        </div>
</asp:Content>
