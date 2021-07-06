<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="Dealers.aspx.cs" Inherits="Funeral.Web.Admin.FindDealer" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">     
        em {
            color: red;
        }    

        em {
            color: red;
        }   

        em {
            color: red;
        }
    </style>
</asp:Content>
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
                        <label>Name  <em>*</em> </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtName" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtName" ID="RequiredFieldValidatorName" ForeColor="red" runat="server" ErrorMessage="Please Enter Dealer Name"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegExp1" ValidationGroup="debitOrder" runat="server" ErrorMessage="Name Enter Only characters" ControlToValidate="txtName" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>Surname  <em>*</em>  </label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtSurname" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtSurname" ID="RequiredFieldValidatorSurname" ForeColor="red" runat="server" ErrorMessage="Please Enter Dealer Surname"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>Landline</label>
                        <asp:TextBox MaxLength="10" runat="server" ID="txtLandline" name="name" type="Integer" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtLandline" ID="RequiredFieldValidatorLandLine" ForeColor="red" runat="server" ErrorMessage="Please Enter LandLine"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorLandLine" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtLandLine" ErrorMessage="Please Enter LandLine" />--%>
                    </div>
        <div class="form-group">
                        <label>Cell Number</label>
                        <asp:TextBox MaxLength="10" runat="server" ID="txtCellNumber" name="name" type="Integer" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtCellNumber" ID="RequiredFieldValidatorCellNumber" ForeColor="red" runat="server" ErrorMessage="Please Enter Cell Number"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
        <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox MaxLength="25" runat="server" ID="txtEmail" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtEmail" ID="RequiredFieldValidatorEmail" ForeColor="red" runat="server" ErrorMessage="Please Enter Email"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator4" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
                    </div>
    
        </div>

        <div class="col-lg-6">
        <div class="form-group">
                        <label>Dealership Name</label>
                        <%--<asp:TextBox MaxLength="25" runat="server" ID="txtDealershipName" name="name" type="text" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="None" ValidationGroup="debitOrder" ControlToValidate="txtSurname" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please enter Surname"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator5" ValidationGroup="debitOrder" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />--%>
            <asp:DropDownList ID="ddlDealerships" class="form-control" runat="server"></asp:DropDownList>
                    </div>
        <div class="form-group">
         <label>Dealer Type </label>
                        <asp:DropDownList ID="ddlDealerType" class="form-control" runat="server">
                            <%--<asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="1">Salesman</asp:ListItem>
                            <asp:ListItem Value="2">FNI</asp:ListItem>
                             <asp:ListItem Value="3">Spotter</asp:ListItem>--%>
                        </asp:DropDownList>
            </div>
            <div class="form-group">
         <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                            <%--<asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Silver</asp:ListItem>
                            <asp:ListItem Value="2">Gold</asp:ListItem>
                             <asp:ListItem Value="3">Platinum</asp:ListItem>--%>
                        </asp:DropDownList>
       </div>
            <div class="form-group">
         <label>Province</label>
                        <asp:DropDownList ID="ddlProvince" class="form-control" runat="server">
                            <asp:ListItem Value="-1">Select Province</asp:ListItem>
                          <%--  <asp:ListItem Value="0">Gauteng</asp:ListItem>
                            <asp:ListItem Value="1">Mpumalanga</asp:ListItem>
                            <asp:ListItem Value="2">North West</asp:ListItem>
                            <asp:ListItem Value="3">Northern Cape</asp:ListItem>
                            <asp:ListItem Value="4">KwaZulu-Natal</asp:ListItem>
                            <asp:ListItem Value="5">Western Cape</asp:ListItem>
                            <asp:ListItem Value="6">Limpopo</asp:ListItem>
                            <asp:ListItem Value="7">Eastern Cape</asp:ListItem>
                            <asp:ListItem Value="8">Free State</asp:ListItem>--%>
                        </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvince" runat="server" 
            ErrorMessage="Please Select Province" ForeColor="Red"
            ControlToValidate="ddlProvince" InitialValue="-1" Display="Dynamic" >
            </asp:RequiredFieldValidator>
       </div>    
                <div class="form-group">

                        <div class="btn-group">                        
                            <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="btnSaveDealer" ValidationGroup="debitOrder" runat="server" Text="Save Dealer" OnClick="btnSaveDealer_Click" />
                         </div>                                                    
                            </div>        
        </div>

   </div>
        </div>
    </div>
</asp:Content>