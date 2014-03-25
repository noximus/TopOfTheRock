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

public partial class admin_Login : System.Web.UI.Page
{
    const string DEFAULT_REDIRECT = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_OnClick(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            BasePrincipal _pr = BasePrincipal.LoginUser(txt_UserName.Text, txt_Password.Text,
                        ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString);

            if (_pr != null)
            {
                this.Context.User = _pr;
                _pr.SaveToSession();

                FormsAuthentication.SetAuthCookie(((TopRockUser)_pr.Identity).ID.ToString(), ch_RememberMe.Checked);
                String _redirect = Request.QueryString["source"];
                if (string.IsNullOrEmpty(_redirect)) { _redirect = DEFAULT_REDIRECT; }
                Response.Redirect(_redirect);

            }
            else
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "Invalid User Name or Password. Please try again.";
            }
        }
    }
}
