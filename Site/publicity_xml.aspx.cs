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

public partial class publicity_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _conn = ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString;
        Publicity _ev = new Publicity(_conn);

        String _filepath = ConfigurationManager.AppSettings["PublicityFilePath"].Replace("../", "");
        DisplayResult(_ev.GetPublicityXml(Enums.enumStatuses.Active, _filepath));

    }


    private void DisplayResult(string inXml)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        Response.Write(inXml);
        Response.End();

    }
}
