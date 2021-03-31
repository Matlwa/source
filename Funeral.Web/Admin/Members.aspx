<%@ Page Title="Client list" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="Funeral.Web.Admin.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        #tblMembersSearch_filter {
            float: right;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tblMembersSearch').dataTable({
                "oLanguage": { "sSearch": "Search Members:" },
                "iDisplayLength": 10,
                "sPaginationType": "full_numbers",
                "aaSorting": [[0, "asc"]]
            });
        });
        function OpenStatusPopup(ctrl) {
            $("#<%=ddlStatus.ClientID%>").val($(ctrl).data("status"))
            $("#<%=hdnMemberId.ClientID%>").val($(ctrl).data("id"))
            $("#<%=hdnOldStatus.ClientID%>").val($(ctrl).data("status"));
             $("#<%=hdnParlourId.ClientID%>").val($(ctrl).data("parlourid"));
            $('#dvChangeStatusModel').modal('show');
        }

        document.getElementById('<%=txtKeyword.ClientID%>').setAttribute("onkeyup", "runScript(event);return false;");
        function runScript(e) {
            if (e.keyCode == 13) {
                document.getElementById('<%=btnSearch.ClientID%>').click();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dataTables_wrapper" id="tblMembersSearch_wrapper">
        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Clients</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <div class="input-group">
                                    <label>Show</label>
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
                                    entries
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
                        <div class="col-sm-12">
                            <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 ">
                            <div class="table-responsive">
                                <asp:GridView ID="gvMembers" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                    AllowPaging="true" PageSize="25" OnPageIndexChanging="gvMembers_PageIndexChanging" AutoGenerateColumns="False" EmptyDataText="There are no member found."
                                    OnRowCommand="gvMembers_RowCommand">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:BoundField DataField="MemeberNumber" HeaderText="Policy No" ReadOnly="True" />
                                        <asp:BoundField DataField="IDNumber" HeaderText="ID No" ReadOnly="True" />
                                        <asp:BoundField DataField="FullNames" HeaderText="FullNames" ReadOnly="True" />
                                        <asp:BoundField DataField="Cellphone" HeaderText="Cellphone" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                       <asp:BoundField DataField="Telephone" HeaderText="Email" ReadOnly="True" />
                                        <asp:BoundField DataField="CoverDate" HeaderText="Cover date" DataFormatString="{0:dd/MMM/yyyy}" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                        <%--<asp:HyperLinkField DataTextField="PolicyStatus" HeaderText="Policy Status" DataNavigateUrlFields="pkiMemberID,parlourid" DataNavigateUrlFormatString="~/Admin/ManageMembersPayment.aspx?Id={0}&ParlourId={1}" />--%>
                                        <asp:TemplateField HeaderText="Policy Status">
                                            <ItemTemplate>
                                                <%if (this.HasEditRight)
                                                    { %>
                                                <a href="#" id="aChangeStatus" class="cssStatus" onclick="OpenStatusPopup(this)" title="Click here to change status" data-parlourid='<%#Eval("parlourid") %>' data-id='<%#Eval("pkiMemberID")%>' data-status="<%#Eval("PolicyStatus")%>"><%#(Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %></a>
                                                <%}
                                                    else
                                                    { %>
                                                <asp:HyperLink runat="server" ID="hlPolicyStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/ManageMembersPayment.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                <%}  %>
                                            </ItemTemplate>
                                           <%-- <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="hlPolicyStatus" Text='<%# (Convert.ToString(Eval("PolicyStatus"))=="1"?"Active":(Convert.ToString(Eval("PolicyStatus"))=="0"?"waiting":Eval("PolicyStatus"))) %>' NavigateUrl='<%# "~/Admin/ManageMembersPayment.aspx?Id="+ Eval("pkiMemberID") + "&ParlourId="+ Eval("parlourid")  %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                            </ItemTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <%if (this.HasEditRight)
                                                { %>
                                                <asp:HyperLink runat="server" ToolTip='Click here to download - ' ID="hrLink" NavigateUrl='<%#Eval("pkiMemberID", "~/Admin/ManageMember.aspx?Id={0}") %>'><i class="fa fa-edit"></i></asp:HyperLink>
                                                &nbsp;
                                                <%}
                                                    //if (this.HasDeleteRight)
                                                    //{ %>
                                                        <%-- &nbsp;--%>
                                               <%-- <asp:LinkButton runat="server" ID="lbtnDelete" OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%#Eval("pkiMemberID")%>' CommandName="deleteMemeber"><i class="fa fa-trash-o"></i></asp:LinkButton>--%>
                                                <%--<asp:LinkButton runat="server" ID="lbtnDeleteDependatn" ToolTip="Click here To Delete Member" OnClientClick="return confirm('Are you sure you want to delete it?')" CommandArgument='<%#Eval("pkiMemberID") %>' CommandName="deleteMemeber"><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                               <%-- <%} %>--%>
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
    </div>   
     <asp:HiddenField runat="server" ID="hdnMemberId" />
    <asp:HiddenField runat="server" ID="hdnOldStatus" />
    <asp:HiddenField runat="server" ID="hdnParlourId" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">
    <div class="modal fade" id="dvChangeStatusModel" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;  </button>
                    <h4 class="modal-title">Change Status</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label>Status </label>
                                <asp:DropDownList runat="server" ID="ddlStatus" DataTextField="Status" DataValueField="Status" CssClass="form-control">
                                   

                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Reason </label>
                                <asp:TextBox MaxLength="500" TextMode="MultiLine" Columns="50" Rows="5" runat="server" ID="txtChangeReason" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Button Text="Submit" CssClass="btn btn-sm btn-primary pull-right m-t-n-xs" runat="server" ID="btnChangeSubmit" OnClick="btnChangeSubmit_Click" />
                            </div>
                        </div>
                    </div>
               </div>               
            </div>
        </div>
    </div>
</asp:Content>
