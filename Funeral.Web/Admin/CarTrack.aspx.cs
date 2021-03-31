using Funeral.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Funeral.Web.Admin
{
    public partial class WebForm5 : AdminBasePage
    {
        #region Page PreInit
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.dbPageId = 1;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dropDownMake.SelectedValue == "Mercedes Benz")
            {
                string[] list = new string[] { "A-Class", "B-Class", "C-Class", "CLA", "CLS", "E-Class", "G-Class", "GLA", "GLC" };
            }
            else if (dropDownMake.SelectedValue == "")
            {
                string[] list = new string[] { "Auris", "Avanza", "Aygo", "Corolla", "Etios", "FJ Cuiser", "Fortuner", "Hilux" };
            }
            else if (dropDownMake.SelectedValue == "VW")
            {
                string[] list = new string[] { "Polo Vivo", "Polo Sedan", "Polo Hatch", "Jetta", "Golf", "Beetle", "Golf", "Polo GTI", "Tiguan" };
            }
            else if (dropDownMake.SelectedValue == "Chevrolet")
            {
                string[] list = new string[] { "Captiva", "Cruze", "Spark", "Trailblazer", "Utility" };
            }

            for (int i = 0; i < dropDownModel.Items.Count; i++)
            {

            }
        }
    }
}