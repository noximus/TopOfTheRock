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

public partial class specialoffers_specialoffers_events : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Image1_Click(object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_rockpath.aspx");
    }
    protected void Image2_Click(object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_bodies.aspx");
    }
    protected void Image3_Click(object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_moma.aspx");
    }

    protected void Image4_Click(object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_art.aspx");
    }

}
