using Funeral.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funeral.Web.App_Start;

namespace Funeral.Web.Tools
{
    public partial class BanksSetup :AdminBasePage
    {
        public int BankId
        {
            get
            {
                if (ViewState["_BankId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["_BankId"]);
            }
            set
            {
                ViewState["_BankId"] = value;
            }
        }

        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ucBanks1.btnBankSaveClickEvent += UcBanks1_btnBankSaveClickEvent;
            if (!Page.IsPostBack)
            {
                BindgvBanks();
            }
        }
        protected void BindgvBanks()
        {
            BankModel model = new BankModel();
            List<BankModel> objList = new List<BankModel>();
            objList = client.GetAllBank().ToList();
            gvBanks.DataSource = objList;
            gvBanks.DataBind();

        }
        private void UcBanks1_btnBankSaveClickEvent(object sender, EventArgs e)
        {
            BindgvBanks();
            
        }

        public BankModel BindBankToUpdate(int id)
        {
            var BankData = client.SelectBankByID(id);
            BankModel model = new BankModel();
            if ((BankData == null) || (BankData.BankId != BankId))
            {
                Response.Write("<script>alert('Sorry!you are not authorized to perform edit on this Bank.');</script>");
            }
            else
            {

                model.BankId = BankData.BankId;
                model.BankName = BankData.BankName;
                model.BranchCode = BankData.BranchCode;

            }

            return model;
        }


        protected void gvBanks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBank")
            {
               

                BankId =Convert.ToInt32(e.CommandArgument.ToString());
                try
                {
                    ucBanks1.BankId = this.BankId;
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal("+ this.BankId + ");", true);
                   
                }
                catch (Exception exe)
                {
                   ShowMessage(ref lblMessage, MessageType.Danger,exe.Message);
                   lblMessage.Visible = true;
                }

            }
            if (e.CommandName == "deleteBank")
            {
               int  SBankId = Convert.ToInt32(e.CommandArgument.ToString());
                try
                {
                  int retID = client.DeleteBank(SBankId);
                    ShowMessage(ref lblMessage, MessageType.Success, "Record deleted successfully.");
                    lblMessage.Visible = true;
                    BindgvBanks();
                }
                catch (Exception exc)
                {
                    ShowMessage(ref lblMessage, MessageType.Danger, exc.Message);
                    lblMessage.Visible = true;
                }

            }
        }


        protected void gvBanks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BankModel rowView = (BankModel)e.Row.DataItem;
                // Retrieve the key value for the current row. Here it is an int.
                //int myDataKey = Convert.ToInt32(rowView["pkiVehicleID"]);
                if (rowView.BankId == 0)
                {
                    LinkButton lbtnEdit = e.Row.FindControl("lbtnEdit") as LinkButton;
                    if (lbtnEdit != null)
                        lbtnEdit.Enabled = true;
                    LinkButton lbtnDelete = e.Row.FindControl("lbtnDelete") as LinkButton;
                    if (lbtnDelete != null)
                        lbtnDelete.Enabled = false;
                }
            }
        }

    }
}