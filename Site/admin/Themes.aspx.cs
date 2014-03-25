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

public partial class admin_Themes : SecurePage
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
        SiteThemes _th = new SiteThemes(this.ConnectionString);
        gv_Themes.DataSource = _th.GetThemes(Enums.enumStatuses.Active);
        gv_Themes.DataBind();

        SiteThemesCollection<SiteThemes> _coll = new SiteThemesCollection<SiteThemes>(this.ConnectionString);

        _coll.AddRange(_th.GetThemes(Enums.enumStatuses.Inactive));
        _coll.AddRange(_th.GetThemes(Enums.enumStatuses.Pending));

        gv_ThemesNotActive.DataSource = _coll;
        gv_ThemesNotActive.DataBind();
    }

    protected void Themes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editThemes"))
        {
            Response.Redirect("EditThemes.aspx?themeId=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.Equals("SetDefault"))
        {
            SiteThemes _t = new SiteThemes(this.ConnectionString);
            _t.LitePopulate(e.CommandArgument.ToString(), false);
            _t.Default = true;
            _t.Save();
            BindData();
        }
    }

    protected void InThemes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editThemes"))
        {
            Response.Redirect("EditThemes.aspx?themeId=" + e.CommandArgument.ToString());
        }
    }

    protected void Updade_Click(object sender, EventArgs e)
    {
        SiteThemes _st = null;
        foreach (GridViewRow I in gv_Themes.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_Id");
            if (_id != null)
            {

                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                if (Regex.IsMatch(_sort.Text, @"\d+", RegexOptions.IgnoreCase))
                {
                    _st = new SiteThemes(this.ConnectionString);
                    _st.LitePopulate(_id.Text, false);
                    _st.Sort = Convert.ToInt32(_sort.Text);
                    _st.Save();
                }
                
            }
        }
        BindData();
    }
}
