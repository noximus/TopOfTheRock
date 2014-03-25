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

public partial class events_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _conn = ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString;
        Events _ev = new Events(_conn);
        
        String _largepath = ConfigurationManager.AppSettings["EventLargeImgPath"].Replace("../", "");
        String _smallpath = ConfigurationManager.AppSettings["EventSmallImgPath"].Replace("../", "");
        String _thumbpath = ConfigurationManager.AppSettings["EventThumbImgPath"].Replace("../", "");
        DisplayResult(_ev.GetEventsXml(_largepath,_smallpath, _thumbpath) );

    }

    
    private void DisplayResult(string inXml)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        Response.Write(inXml);
        Response.End();

    }
}
