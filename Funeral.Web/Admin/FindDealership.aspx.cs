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
    public partial class FindDealership : AdminBasePage//System.Web.UI.Page
    {
        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDealerships();
            }
        }
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
        #endregion

        #region Search Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDealership();
        }
        #endregion

        //public void ToggleSortOrder()
        //{
        //    if (SortOrder == "ASC")
        //        SortOrder = "DESC";
        //    else
        //        SortOrder = "ASC";
        //    BindDealerships();
        //}

        private void ClearSearchBox()
        {
            txtKeyword.Text = string.Empty;
        }

        private void BindAllDealerships()
        {
            gvDealerships.PageSize = PageSize;
            DealershipViewModel model = client.SelectAllDealerships(UserName);
            StringBuilder sb = new StringBuilder();
            gvDealerships.DataSource = model.DealershipList;
            gvDealerships.DataBind();
        }

        private void BindDealership()
        {
            if (!string.IsNullOrEmpty(txtKeyword.Text.Trim()))
            {

                gvDealerships.PageSize = PageSize;
                DealershipViewModel returnedDealership = client.SelectDealership(PageSize, PageNum, txtKeyword.Text, UserName);
                StringBuilder ds = new StringBuilder();
                gvDealerships.DataSource = returnedDealership.DealershipList;
                gvDealerships.DataBind();

            }
            // else
            //{
            //    ShowMessage(ref lblMessage, MessageType.Warning, "No Dealerships Found!");
            //    ClearSearchBox();
            //}
        }

        protected void gvDealerships_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKeyword.Text.Trim()))
            {
                gvDealerships.PageIndex = e.NewPageIndex;
                BindDealership();
            }
            else try
                {
                    gvDealerships.PageIndex = e.NewPageIndex;
                    BindAllDealerships();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
        }
    }
}