using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_Default : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navWelcome");
        _nc.Attributes.Add("class", "active");

        lbl_Welcome.Text = String.Format(", {0} {1}", LogedInUser.FirstName, LogedInUser.LastName);
    }
}
