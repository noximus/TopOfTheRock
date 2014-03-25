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

public partial class faq_Default : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void History(object sender, EventArgs e) {
        Response.Redirect("default.aspx");
    }

    protected void Rock_Center(object sender, EventArgs e) {
        Response.Redirect("rockefellercenter.aspx");
    }
    protected void Photo_Credits(object sender, EventArgs e) {
        Response.Redirect("photocredits.aspx");
    }
    
}
