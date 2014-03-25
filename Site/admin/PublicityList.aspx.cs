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

public partial class admin_PublicityList : SecurePage
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
        Publicity _th = new Publicity(this.ConnectionString);
        gv_Publicity.DataSource = _th.GetPublicity(Enums.enumStatuses.Active);
        gv_Publicity.DataBind();

        PublicityCollection<Publicity> _coll = new PublicityCollection<Publicity>(this.ConnectionString);

        _coll.AddRange(_th.GetPublicity(Enums.enumStatuses.Inactive));
        _coll.AddRange(_th.GetPublicity(Enums.enumStatuses.Pending));

        gv_PublicityNotActive.DataSource = _coll;
        gv_PublicityNotActive.DataBind();
    }

    protected void Publicity_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editPress"))
        {
            Response.Redirect("EditPublicity.aspx?pubId=" + e.CommandArgument.ToString());
        }
    }
}
