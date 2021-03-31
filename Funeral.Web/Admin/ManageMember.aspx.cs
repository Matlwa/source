using Funeral.Model;
using Funeral.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;
using Funeral.BAL;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Configuration;
using System.ServiceModel;
using Funeral.Web.FuneralServiceReference;
using Funeral.Web.Common;
using System.Globalization;
using System.Net.Mail;

namespace Funeral.Web.Admin
{
    public partial class ManageMember : AdminBasePage
    {
        private readonly ISiteSettings _siteConfig = new SiteSettings();
        #region Fields
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
        public string MemburNumber
        {
            get
            {
                if (ViewState["_MemburNumber"] == null)
                    return string.Empty;
                else
                    return ViewState["_MemburNumber"].ToString();
            }
            set
            {
                ViewState["_MemburNumber"] = value;
            }
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
        #endregion

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

        #region Page PreInit
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.dbPageId = 3;
        }
        #endregion

        #region PageInit
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    this.dbPageId = 3;
        //    SecureUserGroupsModel[] obj = client.EditSecurUserbyID(UserID);
        //    List<int> list = new List<int>();
        //    list.Add(5);
        //    list.Add(4);
        //    list.Add(12);
        //    var result = obj.Where(x => list.Contains(x.fkiSecureGroupID));
        //    if (result.FirstOrDefault() == null)
        //    {
        //        Response.Redirect("~/Admin/403Error.aspx", false);
        //    }
        //}
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnId.Value = MemberId.ToString();
            ucBanks1.btnBankSaveClickEvent += UcBanks1_btnBankSaveClickEvent;
            if (!Page.IsPostBack)
            {
                SecureUserGroupsModel model;
                model = client.GetUserAccessByID(UserID, ParlourId);
                if (model != null)
                    txtInception.Enabled = true;
                else
                {
                    txtInception.Enabled = false;
                }
                BindBank();
                BindAllAgent();
                BindCountry();
                bindPolicy();
                BindMonth();
                BindYear();
                BindSociety();
                BindBranches();
                BindNotesList();
                AddonProduct();
                BindCustomDetails();
                // BindReportData();
                PolicyDoc.Enabled = false;
                rfvPassport.Enabled = false;

                LocalQoute = applictionLogo();
                if (Request.QueryString["ID"] != null)
                {
                    PolicyDoc.Enabled = true;

                    BindMemberToUpdate();
                   
                }
                else
                {
                    bindInceptiondate();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableControl", "$(\"#tab6\").hide();", true);
                }

                bindTotalPremium();
                SuperUserRoles();
                LoadUserRights();
            }
        }

        private void UcBanks1_btnBankSaveClickEvent(object sender, EventArgs e)
        {
            BindBank();
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab41", "goToTab(4);", true);
           
        }
        #endregion

        #region Events
        protected void PolicyDocPrint_Click(object sender, EventArgs e)
        {
            //    ServerReport ap =Convert.ToUInt32(ReportViewer1.LocalReport);
            //ReportPrintDocument rp = new ReportPrintDocument(ReportViewer1.LocalReport);
            //rp.Print(); 
        }
        //protected void ddlDependency_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindDependency();
        //}
        protected void btnResetTab_Click(object sender, EventArgs e)
        {
            Response.Redirect("Members.aspx");
        }
        protected void IdorPass_chkEvent(object sender, EventArgs e)
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

        #endregion

        #region Methods
        public void LoadUserRights()
        {
            btnSave.Enabled = this.HasCreateRight;
        }
        public void bindInceptiondate()
        {
            txtInception.Text = (System.DateTime.Now).ToString("dd MMM yyyy");
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
        public void BindAllAgent()
        {
            ddlAgent.DataSource = client.GetAllAgent(ParlourId);
            ddlAgent.DataBind();
            ddlAgent.Items.Insert(0, new ListItem("Select Agent", "0"));
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

        private void BindMonth()
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            int from = DateTime.Now.Month - 1;
            int to = DateTime.Now.Month + 2;

            if (DateTime.Now.Day > 7)
            {
                from= from + 1;
            }



            for (int i = from; i < DateTime.Now.Month + 2; i++)
            {

                if (i <= 12)
                { ddlPolicyStartDate.Items.Add(new ListItem(months[i], (i + 1).ToString())); }
                else
                {
                    if (i == 13)
                        ddlPolicyStartDate.Items.Add(new ListItem(months[i - 12], (i - 12 + 1).ToString()));
                    if (i == 14)
                        ddlPolicyStartDate.Items.Add(new ListItem(months[i - 12], (i - 12 + 1).ToString()));
                    if (i == 15)
                        ddlPolicyStartDate.Items.Add(new ListItem(months[i - 12], (i - 12 + 1).ToString()));
                }

            }

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
        public DateTime MaxIfEmpty(string strValue)
        {
            if (strValue == "" || strValue == string.Empty)
                return DateTime.MaxValue;
            else
                return Convert.ToDateTime(strValue);
        }
        public void bindPolicy()
        {
            PolicyModel[] objPolicyModel = client.GetPolicyByParlourId(ParlourId);
            foreach (PolicyModel policy in objPolicyModel)
            {
                ListItem li = new ListItem();
                li.Text = policy.PlanName;
                li.Value = policy.pkiPlanID.ToString();
                ddlPolicy.Items.Add(li);
            }
            bindTotalPremium();
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
        public void bindTotalPremium()
        {

            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            if (Convert.ToInt32(Request.QueryString["ID"]) == 0)
                ID = Convert.ToInt32(hdnId.Value);
            // ID = Convert.ToInt32(hdnId1.Value);
           
           // txtTotalPremium.Text = client.SumPremium(ID, ParlourId).ToString("R 0.00");

            txtTotalPremium.Text = (client.SumPremium(ID, ParlourId) * IncrementVehicle).ToString("R 0.00");



        }
        public void bindInvoices()
        {
            StringBuilder sb = new StringBuilder();
            MemberInvoiceModel[] objMemberInvoiceModel = client.GetInvoices(ParlourId, MemberId);
            gvInvoices.DataSource = objMemberInvoiceModel;
            gvInvoices.DataBind();
        }
        public void BindSociety()
        {
            SocietyModel[] objSocietyModel = client.SocietyByparlourId(ParlourId);
            foreach (SocietyModel society in objSocietyModel)
            {
                ListItem li = new ListItem();
                li.Text = society.SocietyName;
                li.Value = society.pkiSocietyID.ToString();
                ddlMemberSociety.Items.Add(li);
            }
        }
        public void BindBranches()
        {
            BranchModel[] objBranchModel = client.BranchByparlourId(ParlourId);
            foreach (BranchModel branch in objBranchModel)
            {
                ListItem li = new ListItem();
                li.Text = branch.BranchName;
                li.Value = branch.BranchName;//branch.Brancheid.ToString();
                ddlBankBranch.Items.Add(li);
            }
        }
        public int AgeFromDOB(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
                age--;
            return age;
        }
        //public string FormatDateTime(string date)
        //{
        //    return string.IsNullOrEmpty(date) ? string.Empty : Convert.ToDateTime(date).ToString("dd MMM yyyy");
        //}
        public void bindSupportedDocuments()
        {
            SupportedDocumentModel[] objSupportedDocumentModel = client.SelectSupportDocumentsByMemberId(MemberId);

            gvSupportedDocument.DataSource = objSupportedDocumentModel;
            gvSupportedDocument.DataBind();

        }
        private void BindMemberToUpdate()
        {
            MembersModel model = client.GetMemberByID(Convert.ToInt32(Request.QueryString["ID"]), ParlourId);
            if ((model == null) || (model.parlourid != ParlourId))
            {
                Response.Write("<script>alert('Sorry!you are not authorized to perform edit on this Member.');</script>");
            }
            else
            {
                hdnId.Value = model.pkiMemberID.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DisableControl", "EnableTab()", true);
                MemberId = model.pkiMemberID;
                txtFirstname.Text = model.FullNames;
                txtLastName.Text = model.Surname;
                txtIdNumber.Text = model.IDNumber;
                txtBirthDay.Text = FormatDateTime(model.DateOfBirth.ToString());
                if (model.Gender == "Female")
                    rbtnlGender.SelectedIndex = 1;
                else if (model.Gender == "1")
                    rbtnlGender.SelectedIndex = 1;
                else
                    rbtnlGender.SelectedIndex = 0;

                txtCellphone.Text = model.Cellphone;
                txtTelePhone.Text = model.Telephone;
                txtEmail.Text = model.Email;
                ddlDebitDate.SelectedValue = model.DebitDate.Day.ToString();

                txtStreetAddress.Text = model.Address1;
                txtTown.Text = model.Address2;
                txtCity.Text = model.Address4;
                txtProvince.Text = model.Address3;
                //txtStreetPostalAddress.Text = model.Address4;
                txtCode.Text = model.Code;

                txtPostStreetAddress.Text = model.PostAddress1;
                txtPostTown.Text = model.PostAddress2;
                txtPostProvince.Text = model.PostAddress3;
                txtPostCode.Text = model.PostCode;
                ddlBankBranch.SelectedValue = model.MemberBranch;

                //ddlAgent.SelectedItem.Text = model.Agent;
                ListItem liAgent = ddlAgent.Items.FindByText(model.Agent);
                if (liAgent != null)
                    liAgent.Selected = true;

                txtAccountholder.Text = model.AccountHolder;

                //txtbank.Text = model.Bank;
                ListItem li = ddlBank.Items.FindByText(model.Bank);
                if (li != null)
                    li.Selected = true;

                ddlBank.Text = model.Bank;
                ddlAccountType.Text = model.AccountType;

                //txtBranch.Text = model.Branch;
                txtBranchcode.Text = model.BranchCode;
                txtAccountno.Text = model.AccountNumber;
                if (!IsAdministrator && !IsSuperUser)
                {
                    txtAccountno.TextMode = TextBoxMode.Password;
                    txtAccountno.Attributes.Add("value", model.AccountNumber);
                }
                else
                {
                    txtAccountno.TextMode = TextBoxMode.SingleLine;
                }

                ListItem liAccount = ddlAccountType.Items.FindByText(model.AccountType);
                if (liAccount != null)
                {
                    liAccount.Selected = true;
                }
                ddlMemberSociety.SelectedValue = model.MemberSociety;
                txtInception.Text = FormatDateTime(model.InceptionDate.ToString());
                ddlDebitDate.SelectedValue = model.DebitDate.Day.ToString();
                ddlPolicy.SelectedIndex = ddlPolicy.Items.IndexOf(ddlPolicy.Items.FindByValue(model.fkiPlanID.ToString()));
                // txtPolicyNo.Text = model.MemeberNumber;
                ltrPolicyNumber.Text = model.MemeberNumber;
                txtEasyToPay.Text = model.EasyPayNo;
                txtAge.Text = AgeFromDOB(Convert.ToDateTime(model.DateOfBirth.ToString())).ToString();
                //txtCitizenship.Text = model.Citizenship;

                ddlCitizenship.ClearSelection(); //making sure the previous selection has been cleared
                try
                {
                    ddlCitizenship.Items.FindByText(model.Citizenship).Selected = true;
                }
                catch { ddlCitizenship.Items.FindByValue("ZA").Selected = true; }

                txtPassport.Text = model.Passport;


             
                var m = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(model.StartDate.Month);
               
                        ddlPolicyStartDate.SelectedValue = model.StartDate.Month.ToString();
                        hdnEditStartDate.Value = model.StartDate.ToShortDateString();
                ddlPolicyStartDateYear.SelectedValue = model.StartDate.Year.ToString();

                // var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(model.StartDate.Month);
                //txtPolicyStartDate.Text = FormatDateTime(model.StartDate.ToString());

                hdCoverDate.Value = model.CoverDate != null ? Convert.ToDateTime( model.CoverDate).ToShortDateString() : string.Empty;
                txtCoverDate.Text = hdCoverDate.Value;
                //*****************
                txtIdNumber.ReadOnly = true;
                txtPassport.ReadOnly = true;
                rfvIdnumber.Enabled = false;
                rfvPassport.Enabled = false;
                chkIdORPass.Enabled = false;
                //****************
                /* changes for custom field implemented on 10th April 2017*/
                ddlCustom1.SelectedValue = model.CustomId1 != null ? model.CustomId1.ToString() : string.Empty;
                ddlCustom2.SelectedValue = model.CustomId2 != null ? model.CustomId2.ToString() : string.Empty;
                ddlCustom3.SelectedValue = model.CustomId3 != null ? model.CustomId3.ToString() : string.Empty;
                /* changes for custom field implemented on 10th April 2017  completed*/

                BindNotesList();
                bindInvoices();
                bindVehicles();
                BindAddonProducts();
                Response.Write("<script>window.onload=function(){FillAjaxdata();}</script>");
                //   BindAddonProducts();
                bindSupportedDocuments();
                lblCientDetails.Text = String.Format("{0} {1} {2}", txtFirstname.Text, txtLastName.Text, txtIdNumber.Text);
            }
        }
        public void BindNotesList()
        {
            MemberNotesModel[] objMemberNotesModel = client.GetMemberNoteByMemberID(MemberId);
            gvNotes.DataSource = objMemberNotesModel;
            gvNotes.DataBind();

        }
        public void saveAddproduct(int id)
        {
            MemberAddonProductsModel profile = (MemberAddonProductsModel)Session["Product"];
            if (profile != null)
            {
                profile.fkiMemberid = id;
                int AddonProductID = client.SaveAddonProducts(profile);
                Session["Product"] = null;
            }
        }
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
        public void BindAddonProducts()
        {
            MemberAddonProductsModel[] objAddonProducts = client.SelectMemberAddonProducts(MemberId);
            gvProduct.DataSource = objAddonProducts;
            gvProduct.DataBind();

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
        #endregion

        #region WebMethods
        [WebMethod]
        public static List<string> ddlPolicy_SelectedIndexChanged(int id, string date)
        {
            FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
            PolicyModel objPolicyModel = client.GetPlanSubscriptionByPlanId(id).ToList().FirstOrDefault();
            List<string> Response = new List<string>();
            try
            {
                if (objPolicyModel != null)
                    Response.Add(objPolicyModel.PlanSubscription);
                else
                    Response.Add(string.Empty);
                Response.Add(string.IsNullOrEmpty(client.GetPlanUnderwriterByPlanId(id)) ? string.Empty : client.GetPlanUnderwriterByPlanId(id));
                //  int WaitingPeriod = client.GetWaitingPeriodByPlanId(id);

                if (objPolicyModel.WaitingPeriod != 0 && objPolicyModel.WaitingPeriod == null)
                {
                    Response.Add(DateTime.Now.ToString("dd MMM yyyy"));
                    // Response.Add(DateTime.Now.AddMonths(client.GetWaitingPeriodByPlanId(id)).ToString("dd MMM yyyy"));
                }
                else if (date != "" || date != string.Empty)
                {
                    //DateTime PolicystartDate = Convert.ToDateTime(date);
                    //  Response.Add(PolicystartDate.ToString("dd MMM yyyy"));
                    Response.Add(date);
                    //Response.Add(PolicystartDate.AddMonths(client.GetWaitingPeriodByPlanId(id)).ToString("dd MMM yyyy"));
                }
                //if (objPolicyModel != null)
                //    Response.Add(objPolicyModel.totalPremium);
                //else
                //    Response.Add(string.Empty);
            }
            catch (Exception e) { }

            return Response;
        }

        [WebMethod]
        public static List<string> ddlPolicyStartDate_SelectedIndexChanged(int id, string date, string month, string year)
        {
            List<string> Response = new List<string>();
            try
            {
                if (date != "" || date != string.Empty && month != "" || month != string.Empty && year != "" && month != string.Empty)
                {
                    //DateTime PolicystartDate = Convert.ToDateTime(date);
                    //  Response.Add(PolicystartDate.ToString("dd MMM yyyy"));
                    Response.Add(date);
                    //Response.Add(PolicystartDate.AddMonths(client.GetWaitingPeriodByPlanId(id)).ToString("dd MMM yyyy"));
                }
                //if (objPolicyModel != null)
                //    Response.Add(objPolicyModel.totalPremium);
                //else
                //    Response.Add(string.Empty);
            }
            catch (Exception e) { }

            return Response;
        }


        [WebMethod]


        public static List<string> DependencyStartdateChange(int id, string date)
        {
            FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
            List<string> Response = new List<string>();
            if (date != "" || date != string.Empty)
            {
                DateTime PolicystartDate = Convert.ToDateTime(date);
                Response.Add(PolicystartDate.AddMonths(client.GetWaitingPeriodByPlanId(id)).ToString("dd MMM yyyy"));
            }
            else
            {
                Response.Add(DateTime.Now.AddMonths(client.GetWaitingPeriodByPlanId(id)).ToString("dd MMM yyyy"));
            }
            return Response;
        }
        [WebMethod]
        public static string ddlProductNameChanged(string id)
        {
            Guid strProductName = Guid.Parse(id);
            List<AddonProductsModal> k = MembersBAL.MemberListBindAddonProduct(strProductName);
            string Product = string.Empty;
            if (k.Count != 0)
                Product = "R " + (Math.Round(Convert.ToDecimal(k.FirstOrDefault().ProductCost), 2)).ToString();

            return Product;
        }
        
        [WebMethod]
        public static string ViewNoteDetails(string id)
        {
            var datatable = MembersBAL.MemberNotesBypkiNoteID(Convert.ToInt32(id));
            return (FuneralHelper.DataTableMapToList<MemberNotesModel>(datatable)).FirstOrDefault().Notes.ToString();
        }
        #endregion

        #region Other function and control event
        public void BindReportData()
        {
            LocalReport Rpt = ReportViewer1.LocalReport;
            Rpt.DataSources.Clear();
            Rpt.EnableHyperlinks = true;
        
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com.CommandText = "MemberSelectList";
            com.Parameters.Add(new SqlParameter("@ID", MemberId));
            com.Parameters.Add(new SqlParameter("@ParlourId", ParlourId));
            SqlDataAdapter adp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            SqlCommand com2 = new SqlCommand();
            com2.CommandType = CommandType.StoredProcedure;
            com2.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com2.CommandText = "GetVehicleByMemberID";
            com2.Parameters.Add(new SqlParameter("@fkiMemberID", MemberId));
            SqlDataAdapter adp2 = new SqlDataAdapter(com2);
            DataTable GetVehicleByMemberID = new DataTable();
            adp2.Fill(GetVehicleByMemberID);

            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.StoredProcedure;
            com1.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com1.CommandText = "SelectApplicationTnCByParlourId";
            com1.Parameters.Add(new SqlParameter("@ParlourId", ParlourId));
            SqlDataAdapter adp1 = new SqlDataAdapter(com1);
            DataTable dtTnC = new DataTable();
            adp1.Fill(dtTnC);
            SqlCommand com3 = new SqlCommand();
            com3.CommandType = CommandType.StoredProcedure;
            com3.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com3.CommandText = "BankingSelectById";
            com3.Parameters.Add(new SqlParameter("@ID", ParlourId));
            SqlDataAdapter adp3 = new SqlDataAdapter(com3);
            DataTable BankDT = new DataTable();
            adp3.Fill(BankDT);
            SqlCommand com4 = new SqlCommand();
            com4.CommandType = CommandType.StoredProcedure;
            com4.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com4.CommandText = "PolicyDocTotalPremium";
            com4.Parameters.Add(new SqlParameter("@ID", MemberId));
            SqlDataAdapter adp4 = new SqlDataAdapter(com4);
            DataTable PoliDocTotPremium = new DataTable();
            adp4.Fill(PoliDocTotPremium);

            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.ReportPath = "admin/Reports/ReportLayouts/PolicyDocReport.rdlc";
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMemberSelectList", dt));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGetVehicleByMemberID", GetVehicleByMemberID));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DtApplicationSetting", LocalQoute));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsTermsAndConditionOfApplication", dtTnC));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsBankDetails", BankDT));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsPolicyDocTotalPremium", PoliDocTotPremium));

            ReportViewer1.DataBind();


            ReportParameterCollection reportParameters = new ReportParameterCollection();

            
       
            reportParameters.Add(new ReportParameter("txtApplicantName", ApplicationName));
            ReportViewer1.LocalReport.SetParameters(reportParameters);
            ReportViewer1.LocalReport.Refresh();

        }
        protected void PolicyDoc_Click(object sender, EventArgs e)
        {

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string filename;

            try
            {
                ReportViewer rpw = new ReportViewer();
                rpw.ProcessingMode = ProcessingMode.Remote;
                IReportServerCredentials irsc = new MyReportServerCredentials();
                rpw.ServerReport.ReportServerCredentials = irsc;

                rpw.ProcessingMode = ProcessingMode.Remote;
                rpw.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
                //rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Unplugg IT Busy Days //UIS All Members Report";
                rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Motion Assist Policy Document";
                ReportParameterCollection reportParameters = new ReportParameterCollection();

                reportParameters.Add(new ReportParameter("fkiMemberID", MemberId.ToString()));
                rpw.ServerReport.SetParameters(reportParameters);
                string ExportTypeExtensions = "pdf";
                byte[] bytes = rpw.ServerReport.Render(ExportTypeExtensions, null, out mimeType, out encoding, out ExportTypeExtensions, out streamids, out warnings);
                filename = string.Format("{0}.{1}", "Motion Assist Policy Document", ExportTypeExtensions);
               
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.ContentType = mimeType;
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

               
            }
            catch (Exception exc)
            {
                ShowMessage(ref lblMessage, MessageType.Danger, exc.Message);
            }
        }
        protected void BtnAddNote_Click(object sender, EventArgs e)
        {
            try
            {
                MemberNotesModel objnotes = new MemberNotesModel();
                objnotes.Notes = txtArea.Text.Trim();
                objnotes.fkiMemberID = MemberId;
                objnotes.NoteDate = DateTime.Now;
                objnotes.ModifiedUser = this.User.Identity.Name;
                int noteID = client.SaveMemberNote(objnotes);
                txtArea.Text = string.Empty;
                ShowMessage(ref lblMessage, MessageType.Success, "Notes saved successfully");
                BindNotesList();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab71", "goToTab(7);", true);

            }
            catch (Exception ex)
            {

                ShowMessage(ref lblMessage, MessageType.Danger, "Error in SaveNote: " + ex.Message);
            }
        }
        protected void gridNoteList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pkiNoteID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditNote")
            {
                BtnAddNote.Visible = false;
                btnUpdateNotes.Visible = true;
                MemberNotesModel objnotes = new MemberNotesModel();
                DataTable dr = MembersBAL.MemberNotesBypkiNoteID(pkiNoteID);
                if (dr.Rows.Count > 0)
                {
                    txtArea.Text = dr.Rows[0]["Notes"].ToString();
                    hdnNoteId.Value = dr.Rows[0]["pkiNoteID"].ToString();
                    //FKMemberId = Convert.ToInt32(dr["fkiMemberID"]);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab7", "goToTab(7);", true);
                }
            }
        }
        protected void lnkClose_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            pnlWrapper.Visible = false;
            BindNotesList();
        }
        protected void btnUpdateNotes_Click(object sender, EventArgs e)
        {
            try
            {
                MemberNotesModel objnotes = new MemberNotesModel();
                objnotes.Notes = txtArea.Text.Trim();
                objnotes.fkiMemberID = MemberId;
                objnotes.LastModified = DateTime.Now;
                objnotes.ModifiedUser = this.User.Identity.Name;
                objnotes.pkiNoteID = Convert.ToInt32(hdnNoteId.Value);
                int noteID = client.UpdateNotesMember(objnotes);
                // int NoteID=client.SaveMemberNote(o)
                txtArea.Text = string.Empty;
                hdnNoteId.Value = string.Empty;
                BtnAddNote.Visible = true;
                btnUpdateNotes.Visible = false;

                ShowMessage(ref lblMessage, MessageType.Success, "Notes update successfully");
                BindNotesList();
                //Response.Redirect("ManageMember.aspx?ID=" + objnotes.fkiMemberID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab7", "goToTab(7);", true);

            }
            catch (Exception ex)
            {

                ShowMessage(ref lblMessage, MessageType.Danger, "Error in UpdateNote:" + ex.Message);
            }
            //  BindNotesList();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    MemberAddonProductsModel objProductModel = new MemberAddonProductsModel();

                    objProductModel.DateCreated = DateTime.Now;
                    int index = txtPremium.Text.IndexOf("R ");
                    string cleanPath = (index < 0)
                        ? txtPremium.Text
                        : txtPremium.Text.Remove(index, "R ".Length);
                    objProductModel.ProductCost = Convert.ToDecimal(cleanPath);
                    objProductModel.fkiMemberid = Convert.ToInt32(MemberId);
                    objProductModel.LastModified = DateTime.Now;
                    objProductModel.UserID = Request.LogonUserIdentity.User.ToString();
                    objProductModel.ModifiedUser = this.User.Identity.Name;
                    objProductModel.Deleted = 0;
                    objProductModel.fkiProductID = new Guid(drpProductName.SelectedValue);

                    // objProductModel.UserID = drpUsername.SelectedItem.ToString();
                    //   objProductModel.ProductName = drpProductName.SelectedItem.ToString();
                    objProductModel.parlourid = this.ParlourId;
                    // Guid pkiMemberProductID = Guid.NewGuid();
                    objProductModel.pkiMemberProductID = Guid.NewGuid();

                    if (objProductModel.fkiMemberid != 0)
                    { var AddonProductID = client.SaveAddonProducts(objProductModel); }
                    if (objProductModel.fkiMemberid == 0)
                    { Session["Product"] = objProductModel; }
                    //drpProductName.SelectedIndex = 0;

                   
                    txtPremium.Text =string.Empty ;
                    //if (AddonProductID > 0)
                    //{

                    //    ShowMessage(ref lblMessage, MessageType.Success, "Addon product add successfully");
                    //    bindTotalPremium();
                    //    BindAddonProducts();
                    //}
                    ShowMessage(ref lblMessage, MessageType.Success, "Addon product add successfully");
                    if (objProductModel.fkiMemberid != 0)
                    {
                        BindAddonProducts();
                        bindTotalPremium();
                    }
                    //Response.Redirect("~/Admin/ManageMember.aspx?tabId=9&ID=" + MemberId.ToString());
                    ShowMessage(ref lblMessage, MessageType.Success, "Addon product add successfully");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab9", "goToTab(9);", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab91", "goToTab(9);", true);
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ref lblMessage, MessageType.Danger, "Error in add product: " + ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab91", "goToTab(9);", true);
                //lblMessage.Text = "Error in AddProduct:" + ex.Message;
            }
        }
        protected void drpProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid strProductName = Guid.Parse(drpProductName.SelectedValue);
            var k = MembersBAL.MemberListBindAddonProduct(strProductName);
            txtPremium.Text = "R " + k.FirstOrDefault().ProductCost.ToString();

            
            // SqlDataReader dr = MembersBAL.MemberListBindAddonProduct(strProductName);
        }
        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    btnAdd.Visible = true;
                    btnUpdateProduct.Visible = false;
                    MemberAddonProductsModel objProductModel = new MemberAddonProductsModel();
                    objProductModel.pkiMemberProductID = Guid.Parse(hdnProductId.Value);
                    int index = txtPremium.Text.IndexOf("R ");
                    string cleanPath = (index < 0)
                        ? txtPremium.Text
                        : txtPremium.Text.Remove(index, "R ".Length);
                    objProductModel.ProductCost = Convert.ToDecimal(cleanPath);
                    objProductModel.LastModified = DateTime.Now;
                    objProductModel.ModifiedUser = this.User.Identity.Name;
                    objProductModel.fkiProductID = new Guid(drpProductName.SelectedValue);
                    int AddonProductID = client.AddonProductUpdateMember(objProductModel);
                    BindAddonProducts();
                    txtPremium.Text = string.Empty;
                    hdnProductId.Value = string.Empty;
                    drpProductName.SelectedIndex = -1;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab91", "goToTab(9);", true);
                    ShowMessage(ref lblMessage, MessageType.Success, "Product updated successfully.");
                    bindTotalPremium();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab91", "goToTab(9);", true);
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ref lblMessage, MessageType.Danger, "Error in add product: " + ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab91", "goToTab(9);", true);
            }
        }
        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {

                btnAdd.Visible = false;
                btnUpdateProduct.Visible = true;
                Guid id = Guid.Parse(e.CommandArgument.ToString());
                var k = MembersBAL.SelectMembarAddonProductBypkiMemberProductID(id).FirstOrDefault();
                //ListItem li = drpProductName.Items.FindByValue(k.fkiProductID.ToString());
                //if (li != null)
                //    li.Selected = true;
                drpProductName.SelectedValue = k.fkiProductID.ToString();
                txtPremium.Text = Convert.ToDecimal(k.ProductCost).ToString();
                hdnProductId.Value = k.pkiMemberProductID.ToString();
            }
            else if (e.CommandName == "DeleteProduct")
            {
                Guid pkProductId = Guid.Parse(e.CommandArgument.ToString());
                MembersBAL.MemberAddonProductsRemove(pkProductId);
                BindAddonProducts();
                ShowMessage(ref lblMessage, MessageType.Success, "Product deleted successfully");
                bindTotalPremium();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab95", "goToTab(9);", true);
        }
        #endregion

        #region SupportDocument
        protected void BtnDocumentSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (fuSupportDocument.HasFile)
                {
                    string filename = Path.GetFileName(fuSupportDocument.PostedFile.FileName);
                    string contentType = fuSupportDocument.PostedFile.ContentType;
                    using (Stream fs = fuSupportDocument.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            SupportedDocumentModel ObjSupportedDocumentModel = new SupportedDocumentModel();
                            ObjSupportedDocumentModel.DocContentType = contentType;
                            ObjSupportedDocumentModel.ImageName = filename;
                            ObjSupportedDocumentModel.ImageFile = bytes;
                            ObjSupportedDocumentModel.fkiMemberID = MemberId;
                            ObjSupportedDocumentModel.CreateDate = System.DateTime.Now;
                            ObjSupportedDocumentModel.parlourid = this.ParlourId;
                            ObjSupportedDocumentModel.LastModified = DateTime.Now;
                            ObjSupportedDocumentModel.ModifiedUser = this.User.Identity.Name;
                            ObjSupportedDocumentModel.DocType = Convert.ToInt32(rdbdocument.SelectedValue.ToString());
                            //int documentId = client.SaveSupportDocument(ObjSupportedDocumentModel);
                            int documentId = MembersBAL.SaveSupportDocument(ObjSupportedDocumentModel);
                            if (documentId > 0)
                            {

                                ShowMessage(ref lblMessage, MessageType.Success, "Supporting document uploaded successfully");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab8", "goToTab(8);", true);
                            }
                            bindSupportedDocuments();
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab8", "goToTab(8);", true);
            }
        }
        protected void gvSupportedDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteDocument")
            {
                client.DeleteSUpportdocumentById(Convert.ToInt32(e.CommandArgument));
                bindSupportedDocuments();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab8", "goToTab(8);", true);
        }
        #endregion       

        #region Vehicles

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

        #endregion

        #region AddonProducts
        public void AddonProduct()
        {

            drpProductName.DataSource = MembersBAL.SelectProductName(ParlourId);
            drpProductName.DataTextField = "ProductName";
            drpProductName.DataValueField = "pkiProductID";
            drpProductName.DataBind();

            drpProductName.Items.Insert(0, new ListItem("Select", new Guid().ToString()));
        }
        #endregion

        #region Control Event

        protected void cvIdvalidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                bool IDCheck = IdValidationClass.IdValidation(txtIdNumber.Text);
                args.IsValid = IDCheck;
            }
        }

        protected void cvIdvalidation_ServerValidate2(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                //bool IDCheck = IdValidationClass.IdValidation(txtDependencyIdNumber.Text);
                //args.IsValid = IDCheck;
            }
        }

        protected void btnNextTb1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(2);", true);
            }

        }

        protected void btnTab2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(3);", true);
            }
        }

        protected void btnTab3_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(5);", true);
            }
        }

        protected void btnTab4_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BindBank();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(5);", true);
            }
        }

        protected void btnTab5_Click(object sender, EventArgs e)
        {
            if (gvVehicles.Rows.Count == 0)
            {

                ShowMessage(ref lblMessage, MessageType.Info, "Vehicle Record Not available");

            }
            else
            {
                BindBank();
                hdnId1.Value = gvVehicles.Rows.Count.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(4);", true);

            }

            //if (Session["Vehicle"] != null)
            //{
            //    //vehicleList = (List<VehiclesModel>)Session["Vehicle"];

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(4);", true);

            //}
            //else
            //{
            //    ShowMessage(ref lblMessage, MessageType.Info, "Vehicle Record Not available");


            //}


        }


        protected void btnTab10_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(8);", true);
        }
        protected void btnBanksave_Click(object sender,EventArgs e)
        {
            BindBank();
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
                AdditionalMemberInfoModel model1 = new AdditionalMemberInfoModel();
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
                    //.DebitDate = MaxIfEmpty(txtDebitdate.Text);
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
                    model.Address1 = txtStreetAddress.Text;
                    model.Address2 = txtTown.Text;
                    model.Address4 = txtCity.Text;
                    model.Address3 = txtProvince.Text;

                    //model.Address4 = txtStreetPostalAddress.Text;
                    model.Code = txtCode.Text;
                    model.PostAddress1 = txtPostStreetAddress.Text;
                    model.PostAddress2 = txtPostTown.Text;
                    model.PostAddress3 = txtPostProvince.Text;
                    model.PostCode = txtPostCode.Text;
                    model.MemberBranch = ddlBankBranch.SelectedValue;
                    if (ddlAgent.SelectedValue == "0")
                        model.Agent = string.Empty;
                    else
                        model.Agent = ddlAgent.SelectedItem.Text;
                    model.AccountHolder = txtAccountholder.Text;
                    model.Bank = ddlBank.SelectedItem.Text;
                    //model.Branch = txtBranch.Text;
                    model.BranchCode = txtBranchcode.Text;
                    model.AccountNumber = txtAccountno.Text;
                    model.AccountType = ddlAccountType.SelectedItem.Text;
                    model.MemberSociety = ddlMemberSociety.SelectedValue;
                    if (string.IsNullOrEmpty(txtInception.Text))
                    { model.InceptionDate = System.DateTime.Now; }
                    else
                    { model.InceptionDate = Convert.ToDateTime(txtInception.Text); }

                    //model.DebitDate = MaxIfEmpty(txtDebitdate.Text);
                    model.parlourid = ParlourId;

                    if (ddlPolicy.SelectedIndex != -1 && ddlPolicy.SelectedValue != "0")
                        model.fkiPlanID = Convert.ToInt32(ddlPolicy.SelectedValue);
                    //model.MemeberNumber = txtPolicyNo.Text;
                    model.EasyPayNo = txtEasyToPay.Text;
                    model.pkiAdditionalMemberInfo = Guid.NewGuid();
                    //model.
                    model.Citizenship = ddlCitizenship.SelectedItem.Text;
                    model.Passport = txtPassport.Text;
                    model.PolicyStatus = "On Trial";
                    model.MemeberNumber = ltrPolicyNumber.Text;
                    model.ModifiedUser =UserName;
                    //if (string.IsNullOrEm this.User.Identity.Namepty(txtPolicyStartDate.Text))
                    //    model.StartDate = System.DateTime.Now;
                    //else
                    //    model.StartDate = Convert.ToDateTime(txtPolicyStartDate.Text);
                    hdnEditStartDate.Value = new DateTime(Convert.ToInt32(ddlPolicyStartDateYear.SelectedValue), Convert.ToInt32(ddlPolicyStartDate.SelectedValue), 1).ToString(); 
                    if (string.IsNullOrEmpty(hdnEditStartDate.Value))
                        model.StartDate = new DateTime(Convert.ToInt32(ddlPolicyStartDateYear.SelectedValue), Convert.ToInt32(ddlPolicyStartDate.SelectedValue), 1);
                    else
                        model.StartDate = Convert.ToDateTime(hdnEditStartDate.Value);

                    if (string.IsNullOrEmpty(hdCoverDate.Value))
                        model.CoverDate = null;
                    else
                        model.CoverDate = Convert.ToDateTime(hdCoverDate.Value);

                    if (ddlCustom1.SelectedIndex != -1)
                        model.CustomId1 = Convert.ToInt32(ddlCustom1.SelectedValue);
                    else
                        model.CustomId1 = 0;

                    if (ddlCustom2.SelectedIndex != -1)
                    {
                        model.CustomId2 = Convert.ToInt32(ddlCustom2.SelectedValue);
                    }
                    else
                    {
                        model.CustomId2 = 0;
                    }

                    if (ddlCustom3.SelectedIndex != -1)
                    {
                        model.CustomId3 = Convert.ToInt32(ddlCustom3.SelectedValue);
                    }
                    else
                    {
                        model.CustomId3 = 0;
                    }
                    
                    model.IsUploaded = false;
                    model.TotalVehicle = IncrementVehicle;
                        //================================================================ 
                    int retID = client.SaveMember(model);
                    MemberId = retID;
                    if (Request.QueryString["ID"] == null)
                    {
                        saveAddproduct(MemberId);
                        SaveVehicle(MemberId);
                    }
                    PolicyDoc.Enabled = true;
                    if (MemberId > 0 && model.pkiMemberID == 0)
                    {
                        SendEmail();
                        //Member New Registration Welcome SMS Send 
                        int SmsGrupId = Convert.ToInt32(SmsGroupType.Welcome);
                        smsSendingGroupModel modelSSG = client.GetsmsGroupbyID(SmsGrupId, ParlourId);
                        if (modelSSG != null)
                        {
                            StringBuilder strsb = new StringBuilder();
                            smsTempletModel _EmailTemplate = client.GetEmailTemplateByID(SmsGrupId, ParlourId);
                            if (_EmailTemplate != null)
                            {
                                strsb = new StringBuilder(_EmailTemplate.smsText);
                                strsb = strsb.Replace("@Name", "<p>" + model.FullNames + " " + model.Surname + "</p>");
                                string CellNo = (model.Cellphone == string.Empty ? "0" : model.Cellphone);
                                if (CellNo == "0")
                                    CellNo = (model.Telephone == string.Empty ? "0" : model.Telephone);

                                SendReminderModel smsModel = new SendReminderModel();
                                smsModel.MemeberID = UserID.ToString();
                                smsModel.MemberData = strsb.ToString();
                                smsModel.MemeberToNumber = Convert.ToInt64(CellNo.Replace(" ", ""));
                                smsModel.parlourid = ParlourId;

                                int SendOpration = client.InsertSendReminder(smsModel);
                            }
                        }
                    }
                    hdnId.Value = retID.ToString();
                    bindTotalPremium(); 


                    bindEasyPayNumber();
                    BindAddonProducts();
                    bindVehicles();
                    GetPolicyNumber(MemberId);
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab515", "goToTab(1);", true);
                    //SendEmail();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "EnableControl1", "EnableTab();", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab1", "goToTab(10)", true);
                    ShowMessage(ref lblMessage, MessageType.Success, "Member successfully saved");
                }
                btnAdd.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "goToTab512", "goToTab(5);", true);
            }
        }
        public void bindEasyPayNumber()
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            if (Convert.ToInt32(Request.QueryString["ID"]) == 0)
                ID = Convert.ToInt32(hdnId.Value);
            MembersModel model = client.GetMemberByID(ID, ParlourId);
            // txtPolicyNo.Text = model.MemeberNumber;
            txtEasyToPay.Text = model.EasyPayNo;
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

        protected void gvNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text.Length > 200)
                {
                    var str = e.Row.Cells[0].Text.Substring(0, 200);
                    e.Row.Cells[0].Text = str.Substring(0, str.LastIndexOf(' ')) + "...";
                }
            }
        }

        protected void chkResOrPost_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResOrPost.Checked == true)
            {
                txtPostStreetAddress.Text = txtStreetAddress.Text;
                txtPostTown.Text = txtTown.Text;
                txtPostProvince.Text = txtProvince.Text;
                txtPostCode.Text = txtCode.Text;
                lblAddress.Text = "Street Address";
            }
            else
            {
                txtPostStreetAddress.Text = string.Empty;
                txtPostTown.Text = string.Empty;
                txtPostProvince.Text = string.Empty;
                txtPostCode.Text = string.Empty;
                lblAddress.Text = "P.O. Box";
            }
        }
        protected void ddlbank_Changed(object sender,EventArgs e)
        {
          if(ddlBank.SelectedValue == "-1")
            {
                BindBank();
            }

            BindBank();
         // ScriptManager.RegisterStartupScript(this, this.GetType(), "ucBank", "selectFollowUpPopUp(\'ucBank\');", true);
           
        }
        #endregion

        #region Super user roles.
        private void SuperUserRoles()
        {
            SecureUserGroupsModel model;
            model = client.GetSuperUserAccessByID(UserID, ParlourId).Where(x => x.fkiSecureGroupID == 12 || x.fkiSecureGroupID == 4).FirstOrDefault();
            if (model != null)
            {
                txtIdNumber.ReadOnly = false;
            }
        }
        #endregion

        #region Bind Custom Details
        private void BindCustomDetails()
        {
            var custom1 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom1));
            var custom2 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom2));
            var custom3 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom3));
            ddlCustom1.DataSource = custom1;
            ddlCustom1.DataTextField = "Name";
            ddlCustom1.DataValueField = "Id";
            ddlCustom1.DataBind();
            ddlCustom1.Items.Insert(0, new ListItem("All", "0"));

            ddlCustom2.DataSource = custom2;
            ddlCustom2.DataTextField = "Name";
            ddlCustom2.DataValueField = "Id";
            ddlCustom2.DataBind();
            ddlCustom2.Items.Insert(0, new ListItem("All", "0"));

            ddlCustom3.DataSource = custom3;
            ddlCustom3.DataTextField = "Name";
            ddlCustom3.DataValueField = "Id";
            ddlCustom3.DataBind();
            ddlCustom3.Items.Insert(0, new ListItem("All", "0"));

        }

        #endregion

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

        private void GetPolicyNumber(int memberId)
        {
            MembersModel objmem = client.GetMemberByID(memberId, ParlourId);
            if (objmem != null)
            {
                ltrPolicyNumber.Text = objmem.MemeberNumber;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "policyNumber", "selectFollowUpPopUp(\'PolicyNumber\');", true);
            }
        }
       


        #region Send Mail

        private void SendEmail()
        {

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string filename;

            try
            {
                ReportViewer rpw = new ReportViewer();
                rpw.ProcessingMode = ProcessingMode.Remote;
                IReportServerCredentials irsc = new MyReportServerCredentials();
                rpw.ServerReport.ReportServerCredentials = irsc;

                rpw.ProcessingMode = ProcessingMode.Remote;
                rpw.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
                //rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Unplugg IT Busy Days //UIS All Members Report";
                rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Motion Assist Policy Document" ;
                ReportParameterCollection reportParameters = new ReportParameterCollection();

                reportParameters.Add(new ReportParameter("fkiMemberID", MemberId.ToString()));
                rpw.ServerReport.SetParameters(reportParameters);
                string ExportTypeExtensions = "pdf";
                byte[] bytes = rpw.ServerReport.Render(ExportTypeExtensions, null, out mimeType, out encoding, out ExportTypeExtensions, out streamids, out warnings);
                filename = string.Format("{0}.{1}", "Motion Assist Policy Document", ExportTypeExtensions);
                //MailSend
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    MemoryStream s = new MemoryStream(bytes);
                    s.Seek(0, SeekOrigin.Begin);
                    Attachment a = new Attachment(s, filename);
                    MailMessage message = new MailMessage(ConfigurationManager.AppSettings["ReportEmailSenderId1"].ToString().Trim(), txtEmail.Text.Trim(), "Motion Assist Policy Document", "");
                    message.Attachments.Add(a);
                    SmtpClient client = new SmtpClient();
                    message.Subject = "Motion Assist Policy Document - PolicyNumber " + ltrPolicyNumber.Text;
                    message.Body = "Good Day " + txtFirstname.Text +" " + txtLastName.Text  + Environment.NewLine + Environment.NewLine +
                            "Welcome to  Motion Assist, your Motion Assist Policy details:" + Environment.NewLine+ Environment.NewLine +
                           " Policy No: " + ltrPolicyNumber.Text + Environment.NewLine +
                            " Cover Date: " + txtCoverDate.Text + Environment.NewLine +
                            " 24/7 Line: 0861 800 111" + Environment.NewLine + Environment.NewLine+ Environment.NewLine +
                           " Regards :)" + Environment.NewLine +
                            " MIB Team";
                    client.Send(message);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Email Sent Successfully.";
                    ShowMessage(ref lblMessage, MessageType.Success, "Email sent successfully");
                }

                /*
                Attachment policyDocument = new Attachment(s, "Policy-Doc-" + ltrPolicyNumber.Text + ".pdf");
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    MailMessage message = new MailMessage(ConfigurationManager.AppSettings["ReportEmailSenderId1"].ToString().Trim(), txtEmail.Text.Trim(), "Policy Document", "Please find all attached policy document.");
                    
                    message.Attachments.Add(policyDocument);
                  
                    smtpClient.Send(message);
                    ShowMessage(ref lblMessage, MessageType.Success, "Email sent successfully");
                }*/
            }
            catch (Exception exc)
            {
                ShowMessage(ref lblMessage, MessageType.Danger, exc.Message);
            }
        }



        #endregion

        protected void EmailPolicyDoc_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void BindYear()
        {

            for (int i = DateTime.Now.Year - 5; i < DateTime.Now.Year + 5; i++)
            {
                ddlPolicyStartDateYear.Items.Add(i.ToString());
            }

        }

        protected void txtIdNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
