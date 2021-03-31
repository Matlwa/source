using System;
using Funeral.Model;
using Funeral.BAL;
using Funeral.Web.App_Start;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Funeral.Web;

namespace Funeral.Web.Admin
{
    public partial class FindDealer : AdminBasePage
    {
        private DealerModel model;
        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSaveDealer.Enabled = true;
                ClearDealerDetailsForm();
                lblMessage.Visible = false;
                BindDealerStatus();
                BindDealership();
                BindDealerType();
                BindProvince();
            }
    }
        private void BindDealership()
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); 
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("select * from Dealerships", con);  
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            //ddlDealerships.DataValueField = ds.Tables[0].Columns["DealershipId"].ToString();             // to retrive specific  textfield name 
            ddlDealerships.DataTextField = ds.Tables[0].Columns["DealershipName"].ToString(); // text field name of table dispalyed in dropdown
            ddlDealerships.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlDealerships.DataBind();  //binding dropdownlist
        }

        private void BindDealerType()
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("select * from [LookUp].[DealerTypes]", con); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            ddlDealerType.DataTextField = ds.Tables[0].Columns["DealerType"].ToString(); // text field name of table dispalyed in dropdown
            //ddlDealerType.DataValueField = ds.Tables[0].Columns["DealerTypeId"].ToString();             // to retrive specific  textfield name 
            ddlDealerType.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlDealerType.DataBind();  //binding dropdownlist
        }

        private void BindDealerStatus()
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("select * from [LookUp].[DealerStatusType]", con); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            ddlStatus.DataTextField = ds.Tables[0].Columns["StatusType"].ToString(); // text field name of table dispalyed in dropdown
            //ddlStatus.DataValueField = ds.Tables[0].Columns["StatusTypeId"].ToString();             // to retrive specific  textfield name 
            ddlStatus.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlStatus.DataBind();  //binding dropdownlist

        }

        private void BindProvince()
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("select * from [dbo].[Provices]", con); // table name 
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            ddlProvince.DataTextField = ds.Tables[0].Columns["Province"].ToString(); // text field name of table dispalyed in dropdown
            //ddlStatus.DataValueField = ds.Tables[0].Columns["StatusTypeId"].ToString();             // to retrive specific  textfield name 
            ddlProvince.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlProvince.DataBind();  //binding dropdownlist
        }

        protected void btnSaveDealer_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand checkDealer = new SqlCommand("SELECT COUNT(*) FROM [dbo].[DealerSales] WHERE ([Name] = @Name AND [Surname] = @Surname AND [DealershipName] = @DealershipName)", con);
            checkDealer.Parameters.AddWithValue("@Name", txtName.Text);
            checkDealer.Parameters.AddWithValue("@Surname",txtSurname.Text );
            checkDealer.Parameters.AddWithValue("@DealershipName", ddlDealerships.Text );
            int DealerExist = (int)checkDealer.ExecuteScalar();

            if (DealerExist > 0)
            {
                //Dealer exist
                ShowMessage(ref lblMessage, MessageType.Warning, "Dealer Already Exists");
                lblMessage.Visible = true;
                ClearDealerDetailsForm();
            }
            else

            {

                model = new DealerModel();
                model.Name = txtName.Text;
                model.Surname = txtSurname.Text;
                model.DealershipName = Convert.ToString(ddlDealerships.Text);
                model.DealerType = ddlDealerType.SelectedItem.Text;
                model.Landline = txtLandline.Text;
                model.CellphoneNumber = txtCellNumber.Text;
                model.Email = txtEmail.Text;
                model.Province = ddlProvince.SelectedItem.Text;
                model.Status = ddlStatus.SelectedItem.Text;

                DealerBAL.SaveDealerDetails(model);
                ShowMessage(ref lblMessage, MessageType.Success, "Dealer Saved Successfully");
                lblMessage.Visible = true;
                ClearDealerDetailsForm();
            }
        }
            

        private void ClearDealerDetailsForm()
        {
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            //txtDealershipName.Text = string.Empty;
           // ddlDealerType.Items = string.Empty;
            txtLandline.Text = string.Empty;
            txtCellNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            //ddlProvince.Items = string.Empty;        
           // ddlStatus.Items.Clear();
        }
    }
}