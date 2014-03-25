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

public partial class master_SecureAdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BasePrincipal _pr = BasePrincipal.GetFromSession();
        if (_pr != null)
        {
            TopRockUser _user = (TopRockUser)_pr.Identity;
            LinkButtonLoggedIn.Text = String.Format("{0} {1}", _user.FirstName, _user.LastName);
        }
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
