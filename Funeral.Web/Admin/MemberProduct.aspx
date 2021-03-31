<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MemberProduct.aspx.cs" Inherits="Funeral.Web.Admin.MemberProduct" %>

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
                    
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="panel blank-panel">
                            <div class="panel-heading">
                                <div class="panel-options" id="Tabs">
                                    <ul class="nav nav-tabs" id="myTab">
                                        <li class="active" id="tab1"><a data-toggle="tab" href="#tab-1" aria-expanded="true">Personal Details</a></li>
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
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab1" ControlToValidate="txtIdNumber" ID="rfvIdnumber" ForeColor="red" runat="server" ErrorMessage="Please enter id number"></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ErrorMessage="Invalid Id Number" ID="cvIdvalidation" OnServerValidate="cvIdvalidation_ServerValidate" ControlToValidate="txtIdNumber" ValidationGroup="tab1" runat="server" />
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Date of Birth </label>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtBirthDay" name="name" type="text" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>Age</label>
                                                    <asp:TextBox MaxLength="4" runat="server" ID="txtAge" ReadOnly="true" Text="Will be Calculated From Date Of Birth" name="txtAge" type="text" class="form-control"></asp:TextBox>
                                                    <%--                                                    <div class="ibox-title">
                                                        <h5>Vehicles</h5>
                                                        <div class="ibox-tools">
                                                            <a class="collapse-link">
                                                                <i class="fa fa-chevron-up"></i>
                                                            </a>
                                                            <a class="close-link">
                                                                <i class="fa fa-times"></i>
                                                            </a>
                                                        </div>
                                                    </div>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Gender</label>
                                                    <asp:RadioButtonList CssClass="radio radiogroup "  RepeatDirection="Horizontal" ID="rbtnlGender" runat="server">
                                                        <asp:ListItem  Value="0">Male</asp:ListItem>
                                                        <asp:ListItem Value="1">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Cellphone Number  <em>*</em>  </label>
                                                    <%--   <label>Cellphone Number <%#Eval("Surname") %>  </label>--%>
                                                    <asp:TextBox MaxLength="20" runat="server" ID="txtCellphone" name="txtCellphone" type="text" class="form-control"></asp:TextBox>
                                                    <%#Eval("FullName") %>
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
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleMake" ID="RequiredFieldValidator19" ForeColor="red" runat="server" Display="None" ErrorMessage="Please enter vehicle make"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Citizenship</label>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleModel" ID="RequiredFieldValidator29" ForeColor="red" runat="server" ErrorMessage="Please enter vehicle model" Display="None"></asp:RequiredFieldValidator>--%>
                                                    <asp:DropDownList ID="ddlCitizenship" runat="server" DataTextField="Name" DataValueField="CountryCode" CssClass="form-control m-b"></asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab5" ControlToValidate="txtVehicleYear" ID="RequiredFieldValidator37" ForeColor="red" runat="server" Display="None" ErrorMessage="Please enter vehicle year"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Passport</label>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtPassport" name="txtPassport" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="tab1" ControlToValidate="txtPassport" ID="rfvPassport" ForeColor="red" runat="server" ErrorMessage="Enter Passport Number"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:CheckBox ID="chkIdORPass" runat="server" Text="Either Allow Passport Number Or ID Number" AutoPostBack="true" OnCheckedChanged="chkIdORPass_CheckedChanged" />
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
                                                                    <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
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
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtVehicleYear" Display="None" ErrorMessage="Please Enter Year" ForeColor="Red" ValidationGroup="tab5"></asp:RequiredFieldValidator>
                                                                </div>


                                                                <div class="form-group">
                                                                    <label>Color <em>*</em></label>
                                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtVehicleColor" name="name" type="text" class="form-control"></asp:TextBox>
                                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
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
                                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                                </div>
                                                                <div class="form-group">
                                                                    <asp:TextBox CssClass="form-control" MaxLength="30" runat="server" ID="txtDependencyCovertDate" placeholder="Enter Cover Date" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                                </div>

                                                                <div class="form-group">
                                                                    &nbsp;<asp:TextBox MaxLength="30" runat="server" ID="txtDependencyDOB" placeholder="Enter Date Of Birth" name="name" type="text" class="form-control" Visible="False"></asp:TextBox>
                                                                    <%--                                                 <div>
                                                        <asp:Button runat="server" ID="Button10" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" Text="Next" OnClick="btnTab10_Click" />
                                                    </div>--%>
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
                                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(1);">Back</button>
                                                                    </div>
                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="False" ID="btnResetTab" runat="server" Text="Reset" OnClick="btnResetTab_Click" Enabled="False" />
                                                                    </div>
                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="true" ID="btnTab5" runat="server" Text="Next" OnClick="btnTab5_Click" />
                                                                    </div>
                                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
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
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                </div>

                                                <div class="form-group">
                                                    <label>Bank Name <em>*</em></label>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                    <asp:DropDownList ID="ddlBank" InitialValue="0" runat="server" DataTextField="BankName" DataValueField="BranchCode" CssClass="form-control m-b">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0" ValidationGroup="tab4" ControlToValidate="ddlBank" ID="RequiredFieldValidator35" ForeColor="red" runat="server" ErrorMessage="Please Select Bank" Display="None"></asp:RequiredFieldValidator>

                                                </div>
                                                <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>                                                    <%#Eval("VehicleMake") %>                                                    <%#Eval("VehicleModel") %>                                            <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>

                                                <div class="form-group">
                                                    <label>Branch Code <em>*</em></label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtBranchcode" name="name" type="text" class="form-control"></asp:TextBox>

                                                    <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Account Number <em>*</em></label>
                                                    <asp:TextBox MaxLength="50" runat="server" ID="txtAccountno" name="name" type="text" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="tab4" ControlToValidate="txtAccountno" ID="RequiredFieldValidator7" ForeColor="red" runat="server" ErrorMessage="Please enter Account Number"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Account Type <em>*</em></label>
                                                    <%--<asp:HyperLink runat="server" ToolTip='Edit' ID="hrLink" NavigateUrl='<%# "~/Admin/ManageMember.aspx?Id="+MemberId.ToString()+"&PkInoteIDList="+Eval("pkiNoteID")%>'><i class="fa fa-edit"></i></asp:HyperLink>--%>
                                                    <asp:DropDownList runat="server" ID="ddlAccountType" DataTextField="AccountType" DataValueField="AccountTypeID" class="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="None" InitialValue="0" ValidationGroup="tab4" ControlToValidate="ddlAccountType" ID="RequiredFieldValidator8" ForeColor="red" runat="server" ErrorMessage="Please select Account Type"></asp:RequiredFieldValidator>
                                                    <%--<asp:Label ID="lbldoctype" runat="server" Text='<%#Eval("DocType")%>'></asp:Label>--%>
                                                </div>
                                                <div class="form-group">
                                                    <%--                                                                    <div class="btn-group">
                                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" Visible="false" ValidationGroup="tab5" ID="btnDependecyUpdate" runat="server" Text="Update" OnClick="btnDependecyUpdate_Click" />
                                                                    </div>--%>
                                                    <asp:TextBox MaxLength="30" runat="server" ID="txtDebitdate" name="name" type="text" class="form-control" Enabled="False" Visible="False"></asp:TextBox>
                                                    <label>Debit Date <em>*</em> </label>
                                                    <asp:DropDownList ID="ddlDebitDate" class="form-control" runat="server">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">1st</asp:ListItem>
                                                        <asp:ListItem Value="15">15th</asp:ListItem>
                                                        <asp:ListItem Value="25">25th</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="None" InitialValue="0" ValidationGroup="tab4" ControlToValidate="ddlDebitDate" ID="RequiredFieldValidator9" ForeColor="red" runat="server" ErrorMessage="Please select Debit Date"></asp:RequiredFieldValidator>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="tab7" ControlToValidate="txtArea" ID="RequiredFieldValidator31" ForeColor="red" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-primary pull-right m-t-n-xs" onclick="return goToTab(5);">Back</button>
                                                    </div>
                                                  
                                                    <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" ID="btnResetTab4" Visible="false" Enabled="false" runat="server"  Text="Reset" OnClick="btnResetTab_Click"  Style="height: 26px" />
                                                    </div>
                                                
                                                   <div class="btn-group">
                                                        <asp:Button class="btn btn-sm btn-primary pull-right m-t-n-xs" OnClick="btnSave_Click" ID="btnSave"  runat="server" Text="Accept Policy" />
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


        //function EnableTab() {
        //    $("#tab1").show();
        //    $("#tab5").show();
        //    $("#tab4").show();
          
        //    FillAjaxdata();

        //}
    </script>

 <script type="text/javascript">
     $(document).ready(function () {
         //enabledisabletab();
         $("#<%=txtBirthDay.ClientID %>").datepicker({ format: 'dd MM yyyy' });
         $("#<%=txtBirthDay.ClientID %>").on('changeDate', function (ev) {
             $(this).datepicker('hide');
             getAge($("#<%=txtBirthDay.ClientID %>").val())
         })

        
         validate();
         $('#MainContent_txtLastName, #MainContent_txtFirstname').change(validate);

         var tab = $("[id*=TabName]").val();
         $('#myTab a[href="#' + tab + '"]').tab('show');
         var liId = tab.replace("tab-", "");
         $('["#tab' + liId + '"]').addClass("active");
         $('["#tab' + liId + '"]').addClass("active");


         $("li").has('a[data-toggle="tab"]').removeClass("active");
         $("li").has('a[href="#tab-1"]').addClass("active");

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

     function makeReset(target) {
         $('#tabs-' + target + ' input').val('');
         $('#tabs-' + target + ' select').val('0');
         return false;
     }
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

     function DateComparisionJavascriptFun() {
         var idNumber = $("#<%=txtIdNumber.ClientID %>").val();
         //alert(idNumber);
         var textLength = idNumber.length;
         if (textLength == 13) {
             // //alert(textLength);
             Validate();
         }
     }

    



 </script>
</asp:Content>
