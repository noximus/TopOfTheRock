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

public partial class share_storieslist : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String _catId = Request.QueryString["source"];
            StoryCategoriesCollection<StoryCategories> _cat = null;
            StoryCategories _st = null;
            if (!String.IsNullOrEmpty(_catId))
            {
                _cat = PortalCacheFactory.GetStoryCategory();

                _st = (StoryCategories)_cat.FindByID(_catId);

                if (_st == null)
                {
                    _st = (StoryCategories)_cat[0];
                }
                //lbl_Categoty.Text = _st.Description;
                tText.Text = "so.addVariable(\"text\",\"STORIES FROM THE TOP - <font size='22'>" + _st.Description.ToUpper() + "</font>\")";
                hid_Category.Value = _st.ID.ToString();
                hid_Status.Value = ((Int32)Enums.enumStatuses.Active).ToString();

            }
            else
            {
                _cat = PortalCacheFactory.GetStoryCategory();
                _st = ((StoryCategories)_cat[0]);
                //lbl_Categoty.Text = _st.Description;
                tText.Text = "so.addVariable(\"text\",\"STORIES FROM THE TOP - <font size='16'>" + _st.Description + "</font>\")";
            }

            StoriesCollection<Stories> _coll = new StoriesCollection<Stories>(this.ConnectionString);
            _coll.PopulateFixedRecords(_coll.CreateArgListForFixedRecords(dgStories.PageSize, _st.ID.ToString(), Convert.ToInt32(Enums.enumStatuses.Active).ToString()));

            dgStories.DataSource = _coll;
            dgStories.DataBind();
        }

    }


    protected void Stories_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton _lb = (ImageButton)e.Row.FindControl("lb_ViewVideo");
            ImageButton _vP = (ImageButton)e.Row.FindControl("lb_ViewPhoto");
            Stories _stor = ((Stories)e.Row.DataItem);
            if (_lb != null)
            {
                if (String.IsNullOrEmpty(CommonUtility.NullSafeString(_stor.YouTubeLink, "").Trim()))
                {
                    _lb.Visible = false;
                }
            }
            if (_vP != null)
            {
                if (String.IsNullOrEmpty(CommonUtility.NullSafeString(_stor.ImgType, "").Trim()))
                {
                    _vP.Visible = false;
                }
            }

        }
    }

    protected void Stories_OnRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("View"))
        {
            Response.Redirect("story.aspx?source=" + e.CommandArgument.ToString());
        }
    }

}
