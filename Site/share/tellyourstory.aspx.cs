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
using CoreLibrary;

public partial class share_tellyourstory : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            dd_Category.DataSource = PortalCacheFactory.GetStoryCategory();
            dd_Category.DataTextField = "Description";
            dd_Category.DataValueField = "ID";
            dd_Category.DataBind();

            dd_Category.Items.Insert(0, new ListItem("- Select A Category -", ""));
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        Stories _stor = new Stories(this.ConnectionString);

        _stor.Title = HttpUtility.HtmlEncode(txt_Title.Text);
        _stor.Story = HttpUtility.HtmlEncode(txt_Story.Text);
        _stor.Status = (Int32)Enums.enumStatuses.Pending;
        _stor.CategoryId = Convert.ToInt32(dd_Category.SelectedValue);

        string _imgType = "";
        if (fu_Image.HasFile)
        {
            _stor.YouTubeLink = "";
            _imgType = fu_Image.FileName.Split('.')[1];
            _stor.ImgType = _imgType;
        }
        else
        {
            if (Regex.IsMatch(txt_YouTube.Text, @"^<object[\s\S]+</object>$"))
            {
                _stor.YouTubeLink = GetYouTubeLink();
                _stor.ImgType = "";
            }
        }


        if (_stor.Save())
        {
            if (fu_Image.HasFile)
            {
                System.Drawing.Image _img = CoreLibrary.Utility.ImageUtility.FixedSize(fu_Image.FileContent,
                    Convert.ToInt32(ConfigurationManager.AppSettings["ImageStoryWidth"]),
                    Convert.ToInt32(ConfigurationManager.AppSettings["ImageStoryHight"]), System.Drawing.Color.Black);

                String _path = ConfigurationManager.AppSettings["StoriesImagesPath"];

                _path = Server.MapPath(String.Format(_path, _stor.ID.ToString(), _imgType));
                _img.Save(_path);
                _img.Dispose();
            }
            Response.Redirect("Default.aspx");
        }
        else
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('An unexpected error has occurred. Please try again..');", true);
        }
    }

    private string GetYouTubeLink()
    {
        String _youTubeLink = Regex.Replace(txt_YouTube.Text, @"width[ ]*=[ ]*\x22?\d{2,4}\x22?", String.Format("width={0}",
            ConfigurationManager.AppSettings["YouTubeLinkWidth"]));

        _youTubeLink = Regex.Replace(_youTubeLink, @"height[ ]*=[ ]*\x22?\d{2,4}\x22?", String.Format("height={0}",
            ConfigurationManager.AppSettings["YouTubeLinkHight"]));

        return _youTubeLink;
    }

}
