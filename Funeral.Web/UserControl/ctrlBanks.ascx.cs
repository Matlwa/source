using Funeral.Model;
using Funeral.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Funeral.Web.UserControl
{
    public partial class ctrlBanks : BaseUserControl
    {
        private readonly FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
        public event EventHandler btnBankSaveClickEvent;
        
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //if (Request.QueryString["ID"] != null)
                //{
                   
                //    BindBankToUpdate(Convert.ToInt32(Request.QueryString["ID"]));

                //}
            }
        }
       
        protected void btnSaveBank_Click(object sender,EventArgs e)
        {
            if (Page.IsValid)
            {
                BankModel model = new BankModel();
                model.BankId = BankId;
                model.BankName = txtBankname.Text;
                model.BranchCode = txtBankBranchCode.Text;
                int retID = client.SaveBank(model);
                btnBankSaveClickEvent(sender, e);
            }            
        }
    //    public BankModel BindBankToUpdate(int id)
    //    {
            
    //        var BankData = client.SelectBankByID(id);
    //        BankModel model = new BankModel();
    //        if ((BankData == null) || (BankData.BankId != BankId))
    //        {
    //            Response.Write("<script>alert('Sorry!you are not authorized to perform edit on this Bank.');</script>");
    //        }
    //        else
    //        {

    //            model.BankId = BankData.BankId;
    //            model.BankName = BankData.BankName;
    //            model.BranchCode = BankData.BranchCode;

    //        }

    //        return model;
       
    //    //BankModel model = client.SelectBankByID(BankId);
    //    //if ((model == null) || (model.BankId != BankId))
    //    //{
    //    //    Response.Write("<script>alert('Sorry!you are not authorized to perform edit on this Bank.');</script>");
    //    //}
    //    //else
    //    //{
    //    //    BankId = model.BankId;
    //    //    txtBankname.Text = model.BankName;
    //    //    txtBankBranchCode.Text = model.BranchCode;
    //    //    btnBankAdd.Text = "Update";

    //    //   // int bankid = client.SaveBank(bankid);
    //    //}


    //}
}
}