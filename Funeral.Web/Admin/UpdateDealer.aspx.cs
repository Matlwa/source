using Funeral.DAL;
using Funeral.Model;
using Funeral.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Funeral.Web.Admin
{
    public partial class UpdateDealer1 : AdminBasePage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();
        int DealerId = 0;
        string Date = Convert.ToString(DateTime.Now.DayOfWeek);
        private DealerDetailsDAL model;
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
        public Int64 TotalRecord
        {
            get
            {
                if (ViewState["_TotalRecord"] == null)
                    return 10;
                else { return Convert.ToInt32(ViewState["_TotalRecord"].ToString()); }
            }
            set { ViewState["_TotalRecord"] = value; }

        }

        public string Name
        {
            get
            {
                if (ViewState["_SortByName"] == null)
                    return " ";
                else { return ViewState["_SortByName"].ToString(); }
            }
            set { ViewState["_SortByName"] = value; }

        }

        public string SortBy
        {
            get
            {
                if (ViewState["_SortBy"] == null)
                    return " ";
                else { return ViewState["_SortBy"].ToString(); }
            }
            set { ViewState["_SortBy"] = value; }

        }
        public string SortOrder
        {
            get
            {
                if (ViewState["_SortOrder"] == null)
                    return "DealerId";
                else { return ViewState["_SortOrder"].ToString(); }
            }
            set { ViewState["_SortOrder"] = value; }

        }

        public string Username
        {
            get
            {
                if (ViewState["_Username"] == null)
                    return UserName;
                else { return ViewState["_Username"].ToString(); }
            }
            set { ViewState["_Username"] = value; }

        }

        public string _DealerId
        {
            get
            {
                if (ViewState["_DealerId"] == null)
                    return "DealerId";
                else { return ViewState["_DealerId"].ToString(); }
            }
            set { ViewState["_DealerId"] = value; }

        }

        #region Declarations
        protected global::System.Web.UI.WebControls.Label lblMessage;

        /// <summary>
        /// gvDealerSales control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindAllDealers();
        }
        #endregion
        #region Search Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDealer();
        }
        #endregion
        private void ClearSearchBox()
        {
            txtKeyword.Text = string.Empty;
        }
        protected void SoryBy_Click(object sender, EventArgs e)
        {
            BindAllDealers();
        }

        protected void lbSortDealer_Click(object sender, EventArgs e)
        {
            ToggleSortOrder();
            switch (((LinkButton)sender).ID.ToString())
            {
                case "lbSortDealerName":
                    SortBy = "Name";
                    break;
                case "lbSortDealer":
                    SortBy = "Surname";
                    break;
                case "lbSortDealershipName":
                    SortBy = "DealershipName";
                    break;
                case "lbSortDealerType":
                    SortBy = "DealerType";
                    break;
                default:
                    SortBy = "Name";
                    break;
            }
            BindAllDealers();
        }
        public void ToggleSortOrder()
        {
            if (SortOrder == "ASC")
                SortOrder = "DESC";
            else
                SortOrder = "ASC";
            BindAllDealers();
        }
        //private void DealerTotal()
        //{
        //    DealersViewModel TotalDealers = client.GetDealerTotal(Username);
        //    StringBuilder sb = new StringBuilder();
        //    gvDealerSales.DataSource = TotalDealers.TotalDealers;
        //    gvDealerSales.DataBind();
        //    ShowMessage(ref lblMessage, MessageType.Info, UserName + "You Have" + "" + TotalDealers + "" + "Dealers");
        //}

        private void BindAllDealers()
        {
            //gvDealerSales.PageSize = PageSize;
            //DealersViewModel model = client.GetDealersList(UserName);
            //StringBuilder sb = new StringBuilder();
            //gvDealerSales.DataSource = model.DealerList;
            //gvDealerSales.DataBind();

            var dayOfWeek = DateTime.Now.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Monday)
            {
                gvDealerSales.PageSize = PageSize;
                DealersViewModel model = client.GetDailyDealers(UserName, Date);
                StringBuilder sb = new StringBuilder();
                gvDealerSales.DataSource = model.DealerList;
                gvDealerSales.DataBind();
            }
            else if (dayOfWeek == DayOfWeek.Tuesday)
            {
                gvDealerSales.PageSize = PageSize;
                DealersViewModel model = client.GetDailyDealers(UserName, Date);
                StringBuilder sb = new StringBuilder();
                gvDealerSales.DataSource = model.DealerList;
                gvDealerSales.DataBind();
            }
            else if (dayOfWeek == DayOfWeek.Wednesday)
            {
                gvDealerSales.PageSize = PageSize;
                DealersViewModel model = client.GetDailyDealers(UserName, Date);
                StringBuilder sb = new StringBuilder();
                gvDealerSales.DataSource = model.DealerList;
                gvDealerSales.DataBind();
            }
            else if (dayOfWeek == DayOfWeek.Thursday)
            {
                gvDealerSales.PageSize = PageSize;
                DealersViewModel model = client.GetDailyDealers(UserName, Date);
                StringBuilder sb = new StringBuilder();
                gvDealerSales.DataSource = model.DealerList;
                gvDealerSales.DataBind();
            }
            else if (dayOfWeek == DayOfWeek.Friday)
            {
                gvDealerSales.PageSize = PageSize;
                DealersViewModel model = client.GetDailyDealers(UserName, Date);
                StringBuilder sb = new StringBuilder();
                gvDealerSales.DataSource = model.DealerList;
                gvDealerSales.DataBind();

            }
        }

        protected void gvDealerSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDealerSales.PageIndex = e.NewPageIndex;
                BindAllDealers();
                lblMessage.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void BindDealer()
        {
            if (!string.IsNullOrEmpty(txtKeyword.Text.Trim()))
            {

                gvDealerSales.PageSize = PageSize;
                DealersViewModel returnedDealer = client.SelectDealer(DealerId, PageSize, PageNum, txtKeyword.Text, SortBy, SortOrder, Username);
                StringBuilder ds = new StringBuilder();
                gvDealerSales.DataSource = returnedDealer.DealerList;
                gvDealerSales.DataBind();

            }
            else
            {
                ShowMessage(ref lblMessage, MessageType.Warning, "No Dealers Found!");
                ClearSearchBox();
            }

        }
        /*
                protected void gvDealerSales_OnRowCommand(object sender, GridViewCommandEventArgs e)
                {
                    if (e.CommandName == "GotQuote")
                    {
                        //Add 1 to the total monthly quotes

                        //int id = Convert.ToInt32(e.CommandArgument);
                        //GridViewRow row = gvDealerSales.Rows[DealerId];
                        //client.AddMonthlyQuotes(DealerId, Username);

                        try
                        {
                            //client.AddMonthlyQuotes(Convert.ToInt32(e.CommandArgument));
                            int AddMonthlyQuote = client.AddMonthlyQuotes(Convert.ToInt32(e.CommandArgument), DealerId.ToString());
                            BindDealer();
                        }
                        catch (Exception exc)
                        {
                            ShowMessage(ref lblMessage, MessageType.Danger, exc.Message);
                            lblMessage.Visible = true;
                        }

                        //refresh list
                    }

                } */
    }
}
