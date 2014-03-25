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
using System.IO;

public partial class welcome : BaseNoneSecurePage
{
    private const string DEFAULT_REDIRECT = "welcome/default.aspx";

    protected void Page_PreInit()
    {
        if (Request.QueryString["theme"] != null)
        {
            if (Directory.Exists(Server.MapPath(String.Format("App_Themes/{0}/", Request.QueryString["theme"]))))
            {
                this.Theme = Request.QueryString["theme"];
		
                
                //Save_Seting(Request.QueryString["timeofday"], Request.QueryString["musictype"]);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
	
    }

    private void BindData()
    {
        //SiteThemes _t = new SiteThemes(this.ConnectionString);
        //rpt_Themes.DataSource = _t.GetThemes(Enums.enumStatuses.Active);
        //rpt_Themes.DataBind();

        //rpt_Daybreak.DataSource = PortalCacheFactory.GetTimeOfDayCategory();
        //rpt_Daybreak.DataBind();

        //rpt_TypeMusic.DataSource = PortalCacheFactory.GetMusicCategory();
        //rpt_TypeMusic.DataBind();
    }

    protected void Music_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //LinkButton _lb = (LinkButton)e.Item.FindControl("lb_TypeMusic");
        //if (_lb != null)
        //{
        //    if (ViewState["MusicType"] != null)
        //    {
        //        if (ViewState["MusicType"].ToString().Equals(((MusicCategories)e.Item.DataItem).ID.ToString()))
        //        {
        //            _lb.CssClass = "active";
        //        }
        //    }
        //    else
        //    {
        //        if (Profile.MusicCategory.Equals(((MusicCategories)e.Item.DataItem).ID.ToString()))
        //        {
        //            _lb.CssClass = "active";
        //        }
        //    }
        //}
    }

    protected void Music_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //ViewState["MusicType"] = e.CommandArgument.ToString();
        //BindData();
    }

    protected void Themes_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Image _ib = (Image)e.Item.FindControl("img_Themes");
        //if (_ib != null)
        //{
        //    _ib.ImageUrl = String.Format("App_Themes/{0}/images/favColor/themeColor.gif", ((SiteThemes)e.Item.DataItem).Name);
        //    _ib.Attributes.Add("onclick", "self.location = 'welcome.aspx?theme=" + ((SiteThemes)e.Item.DataItem).Name + "';");
        //    _ib.Style.Add("cursor", "hand");
        //}
    }

    protected void Daybreak_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //ViewState["TimeOfDay"] = e.CommandArgument.ToString();
        //BindData();
    }

    protected void Daybreak_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //LinkButton _lb = (LinkButton)e.Item.FindControl("lb_Daybreak");
        //if (_lb != null)
        //{
        //    if (ViewState["TimeOfDay"] != null)
        //    {
        //        if (ViewState["TimeOfDay"].ToString().Equals(((TimeOfDay)e.Item.DataItem).ID.ToString()))
        //        {
        //            _lb.CssClass = "active";
        //        }
        //    }
        //    else
        //    {
        //        if (Profile.TimeOfDay.Equals(((TimeOfDay)e.Item.DataItem).ID.ToString()))
        //        {
        //            _lb.CssClass = "active";
        //        }
        //    }
        //}
    }

    protected void Save_Seting(string timeOfday, string musicType)
    {

           
         Profile.ThemeName = this.Theme;

       
         Profile.TimeOfDay = timeOfday;
        
         Profile.MusicCategory = musicType;
	 MusicCategories _mus = null;
	 if(PortalCacheFactory.GetMusicCategory().FindByProperty("Description", musicType).Count > 0){
		_mus = (MusicCategories)PortalCacheFactory.GetMusicCategory().FindByProperty("Description", musicType)[0];
	 }
	 
         if(_mus != null) {
            Response.Redirect(_mus.PageUrl);
         } else {
            Response.Redirect(DEFAULT_REDIRECT);
         }

    }

    protected void SaveSetting_Click(object sender, EventArgs e)
    {
	//Response.Redirect("flashRedirect.aspx?p=" + Request.Form["__EVENTARGUMENT"]);
	String[] _arr = Request.Form["__EVENTARGUMENT"].Split('$');
        if (_arr[0] != "undefined" || _arr[0] != "")
        {
            Profile.ThemeName = _arr[0];
        }
        if (_arr[1] != "undefined" || _arr[1] != "")
        {
            Profile.TimeOfDay = _arr[1];
        }
        if (_arr[2] != "undefined" || _arr[2] != "")
        {
            Profile.MusicCategory = _arr[2];
        }
	 MusicCategories _mus = null;
	 if(PortalCacheFactory.GetMusicCategory().FindByProperty("Description", _arr[2]).Count > 0){
		_mus = (MusicCategories)PortalCacheFactory.GetMusicCategory().FindByProperty("Description", _arr[2])[0];
	 }

	TimeOfDay _time = null;
        if (PortalCacheFactory.GetTimeOfDayCategory().FindByProperty("Description", _arr[1]).Count > 0)
        {
            _time = (TimeOfDay)PortalCacheFactory.GetTimeOfDayCategory().FindByProperty("Description", _arr[1])[0];
        }

	if(_mus != null){
		Profile.MusicCategory = _mus.ID.ToString();
	}
	 
         if(_time != null) {
	    Profile.TimeOfDay = _time.ID.ToString();
            Response.Redirect(_time.PageUrl);
	
         } else {
            Response.Redirect(DEFAULT_REDIRECT);
         }
	
	 

    }

    protected void Skip_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome/default.aspx");
    }
}
