using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funeral.Model;
using Funeral.BAL;
using Funeral.Web.App_Start;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Funeral.Web.Admin
{
    public partial class Dealership : AdminBasePage
    {
        private DealershipModel model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnSaveDealership.Visible = true;
                lblMessage.Visible = false;
                ClearFields();
            }
        }

        protected void SaveDealership_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["FuneralConnection"].ToString(); // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand checkDealership = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Dealerships] WHERE ([DealershipName] = @DealershipName)", con);
            checkDealership.Parameters.AddWithValue("@DealershipName", txtDealershipName.Text);
            int DealershipExist = (int)checkDealership.ExecuteScalar();

            if (DealershipExist > 0)
            {
                //Dealership exist
                ShowMessage(ref lblMessage, MessageType.Warning, "Dealership Already Exists");
                lblMessage.Visible = true;
                ClearFields();
            }
            else
            {
                //Dealership doesn't exist.
                model = new DealershipModel();
                model.DealershipName = txtDealershipName.Text;
                model.LandLine = txtLandLine.Text;
                //model.Email = txtEmail.Text;

                DealershipBAL.SaveDealership(model);
                ShowMessage(ref lblMessage, MessageType.Success, "Dealership Saved Successfully");
                lblMessage.Visible = true;
                ClearFields();
            }
            
        }

        private void ClearFields()
        {
            txtDealershipName.Text = string.Empty;
            txtLandLine.Text = string.Empty;
        }
    }
}