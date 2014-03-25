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
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

public partial class forum_viewtopic : BaseNoneSecurePage
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
        if (!IsPostBack)
        {
            String _id = Request.QueryString["topic"];
            if (!String.IsNullOrEmpty(_id))
            {
                if (Regex.IsMatch(_id, @"^\d+$"))
                {
                    ForumTopics _topic = new ForumTopics(this.ConnectionString);
                    _topic.LitePopulate(_id, true);

                    if (!_topic.IsEmpty())
                    {
                        ViewState["topic"] = _topic.ID.ToString();
                        lbl_Title.Text = _topic.Title;
                        lbl_Story.Text = _topic.Topic;
                        BindData(_topic);
                    }
                    else
                    {
                        NoIdSupply();
                    }
                }
                else
                {
                    NoIdSupply();
                }
            }
            else
            {
                NoIdSupply();
            }
        }
    }

    private void NoIdSupply()
    {
        Response.Redirect("Default.aspx");
    }

    private void BindData(){
	CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        _profile.Culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        

	lit_FlashCulture.Text = String.Format("so.addVariable('selectFlag','{0}')", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);


    }    

    protected void BindData(ForumTopics topic)
    {
	BindData();
        rpt_Threads.DataSource = topic.Threads;
        rpt_Threads.DataBind();
    }

    protected void Post_Click(Object sender, EventArgs e)
    {
        pnl_Threads.Visible = false;
        pnl_PostForm.Visible = true;
        btn_PostComment.Visible = false;
        span_Post.Visible = false;
    }

    protected void ChangeCulture_Click(Object sender, EventArgs e)
    {
	BindData();
	Response.Redirect("Default.aspx");
    }

    protected void PostComment_Click(Object sender, EventArgs e)
    {
        String _id = ViewState["topic"].ToString();
	CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        ForumTopics _newTopic = new ForumTopics(this.ConnectionString);
        _newTopic.Topic = txt_Topic.Text;
        _newTopic.ParentId = Convert.ToInt32(_id);
        _newTopic.Status = Convert.ToInt32(Enums.enumStatuses.Active);
	_newTopic.CultureInfo = _profile.Culture;
        if (_newTopic.Save())
        {
            pnl_Threads.Visible = true;
            pnl_PostForm.Visible = false;
            span_Post.Visible = true;
            txt_Topic.Text = "";

            ForumTopics _topic = new ForumTopics(this.ConnectionString);
            _topic.LitePopulate(_id, true);

            BindData(_topic);
        }
        else
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('An unexpected error has occurred. Please try again.');", true);
        }

    }
}
