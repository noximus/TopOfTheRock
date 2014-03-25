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
using CoreLibrary.Utility;


public partial class admin_StoriesList : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");

            dd_Category.DataSource = PortalCacheFactory.GetStoryCategory();
            dd_Category.DataTextField = "Description";
            dd_Category.DataValueField = "ID";
            dd_Category.DataBind();
            dd_Category.Items.Insert(0, new ListItem("---- All ----", ""));


            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();

            dd_Status.Items.FindByValue("3").Selected = true;

        }
    }
    
    protected void Search_OnClick(object sender, EventArgs e)
    {
        this.DataBind();
    }

    protected void Stories_OnRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Update"))
        {
            Response.Redirect("EditStory.aspx?storId=" + e.CommandArgument.ToString());
        }
    }

    protected void Stories_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton _lb = (LinkButton)e.Row.FindControl("lb_ViewVideo");
            LinkButton _vP = (LinkButton)e.Row.FindControl("lb_ViewPhoto");
            Stories _stor = ((Stories)e.Row.DataItem);
            if (_lb != null)
            {
                _lb.OnClientClick = String.Format("return ViewFile({0});", _stor.ID.ToString());
                if (String.IsNullOrEmpty(CommonUtility.NullSafeString(_stor.YouTubeLink, "").Trim()))
                {
                    _lb.Visible = false;
                }
            }
            if (_vP != null)
            {
                _vP.OnClientClick = String.Format("return ViewFile({0});", _stor.ID.ToString());
                if (String.IsNullOrEmpty(CommonUtility.NullSafeString(_stor.ImgType, "").Trim()))
                {
                    _vP.Visible = false;
                }
            }

            DropDownList _dd = (DropDownList)e.Row.FindControl("dd_Status");
            if (_dd != null)
            {
                _dd.DataSource = this.LogedInUser.GetAllStatuses();
                _dd.DataTextField = "Description";
                _dd.DataValueField = "ID";
                _dd.DataBind();
                if (_dd.Items.FindByValue(_stor.Status.ToString()) != null)
                {
                    _dd.Items.FindByValue(_stor.Status.ToString()).Selected = true;
                }
            }

        }
    }

    protected void Publish_Click(Object sender, EventArgs e)
    {
        Stories _st = null;
        foreach (GridViewRow I in dgStories.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_StorId");
            if (_id != null)
            {
                DropDownList _ddst = (DropDownList)I.FindControl("dd_Status");
                _st = new Stories(this.ConnectionString);
                _st.LitePopulate(_id.Text, false);
                if (!_st.Status.ToString().Equals(_ddst.SelectedValue))
                {
                    _st.Status = Convert.ToInt32(_ddst.SelectedValue);
                    _st.Save();
                }
            }
        }
        this.DataBind();
    }
}
