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
using CoreLibrary.Utility;

public partial class share_story : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String _stId = Request.QueryString["source"];
            if (!String.IsNullOrEmpty(_stId))
            {
                Stories _st = new Stories(this.ConnectionString);
                _st.LitePopulate(_stId, false, null);

                if (!_st.IsEmpty())
                {
                    lbl_Story.Text = _st.Story;
                    lbl_Title.Text = _st.Title;
                    tText.Text = "so.addVariable(\"text\",\"STORIES FROM THE TOP - <font size='22'>" + _st.CategoryDescription.ToUpper() + "</font>\")"; 

                    if (!String.IsNullOrEmpty(CommonUtility.NullSafeString(_st.YouTubeLink, "").Trim()))
                    {
                        div_Holder.InnerHtml = _st.YouTubeLink;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(CommonUtility.NullSafeString(_st.ImgType, "").Trim()))
                        {
                            Image _img = new Image();
                            _img.ImageUrl = String.Format(ConfigurationManager.AppSettings["StoriesImagesPath"], _st.ID.ToString(), _st.ImgType);
                            div_Holder.Controls.Add(_img);
                        }
                        else
                        {
                            div_Holder.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("stotieslist.aspx");
                }

            }
            else
            {
                Response.Redirect("stotieslist.aspx");
            }
        }
    }
}
