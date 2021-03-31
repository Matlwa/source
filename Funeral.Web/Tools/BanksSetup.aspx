<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BanksSetup.aspx.cs" Inherits="Funeral.Web.Tools.BanksSetup" %>

<%@ Register Src="~/UserControl/ctrlBanks.ascx" TagName="ucBanks" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        em {
            color: red;
        }

        .Bankmodal {
            width: 1000px;
            left: 20% !important;
            top: 13% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>

        <div class="col-lg-12">
            <div id="Banks" class="ui-tabs-panel ui-widget-content ui-corner-bottom">
                <div class="dataTables_wrapper" id="tblMembersSearch_wrapper">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="ibox ">
                                <div class="ibox-title">
                                    <h5>Banks List</h5>
                                </div>
                                <div class="ibox-content">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Label runat="server" ID="Label1"></asp:Label>
                                        </div>
                                        <asp:Label ID="lblRecords" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 ">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvBanks" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                    AutoGenerateColumns="False" EmptyDataText="There are no jobs to display."
                                                    OnRowCommand="gvBanks_RowCommand" DataKeyNames="BankId">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:BoundField DataField="BankId" HeaderText="ID" ReadOnly="True" Visible="false" />
                                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" ReadOnly="True" />

                                                        <asp:TemplateField HeaderText="Actions">
                                                            <ItemTemplate>
                                                                <%-- <% if (this.HasEditRight)
                                                                   {%>--%>
                                                                <asp:LinkButton runat="server" ToolTip='Click here to Edit - ' ID="lbtnEditBank" CommandArgument='<%#Eval("BankId")%>' CommandName="EditBank"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                <%--<%} if (this.HasDeleteRight)
                                                                   { %>--%>
                                                                <asp:LinkButton runat="server" ID="lbtnDeleteBank" OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%#Eval("BankId")%>' CommandName="deleteBank"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptControl" runat="server">

    <script>
        function openModal(id) {
            $('#ucBank').modal('show');
            FillBindBankAjaxdata(id);
        }

        function FillBindBankAjaxdata(id) {
            //alert('hiii');
           
            //  $('#ucBank').modal('show').on('hidden.bs.modal', function () {

            //  });
            $.ajax({
               // type: "POST",
                url: '<%=ResolveUrl("~/admin/BanksSetup.aspx/BindBankToUpdate")%>',
                data: '{"id":"' + id + '"}',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert(id);
                    alert(data);

                    //var lbl = $(this).val();
                    //if (lbl == "-1") {
                    //openModal();
                    //FillBankAjaxdata();


                    <%--else {
                        $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());
                        // alert(lbl.val());
                    }
                   // alert("good");
                    <%--$('#<%=txtPremium.ClientID%>').val(data.d);--%>
                        <%--  $("#<%=txtBranchcode.ClientID%>").val($("#<%=ddlBank.ClientID%>").val());--%>
                },
             failure: function (response) {
                 alert(response.d);
             }
         });
     }



        <%--(function () {
            
                $('#ucBank').modal('show').on('hidden.bs.modal', function () {
                    
                    $("#<%=gvBanks.ClientID %>").bind();
                  
                }).on('hidden', function () {
                    
                   $("#<%=gvBanks.ClientID %>").bind();
                });
          
        });--%>


    </script>

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

</asp:Content>
