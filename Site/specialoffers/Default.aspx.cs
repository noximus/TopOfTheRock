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

public partial class specialoffers_Default : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Comb_Empty_Click(Object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_combo.aspx");
    }

    protected void GCEmpty_Click(Object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_giftcard.aspx");
    }

    protected void GPSEmpty_Click(Object sender, EventArgs e)
    {
        Response.Redirect("specialoffers_gps.aspx");
    }
         
}
