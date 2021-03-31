using Funeral.BAL;
using Funeral.Model;
using Funeral.Web.App_Start;
using Funeral.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Funeral.Web.Admin
{
    public partial class debitOrderMembers :  AdminBasePage//System.Web.UI.Page
    {
        private MembersModel model;
        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();

        #region Page Property        
        public int PageSize
        {
            get
            {
                if (ViewState["_PageSize"] == null)
                    return 10;
                else { return Convert.ToInt32(ViewState["_PageSize"].ToString()); }

            }
            set { ViewState["_PageSize"] = value; }

        }
        public int PageNum
        {
            get
            {
                if (ViewState["_PageNum"] == null)
                    return 1;
                else { return Convert.ToInt32(ViewState["_PageNum"].ToString()); }
            }
            set { ViewState["_PageNum"] = value; }

        }        
        public string SortBy
        {
            get
            {
                if (ViewState["_SortBy"] == null)
                    return "   ";
                else { return ViewState["_SortBy"].ToString(); }
            }
            set { ViewState["_SortBy"] = value; }

        }
        public string SortOrder
        {
            get
            {
                if (ViewState["_SortOrder"] == null)
                    return "ASC";
                else { return ViewState["_SortOrder"].ToString(); }
            }
            set { ViewState["_SortOrder"] = value; }

        }
        #endregion

        #region Page size change event
        protected void gvDebitOrderMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDebitOrderMembers.PageIndex = e.NewPageIndex;
            BindMember();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            BindMember();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            BindBank();
            btnSaveDebitOrder.Enabled = true;
            BindMember();
            rfvPassport.Enabled = false;
            
        }
        public void BindMember()
        {
            gvDebitOrderMembers.PageSize = PageSize;
            MembersViewModel model = MembersBAL.GetAllDebitOrderMembers(ParlourId, PageSize, PageNum, txtKeyword.Text, SortBy, SortOrder);
            StringBuilder sb = new StringBuilder();
            gvDebitOrderMembers.DataSource = model.MemberList;
            gvDebitOrderMembers.DataBind();
        }
        private void BindBank()
        {            
            ddlBank.DataSource = client.GetAllBank();
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Bank", "0"));
            ddlBank.Items.Add(new ListItem("Other", "-1"));


            ddlAccountType.DataSource = client.AccountTypeSelectAll();
            ddlAccountType.DataBind();
            ddlAccountType.Items.Insert(0, new ListItem("Select account type", "0"));
        }
        protected void cvIdvalidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                bool IDCheck = IdValidationClass.IdValidation(txtIdNumber.Text);
                args.IsValid = IDCheck;
            }
        }
        protected void IdorPass_chkEvent(object sender, EventArgs e)
        {
            if (chkIdORPass.Checked == true)
            {
                txtPassport.ReadOnly = true;
                txtIdNumber.ReadOnly = false;
                rfvIdnumber.Enabled = true;
                rfvPassport.Enabled = false;
                txtIdNumber.Text = string.Empty;
            }
            if (chkIdORPass.Checked == false)
            {
                txtIdNumber.ReadOnly = true;
                txtPassport.ReadOnly = false;
                txtPassport.Text = string.Empty;
                rfvIdnumber.Enabled = false;
                rfvPassport.Enabled = true;
            }
        }
      
        #region Keyword search event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindMember();
        }
        #endregion
        protected void btnSaveDebitOrder_Click(object source, EventArgs e)
        {
            model = new MembersModel();
            model.FullNames = txtName.Text;
            model.Surname = txtSurname.Text;
            model.IDNumber = txtIdNumber.Text;
            model.DateOfBirth = MaxIfEmpty(txtBirthDay.Text);
           // model.DebitDate = DateTime.Parse(txtDebitDate1.Text);    //Convert.ToDateTime(txtDebitDate1.Text);       
            if (ddlDebitDate.SelectedValue == "1")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                model.DebitDate = date;
            }
            else if (ddlDebitDate.SelectedValue == "15")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
                model.DebitDate = date;
            }
            else if (ddlDebitDate.SelectedValue == "23")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 23);
                model.DebitDate = date;
            }
            else if (ddlDebitDate.SelectedValue == "25")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                model.DebitDate = date;
            }
            else if (ddlDebitDate.SelectedValue == "26")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 26);
                model.DebitDate = date;
            }
            else if (ddlDebitDate.SelectedValue == "28")
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
                model.DebitDate = date;
            }
            else
            {
                model.DebitDate = DateTime.MaxValue;
            }
            //model.DebitDate = Convert.ToDateTime(txtDebitdate.Text);
           //model.DebitDate = DateTime.Parse(txtDebitDate.Text);
            // model.AccountHolder = txtAccountholder.Text;
            //model.Premium = Convert.ToDecimal(txtPremium);

            model.Bank = ddlBank.SelectedItem.Text;
            model.Passport = txtPassport.Text;
            model.BranchCode = txtBranchcode.Text;
            model.AccountNumber = txtAccountno.Text;
            model.parlourid = ParlourId;
            model.AccountType = ddlAccountType.SelectedItem.Text;
            model.MemeberNumber = txtPolicyNumber.Text;
            model.PolicyStatus = Convert.ToString("New Business");
            model.Premium = Convert.ToDecimal(txtPremium.Text);

            if (txtIdNumber == null && txtPassport == null)
            {
                return;
            }         
            BindMember();
            MembersBAL.SaveOrderMember(model);          
            //string MemberNumber = MembersBAL.SaveOrderMember(model);                            
            ShowMessage(ref lblMessage, MessageType.Success, "Client Saved Successfully");
            lblMessage.Visible = true;
            ClearOrderMemberControl();       
        }
        
        public DateTime MaxIfEmpty(string strValue)
        {
            if (strValue == "" || strValue == string.Empty)
                return DateTime.MaxValue;
            else
                return Convert.ToDateTime(strValue);
        }
        protected void ddlbank_Changed(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue == "-1")
            {
                BindBank();
            }

            BindBank();
        }
        private void ClearOrderMemberControl()
        {
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtIdNumber.Text = string.Empty;
            txtBirthDay.Text = string.Empty;
            //txtAccountholder.Text = string.Empty;
            txtAccountno.Text = string.Empty;
            txtBranchcode.Text = string.Empty;
            //ddlBank.Items.Clear();
            //ddlAccountType.Items.Clear();
            txtPremium.Text = string.Empty;
            txtPolicyNumber.Text = string.Empty;
            //txtDebitdate.Text = string.Empty;
            ddlDebitDate.Items.Clear();           
        }

        //public void EditPolicy(object sender, EventArgs e)
        //{           
        //    model.FullNames = txtName.Text;
        //    model.Surname = txtSurname.Text;
        //    model.IDNumber = txtIdNumber.Text;
        //    model.DateOfBirth = MaxIfEmpty(txtBirthDay.Text);
        //    model.DebitDate = DateTime.Parse(txtDebitDate1.Text); 
        //    model.Bank = ddlBank.SelectedItem.Text;
        //    model.Passport = txtPassport.Text;
        //    model.BranchCode = txtBranchcode.Text;
        //    model.AccountNumber = txtAccountno.Text;
        //    model.parlourid = ParlourId;
        //    model.AccountType = ddlAccountType.SelectedItem.Text;
        //    model.MemeberNumber = txtPolicyNumber.Text;
        //    model.PolicyStatus = Convert.ToString("Active");
        //    model.Premium = Convert.ToDecimal(txtPremium.Text);
        //    if (txtIdNumber == null && txtPassport == null)
        //    {
        //        return;
        //    }
        //    BindMember();
        //    MembersBAL.SaveOrderMember(model);
        //}

        //protected void gvDebitOrderMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
           

        //    // Convert the row index stored in the CommandArgument
        //    // property to an Integer.

        //    int index = Convert.ToInt32(e.CommandArgument);

        //    // Retrieve the row that contains the edit button clicked 
                          
        //    GridViewRow row = gvDebitOrderMembers.Rows[index];
        //    //gvDebitOrderMembers is the gv name

        //    // Accessing the gridviewrow.
        //    if (e.CommandName == "Edit_Policy")
        //    {        
                        
        //        var Names = row.Cells[0].Text;
        //        var Surname = row.Cells[1].Text;
        //        var IDNumber = row.Cells[2].Text;
        //        var DateOfBirth = row.Cells[3].Text;               
        //        var Bank = row.Cells[4].Text;
        //        var BranchCode = row.Cells[5].Text;
        //        var Premium = row.Cells[6].Text;
        //        var AccountNumber = row.Cells[7].Text;
        //        var AccountType = row.Cells[8].Text;
        //        var DebitDate = row.Cells[9].Text;
        //        var Passport = row.Cells[10].Text;                                                                                                
        //        var MemeberNumber = row.Cells[11].Text;

        //        int results = MembersBAL.GetMember(model);
                            
        //    }
        //}

        //protected void Page_Load1(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        ShowData();
        //    }
        //}

        //protected void ShowData()
        //{
        //    dtblTable = new DataTable();
        //    con = new SqlConnection(cs);
        //    con.Open();
        //    adapt = new SqlDataAdapter("Select ID,Name,City from tbl_Employee", con);
        //    adapt.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        gvDebitOrderMembers.DataSource = dt;
        //        gvDebitOrderMembers.DataBind();
        //    }
        //    con.Close();
        //}

        //protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        //{
        //    //NewEditIndex property used to determine the index of the row being edited.  
        //    gvDebitOrderMembers.EditIndex = e.NewEditIndex;
        //    ShowData();
        //}

        //protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        //{
        //    //Finding the controls from Gridview for the row which is going to update  
        //    Label id = gvDebitOrderMembers.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        //    TextBox name = gvDebitOrderMembers.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        //    TextBox city = gvDebitOrderMembers.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        //    con = new SqlConnection(cs);
        //    con.Open();
        //    //updating the record  
        //    SqlCommand cmd = new SqlCommand("Update tbl_Employee set Name='" + name.Text + "',City='" + city.Text + "' where ID=" + Convert.ToInt32(id.Text), con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //    gvDebitOrderMembers.EditIndex = -1;
        //    //Call ShowData method for displaying updated data  
        //    ShowData();
        //}
        //protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        //{
        //    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        //    gvDebitOrderMembers.EditIndex = -1;
        //    ShowData();
        //}
        //protected void gvDebitOrderMembers(object sender, GridViewEditEventArgs e)
        //{

        //}
    }
}