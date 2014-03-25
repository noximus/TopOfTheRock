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
using CoreLibrary;
using System.Threading;
using System.Globalization;

public partial class forum_newtopic : BaseNoneSecurePage
{
    protected override void InitializeCulture()
    {
        String _cult = Request.Form["__EVENTARGUMENT"];

        if (!String.IsNullOrEmpty(_cult))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_cult);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_cult);
        }else{
	    CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
	    Thread.CurrentThread.CurrentUICulture = new CultureInfo(_profile.Culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_profile.Culture);
	}
        
        
	base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
	if(!IsPostBack){
		BindData();
	}

    }

    protected void ChangeCulture_Click(Object sender, EventArgs e)
    {
	BindData();
	Response.Redirect("Default.aspx");
    }

   private void BindData(){
	CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        _profile.Culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        

	lit_FlashCulture.Text = String.Format("so.addVariable('selectFlag','{0}')", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
	
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        ForumTopics _forum = new ForumTopics(this.ConnectionString);
        _forum.Title = HttpUtility.HtmlEncode(txt_Title.Text);
        _forum.Topic = HttpUtility.HtmlEncode(txt_Topic.Text);
        _forum.Status = Convert.ToInt32(Enums.enumStatuses.Active);
        _forum.CultureInfo = _profile.Culture;
        if (_forum.Save())
        {
            Response.Redirect("viewtopic.aspx?topic=" + _forum.ID.ToString());
        }
        else
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('An unexpected error has occurred. Please try again.');", true);
        }
    }
}
