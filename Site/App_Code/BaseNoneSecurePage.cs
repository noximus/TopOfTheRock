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

/// <summary>
/// Summary description for BaseNoneSecurePage
/// </summary>
public class BaseNoneSecurePage :System.Web.UI.Page
{
    public BaseNoneSecurePage() {
        PreInit += new EventHandler(BasePage_PreInit);
    }

    protected void BasePage_PreInit(object sender, EventArgs e)
    {
        CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        this.Theme = _profile.ThemeName;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    public string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString; }
    }


}
