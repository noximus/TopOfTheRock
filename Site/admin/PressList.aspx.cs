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

public partial class admin_PressList : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navPress");
            _nc.Attributes.Add("class", "active");
            BindData();
        }
    }

    private void BindData()
    {
        Press _th = new Press(this.ConnectionString);
        gv_Press.DataSource = _th.GetPress(Enums.enumStatuses.Active);
        gv_Press.DataBind();

        PressCollection<Press> _coll = new PressCollection<Press>(this.ConnectionString);

        _coll.AddRange(_th.GetPress(Enums.enumStatuses.Inactive));
        _coll.AddRange(_th.GetPress(Enums.enumStatuses.Pending));

        gv_PressNotActive.DataSource = _coll;
        gv_PressNotActive.DataBind();
    }

    protected void Press_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editPress"))
        {
            Response.Redirect("EditPress.aspx?pressId=" + e.CommandArgument.ToString());
        }
    }
}
