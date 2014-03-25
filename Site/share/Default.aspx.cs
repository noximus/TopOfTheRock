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

public partial class share_Default : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Pages _page = new Pages(this.ConnectionString);
            _page.LitePopulate(ConfigurationManager.AppSettings["Share"], true);

            lit_ViewPhotoTitle.Text = ((SiteContents)_page.PageContents[0]).Description;

            lit_ShareStoryTitle.Text = ((SiteContents)_page.PageContents[1]).Description;

            lit_StoryFromTitle.Text = ((SiteContents)_page.PageContents[2]).Description;
        }
    }

    protected void Tell_Click(Object sender, EventArgs e)
    {
        Response.Redirect("tellyourstory.aspx");
    }
    protected void View_Click(Object sender, EventArgs e)
    {
        Response.Redirect("storyfromtop.aspx");
    }


}
