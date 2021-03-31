using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Funeral.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        
         
        
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        //void Application_Error(object sender, EventArgs e)
        //{
        //    var url = "";
        //    var page = new object();
        //    try
        //    {

        //        // Code that runs when an unhandled error occur
        //        Exception ex = HttpContext.Current.Server.GetLastError().GetBaseException();
        //        HttpException httpException = ex as HttpException;
        //        if (httpException == null)
        //        {
        //            Exception innerException = ex.InnerException;
        //            httpException = innerException as HttpException;
        //        }

        //        if (ex is System.Threading.ThreadAbortException)
        //            return;
        //        //write error log to a text file
        //        string logFile = Server.MapPath("~/ErrorLog/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("MMM") + ".txt");
        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true);
        //        if (HttpContext.Current != null)
        //        {
        //            url = HttpContext.Current.Request.Url.ToString();
        //            page = HttpContext.Current.Handler as System.Web.UI.Page;
        //        }
        //        sw.WriteLine("-----------------------------------------------------------------------------------------");
        //        //sw.WriteLine("User ID: " + Request.QueryString["xxx"]);
        //        sw.WriteLine("Error message: " + ex.Message);
        //        sw.WriteLine("Error occurred on: " + DateTime.Now.ToString());
        //        sw.WriteLine("Error Stack Trace: " + ex.StackTrace);
        //        sw.WriteLine("Error PageUrl: " + url);
        //        sw.WriteLine();
        //        sw.Flush();
        //        sw.Close();
        //        sw.Dispose();

        //        //Server.Transfer("Error Page.aspx");
        //        //Server.ClearError();
        //        HttpContext.Current.ClearError();
        //        Response.Redirect("~/Admin/Error.aspx", false);
        //        // Code that runs when an unhandled error occurs

        //    }
        //    catch
        //    { }
        //    // Code that runs when an unhandled error occurs
        //}

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}