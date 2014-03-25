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

public partial class admin_ViewStoryFile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String _storId = Request.QueryString["storId"];

        if (!String.IsNullOrEmpty(_storId))
        {
            Stories _st = new Stories(ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString);
            _st.LitePopulate(_storId);

            if (!String.IsNullOrEmpty(CommonUtility.NullSafeString(_st.YouTubeLink, "").Trim()))
            {
                Literal _li = new Literal();
                _li.Text = _st.YouTubeLink;
                secureHolder.Controls.Add(_li);
            }
            else
            {
                if (!String.IsNullOrEmpty(CommonUtility.NullSafeString(_st.ImgType, "").Trim()))
                {
                    Image _img = new Image();
                    _img.ImageUrl = String.Format(ConfigurationManager.AppSettings["StoriesImagesPath"], _st.ID.ToString(), _st.ImgType);
                    secureHolder.Controls.Add(_img);
                }
            }
            
        }
    }
}
