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

public partial class master_BaseMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);

        if(oInfo.ToString() == "/history/Default.aspx") LiteralAudio.Text = "so.addVariable('audioPlay', 'false');" ;
    }
    protected void bGroups_Click(object sender, EventArgs e) {
        Response.Redirect("~/groups/default.aspx");
    }

    protected void bVisitor_Click(object sender, EventArgs e) {
        Response.Redirect("~/visitor/default.aspx");
    }
    protected void bTravelPro_Click(object sender, EventArgs e) {
        Response.Redirect("~/groups/travelprofessionals.aspx");
    }
    protected void bPress_Click(object sender, EventArgs e) {
        Response.Redirect("~/press/default.aspx");
    }
    protected void bPublicity_Click(object sender, EventArgs e) {
        Response.Redirect("~/press/publicity.aspx");
    }

}
