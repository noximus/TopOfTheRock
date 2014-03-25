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

public partial class press_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _conn = ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString;
        Press _ev = new Press(_conn);

        String _pressThumb = ConfigurationManager.AppSettings["PressThumbPath"].Replace("../", "");
        String _musicPath = ConfigurationManager.AppSettings["PressAudioPath"].Replace("../", "");
        String _contThumb = ConfigurationManager.AppSettings["PressContentThumbPath"].Replace("../", "");
        String _videoPath = ConfigurationManager.AppSettings["PressVideoPath"].Replace("../", "");

        DisplayResult(_ev.GetPressXml(Enums.enumStatuses.Active, _pressThumb, _musicPath, _contThumb, _videoPath));

    }


    private void DisplayResult(string inXml)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        Response.Write(inXml);
        Response.End();

    }
}
