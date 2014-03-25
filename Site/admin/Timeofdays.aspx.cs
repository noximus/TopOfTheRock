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
using System.Text.RegularExpressions;

public partial class admin_Timeofdays : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navThemes");
            _nc.Attributes.Add("class", "active");
            BindData();
        }
    }

    private void BindData()
    {
        TimeOfDay _th = new TimeOfDay(this.ConnectionString);
        gv_Themes.DataSource = _th.GetTimeOfDays(Enums.enumStatuses.Active);
        gv_Themes.DataBind();

        TimeOfDayCollection<TimeOfDay> _coll = new TimeOfDayCollection<TimeOfDay>(this.ConnectionString);

        _coll.AddRange(_th.GetTimeOfDays(Enums.enumStatuses.Inactive));
        _coll.AddRange(_th.GetTimeOfDays(Enums.enumStatuses.Pending));

        gv_ThemesNotActive.DataSource = _coll;
        gv_ThemesNotActive.DataBind();

        PortalCacheFactory.RefreshTimeOfDay();

    }

    protected void Themes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editThemes"))
        {
            Response.Redirect("EditTimeOfDay.aspx?Id=" + e.CommandArgument.ToString());
        }
    }

    protected void InThemes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editThemes"))
        {
            Response.Redirect("EditTimeOfDay.aspx?Id=" + e.CommandArgument.ToString());
        }
    }

    protected void Updade_Click(object sender, EventArgs e)
    {
        TimeOfDay _st = null;
        foreach (GridViewRow I in gv_Themes.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_Id");
            if (_id != null)
            {

                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                if (Regex.IsMatch(_sort.Text, @"\d+", RegexOptions.IgnoreCase))
                {
                    _st = new TimeOfDay(this.ConnectionString);
                    _st.LitePopulate(_id.Text, false);
                    _st.Sort = Convert.ToInt32(_sort.Text);
                    _st.Save();
                }

            }
        }
        BindData();
    }
}
