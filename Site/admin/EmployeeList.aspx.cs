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

public partial class admin_EmployeeList : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navManageUser");
            _nc.Attributes.Add("class", "active");

            dgUsers.DataSource = this.LogedInUser.GetUsers(TopRockUser.enumStatuses.Active);
            dgUsers.DataBind();

            dgUsersNotActive.DataSource = this.LogedInUser.GetUsers(TopRockUser.enumStatuses.Inactive);
            dgUsersNotActive.DataBind();
        }
    }

    protected void Users_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editUser"))
        {
            Response.Redirect("EditEmployee.aspx?userId=" + e.CommandArgument.ToString());
        }
    }

    protected void InUsers_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editUser"))
        {
            Response.Redirect("EditEmployee.aspx?userId=" + e.CommandArgument.ToString());
        }
    }

}
