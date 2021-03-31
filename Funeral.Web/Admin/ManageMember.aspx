<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="Funeral.Web.Admin.ManageMember" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/UserControl/ctrlBanks.ascx" TagName="ucBanks" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style type="text/css">
        input[type=radio] {
            margin-left: 4px !important;
        }

        #MainContent_btnSave {
            background-color: red;
        }

        em {
            color: red;
        }

        /*.popup, #popup {
            position: fixed;
            width: 350px;
            height: 171px;
            top: 24%;
            left: 33%;
            margin: 0 auto;
            text-align: center;          
            background-color: white;
            display: none;
        }*/

        #poptable {
            margin: 25px;
        }

            #poptable td, #poptable tr, #poptable td input[type=text] {
                margin: 10px;
            }

        .noteHead {
            width: 100%;
        }

            .noteHead h3 {
                float: left;
            }

        .noteDate {
            float: right;
            margin-right: 5px;
        }

        .noteContainer {
            margin-top: 44px;
            float: left;
        }

        #ddlDependencyTypeFormInput, #ddlDependencyRelationshipFormInput {
            max-width: 60% !important;
        }

        #NotePopUp {
            width: 50%;
            height: 50%;
            z-index: 5000;
            position: fixed;
            background-color: white;
            top: 22%;
            left: 25%;
            padding: 12px;
            display: none;
        }

        #NotePopUpWrap {
            height: 100%;
            width: 100%;
            position: fixed;
            z-index: 4000;
            background-color: black;
            opacity: .7;
            display: none;
            top: 0;
            left: 0;
        }

        .NoteCss {
            float: right;
            margin-right: 50Px;
        }
        .Bankmodal {
            width: 1000px;
            left: 20% !important;
            top: 13% !important;
          
        }

        /*.modalPopup {
            top: 20%;
            background-color: #FFFFFF;
            width: 500px;
            height: auto;
            border-radius: 5px;
            position: fixed;
            font-size: 12px;
            margin: 0 auto;
          
        }

   .modal-backdrop {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 30px !important;
    left: 47px !important;
    z-index: 1040;
    background-color: #000;
}
        .modal-backdrop.in{
            opacity:0;
                               }*/
    </style>
    <style type="text/css">
        .modal {
            width: 1000px;

            position: absolute;
            top: -1%;
            left: 20%;
            position: absolute;
            top: 50%;
            left: 32%;

            /*top: 22% !important;*/
            /*left: 16% !important;*/
            /* left:18% !important;*/
        }

        #TaskFollowUpModel {
            left: 12% !important;
        }

        /*#AgentInfoModel {
            left: 13% !important;
        }*/

        .closePopUp {
            float: right;
            color: #676a6c;
            margin-right: 3px;
            cursor: pointer;
        }

        .PanelHeder {
            background-color: red;
            color: white;
            padding: 10px !important;
            margin: -10px !important;
        }

        .TabColor {
            background-color: #ED1C24;
            color: aliceblue;
        }

        td {
            cursor: pointer;
        }

        input[type="radio"] {
            margin: 5px;
             }
        .PolicyDoc{
            top:20% !important;
            overflow-x:no-content !important;
            overflow-y:no-content !important;
            left:15% !important;

               }
        .PolicyDoc .modal-open .modal {
    overflow-x: hidden;
   
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:HiddenField ID="TabName" runat="server" />
            <asp:HiddenField ID="hdnNoteId" runat="server" />
            <asp:HiddenField ID="hdnProductId" runat="server" />
        </div>
        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>
                        <asp:Label ID="lblCientDetails" runat="server" Text="Client Details"></asp:Label>
                    </h5>
                    <asp:HiddenField runat="server" ID="hdnId" />
                    <asp:HiddenField runat="server" ID="hdnId1" />
                    <div class="pull-right">
                        <div class="btn-group">
                            <asp:Button runat="server" ID="PolicyDoc" ValidationGroup="tab3" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Policy Doc" OnClick="PolicyDoc_Click" />
                            <!--<asp:Button runat="server" ID="PolicyDocPrint" ValidationGroup="tab3" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Policy Doc Print" OnClick="PolicyDocPrint_Click" />-->
                        &nbsp;&nbsp;
                            <asp:Button runat="server" ID="EmailPolicyDoc" ValidationGroup="tab3" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Email Policy Doc" OnClick="EmailPolicyDoc_Click" />
                            <br />
                        </div>
                    </div>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="panel blank-panel">
                            <div class="panel-heading">
                                <div class="panel-options" id="Tabs">
                                    <ul class="nav nav-tabs" id="myTab">
                                        <li class="active" id="tab1"><a data-toggle="tab" href="#tab-1" aria-expanded="true">Personal Details</a></li>
                                        <li class="" id="tab2"><a data-toggle="tab" href="#tab-2" aria-expanded="false">Risk Address</a></li>
                                        <li class="" id="tab3"><a data-toggle="tab" href="#tab-3" aria-expanded="false">Policy Details</a></li>
                                        <li class="" id="tab5"><a data-toggle="tab" href="#tab-5" aria-expanded="false">Vehicles</a></li>
                                        <li class="" id="tab4"><a data-toggle="tab" href="#tab-4" aria-expanded="false">Debit Order Details</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div id="tab-1" class="tab-pane active">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <asp:ValidationSummary runat="server" ID="vSummaryTab1" ValidationGroup="tab1" ForeColor="Red" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label>Last Name  <em>*</em> </label>
                                                    <asp:TextBox MaxLength="25" runat="server" ID="txtLastName" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab1" ControlToValidate="txtLastName" ID="RequiredFieldValidator1" ForeColor="red" runat="server" ErrorMessage="Please enter Last name"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display="None" ID="RegExp1" ValidationGroup="tab1" runat="server" ErrorMessage="Last Name Enter Only characters" ControlToValidate="txtLastName" ValidationExpression="[a-zA-Z ]*$" />
                                                </div>
                                                <div class="form-group">
                                                    <label>First Name  <em>*</em>  </label>
                                                    <asp:TextBox MaxLength="25" runat="server" ID="txtFirstname" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab1" ControlToValidate="txtFirstName" ID="RequiredFieldValidator2" ForeColor="red" runat="server" ErrorMessage="Please enter first name"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" ValidationGroup="tab1" runat="server" ControlToValidate="txtFirstname" ErrorMessage="First Name Enter Only characters" ValidationExpression="[a-zA-Z ]*$" />
                                                </div>
                                                <div class="form-group">
                                                    <label>ID Number <em>*</em>  </label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtIdNumber" name="name" type="text" class="form-control" onkeyup="DateComparisionJavascriptFun();"></asp:TextBox>
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit ' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkAddonProductID="+Eval("pkiMemberProductID")%>'></asp:HyperLink>
                                                                    <asp:HyperLink OnClientClick="return confirm('Are you sure want to delete?');" runat="server" ToolTip='Delete' ID="HyperLink2" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkInoteIDRemove="+Eval("pkiMemberProductID")%>'><i class="fa fa-trash"></i></asp:HyperLink>--%>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab1" ControlToValidate="txtIdNumber" ID="rfvIdnumber" ForeColor="red" runat="server" ErrorMessage="Please enter id number"></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ErrorMessage="Invalid Id Number" ID="cvIdvalidation" OnServerValidate="cvIdvalidation_ServerValidate" ControlToValidate="txtIdNumber" ValidationGroup="tab1" runat="server" />
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleTrackingCompany" ID="RequiredFieldValidator42" ForeColor="red" runat="server" ErrorMessage="Please enter Vehicle tracking company" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Date of Birth </label>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtBirthDay" name="name" type="text" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Age</label>
                                                    <asp:TextBox MaxLength="4" runat="server" ID="txtAge" ReadOnly="true" Text="Will be Calculated From Date Of Birth" name="txtAge" type="text" class="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleTrackingCompany" ID="RequiredFieldValidator42" ForeColor="red" runat="server" ErrorMessage="Please enter Vehicle tracking company" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Gender</label>
                                                    <asp:RadioButtonList CssClass="radio radiogroup " RepeatDirection="Horizontal" ID="rbtnlGender" runat="server">
                                                        <asp:ListItem Selected="True" Value="0">Male</asp:ListItem>
                                                        <asp:ListItem Value="1">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Cellphone Number  <em>*</em>  </label>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleEngNo" ID="RequiredFieldValidator39" ForeColor="red" runat="server" Display="None" ErrorMessage="Please enter Vehicle No."></asp:RequiredFieldValidator>--%>
                                                    <asp:TextBox MaxLength="20" runat="server" ID="txtCellphone" name="txtCellphone" type="text" class="form-control"></asp:TextBox>
                                                    <%#Eval("Surname") %>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab1" ControlToValidate="txtCellphone" ID="RequiredFieldValidator3" ForeColor="red" runat="server" ErrorMessage="Please enter Cellphone Number"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" ValidationGroup="tab1" runat="server" ControlToValidate="txtCellphone" ErrorMessage="Cellphone Number Enter Only Number" ValidationExpression="^[0-9]+$" />
                                                </div>
                                                <div class="form-group">
                                                    <label>Telephone Number</label>
                                                    <asp:TextBox MaxLength="20" runat="server" ID="txtTelePhone" name="txtTelePhone" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" ValidationGroup="tab1" runat="server" ControlToValidate="txtTelePhone" ErrorMessage="Telephone Number Enter Only Number" ValidationExpression="^[0-9]*$" />
                                                </div>
                                                <div class="form-group">
                                                    <label>Email Address</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtEmail" name="txtEmail" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display="None" runat="server" ID="revEmailValidation" ValidationGroup="tab1" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <%#Eval("FullName") %>
                                                </div>
                                                <div class="form-group">
                                                    <label>Citizenship</label>
                                                    <%--<asp:BoundField DataField="RelationshipType" HeaderText="RelationShip" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />--%>
                                                    <asp:DropDownList ID="ddlCitizenship" runat="server" DataTextField="Name" DataValueField="CountryCode" CssClass="form-control m-b"></asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleVinNo" ID="RequiredFieldValidator41" ForeColor="red" runat="server" ErrorMessage="Please enter Vehicle model" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Passport</label>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtPassport" name="txtPassport" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="tab1" ControlToValidate="txtPassport" ID="rfvPassport" ForeColor="red" runat="server" ErrorMessage="Enter Passport Number"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:CheckBox ID="chkIdORPass" runat="server" Text="Either Allow Passport Number Or ID Number" AutoPostBack="true" OnCheckedChanged="IdorPass_chkEvent" />
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary" Visible="False" ID="btnResetTab1" runat="server" Text="Reset" OnClientClick="this.form.reset();return false;" Enabled="False" />
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button runat="server" ID="btnNextStep" ValidationGroup="tab1" CssClass="btn btn-sm btn-primary" Text="Next" OnClick="btnNextTb1_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-2" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="tab2" ForeColor="Red" Visible="False" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <h4>Residential Address</h4>
                                                <br />
                                                <br />
                                                <div class="form-group">
                                                    <label>Street Address <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtDependencyStartDate" ID="RequiredFieldValidator33" ForeColor="red" runat="server" ErrorMessage="Please enter Start date" Display="None" Visible="False" Enabled="False"></asp:RequiredFieldValidator>--%> </label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtStreetAddress" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Town</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtTown" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%-- <asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtDependencyCovertDate" ID="RequiredFieldValidator33" ForeColor="red" runat="server" ErrorMessage="Please enter cover date" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                  <div class="form-group">
                                                    <label>City</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtCity" name="name" type="text" class="form-control"></asp:TextBox>
                                                      <%--<asp:HyperLink runat="server" ToolTip='Edit ' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkAddonProductID="+Eval("pkiMemberProductID")%>'></asp:HyperLink>
                                                                    <asp:HyperLink OnClientClick="return confirm('Are you sure want to delete?');" runat="server" ToolTip='Delete' ID="HyperLink2" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkInoteIDRemove="+Eval("pkiMemberProductID")%>'><i class="fa fa-trash"></i></asp:HyperLink>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Province</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtProvince" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%--  <div class="form-group" style="display:none;">
                                                    <label>Policy No / Membership No<em> <asp:Literal runat="server" ID="ltrPolicyNumber" Text="*"></asp:Literal></em> </label>
                                                    <asp:TextBox CssClass="form-control" MaxLength="20" runat="server" ID="txtPolicyNo" name="txtPolicyNo" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="txtPolicyNo" ID="rfvPolicyNo" ForeColor="red" runat="server" Display="None" ErrorMessage="Please enter policy no"></asp:RequiredFieldValidator>
                                                </div>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Code</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtCode" name="name" type="text" onkeypress="return isDecimalNumber(event,this);" class="form-control"></asp:TextBox>
                                                    <%--<div class="form-group">
                                                    <label>Policy Start Date</label>
                                                    <label><em>*</em></label>&nbsp;<asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtPolicyStartDate" name="name" type="text" placeholder="Enter Start  Date" class="form-control"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="txtPolicyStartDate" ID="RequiredFieldValidator7" ForeColor="red" runat="server" ErrorMessage="Please enter Start date" Display="None"></asp:RequiredFieldValidator>

                                                </div>--%>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <h4>Postal Address</h4>
                                                    <br />
                                                    <asp:CheckBox ID="chkResOrPost" runat="server" Text="Same as Residential Address" AutoPostBack="true" OnCheckedChanged="chkResOrPost_CheckedChanged" />
                                                </div>
                                                <div class="form-group">
                                                    <label id="lblPostaddress">
                                                        <asp:Label ID="lblAddress" runat="server" Text="P.O. Box"></asp:Label>
                                                        &nbsp;<%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtDependencyDOB" ID="RequiredFieldValidator35" ForeColor="red" runat="server" ErrorMessage="Please enter date of birth" Display="None" Enabled="False" Visible="False"></asp:RequiredFieldValidator>--%></label><asp:TextBox MaxLength="50" runat="server" ID="txtPostStreetAddress" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Town or City</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtPostTown" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%#Eval("VehicleMake") %>
                                                </div>
                                                <div class="form-group">
                                                    <label>Province</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtPostProvince" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%#Eval("VehicleModel") %>
                                                </div>
                                                <div class="form-group">
                                                    <label>Code</label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtPostCode" name="name" type="text" onkeypress="return isDecimalNumber(event,this);" class="form-control"></asp:TextBox>
                                                    <%--                                       <div class="form-group">
<%--                                                    <label>Bank Branch</label>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(1);">Back</button>

                                                        <%--<asp:TextBox MaxLength="50" runat="server" ID="txtBranch" name="name" type="text" class="form-control"></asp:TextBox>--%>
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="btnResetTab2" runat="server" Text="Reset" OnClick="btnResetTab_Click" Enabled="False" />
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button runat="server" ID="btnTab2" ValidationGroup="tab2" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab2_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-3" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <asp:ValidationSummary runat="server" ID="ValidationSummary2" ValidationGroup="tab3" ForeColor="Red" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">

                                                <div class="form-group">
                                                    <label>Policy Name<em>*</em> </label>
                                                    <asp:DropDownList ID="ddlPolicy" class="form-control" runat="server">
                                                        <asp:ListItem Value="0">Select Policy</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="ddlPolicy" Display="None" InitialValue="0" ID="RequiredFieldValidator17" ForeColor="red" runat="server" ErrorMessage="Select Policy"></asp:RequiredFieldValidator>
                                                    <asp:HiddenField ID="hdCoverDate" runat="server" />
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox MaxLength="10" CssClass="form-control" Enabled="false" runat="server" ID="txtPolicyPremium" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <%--    </div>--%>
                                                <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>

                                                <div class="form-group">
                                                    <label>Policy Start Date<em>*</em> </label>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <asp:DropDownList ID="ddlPolicyStartDate" class="form-control" runat="server">
                                                                <asp:ListItem Value="0">Select Policy Start Month</asp:ListItem>
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="ddlPolicyStartDate" Display="None" InitialValue="0" ID="RequiredFieldValidator5" ForeColor="red" runat="server" ErrorMessage="Select Policy Start Month"></asp:RequiredFieldValidator>
                                                        </div>


                                                        <div class="col-md-6">
                                                            <asp:DropDownList ID="ddlPolicyStartDateYear" class="form-control" runat="server">
                                                                <asp:ListItem Value="0">Select Policy Start Year</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="ddlPolicyStartDateYear" Display="None" InitialValue="0" ID="RequiredFieldValidator11" ForeColor="red" runat="server" ErrorMessage="Select Policy Start Year"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>

                                                    <asp:HiddenField ID="hdnEditStartDate" runat="server" />
                                                </div>

                                                <div class="form-group">
                                                    &nbsp;<asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtInception" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit ' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkAddonProductID="+Eval("pkiMemberProductID")%>'></asp:HyperLink>
                                                                    <asp:HyperLink OnClientClick="return confirm('Are you sure want to delete?');" runat="server" ToolTip='Delete' ID="HyperLink2" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkInoteIDRemove="+Eval("pkiMemberProductID")%>'><i class="fa fa-trash"></i></asp:HyperLink>--%>
                                                </div>

                                                <div class="form-group">
                                                    <label>Policy Cover Date</label>
                                                    &nbsp;<asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtCoverDate" name="name" type="text" class="form-control" ReadOnly="True"></asp:TextBox>
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                </div>

                                                <div class="form-group">
                                                    &nbsp;<asp:TextBox MaxLength="50" CssClass="form-control" runat="server" ID="txtEasyToPay" name="txtEasyToPay" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:DropDownList ID="ddlBankBranch" class="form-control" runat="server" Visible="False" Enabled="False">
                                                        <asp:ListItem Value="0">Select Branch</asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ValidationGroup="tab3" ControlToValidate="ddlBankBranch" Display="None" InitialValue="0" ID="RequiredFieldValidator36" ForeColor="red" runat="server" ErrorMessage="Select a Branch" Enabled="False"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:DropDownList ID="ddlCustom1" class="form-control" runat="server" Visible="False" Enabled="False">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:DropDownList ID="ddlCustom2" class="form-control" runat="server" Visible="False" Enabled="False">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:DropDownList ID="ddlCustom3" class="form-control" runat="server" Visible="False" Enabled="False">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    &nbsp;<asp:DropDownList ID="ddlMemberSociety" class="form-control m-b" runat="server" Visible="False" Enabled="False">
                                                        <asp:ListItem Value="0">Select Society</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:TextBox MaxLength="50" runat="server" ID="txtUnderwriter" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%><asp:DropDownList ID="ddlAgent" runat="server" DataTextField="Agent" DataValueField="AgentID" CssClass="form-control m-b" Visible="False"></asp:DropDownList>
                                                    <%#Eval("VehicleMake") %>
                                                </div>
                                                <div class="form-group">
                                                    &nbsp;<asp:TextBox MaxLength="20" runat="server" ID="txtTotalPremium" name="name" type="text" ReadOnly="true" class="form-control" Visible="False"></asp:TextBox>
                                                    <%#Eval("VehicleModel") %>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(2);">Back</button>
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="btnResetTab3" runat="server" Text="Reset" OnClick="btnResetTab_Click" />

                                                    </div>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    <div class="btn-group">
                                                        <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                                                        <asp:Button runat="server" ID="btnTab3" ValidationGroup="tab3" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab3_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-9" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <asp:ValidationSummary runat="server" ID="ValidationSummary5" ValidationGroup="tabs-9" ForeColor="Red" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label>Product Name <em>*</em></label>
                                                    <asp:DropDownList ID="drpProductName" class="form-control m-b" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ValidationGroup="tabs-9" ControlToValidate="drpProductName" ID="RequiredFieldValidator4" ForeColor="red" runat="server" ErrorMessage="Please select product name" Display="None"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Premium<em>*</em></label>
                                                    <asp:TextBox MaxLength="20" runat="server" ID="txtPremium" placeholder="Premium " name="name" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="tabs-9" ControlToValidate="txtPremium" ID="RequiredFieldValidator30" ForeColor="red" runat="server" ErrorMessage="Please enter premium amount" Display="None"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="btnAdd" CssClass="btn btn-sm btn-primary" ValidationGroup="tabs-9" runat="server" Text="Save AddonProducts" OnClick="btnAdd_Click" />
                                                    <asp:Button ID="btnUpdateProduct" class="btn btn-sm btn-primary" ValidationGroup="tabs-9" Visible="false" runat="server" Text="Update AddonProducts" OnClick="btnUpdateProduct_Click" />
                                                    <br />
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(3);">Back</button>
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="Button1" runat="server" Text="Reset" OnClick="btnResetTab_Click" />
                                                    </div>
                                                    <div class="btn-group">
                                                        <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                        <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab4_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvProduct" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        AllowPaging="false" AutoGenerateColumns="False" EmptyDataText="There are no product available." OnRowCommand="gvProduct_RowCommand">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" />
                                                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                            <asp:BoundField DataField="ProductCost" HeaderText="Product Cost" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" DataFormatString="{0:n}" />
                                                            <asp:TemplateField HeaderText="Actions">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="btnEditProduct" CommandName="EditProduct" ToolTip="Click here to edit product" CommandArgument='<%#Eval("pkiMemberProductID") %>'><i class="fa fa-edit"></i></asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return confirm('Are you sure you want to delete it?')" CommandName="DeleteProduct" ToolTip="Click here to delete product" CommandArgument='<%#Eval("pkiMemberProductID") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit ' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkAddonProductID="+Eval("pkiMemberProductID")%>'></asp:HyperLink>
                                                                    <asp:HyperLink OnClientClick="return confirm('Are you sure want to delete?');" runat="server" ToolTip='Delete' ID="HyperLink2" NavigateUrl='<%# "~/Admin/ManageMember.aspx?ID="+MemberId.ToString()+"&PkInoteIDRemove="+Eval("pkiMemberProductID")%>'><i class="fa fa-trash"></i></asp:HyperLink>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div id="tab-4" class="tab-pane">
                                        <div class="row">
                                         <div class="col-lg-12">
                                             <div class="form-group">
                                                    <div class="input-group">
                                                        <asp:ValidationSummary runat="server" ID="ValidationSummary6" ValidationGroup="tab4" ForeColor="Red" />
                                                    </div>
                                                    </div>
                                         </div>
                                            <div class="col-lg-6">
                                                
                                                <div class="form-group">
                                                    <label>Account Holder <em>*</em></label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtAccountholder" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab4" ControlToValidate="txtAccountholder" ID="RequiredFieldValidator6" ForeColor="red" runat="server" ErrorMessage="Please enter Account Holder"></asp:RequiredFieldValidator>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                               </div>
                                                
                                                <div class="form-group">
                                                    <label>Bank Name <em>*</em></label>
                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                    <asp:DropDownList ID="ddlBank" InitialValue="0" runat="server" DataTextField="BankName" DataValueField="BranchCode" CssClass="form-control m-b">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0"  ValidationGroup="tab4" ControlToValidate="ddlBank" ID="RequiredFieldValidator35" ForeColor="red" runat="server" ErrorMessage="Please Select Bank" Display="None"></asp:RequiredFieldValidator>
                                                
                                                     </div>
                                                <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%><%#Eval("VehicleMake") %><%#Eval("VehicleModel") %><%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>

                                                <div class="form-group">
                                                    <label>Branch Code <em>*</em></label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtBranchcode" name="name" type="text" class="form-control"></asp:TextBox>
                                                 
                                                       <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Account Number <em>*</em></label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtAccountno" name="name" type="text" class="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator Display="None"  ValidationGroup="tab4" ControlToValidate="txtAccountno" ID="RequiredFieldValidator7" ForeColor="red" runat="server" ErrorMessage="Please enter Account Number"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Account Type <em>*</em></label>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                    <asp:DropDownList runat="server" ID="ddlAccountType" DataTextField="AccountType" DataValueField="AccountTypeID" class="form-control"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator Display="None" InitialValue="0" ValidationGroup="tab4" ControlToValidate="ddlAccountType" ID="RequiredFieldValidator8" ForeColor="red" runat="server" ErrorMessage="Please select Account Type"></asp:RequiredFieldValidator>
                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                </div>
                                                <div class="form-group">
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtDebitdate" name="name" type="text" class="form-control" Enabled="False" Visible="False"></asp:TextBox>
                                                    <label>Debit Date <em>*</em> </label>
                                                    <asp:DropDownList ID="ddlDebitDate" class="form-control" runat="server">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">1st</asp:ListItem>
                                                        <asp:ListItem Value="15">15th</asp:ListItem>
                                                        <asp:ListItem Value="25">25th</asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator Display="None" InitialValue="0" ValidationGroup="tab4" ControlToValidate="ddlDebitDate" ID="RequiredFieldValidator9" ForeColor="red" runat="server" ErrorMessage="Please select Debit Date"></asp:RequiredFieldValidator>
                                                    <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(5);">Back</button>
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="btnResetTab4" runat="server" Text="Reset" OnClick="btnResetTab_Click" Enabled="False" Style="height: 26px" />
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" OnClick="btnSave_Click" ID="btnSave" ValidationGroup="tab4" runat="server" Text="Accept Policy" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    <div id="tab-5" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-12 ">
                                                <div class="ibox float-e-margins">
                                                    <div class="ibox-title">
                                                        <h5>Vehicles</h5>
                                                        <div class="ibox-tools">
                                                            <a class="collapse-link">
                                                                <i class="fa fa-chevron-up"></i>
                                                            </a>
                                                            <a class="close-link">
                                                                <i class="fa fa-times"></i>
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div class="ibox-content">
                                                        <div class="row">
                                                            <div class="col-sm-12 ">

                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="gvVehicles" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                        AllowPaging="false" DataKeyNames="pkiVehicleID" AutoGenerateColumns="False" OnRowDataBound="gvVehicles_RowDataBound" EmptyDataText="There are no Vehicles added." OnRowCommand="gvVehicles_RowCommand">
                                                                        <PagerStyle CssClass="pagination-ys" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Make">
                                                                                <ItemTemplate>
                                                                                    <%#Eval("VehicleMake") %>&nbsp<%#Eval("VehicleModel") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="VehicleModel" HeaderText="Model" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                                            <asp:BoundField DataField="VehicleYear" HeaderText="Year" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                                            <asp:BoundField DataField="VehicleTrackingCompany" HeaderText="Tracking Company" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                                            <asp:BoundField DataField="VehicleVinNo" HeaderText="Vin No." HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                                            <asp:BoundField DataField="VehicleEngNo" HeaderText="Engine No." HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                                            <asp:BoundField DataField="VehicleRegNo" HeaderText="Reg No." HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                                            <asp:TemplateField HeaderText="Actions">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lbtnEditVehicle" ToolTip="Click here To Edite Vehicle" CommandArgument='<%#Eval("pkiVehicleID") %>' CommandName="EditVehicle"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                    &nbsp;
                                                                                    <asp:LinkButton runat="server" ID="lbtnDeleteVehicle" ToolTip="Click here To Delete Vehicle" CommandArgument='<%#Eval("pkiVehicleID") %>' OnClientClick="return confirm('Are you sure you want to delete it?')" CommandName="DeleteVehicle"><i class="fa fa-trash"></i></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12 ">
                                                <div class="ibox float-e-margins">
                                                    <div class="ibox-title">
                                                        <h5>Add/Update vehicle</h5>
                                                        <div class="ibox-tools">
                                                            <a class="collapse-link">
                                                                <i class="fa fa-chevron-up"></i>
                                                            </a>
                                                            <a class="close-link">
                                                                <i class="fa fa-times"></i>
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div class="ibox-content">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="form-group">
                                                                    <div class="input-group">
                                                                        <asp:ValidationSummary runat="server" ID="ValidationSummary4" ValidationGroup="tab5" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="form-group">
                                                                    <label>Make <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleMake" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtVehicleMake" Display="None" ErrorMessage="Please enter Make" ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label>Model <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleModel" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtVehicleModel" Display="None" ErrorMessage="Please Enter Model" ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label>Year <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleYear" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtVehicleYear" Display="None" ErrorMessage="Please Enter Year" ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>


                                                                <div class="form-group">
                                                                    <label>Color <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleColor" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--                                                 <div>
                                                        <asp:Button runat="server" ID="Button10" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab10_Click" />
                                                    </div>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtVehicleColor" Display="None" ErrorMessage="Please Enter Color" ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                </div>

                                                            </div>
                                                            <div class="col-lg-6">

                                                                <div class="form-group">
                                                                    <label>Tracking Company </label>
                                                                    &nbsp;<asp:TextBox MaxLength="50" runat="server" ID="txtVehicleTrackingCompany" name="name" type="text" class="form-control"></asp:TextBox>

                                                                </div>

                                                                <div class="form-group">
                                                                    <label>Engine No. <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleEngNo" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtVehicleEngNo" Display="None" ErrorMessage="Please Enteer Engine No." ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label>Reg No. <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleRegNo" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtVehicleRegNo" Display="None" ErrorMessage="Please Enter Registration No." ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                    <label>Vin No. <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleVinNo" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtVehicleVinNo" Display="None" ErrorMessage="Please Enter Vin No." ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="form-group">
                                                                    &nbsp;<asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtDependencyStartDate" placeholder="Enter Start  Date" name="name" class="form-control" Visible="False"></asp:TextBox>

                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtDependencyInceptionDate" placeholder="Enter Inception Date" name="name" class="form-control" Visible="False"></asp:TextBox>
                                                                    <%#Eval("Notes") %>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtDependencyCovertDate" placeholder="Enter Cover Date" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                                </div>

                                                                <div class="form-group">
                                                                    &nbsp;<asp:TextBox MaxLength="30" runat="server" ID="txtDependencyDOB" placeholder="Enter Date Of Birth" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                                </div>


                                                            </div>
                                                            <div class="col-lg-12">
                                                                <div class="form-group">
                                                                    <div class="btn-group">
                                                                        <asp:HiddenField ID="hfVehicleId" runat="server" />
                                                                        <br />
                                                                        <asp:Button ID="btnAddVehicle" CssClass="btn btn-sm btn-primary" ValidationGroup="tab5" runat="server" Text="Add Vehicle" OnClick="btnAddVehicle_Click" />
                                                                        <asp:Button ID="btnUpdateVehicle" CssClass="btn btn-sm btn-primary" ValidationGroup="tab5" runat="server" Text="Update Vehicle" OnClick="btnUpdateVehicle_Click" Visible="False" />
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <div class="btn-group">
                                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(3);">Back</button>
                                                                    </div>
                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="Button3" runat="server" Text="Reset" OnClick="btnResetTab_Click" Enabled="False" />
                                                                    </div>
                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="true" ID="btnTab5" runat="server" Text="Next" OnClick="btnTab5_Click" />
                                                                    </div>
                                                                    <%--                                                 <div>
                                                        <asp:Button runat="server" ID="Button10" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab10_Click" />
                                                    </div>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-6" class="tab-pane">
                                        <br />
                                        <br />
                                        <div class="col-lg-12 ">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvInvoices" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                    AllowPaging="true" PageSize="25" AutoGenerateColumns="False" EmptyDataText="There are no payment history.">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:BoundField DataField="AmountPaid" HeaderText="Amount" ReadOnly="True" />
                                                        <asp:BoundField DataField="DatePaid" HeaderText="Date paid" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                        <asp:BoundField DataField="RecievedBy" HeaderText="Recieved by" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                        <asp:BoundField DataField="InvNumber" HeaderText="Invoice Number" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                        <asp:BoundField DataField="PaymentBranch" HeaderText="Payment Branch" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-7" class="tab-pane">
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Enter note description</label>
                                                    <asp:TextBox TextMode="MultiLine" Rows="12" ValidationGroup="tab7" MaxLength="255" runat="server" ID="txtArea" placeholder="Enter Note" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="BtnAddNote" ValidationGroup="tab7" runat="server" Text="Add Note" OnClick="BtnAddNote_Click" />
                                                    <asp:Button ID="btnUpdateNotes" ValidationGroup="tab7" class="btn btn-sm btn-primary pull-right m-t-n-x" Visible="false" runat="server" Text="Update Note" OnClick="btnUpdateNotes_Click" />
                                                    <br />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 ">
                                                <div class="table-responsive">
                                                    <asp:GridView OnRowDataBound="gvNotes_RowDataBound" ID="gvNotes" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        AllowPaging="true" PageSize="25" AutoGenerateColumns="False" EmptyDataText="There are no notes to diplay." OnRowCommand="gridNoteList_RowCommand">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Notes" HeaderText="Note" ReadOnly="True" />
                                                            <asp:BoundField DataField="NoteDate" HeaderText="Note Date" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                            <asp:BoundField DataField="LastModified" HeaderText="Last Modified" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                            <asp:TemplateField HeaderText="Actions">
                                                                <ItemTemplate>
                                                                    <div class="modal inmodal fade" id="myModal<%#Eval("pkiNoteID") %>>" role="dialog" hidden="true">
                                                                        <div class="modal-dialog modal-lg">
                                                                            <div class="modal-content">
                                                                                <div class="modal-header">
                                                                                    <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                                                                                    <h4 class="modal-title">Modal title</h4>
                                                                                    <small class="font-bold">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</small>
                                                                                </div>
                                                                                <div class="modal-body">
                                                                                    <%#Eval("Notes") %>
                                                                                </div>
                                                                                <div class="modal-footer">
                                                                                    <button type="button" class="btn btn-sm btn-primary close" data-dismiss="modal">Close</button>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <asp:LinkButton runat="server" ID="LinkButton2" CausesValidation="false" ToolTip="Click here to edit Note" CommandName="EditNote" CommandArgument='<%#Eval("pkiNoteID") %>'><i class="fa fa-edit"></i></asp:LinkButton>
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                                    &nbsp;
                                                                    <button type="button" title="Click here to view Note" onclick="ViewNote('<%#Eval("pkiNoteID") %>'); return false;">
                                                                        <i class="fa fa-search"></i>
                                                                    </button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Visible="false">
                                                <asp:LinkButton ID="lnkClose" Font-Bold="true" ForeColor="Blue" CssClass="lnkClose" runat="server" Text="[X]" OnClick="lnkClose_Click"></asp:LinkButton>
                                                <br />
                                                <div class="spaceMargin">
                                                    <div class="noteHead">
                                                        <h3 style="float: left;">Note</h3>
                                                        <span class="noteDate" style="margin-top: 5px; float: right;">
                                                            <asp:Literal ID="ltrNoteDate" runat="server"></asp:Literal>
                                                        </span>
                                                    </div>
                                                    <div class="noteContainer">
                                                        <asp:Literal ID="ltrNotes" runat="server"></asp:Literal>
                                                    </div>

                                                    <br />
                                                    <asp:Literal Visible="false" ID="ltrLastDate" runat="server"></asp:Literal>
                                                    <br />


                                                </div>

                                            </asp:Panel>
                                            <asp:Panel Visible="false" ID="pnlWrapper" runat="server">
                                                <div class="WrapLayout"></div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div id="tab-8" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>Select Supported Document File</label>
                                                    <div class="input-group">
                                                        <asp:FileUpload ID="fuSupportDocument" runat="server" />
                                                        <span class="input-group-btn">&nbsp;
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="radio">
                                                        <asp:RadioButtonList runat="server" ID="rdbdocument" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Text="Id Documents/ passports – main member – spouse" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Marriage certificate"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Dependants – birth certificate"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="btnDocumentSubmit" class="btn btn-sm btn-primary pull-right m-t-n-xs" OnClick="BtnDocumentSubmit_Click" runat="server" Text="Save Document" />
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 ">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvSupportedDocument" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        AllowPaging="false" AutoGenerateColumns="False" EmptyDataText="There are no document upload." OnRowCommand="gvSupportedDocument_RowCommand">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ImageName" HeaderText="Documet" ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Documet Type">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                                    <asp:Label ID="lbldoctype" runat="server" Text='<%# ( Convert.ToInt32(Eval("DocType"))==1?"Id Documents/ passports":(Convert.ToInt32(Eval("DocType"))==2?"Marriage certificate":"Dependants – birth certificate Save Document")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CreateDate" HeaderText="Created date" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                    <asp:HyperLink runat="server" ToolTip='Download document' ID="hrLink" NavigateUrl='<%# "~/Handler/DocumentHandler.ashx?DocID="+Eval("pkiPictureID")%>'><i class="glyphicon glyphicon-download"></i></asp:HyperLink>
                                                                    &nbsp; <a href='<%#ResolveUrl("~/Handler/DocumentHandler.ashx?DocID="+Eval("pkiPictureID"))%>' title="View Document" data-gallery=""><i class="fa fa-search"></i></a>
                                                                    &nbsp;
                                                                    <asp:LinkButton runat="server" ID="lbtnDeleteDocument" ToolTip="Click here To Delete Document" CommandArgument='<%#Eval("pkiPictureID") %>' OnClientClick="return confirm('Are you sure you want to delete it?')" CommandName="DeleteDocument"><i class="fa fa-trash"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab-10" class="tab-pane">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Policy No<em> </em></label>
                                                    <asp:TextBox CssClass="form-control" MaxLength="20" runat="server" ID="txtPolicyNo" name="txtPolicyNo" type="text" class="form-control" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(4);">Back</button>
                                                    </div>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="Button4" runat="server" Text="Reset" OnClick="btnResetTab_Click" />
                                                    </div>
                                                    <%--                                                 <div>
                                                        <asp:Button runat="server" ID="Button10" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab10_Click" />
                                                    </div>--%>
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="btnbanksave" runat="server" Text="Reset" OnClick="btnBanksave_Click" />
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">
    <script>

        $(document).ready(function () {
            $("#tab2").click(function (e) {
                e.preventDefault();
                if ($('#MainContent_txtLastName').val() == '' || $('#MainContent_txtFirstname').val() == '' || $('#MainContent_txtCellphone').val() == '') { return false; }
                else { return true; }
            });
            $("#tab3").click(function (e) {
                if ($('#MainContent_txtLastName').val() == '' || $('#MainContent_txtFirstname').val() == '' || $('#MainContent_txtCellphone').val() == '') { return false; }
                else { return true; }
            });
            $("#tab4").click(function (e) {
                if ($('#MainContent_txtLastName').val() == '' || $('#MainContent_txtFirstname').val() == '' || $('#MainContent_txtCellphone').val() == '') { return false; }
                else { return true; }
            });
            $("#tab5").click(function (e) {
                if ($('#MainContent_txtLastName').val() == '' || $('#MainContent_txtFirstname').val() == '' || $('#MainContent_txtCellphone').val() == '') { return false; }
                else { return true; }
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //set InceptionDates
            $("#<%=txtDependencyInceptionDate.ClientID %>").val('<%=System.DateTime.Now.ToString("dd MMM yyyy")%>');
            $("#<%=txtInception.ClientID %>").val('<%=System.DateTime.Now.ToString("dd MMM yyyy")%>');


            enabledisabletab();
            $("#<%=txtDependencyDOB.ClientID %>").datepicker({ format: 'dd MM yyyy' });
            $("#<%=txtDependencyInceptionDate.ClientID %>").datepicker({ format: 'dd MM yyyy' });
            $("#<%=txtDependencyCovertDate.ClientID %>").datepicker({ format: 'dd MM yyyy' });
            $("#<%=txtDependencyStartDate.ClientID %>").datepicker({ format: 'dd MM yyyy' });
           <%-- $("#<%=txtPolicyStartDate.ClientID %>").datepicker({ format: 'dd MM yyyy' });--%>
            $("#<%=txtBirthDay.ClientID %>").datepicker({ format: 'dd MM yyyy' });


            $("#<%=txtInception.ClientID %>").datepicker({ format: 'dd MM yyyy' });
            $("#<%=txtDebitdate.ClientID %>").datepicker({ format: 'dd MM yyyy' });

            //Hide Calender on date selected
            $("#<%=txtDependencyDOB.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
                getDependencyAge($("#<%=txtDependencyDOB.ClientID %>").val())
            })
            $("#<%=txtDependencyInceptionDate.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
            })
            $("#<%=txtDependencyInceptionDate.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
            })
            $("#<%=txtDependencyStartDate.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');

                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("~/admin/ManageMember.aspx/DependencyStartdateChange")%>',
                    data: JSON.stringify({ id: $('#<%=ddlPolicy.ClientID%>').val(), date: $('#<%=txtDependencyStartDate.ClientID%>').val() }),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $('#<%=txtDependencyCovertDate.ClientID%>').val(data.d[0]);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            })
            $("#<%=txtBirthDay.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
                getAge($("#<%=txtBirthDay.ClientID %>").val())
            })
            $("#<%=txtInception.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
            })
            $("#<%=txtDebitdate.ClientID %>").on('changeDate', function (ev) {
                $(this).datepicker('hide');
            })

            function getDependencyAge(DOB1) {

                var DOB = new Date(DOB1);
                var today = new Date();
                var nowyear = today.getFullYear();
                var nowmonth = today.getMonth();
                var nowday = today.getDate();

                var birthyear = DOB.getFullYear();
                var birthmonth = DOB.getMonth();
                var birthday = DOB.getDate();

                var age = nowyear - birthyear;
                var age_month = nowmonth - birthmonth;
                var age_day = nowday - birthday;
                if (age_month < 0 || (age_month == 0 && age_day < 0)) {
                    age = parseInt(age) - 1;
                }

            }

            validate();
            $('#MainContent_txtLastName, #MainContent_txtFirstname').change(validate);
            debugger;
            var tab = $("[id*=TabName]").val();
            $('#myTab a[href="#' + tab + '"]').tab('show');
            var liId = tab.replace("tab-", "");
            $('["#tab' + liId + '"]').addClass("active");
            $('["#tab' + liId + '"]').addClass("active");


            $("li").has('a[data-toggle="tab"]').removeClass("active");
            $("li").has('a[href="#tab-3"]').addClass("active");


        })

        function getAge(DOB1) {
            var DOB = new Date(DOB1);
            var today = new Date();
            var nowyear = today.getFullYear();
            var nowmonth = today.getMonth();
            var nowday = today.getDate();

            var birthyear = DOB.getFullYear();
            var birthmonth = DOB.getMonth();
            var birthday = DOB.getDate();

            var age = nowyear - birthyear;
            var age_month = nowmonth - birthmonth;
            var age_day = nowday - birthday;
            if (age_month < 0 || (age_month == 0 && age_day < 0)) {
                age = parseInt(age) - 1;
            }
            $('#<%=txtAge.ClientID%>').val(age.toString());

        }

        function validate() {
            var var1 = $("#<%=txtLastName.ClientID%>").val();
            var var2 = $("#<%=txtFirstname.ClientID%>").val();
            if (var1 != '' && var2 != '') {
                $('[id$=btnNextStep]').prop("disabled", false);
            }
            else {
                $('[id$=btnNextStep]').prop("disabled", true);
            }
        }

        $(function () {
            $('#invoices').DataTable();
            $('#policy').DataTable();
            $('#SupportedDocuments').DataTable();
            $('#Notes').DataTable();
            $('#Product').DataTable();

        });
        function makeReset(target) {
            $('#tabs-' + target + ' input').val('');
            $('#tabs-' + target + ' select').val('0');
            return false;
        }

        $("#<%=ddlPolicy.ClientID%>").change(function () {
            FillAjaxdata();
        });

        $("#<%=ddlPolicyStartDate.ClientID%>").change(function () {
            var date = new Date();
            var year = date.getFullYear();
            var month = $(this).find('option:selected').text();

            var startdate = new Date(year.toString() + '-' + month)
            var sd = startdate.getDate();
            //alert(month);
            //alert(sd);
            //FillAjaxdata1();

            $("#<%=txtCoverDate.ClientID%>").val(sd + '-' + month + '-' + year);
            $('#<%=hdCoverDate.ClientID%>').val(sd + '-' + month + '-' + year);
        });


       <%-- $("#<%=ddlPolicyStartDate.ClientID%>").on('change',function () {
            // FillAjaxdata();
            var date = $(this).val();
           
            $("#<%=txtCoverDate.ClientID%>").val(FillAjaxdata1());

        });--%>


        function FillAjaxdata1(date, month, year) {


            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("~/admin/ManageMember.aspx/ddlPolicyStartDate_SelectedIndexChanged")%>',

                data: JSON.stringify({
                    id: $('#<%=ddlPolicyStartDate.ClientID%>').val(), sd: $('#<%=ddlPolicyStartDate.ClientID%>').val(), year: $('#<%=ddlPolicyStartDate.ClientID%>').val(), month: $('#<%=ddlPolicyStartDate.ClientID%>').val()
                   <%-- //, date: $('#<%=txtPolicyStartDate.ClientID%>').val()--%>
                }),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                   <%-- $('#<%=txtPolicyPremium.ClientID%>').val(data.d[0]);
                    $('#<%=txtUnderwriter.ClientID%>').val(data.d[1]);--%>
                    $('#<%=hdCoverDate.ClientID%>').val(data.d[2]);
                    <%--  $('#<%=txtDependencyCovertDate.ClientID%>').val(data.d[2]);--%>
                    <%-- $('#<%=txtCoverDate.ClientID%>').val(data.d[2]);--%>
                   <%-- $('#<%=txtTotalPremium.ClientID%>').val(data.d[3]);--%>


                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function FillAjaxdata() {
            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("~/admin/ManageMember.aspx/ddlPolicy_SelectedIndexChanged")%>',
                //data: '{"id":' + $('#<%=ddlPolicy.ClientID%>').val() + '}',
                // data: JSON.stringify({id:  $('#<%=ddlPolicy.ClientID%>').val() }),
                data: JSON.stringify({
                    id: $('#<%=ddlPolicy.ClientID%>').val()
                   <%-- //, date: $('#<%=txtPolicyStartDate.ClientID%>').val()--%>
                }),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#<%=txtPolicyPremium.ClientID%>').val(data.d[0]);
                    $('#<%=txtUnderwriter.ClientID%>').val(data.d[1]);
                    $('#<%=hdCoverDate.ClientID%>').val(data.d[2]);
                    $('#<%=txtDependencyCovertDate.ClientID%>').val(data.d[2]);
                    <%-- $('#<%=txtCoverDate.ClientID%>').val(data.d[2]);--%>
                   <%-- $('#<%=txtTotalPremium.ClientID%>').val(data.d[3]);--%>


                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        

        function openModal() {
            $('#ucBank').modal('show');
        }
        $("#<%=ddlBank.ClientID%>").change(function () {
            if (this.value == "-1") {
                $('#ucBank').modal('show').on('hidden.bs.modal', function () {
                    
                    $("#<%=btnbanksave.ClientID %>").click();
                  
                }).on('hidden', function () {
                    
                    $("#<%=btnbanksave.ClientID %>").click();
                    
                });
            }
            else {
                $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());
            }
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


        $("#<%=drpProductName.ClientID%>").change(function () {
            FillProductAjaxdata();
        });
        function FillProductAjaxdata() {
            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("~/admin/ManageMember.aspx/ddlProductNameChanged")%>',
                data: '{"id":"' + $('#<%=drpProductName.ClientID%>').val() + '"}',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#<%=txtPremium.ClientID%>').val(data.d);

                },
                failure: function (response) {
                    alert(response.d);
                }
            });
            }
            function ViewNote(NoteId) {
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("~/admin/ManageMember.aspx/ViewNoteDetails")%>',
                    data: '{"id":"' + NoteId + '"}',
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $("#NoteDesription").html(data.d);
                        document.getElementById("NotePopUpWrap").style.display = "block";
                        document.getElementById("NotePopUp").style.display = "block";

                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
                return false;
            }



            function hideNotePopUp() {
                document.getElementById("NotePopUpWrap").style.display = "none";
                document.getElementById("NotePopUp").style.display = "none";
            }

            function enabledisabletab() {
                var IsNew = $("#<%=hdnId.ClientID%>").val();


                if (eval(IsNew) == 0) {
                    DisableTab();
                }
                else
                    EnableTab();

            }

            function goToTab(id) {
                $("[id*=TabName]").val("tab-" + id + "");
            }
            function DisableTab() {

            }
            function EnableTab() {
                $("#tab1").show();
                $("#tab2").show();
                $("#tab3").show();
                //$("#tab9").show()
                $("#tab4").show();
                FillAjaxdata();

            }

            Date.prototype.monthNames = [
                "January", "February", "March",
                "April", "May", "June",
                "July", "August", "September",
                "October", "November", "December"
            ];

            Date.prototype.getMonthName = function () {

                return this.monthNames[this.getMonth()];
            };
            Date.prototype.getShortMonthName = function () {
                return this.getMonthName().substr(0, 3);
            };
            function Validate() {
                // first clear any left over error messages
                // $('#error p').remove();

                // store the error div, to save typing
                // var error = $('#error');

                var idNumber = $("#<%=txtIdNumber.ClientID %>").val();


                // assume everything is correct and if it later turns out not to be, just set this to false
                var correct = true;

                //Ref: http://www.sadev.co.za/content/what-south-african-id-number-made
                // SA ID Number have to be 13 digits, so check the length
                if (idNumber.length != 13 || !isNumber(idNumber)) {
                    //    error.append('<p>ID number does not appear to be authentic - input not a valid number</p>');
                    correct = false;
                }

                // get first 6 digits as a valid date

                var tempDate = new Date(idNumber.substring(0, 2), idNumber.substring(2, 4) - 1, idNumber.substring(4, 6));
                var id_date = tempDate.getDate();
                var id_month = tempDate.getMonth();
                var dMonth = id_month + 1;
                var dMonthName = tempDate.getMonthName();
                var id_year = tempDate.getFullYear();

                var fullDate = id_date + " " + dMonthName + " " + id_year;
                if (!((tempDate.getYear() == idNumber.substring(0, 2)) && (id_month == idNumber.substring(2, 4) - 1) && (id_date == idNumber.substring(4, 6)))) {
                    //    error.append('<p>ID number does not appear to be authentic - date part not valid</p>');
                    correct = false;
                }

                // get country ID for citzenship
                var citzenship = parseInt(idNumber.substring(10, 11)) == 0 ? "Yes" : "No";

                // apply Luhn formula for check-digits
                var tempTotal = 0;
                var checkSum = 0;
                var multiplier = 1;
                for (var i = 0; i < 13; ++i) {
                    tempTotal = parseInt(idNumber.charAt(i)) * multiplier;
                    if (tempTotal > 9) {
                        tempTotal = parseInt(tempTotal.toString().charAt(0)) + parseInt(tempTotal.toString().charAt(1));
                    }
                    checkSum = checkSum + tempTotal;
                    multiplier = (multiplier % 2 == 0) ? 1 : 2;
                }
                if ((checkSum % 10) != 0) {
                    //    error.append('<p>ID number does not appear to be authentic - check digit is not valid</p>');
                    correct = false;
                };


                // if no error found, hide the error message
                if (correct) {
                    //error.css('display', 'none');

                    // clear the result div
                    //$('#result').empty();
                    // and put together a result message
                    // $('#result').append('<p>South African ID Number:   ' + idNumber + '</p><p>Birth Date:   ' + fullDate + '</p><p>Gender:  ' + gender + '</p><p>SA Citizen:  ' + citzenship + '</p>');
                    $("#<%=txtBirthDay.ClientID %>").val(fullDate);
                    $("#<%=txtBirthDay.ClientID %>").val(fullDate).datepicker('update');

                    var genderCode = idNumber.substring(6, 10);
                    var gender = parseInt(genderCode) < 5000 ? "Female" : "Male";

                    var elementRef = document.getElementById('<%= rbtnlGender.ClientID %>');
                    var inputElementArray = elementRef.getElementsByTagName('input');

                    for (var i = 0; i < inputElementArray.length; i++) {
                        var inputElement = inputElementArray[i];
                        inputElement.checked = false;
                        if (gender == "Male") {
                            var inputElement = inputElementArray[0];
                            inputElement.checked = true;
                        }
                        else {
                            var inputElement = inputElementArray[1];
                            inputElement.checked = true;
                        }
                    }
                }
                // otherwise, show the error
                //else {
                //    error.css('display', 'block');
                //}

                return false;
            }

            function isNumber(n) {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            //$('#idCheck').submit(Validate);
            function DateComparisionJavascriptFun() {
                var idNumber = $("#<%=txtIdNumber.ClientID %>").val();
                //alert(idNumber);
                var textLength = idNumber.length;
                if (textLength == 13) {
                    // //alert(textLength);
                    Validate();
                }
            }
            function DateComparisionJavascriptFundep() {
                var textLengthdep = idNumberdep.length;
                if (textLengthdep == 13) {
                    // //alert(textLength);
                    Validatedep();
                }
            }
            function Validatedep() {
                var correctd = true;
                if (idNumberd.length != 13 || !isNumber(idNumberd)) {
                    correctd = false;
                }

                var tempDated = new Date(idNumberd.substring(0, 2), idNumberd.substring(2, 4) - 1, idNumberd.substring(4, 6));
                var id_dated = tempDated.getDate();
                var id_monthd = tempDated.getMonth();
                var dMonthd = id_monthd + 1;
                var dMonthNamed = tempDated.getMonthName();
                var id_yeard = tempDated.getFullYear();

                var fullDated = id_dated + " " + dMonthNamed + " " + id_yeard;
                if (!((tempDated.getYear() == idNumberd.substring(0, 2)) && (id_monthd == idNumberd.substring(2, 4) - 1) && (id_dated == idNumberd.substring(4, 6)))) {
                    correctd = false;
                }
                var citzenshipd = parseInt(idNumberd.substring(10, 11)) == 0 ? "Yes" : "No";
                var tempTotald = 0;
                var checkSumd = 0;
                var multiplierd = 1;
                for (var i = 0; i < 13; ++i) {
                    tempTotald = parseInt(idNumberd.charAt(i)) * multiplierd;
                    if (tempTotald > 9) {
                        tempTotald = parseInt(tempTotald.toString().charAt(0)) + parseInt(tempTotald.toString().charAt(1));
                    }
                    checkSumd = checkSumd + tempTotald;
                    multiplierd = (multiplierd % 2 == 0) ? 1 : 2;
                }
                if ((checkSumd % 10) != 0) {
                    correctd = false;
                };

                if (correctd) {

                    $("#<%=txtDependencyDOB.ClientID %>").val(fullDated);
                    $("#<%=txtDependencyDOB.ClientID %>").val(fullDated).datepicker('update');

                }
                // otherwise, show the error
                //else {
                //    error.css('display', 'block');
                //}

                return false;
            }
            var count = 0;
            function isDecimalNumber(evt, c) {
                count = count + 1;
                var charCode = (evt.which) ? evt.which : event.keyCode;
                var dot1 = c.value.indexOf('.');
                var dot2 = c.value.lastIndexOf('.');
                if (count > 25) {
                    c.value = "";
                    count = 0;
                }
                if (dot1 > 2) {
                    c.value = "";
                }
                if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
                else if (charCode == 46 && (dot1 == dot2) && dot1 != -1 && dot2 != -1)
                    return false;

                return true;
            }
    </script>

    <div id="NotePopUp">
        <div class="row">
            <div class="col-lg-6">
                <h2>Note</h2>
            </div>
            <div class="col-lg-6">
                <a onclick="hideNotePopUp();return false;" class="pull-right">[x]</a>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-8">
                <p id="NoteDesription"></p>
            </div>

        </div>
    </div>
    <div id="NotePopUpWrap" onclick="hideNotePopUp();"></div>
    <div id="blueimp-gallery" class="blueimp-gallery">
        <div class="slides"></div>
        <h3 class="title"></h3>
        <a class="prev">‹</a>
        <a class="next">›</a>
        <a class="close">×</a>
        <a class="play-pause"></a>
        <ol class="indicator"></ol>
    </div>
    <div class="modal inmodal  PolicyDoc" id="TaskFollowUpModel" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="ibox float-e-margins col-sm-12 center">
            <div class="ibox-title">
                <h5 id="PopFollowUpTitle">Branch</h5>
                <span data-dismiss="modal" target="_blank" class="closePopUp">x</span>
            </div>
            
            <div class="ibox-content">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label runat="server" ID="Label3"></asp:Label>
                    </div>

                    <rsweb:ReportViewer ID="ReportViewer1" ShowPrintButton="true" runat="server" Width="100%"></rsweb:ReportViewer>
                    <div class="col-sm-12">
                    </div>
                </div>
            </div>
               
        </div>

    </div>

    

    <div class="modal inmodal" id="PolicuNumberPopup" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="ibox float-e-margins col-sm-6 col-sm-offset-2">

            <div class="ibox-title">
                <h5>Policy Number</h5>
                <span data-dismiss="modal" target="_blank" class="closePopUp">x</span>
            </div>
            <div class="ibox-content">
                <div class="row">
                    <div class="col-sm-12">
                        <p>
                            <asp:Literal ID="ltrPolicyNumber" runat="server" />
                        </p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade Bankmodal" id="ucBank" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;  </button>
                    <h4 class="modal-title">Bank Detail</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <uc:ucBanks runat="server" ID="ucBanks1" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
        <!-- /.modal-dialog -->
    </div>


    <script>
        function selectFollowUpPopUp(id) {
            if (id == "Report") {
                // alert("3");
                $('#TaskFollowUpModel').modal('show');
                document.getElementById("PopFollowUpTitle").innerHTML = "Policy Doc";
            }
            else if (id == "PolicyNumber") {
                $('#PolicuNumberPopup').modal('show');
            }
            //else if(id="ucBank")
            //{
            //    $('#ucBank').modal('show');
            //}
        }

    </script>
</asp:Content>
