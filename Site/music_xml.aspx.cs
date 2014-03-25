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

public partial class music_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _conn = ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString;
        Musics _mus = new Musics(_conn);
        CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        String _path = ConfigurationManager.AppSettings["MusicFilePath"].Replace("../", "");
        DisplayResult(_mus.GetMusicsByCategory(Convert.ToInt32(_profile.MusicCategory), _path));
	//Response.Write(_profile.MusicCategory);
                
    }


    private void DisplayResult(string inXml)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        Response.Write(inXml);
        Response.End();

    }
}
