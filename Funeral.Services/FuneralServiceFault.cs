using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Funeral.Services
{
    [DataContract]
    public class FuneralServiceFault
    {
        private string _message;

        public FuneralServiceFault(string message)
        {
            _message = message;
        }

        [DataMember]
        public string Message { 
            get { return _message; } 
            set { _message = value; } 
        }

    }
}
    //protected void CancelPolicy(object sender, EventArgs e)
    //{
    //    string connetionString;
    //    SqlConnection con;
    //    connetionString = @"Data Source=129.232.221.42\MSSQLUNP2014;Initial Catalog=ShortTremDev;User Id=Gift; Password=Gift456;Connect Timeout=120;";

    //    con = new SqlConnection(connetionString);
        
    //    con.Open();

    //    SqlCommand command2;
    //    SqlDataAdapter adapter = new SqlDataAdapter();
    //    int pkiMemberid = 0;

    //    string sql = "";
    //    sql = ("UPDATE [ShortTremDev].[dbo].[Members] SET [PolicyStatus] = '" + "cancelled" + "' WHERE @pkiMemberid = pkiMemberid");

    //    command2 = new SqlCommand(sql, con);
    //    adapter.InsertCommand = new SqlCommand(sql, con);
    //    adapter.InsertCommand.ExecuteNonQuery();

    //    command2.Dispose();
    //    con.Close();
    //}