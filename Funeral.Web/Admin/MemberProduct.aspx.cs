using Funeral.Model;
using Funeral.Web.App_Start;
using Funeral.Web.Common;
using Funeral.Web.FuneralServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Funeral.Web.Admin
{
    public partial class MemberProduct : AdminBasePage
    {
        public int MemberId
        {
            get
            {
                if (ViewState["_memberId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["_memberId"]);
            }
            set
            {
                ViewState["_memberId"] = value;
            }
        }

        private int IncrementVehicle
        {
            get
            {
                if (Session["IncrementVehicle"] == null)
                    return 0;

                return (int)Session["IncrementVehicle"];
            }
            set
            {
                Session["IncrementVehicle"] = value;
            }
        }

        public DateTime MaxIfEmpty(string strValue)
        {
            if (strValue == "" || strValue == string.Empty)
                return DateTime.MaxValue;
            else
                return Convert.ToDateTime(strValue);
        }

        public DataTable LocalQoute
        {
            get
            {
                if (Session["LocalQoute"] != null)
                {
                    return Session["LocalQoute"] as DataTable;
                }
                else
                {
                    return null;
                }
            }
            set { Session["LocalQoute"] = value; }
        }

       

        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnId.Value = MemberId.ToString();
           
            if (!Page.IsPostBack)
            {
                SecureUserGroupsModel model;
                model = client.GetUserAccessByID(UserID, ParlourId);
              
                BindBank();
               
                BindCountry();
               
                // BindReportData();
                //PolicyDoc.Enabled = false;
                rfvPassport.Enabled = false;

                LocalQoute = applictionLogo();
                if (Request.QueryString["ID"] != null)
                {
                   // PolicyDoc.Enabled = true;

                  //  BindMemberToUpdate();

                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableControl", "$(\"#tab6\").hide();", true);
                }

               
                SuperUserRoles();
                //LoadUserRights();
            }
        }

        public void bindVehicles()
        {
            List<VehiclesModel> vehicleList;
            if (Session["Vehicle"] != null)
            {
                vehicleList = (List<VehiclesModel>)Session["Vehicle"];
            }
            else
            {
                vehicleList = client.GetVehicleByMemberID(MemberId).ToList();
            }

            gvVehicles.DataSource = vehicleList;
            gvVehicles.DataBind();
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

        private void BindCountry()
        {
            ddlCitizenship.DataSource = client.GetCountry();
            ddlCitizenship.DataBind();
            ddlCitizenship.ClearSelection(); //making sure the previous selection has been cleared
            ddlCitizenship.Items.FindByValue("ZA").Selected = true;
        }

        public DataTable applictionLogo()
        {
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.StoredProcedure;
            com1.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com1.CommandText = "ApplicationSelectByParlourId";
            com1.Parameters.Add(new SqlParameter("@ParlourId", ParlourId));
            SqlDataAdapter adp1 = new SqlDataAdapter(com1);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            return dt1;
        }

        private void SuperUserRoles()
        {
            SecureUserGroupsModel model;
            model = client.GetSuperUserAccessByID(UserID, ParlourId).Where(x => x.fkiSecureGroupID == 12 || x.fkiSecureGroupID == 4).FirstOrDefault();
            if (model != null)
            {
                txtIdNumber.ReadOnly = false;
            }
        }

        //public void LoadUserRights()
        //{
        //    btnSave.Enabled = this.HasCreateRight;
        //}

        //public void saveAddproduct(int id)
        //{
        //    MemberAddonProductsModel profile = (MemberAddonProductsModel)Session["Product"];
        //    if (profile != null)
        //    {
        //        profile.fkiMemberid = id;
        //        int AddonProductID = client.SaveAddonProducts(profile);
        //        Session["Product"] = null;
        //    }
        //}

        public void SaveVehicle(int id)
        {
            if (Session["Vehicle"] != null)
            {
                List<VehiclesModel> vehiclesList = (List<VehiclesModel>)Session["Vehicle"];
                foreach (var vehicle in vehiclesList)
                {
                    if (!string.IsNullOrEmpty(vehicle.VehicleRegNo))
                    {
                        vehicle.FkiMemberID = id;
                        client.SaveVehicle(vehicle);
                    }
                }
                Session["Vehicle"] = null;
            }
        }
        private void SelectVehicleByVehicleId(int VehicleID)
        {
            DateTime dt = new DateTime(1900, 01, 01);
            VehiclesModel objvehiclesmodel = new VehiclesModel();
            objvehiclesmodel = client.SelectVehicleByVehicleId(VehicleID);
            txtVehicleMake.Text = objvehiclesmodel.VehicleMake;
            txtVehicleModel.Text = objvehiclesmodel.VehicleModel;
            txtVehicleYear.Text = objvehiclesmodel.VehicleYear;
            txtVehicleColor.Text = objvehiclesmodel.VehicleColor;
            txtVehicleTrackingCompany.Text = objvehiclesmodel.VehicleTrackingCompany;
            txtVehicleVinNo.Text = objvehiclesmodel.VehicleVinNo;
            txtVehicleRegNo.Text = objvehiclesmodel.VehicleRegNo;
            txtVehicleEngNo.Text = objvehiclesmodel.VehicleEngNo;
            hfVehicleId.Value = objvehiclesmodel.PkiVehicleID.ToString();
            btnAddVehicle.Visible = false;
            btnUpdateVehicle.Visible = true;
        }
        protected void chkIdORPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIdORPass.Checked == true)
            {
                txtPassport.ReadOnly = false;
                txtIdNumber.ReadOnly = true;
                rfvIdnumber.Enabled = false;
                rfvPassport.Enabled = true;
                txtIdNumber.Text = string.Empty;
            }
            if (chkIdORPass.Checked == false)
            {
                txtIdNumber.ReadOnly = false;
                txtPassport.ReadOnly = true;
                txtPassport.Text = string.Empty;
                rfvIdnumber.Enabled = true;
                rfvPassport.Enabled = false;
            }
        }

        protected void ddlbank_Changed(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue == "-1")
            {
                BindBank();
            }

            BindBank();
          

        }

        protected void cvIdvalidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                bool IDCheck = IdValidationClass.IdValidation(txtIdNumber.Text);
                args.IsValid = IDCheck;
            }
        }

        protected void btnNextTb1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(5);", true);
            }

        }

        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string VehicleVinNo = txtVehicleVinNo.Text;
                    if (VehicleVinNo == "" || VehicleVinNo == string.Empty)
                        VehicleVinNo = "0";
                    else
                        VehicleVinNo = txtVehicleVinNo.Text;
                    VehiclesModel ObjVehicleModel;
                    ObjVehicleModel = client.GetVehicleByVinNo(VehicleVinNo, ParlourId, MemberId);
                    if (ObjVehicleModel != null)
                    {
                        ShowMessage(ref lblMessage, MessageType.Danger, "Vehicle  Already Exists.");
                    }
                    else
                    {
                        ObjVehicleModel = new VehiclesModel();
                        ObjVehicleModel.VehicleMake = txtVehicleMake.Text;
                        ObjVehicleModel.VehicleModel = txtVehicleModel.Text;
                        ObjVehicleModel.VehicleYear = txtVehicleYear.Text;
                        ObjVehicleModel.VehicleColor = txtVehicleColor.Text;
                        ObjVehicleModel.VehicleTrackingCompany = txtVehicleTrackingCompany.Text;
                        ObjVehicleModel.VehicleRegNo = txtVehicleRegNo.Text;
                        ObjVehicleModel.VehicleVinNo = txtVehicleVinNo.Text;
                        ObjVehicleModel.VehicleEngNo = txtVehicleEngNo.Text;
                        ObjVehicleModel.FkiMemberID = this.MemberId;
                        ObjVehicleModel.ParlourID = this.ParlourId;
                        ObjVehicleModel.StartDate = DateTime.Now;
                        ObjVehicleModel.LastModified = DateTime.Now;
                        ObjVehicleModel.ModifiedUser = this.User.Identity.Name;

                        int documentId;
                        if (ObjVehicleModel.FkiMemberID != 0)
                        {
                            documentId = client.SaveVehicle(ObjVehicleModel);
                            // bindVehicles();
                        }
                        if (ObjVehicleModel.FkiMemberID == 0)
                        {
                            List<VehiclesModel> modelList = new List<VehiclesModel>();
                            if (Session["Vehicle"] == null)
                            {
                                modelList.Add(ObjVehicleModel);
                            }
                            else
                            {
                                modelList = (List<VehiclesModel>)Session["Vehicle"];
                                modelList.Add(ObjVehicleModel);
                            }
                            Session["Vehicle"] = modelList;
                        }
                        bindVehicles();
                        ClearVehiclesControl();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab5", "goToTab(5);", true);
                        ShowMessage(ref lblMessage, MessageType.Success, "Vehicle successfully saved");
                        IncrementVehicle++;

                    }
                }
                catch (FaultException<FuneralServiceFault> fault)
                {
                    lblMessage.Text = "<div class='ibox-content'><div class='alert alert-Danger'>" + fault.Detail.Message + "</div>";
                }
                catch (Exception ex)
                {
                    ShowMessage(ref lblMessage, MessageType.Danger, ex.Message);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab5", "goToTab(5);", true);
                ShowMessage(ref lblMessage, MessageType.Danger, "Vehicle not saved");
            }
        }

        private void ClearVehiclesControl()
        {
            txtVehicleMake.Text = string.Empty;
            txtVehicleModel.Text = string.Empty;
            txtVehicleYear.Text = string.Empty;
            txtVehicleColor.Text = string.Empty;
            txtVehicleTrackingCompany.Text = string.Empty;
            txtVehicleEngNo.Text = string.Empty;
            txtVehicleVinNo.Text = string.Empty;
            txtVehicleRegNo.Text = string.Empty;
        }

        protected void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    VehiclesModel ObjVehicleModel = new VehiclesModel();
                    ObjVehicleModel = new VehiclesModel();
                    ObjVehicleModel.VehicleMake = txtVehicleMake.Text;
                    ObjVehicleModel.VehicleModel = txtVehicleModel.Text;
                    ObjVehicleModel.VehicleYear = txtVehicleYear.Text;
                    ObjVehicleModel.VehicleColor = txtVehicleYear.Text;
                    ObjVehicleModel.VehicleTrackingCompany = txtVehicleTrackingCompany.Text;
                    ObjVehicleModel.VehicleRegNo = txtVehicleRegNo.Text;
                    ObjVehicleModel.VehicleVinNo = txtVehicleVinNo.Text;
                    ObjVehicleModel.VehicleEngNo = txtVehicleEngNo.Text;
                    ObjVehicleModel.FkiMemberID = this.MemberId;
                    ObjVehicleModel.ParlourID = this.ParlourId;
                    ObjVehicleModel.StartDate = DateTime.Now;
                    ObjVehicleModel.LastModified = DateTime.Now;
                    ObjVehicleModel.ModifiedUser = this.User.Identity.Name;
                    ObjVehicleModel.PkiVehicleID = Convert.ToInt32(hfVehicleId.Value);

                    int documentid = client.UpdateVehicle(ObjVehicleModel);
                    btnAddVehicle.Visible = true;
                    btnUpdateVehicle.Visible = false;
                    bindVehicles();
                    ClearVehiclesControl();
                    ShowMessage(ref lblMessage, MessageType.Success, "Vehicle udpated successfully");
                    Response.Redirect("~/admin/managemember.aspx?tabid=5&id=" + ObjVehicleModel.PkiVehicleID.ToString());
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gototab51", "gototab(5);", true);
                }
                catch (FaultException<FuneralServiceFault> fault)
                {
                    lblMessage.Text = "<div class='ibox-content'><div class='alert alert-danger'>" + fault.Detail.Message + "</div>";

                }
                catch (Exception ex)
                {
                    ShowMessage(ref lblMessage, MessageType.Danger, ex.Message);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gototab51", "gototab(5);", true);
            }
        }

        protected void btnResetTab_Click(object sender, EventArgs e)
        {
            Response.Redirect("Members.aspx");
        }

        protected void btnTab5_Click(object sender, EventArgs e)
        {
            if (gvVehicles.Rows.Count == 0)
            {

                ShowMessage(ref lblMessage, MessageType.Info, "Vehicle Record Not available");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(4);", true);

            }
            else
            {
                BindBank();
                hdnId1.Value = gvVehicles.Rows.Count.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(4);", true);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool isNewPolicy = false;
                string MemberIdNumber = txtIdNumber.Text;
                if (MemberIdNumber == "" || MemberIdNumber == string.Empty)
                    MemberIdNumber = "0";
                else
                    MemberIdNumber = txtIdNumber.Text;
                MembersModel model;
                //AdditionalMemberInfoModel model1 = new AdditionalMemberInfoModel();
                model = client.GetMemberByIDNum(MemberIdNumber, ParlourId);
                if (model != null && model.pkiMemberID != MemberId)
                {
                    ShowMessage(ref lblMessage, MessageType.Danger, "Member Already Exists.");
                }
                else
                {
                    model = new MembersModel();
                    //Fields Which belongs from source page
                    model.pkiMemberID = MemberId;
                    model.FullNames = txtFirstname.Text;
                    model.Surname = txtLastName.Text;
                    model.IDNumber = txtIdNumber.Text;
                    model.MemberType = "Main";
                    model.DateOfBirth = MaxIfEmpty(txtBirthDay.Text);
                    model.Gender = rbtnlGender.SelectedValue;
                    model.Cellphone = txtCellphone.Text;
                    model.Telephone = txtTelePhone.Text;
                    model.Email = txtEmail.Text;

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
                    else if (ddlDebitDate.SelectedValue == "25")
                    {
                        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                        model.DebitDate = date;
                    }
                    else
                    {
                        model.DebitDate = DateTime.MaxValue;
                    }
                  
                    model.AccountHolder = txtAccountholder.Text;
                    model.Bank = ddlBank.SelectedItem.Text;
                   
                    model.BranchCode = txtBranchcode.Text;
                    model.AccountNumber = txtAccountno.Text;
                    model.AccountType = ddlAccountType.SelectedItem.Text;
                   
                    model.parlourid = ParlourId;

                   
                    model.pkiAdditionalMemberInfo = Guid.NewGuid();
                   
                    model.Citizenship = ddlCitizenship.SelectedItem.Text;
                    model.Passport = txtPassport.Text;
                    model.PolicyStatus = "On Trial";
                    //model.MemeberNumber = ltrPolicyNumber.Text;
                    model.ModifiedUser = UserName;
                    

                    model.IsUploaded = false;
                    model.TotalVehicle = IncrementVehicle;
                    //================================================================ 
                    int retID = client.SaveMember(model);
                    MemberId = retID;
                    if (Request.QueryString["ID"] == null)
                    {
                       // saveAddproduct(MemberId);
                        SaveVehicle(MemberId);
                    }
                    //PolicyDoc.Enabled = true;
                    
                    hdnId.Value = retID.ToString();
                 
                   // BindAddonProducts();
                    bindVehicles();
                   
                      ShowMessage(ref lblMessage, MessageType.Success, "Member successfully saved");
                }
              
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab512", "goToTab(5);", true);
            }
        }

        protected void gvVehicles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                VehiclesModel rowView = (VehiclesModel)e.Row.DataItem;
                // Retrieve the key value for the current row. Here it is an int.
                //int myDataKey = Convert.ToInt32(rowView["pkiVehicleID"]);
                if (rowView.PkiVehicleID == 0)
                {
                    LinkButton lbtnEditVehicle = e.Row.FindControl("lbtnEditVehicle") as LinkButton;
                    if (lbtnEditVehicle != null)
                        lbtnEditVehicle.Enabled = true;
                    LinkButton lbtnDeleteVehicle = e.Row.FindControl("lbtnDeleteVehicle") as LinkButton;
                    if (lbtnDeleteVehicle != null)
                        lbtnDeleteVehicle.Enabled = false;
                }
            }
        }

        protected void gvVehicles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditVehicle")
            {
                btnAddVehicle.Visible = false;
                btnUpdateVehicle.Visible = true;

                hfVehicleId.Value = e.CommandArgument.ToString();
                SelectVehicleByVehicleId(Convert.ToInt32(e.CommandArgument));
            }
            else if (e.CommandName == "DeleteVehicle")
            {
                bindVehicles();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab5", "goToTab(5);", true);
        }
    }
}