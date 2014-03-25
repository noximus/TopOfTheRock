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

public partial class admin_Events : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navEvents");
            _nc.Attributes.Add("class", "active");
            BindData();
        }
    }

    protected void BindData()
    {
        Events _ev = new Events(this.ConnectionString);
        gv_Events.DataSource = _ev.GetEvents(Enums.enumStatuses.Active);
        gv_Events.DataBind();

        gv_EventsNotActive.DataSource = _ev.GetEvents(Enums.enumStatuses.Inactive);
        gv_EventsNotActive.DataBind();
    }

    protected void Event_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editEvent"))
        {
            Response.Redirect("EditEvent.aspx?eventId=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.Equals("viewGalery"))
        {
            Response.Redirect("EventGallery.aspx?parentId=" + e.CommandArgument.ToString());
        }
    }

    protected void InEvent_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editEvent"))
        {
            Response.Redirect("EditEvent.aspx?eventId=" + e.CommandArgument.ToString());
        }
    }

    protected void UpdateSort_OnClick(object sender, EventArgs e)
    {
        Events _ev = new Events(this.ConnectionString);
        EventsCollection<Events> _coll = _ev.GetEvents(Enums.enumStatuses.Active);
        foreach (GridViewRow I in gv_Events.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_Id");
            if (_id != null)
            {
                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                if (Regex.IsMatch(_sort.Text, @"^\d+$"))
                {
                    Events _nEv = (Events)_coll.FindByID(_id.Text);

                    _nEv.Sort = Convert.ToInt32(_sort.Text);
                    _nEv.Save();

                }
            }
        }
        BindData();
    }
}
