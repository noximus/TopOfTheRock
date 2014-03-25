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
using System.Text.RegularExpressions;

public partial class admin_EditStory : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");

            StoryCategoriesCollection<StoryCategories> _cat = new StoryCategoriesCollection<StoryCategories>(this.ConnectionString);
            _cat.LitePopulate(new CoreLibrary.ArgumentsList());

            dd_Category.DataSource = _cat;
            dd_Category.DataTextField = "Description";
            dd_Category.DataValueField = "ID";
            dd_Category.DataBind();
            dd_Category.Items.Insert(0, new ListItem("---- Select One ----", ""));

            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();


            String _storId = Request.QueryString["storId"];
            if (!String.IsNullOrEmpty(_storId))
            {
                ViewState.Add("storId", _storId);

                Stories _stor = new Stories(this.ConnectionString);
                _stor.LitePopulate(_storId, false);

                if (dd_Category.Items.FindByValue(_stor.CategoryId.ToString()) != null)
                {
                    dd_Category.Items.FindByValue(_stor.CategoryId.ToString()).Selected = true;
                }

                txt_Title.Text = HttpUtility.HtmlDecode(_stor.Title);
                txt_Story.Text = HttpUtility.HtmlDecode(_stor.Story);
                txt_YouTube.Text = _stor.YouTubeLink;
                if (dd_Status.Items.FindByValue(_stor.Status.ToString()) != null)
                {
                    dd_Status.Items.FindByValue(_stor.Status.ToString()).Selected = true;
                }
            }
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        Stories _stor = new Stories(this.ConnectionString);
        if (ViewState["storId"] != null)
        {
            _stor.LitePopulate(Convert.ToInt32(ViewState["storId"]), false);
        }

        if (IsValidStory(_stor))
        {

            _stor.Title = HttpUtility.HtmlEncode(txt_Title.Text);
            _stor.Story = HttpUtility.HtmlEncode(txt_Story.Text);
            _stor.Status = Convert.ToInt32(dd_Status.SelectedValue);

            _stor.CategoryId = Convert.ToInt32(dd_Category.SelectedValue);

            String _imgType = null;
            if (ViewState["storId"] != null)
            {
                if (fu_Image.HasFile)
                {
                    _stor.YouTubeLink = "";
                    _imgType = fu_Image.FileName.Split('.')[1];
                    _stor.ImgType = _imgType;
                }
                else
                {
                    if (!String.IsNullOrEmpty(txt_YouTube.Text))
                    {
                        _stor.YouTubeLink = GetYouTubeLink();
                        _stor.ImgType = "";
                    }
                }
            }
            else
            {
                if (fu_Image.HasFile)
                {
                    _stor.YouTubeLink = "";
                    _imgType = fu_Image.FileName.Split('.')[1];
                    _stor.ImgType = _imgType;
                }
                else
                {
                    _stor.YouTubeLink = GetYouTubeLink();
                    _stor.ImgType = "";
                }
            }

            if (_stor.Save())
            {
                if (fu_Image.HasFile)
                {
                    String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["StoriesImagesPath"], _stor.ID.ToString(), _imgType));
                    fu_Image.SaveAs(_path);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'StoriesList.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
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

    private bool IsValidStory(Stories stor)
    {
        Boolean _ret = true;
        if (IsValid)
        {
            if (stor.ID != null)
            {
                if (String.IsNullOrEmpty(txt_YouTube.Text) && !fu_Image.HasFile)
                {
                    if (String.IsNullOrEmpty(CommonUtility.NullSafeString(stor.ImgType, "").Trim()) &&
                        String.IsNullOrEmpty(CommonUtility.NullSafeString(stor.YouTubeLink, "").Trim()))
                    {
                        _ret = false;
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(txt_YouTube.Text) && !fu_Image.HasFile)
                {
                    _ret = false;
                }
            }
        }

        if (!_ret)
        {
            lbl_Error.Text = "Please enter Image Or YouTube link.";
            lbl_Error.Visible = true;
        }
        else
        {
            lbl_Error.Visible = false;
        }
        return _ret;
    }
}
