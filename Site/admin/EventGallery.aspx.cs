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

public partial class admin_EventGallery : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navEvents");
            _nc.Attributes.Add("class", "active");

            String _parent = Request.QueryString["parentId"];

            if (!String.IsNullOrEmpty(_parent))
            {
                ViewState.Add("parentId", _parent);
                BindData();
            }
            else
            {
                Response.Redirect("Events.aspx");
            }
        }
    }

    private void BindData()
    {
        Events _ev = new Events(this.ConnectionString);
        _ev.LitePopulate(ViewState["parentId"], true);
        _ev.EventsCollection.Sort("Sort", CoreLibrary.GenericComparer<CoreLibrary.BaseBusinessClass>.SortOrder.Ascending);
        dgPhotos.DataSource = _ev.EventsCollection;
        dgPhotos.DataBind();

        lbl_Header.Text = _ev.Title;

    }

    protected void UpdateSort_OnClick(object sender, EventArgs e)
    {
        Events _ev = new Events(this.ConnectionString);
        _ev.LitePopulate(ViewState["parentId"], true);
        foreach (GridViewRow I in dgPhotos.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_Id");
            if (_id != null)
            {
                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                if (Regex.IsMatch(_sort.Text, @"^\d+$"))
                {
                    Events _nEv = (Events)_ev.EventsCollection.FindByID(_id.Text);

                    _nEv.Sort = Convert.ToInt32(_sort.Text);
                    _nEv.Save();

                }
            }
        }
        BindData();
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditEvent.aspx?parentId=" + ViewState["parentId"].ToString());
    }

    protected string GetPhotoUrl(Object eventId, Object imgType)
    {
        return String.Format(ConfigurationManager.AppSettings["EventThumbImgPath"], eventId.ToString(), imgType.ToString());
    }

    protected void Photos_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editEvent"))
        {
            Response.Redirect("EditEvent.aspx?parentId=" + ViewState["parentId"].ToString() + "&eventId=" + e.CommandArgument.ToString());
        }
    }
}
