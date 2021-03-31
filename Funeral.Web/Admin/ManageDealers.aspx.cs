using System;
using Funeral.BAL;
using Funeral.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funeral.Web.App_Start;
using Funeral.Model;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Funeral.Web.Admin
{
    public partial class DealershipList : AdminBasePage
    {

        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
        private int DealerId;
        public DealerModel model;
        #region Page Property
        public int PageSize
        {
            get
            {
                if (ViewState["_PageSize"] == null)
                    return 5;
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
        public Int64 TotalRecord
        {
            get
            {
                if (ViewState["_TotalRecord"] == null)
                    return 0;
                else { return Convert.ToInt32(ViewState["_TotalRecord"].ToString()); }
            }
            set { ViewState["_TotalRecord"] = value; }

        }
        public string SortBy
        {
            get
            {
                if (ViewState["_SortBy"] == null)
                    return "DealerId";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                btnEnter.Enabled = true;
                //ddlPageSize.SelectedIndex = ddlPageSize.Items.IndexOf(ddlPageSize.Items.FindByValue(PageSize.ToString()));
                //BindDealer();
                string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
                SqlConnection con = new SqlConnection(constr);
                // con.Open();

                // SqlCommand com = new SqlCommand("select * from DealerSales", con); // table name 
                // SqlDataAdapter da = new SqlDataAdapter(com);
                // DataTable dt = new DataTable();
                // da.Fill(dt);  // fill dataset
                //gvDealerSales.DataSource = dt;             //ddlDealerships.DataValueField = ds.Tables[0].Columns["DealershipId"].ToString();             // to retrive specific  textfield name 
                //gvDealerSales.DataTextField = ds.Tables[0].Columns["DealershipName"].ToString(); // text field name of table dispalyed in dropdown
                //gvDealerSales.DataSource = dt.Tables[0];      //assigning datasource to the dropdownlist
                //gvDealerSales.DataBind();
                BindDealerStatus();
                BindDealership();
                BindDealerType();
                BindProvince();

                {
                    con.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM DealerSales", con);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    //gvDealerSales.DataSource = dt;
                    gvDealerSales.DataBind();
                }
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
        private void EditDealer()
        {
            {
                string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //SqlConnection con = new SqlConnection("Data Source=.; uid=sa; pwd=wintellect;database=Rohatash;");
                //string strSQL = "Select * from UserDetail";
                SqlCommand com = new SqlCommand("select * from [dbo].[DealerSales]", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds, "DealerSales");
                con.Close();
                //gvDealerSales.DataSource = ds;
                gvDealerSales.DataBind();
            }
        }

        #region Page size change event
        //protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        //   // BindDealer();
        //}
        #endregion

        //public void BindDealer()
        //{
        //    gvDealerSales.PageSize = PageSize;
        //    DealersViewModel model = client.GetAllDealers(DealerId, PageSize, PageNum, txtKeyword.Text, SortBy, SortOrder); //Fix conversion for DealerId
        //    StringBuilder sb = new StringBuilder();
        //    gvDealerSales.DataSource = model.DealerList;
        //    gvDealerSales.DataBind();
        //}

        protected void gvDealerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDealerSales.PageIndex = e.NewPageIndex;
            //BindDealer();
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            model = new DealerModel();
            model.Name = txtName.Text;
            model.Surname = txtSurname.Text;
            model.Landline = txtLandline.Text;
            model.CellphoneNumber = txtCellNumber.Text;
            model.Email = txtEmail.Text;
            model.DealershipName = ddlDealerships.SelectedItem.Text;//txtDealershipName.Text;
            model.DealerType = ddlDealerType.Text;
            model.Status = ddlStatus.Text;
            model.Province = ddlProvince.Text;
            model.Comment = txtComment.Text;

            DealerDAL.UpdateDealerDetails(model);
            ShowMessage(ref lblMessage, MessageType.Success,"Dealer Updated Successfully");
            lblMessage.Visible = true;
        }

        //protected void btnEdit_Click(object sender, EventArgs e)
        //{
        //    txtName.Text = gvDealerSales.SelectedRow.Cells[1].Text;
        //    txtSurname.Text = gvDealerSales.SelectedRow.Cells[2].Text;
        //    ddlDealerships.Text = gvDealerSales.SelectedRow.Cells[3].Text;
        //    txtLandline.Text = gvDealerSales.SelectedRow.Cells[4].Text;
        //    txtCellNumber.Text = gvDealerSales.SelectedRow.Cells[5].Text;
        //    txtEmail.Text = gvDealerSales.SelectedRow.Cells[6].Text;
        //    ddlDealerType.Text = gvDealerSales.SelectedRow.Cells[7].Text;
        //    ddlStatus.Text = gvDealerSales.SelectedRow.Cells[8].Text;
        //    ddlProvince.Text = gvDealerSales.SelectedRow.Cells[9].Text;
        //    txtComment.Text = gvDealerSales.SelectedRow.Cells[10].Text;
        //}

        protected void gvDealerSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = gvDealerSales.SelectedRow.Cells[0].Text;
            txtSurname.Text = gvDealerSales.SelectedRow.Cells[1].Text; 
            txtLandline.Text = gvDealerSales.SelectedRow.Cells[6].Text;
            txtCellNumber.Text = gvDealerSales.SelectedRow.Cells[5].Text;
            txtEmail.Text = gvDealerSales.SelectedRow.Cells[7].Text;
            ddlDealerships.SelectedItem.Text = gvDealerSales.SelectedRow.Cells[2].Text;
            ddlDealerType.SelectedItem.Text = gvDealerSales.SelectedRow.Cells[3].Text;
            ddlStatus.SelectedItem.Text = gvDealerSales.SelectedRow.Cells[4].Text;
            ddlProvince.SelectedItem.Text = gvDealerSales.SelectedRow.Cells[8].Text;
            txtComment.Text = gvDealerSales.SelectedRow.Cells[10].Text;
        }
    } 
}