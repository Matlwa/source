using Funeral.Model;
using Funeral.Web.App_Start;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Funeral.Web.Admin.Reports
{
    public partial class Reports : AdminBasePage
    {
        private readonly ISiteSettings _siteConfig = new SiteSettings();
        FuneralServiceReference.FuneralServicesClient client = new FuneralServiceReference.FuneralServicesClient();

        #region Page PreInit
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.dbPageId = 8;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    btnExport.Enabled = this.HasReadRight;
                    ReportList();
                 
                    BindDdlAgent();
                 
                    BindCustomDetails();
                }
                catch (Exception ex)
                {
                    //Response.Write(ex.ToString());
                }
            }
        }
        #region Test Code
        public void SSRSReport()
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer rpw = new ReportViewer();
            rpw.ProcessingMode = ProcessingMode.Remote;
            IReportServerCredentials irsc = new MyReportServerCredentials();
            rpw.ServerReport.ReportServerCredentials = irsc;

            rpw.ProcessingMode = ProcessingMode.Remote;
            rpw.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
            rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Unplugg IT Active Parlours";

            //ArrayList reportParam = new ArrayList();
            //reportParam = ReportDefaultPatam();

            //ReportParameter[] param = new ReportParameter[reportParam.Count];
            //for (int k = 0; k < reportParam.Count; k++)
            //{
            //    param[k] = (ReportParameter)reportParam[k];
            //}


            //ReportParameterCollection reportParameters = new ReportParameterCollection();

            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));
            //reportParameters.Add(new ReportParameter("parlourid", "6DCBA090-F363-47E6-93F5-6DEF8F80703E"));

            //ssrsReportViewer1.ServerReport.SetParameters(reportParameters);
            //rpw.ServerReport.SetParameters(param);
            rpw.ServerReport.Refresh();
            byte[] bytes = rpw.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=Monthly BI Stats.pdf");
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download


            //ssrsReportViewer1.ProcessingMode = ProcessingMode.Local;
            //IReportServerCredentials irsc = new MyReportServerCredentials();
            //ssrsReportViewer1.ServerReport.ReportServerCredentials = irsc;

            //ssrsReportViewer1.ProcessingMode = ProcessingMode.Remote;
            //ssrsReportViewer1.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
            //ssrsReportViewer1.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Monthly BI Stats";
            //ssrsReportViewer1.ServerReport.Refresh();
        }
        public void Test()
        {

            //
            ReportViewer rpw = new ReportViewer();
            rpw.ProcessingMode = ProcessingMode.Remote;
            IReportServerCredentials irsc = new MyReportServerCredentials();
            rpw.ServerReport.ReportServerCredentials = irsc;

            rpw.ProcessingMode = ProcessingMode.Remote;
            rpw.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
            //rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Unplugg IT Busy Days";
            rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/" + ddlAdminReort.SelectedItem.Text;

            //

            var p_PayPeriod = new ReportParameter("parlourid", "F7CAF4C0-B3AB-44E0-8C8A-76AA4E8CDA6D");

            //reportParameters.Add(new ReportParameter("parlourid", "F7CAF4C0-B3AB-44E0-8C8A-76AA4E8CDA6D"));
            //rpw.ServerReport.SetParameters(p_PayPeriod);           
            //
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string filename;

            byte[] bytes = rpw.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

            filename = string.Format("{0}.{1}", ddlAdminReort.SelectedItem.Text, "pdf");
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.ContentType = mimeType;
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Bind Dropdown
        public void ReportList()
        {
            // string[] Policystatuslist = client.GetDistinctPolicyStatusList();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com.CommandText = "SelectReportList";
            com.Parameters.Add(new SqlParameter("@FinanceRole", false));
            SqlDataAdapter adp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //DataRow[] results = dt.Select("category = 'Finance Report'");
            if (dt.Rows.Count > 0)
            {
                ddlReportType.DataSource = dt;
                ddlReportType.DataTextField = "category";
                ddlReportType.DataValueField = "category";
                ddlReportType.DataBind();

                ddlReportType.Items.Insert(0, new ListItem("Select Report Type", "0"));
                ddlReportType.Items.FindByValue("0").Selected = true;
            }


        }
      
     
        public void BindDdlAgent()
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuneralConnection"].ConnectionString);
            com.CommandText = "SelectDistinctAgent";
            com.Parameters.Add(new SqlParameter("@parlourid", ParlourId));
            SqlDataAdapter adp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlAgent.DataSource = dt;
                ddlAgent.DataTextField = "Agent";
                ddlAgent.DataValueField = "Agent";
                ddlAgent.DataBind();
                ddlAgent.Items.Insert(0, new ListItem("", ""));
                ddlAgent.Items.Insert(1, new ListItem("ALL", "ALL"));
                
            }

        }
       
        #endregion

        #region ButtonClickEvent
        protected void ExportClickEvent(object sender, EventArgs e)
        {
            try
            {
                //

                ReportViewer rpw = new ReportViewer();
                rpw.ProcessingMode = ProcessingMode.Remote;
                IReportServerCredentials irsc = new MyReportServerCredentials();
                rpw.ServerReport.ReportServerCredentials = irsc;


                rpw.ProcessingMode = ProcessingMode.Remote;
                rpw.ServerReport.ReportServerUrl = new Uri(_siteConfig.SSRSUrl);
                //rpw.ServerReport.ReportPath = "/Unplugg IT Solution BI Reporting/Unplugg IT Busy Days //UIS All Members Report";
                rpw.ServerReport.ReportPath = "/Mosys Reports/" + hfAdminReport.Value;
                //                
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                if (!string.IsNullOrEmpty(txtDateFrom.Text))
                    reportParameters.Add(new ReportParameter("StartDateFrom", txtDateFrom.Text));
                if (!string.IsNullOrEmpty(txtDateTo.Text))
                    reportParameters.Add(new ReportParameter("StartDateTo", txtDateTo.Text));
                
                //if (!string.IsNullOrEmpty(txtDateFrom.Text))
                //    reportParameters.Add(new ReportParameter("DebitDateFrom", txtDebitDateFrom.Text));
                //if (!string.IsNullOrEmpty(txtDateTo.Text))
                //    reportParameters.Add(new ReportParameter("DebitDateTo", txtDebitDateTo.Text));

                if (!string.IsNullOrEmpty(ddlAgent.SelectedItem.Text))
                    reportParameters.Add(new ReportParameter("Agent", ddlAgent.SelectedItem.Text));
               
                if (!string.IsNullOrEmpty(ddlPolicyStatus.SelectedItem.Text))
                    reportParameters.Add(new ReportParameter("PolicyStatus", ddlPolicyStatus.SelectedItem.Text));
             

                reportParameters.Add(new ReportParameter("Parlourid", ParlourId.ToString()));

                rpw.ServerReport.SetParameters(reportParameters);
                //
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string filename;
                //
                string ExportTypeName = rptExportType.SelectedItem.Text;
                string ExportTypeExtensions;
                if (ExportTypeName == "PDF")
                    ExportTypeExtensions = "pdf";
                else if (ExportTypeName == "Word")
                    ExportTypeExtensions = "docx";
                else
                    ExportTypeExtensions = "xls";
                //
 
                byte[] bytes = rpw.ServerReport.Render(ExportTypeName, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                filename = string.Format("{0}.{1}", hfAdminReport.Value, ExportTypeExtensions);
                //MailSend
                if (!string.IsNullOrEmpty(txtcemail.Text))
                {
                    MemoryStream s = new MemoryStream(bytes);
                    s.Seek(0, SeekOrigin.Begin);
                    Attachment a = new Attachment(s, filename);
                    MailMessage message = new MailMessage(ConfigurationManager.AppSettings["ReportEmailSenderId"].ToString().Trim(), txtcemail.Text.Trim(), hfAdminReport.Value, "");
                    message.Attachments.Add(a);
                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Email Sent Successfully.";
                }
                //
                else
                {
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                    Response.ContentType = mimeType;
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ref lblMessage, MessageType.Danger, ex.Message);
            }
        }
        #endregion

        #region Custom Field Impementation
        #region Bind Custom Detailss
        private void BindCustomDetails()
        {
            var custom1 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom1));
            var custom2 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom2));
            var custom3 = client.GetAllCustomDetailsByParlourId(this.ParlourId, Convert.ToInt32(CustomDetailsEnums.CustomDetailsType.Custom3));
          

        }
        #endregion

        #endregion
    }
}