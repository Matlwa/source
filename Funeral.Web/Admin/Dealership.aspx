<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="Dealership.aspx.cs" Inherits="Funeral.Web.Admin.Dealership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ibox ">
        <div class="ibox-content">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
    <div class="col-lg-6">
                    <div class="form-group">
                        <label>Dealership Name  <em>*</em> </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtDealershipName" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtDealershipName" ID="RequiredFieldValidatorDealershipName" ForeColor="red" runat="server" Display="Dynamic" ErrorMessage="Please Enter Dealership Name"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegExp1" ValidationGroup="debitOrder" runat="server" ErrorMessage="Name Enter Only characters" ControlToValidate="txtDealershipName" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>LandLine </label>
                        <asp:TextBox MaxLength="10" runat="server" ID="txtLandLine" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtLandLine" ID="RequiredFieldValidatorLandLine" ForeColor="red" runat="server" ErrorMessage="Please Enter LandLine"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtLandLine" ErrorMessage="LandLine Enter Only Numbers" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
            </div>
                <div class="col-lg-12">
                 <%--<div class="form-group">--%>
                        <%--<label>Email </label>--%>
                        <%--<asp:TextBox MaxLength="25" runat="server" ID="txtEmail" name="name" type="text" class="form-control"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtEmail" ID="RequiredFieldValidator3" ForeColor="red" runat="server" ErrorMessage="Please enter Email"></asp:RequiredFieldValidator>--%>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtEmail" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    <%--</div>--%>
                     <div class="form-group">
                        <div class="btn-group">  
                      <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="SaveDealership" runat="server" Text="Save Dealership" OnClick="SaveDealership_Click"/>                         
                         </div>                                                    
                            </div>
                    </div>
                  
            </div>
                </div>
            </div>
    </asp:Content>