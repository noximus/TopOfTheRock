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


public partial class admin_Forums : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navForum");
            _nc.Attributes.Add("class", "active");
            BindData();
        }
    }

    protected void BindData()
    {
        Forum _for = new Forum(this.ConnectionString);
        gv_Forum.DataSource = _for.GetForums(true);
        gv_Forum.DataBind();

        gv_ForumNotActive.DataSource = _for.GetForums(false);
        gv_ForumNotActive.DataBind();
    }
    
    protected void Forum_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editForum"))
        {
            Response.Redirect("EditForum.aspx?forumId=" + e.CommandArgument.ToString());
        }
    }

    protected void InForum_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editForum"))
        {
            Response.Redirect("EditForum.aspx?forumId=" + e.CommandArgument.ToString());
        }
    }

    protected void Updade_Click(object sender, EventArgs e)
    {
        Forum _st = null;
        foreach (GridViewRow I in gv_Forum.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_Id");
            if (_id != null)
            {

                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                if (Regex.IsMatch(_sort.Text, @"\d+", RegexOptions.IgnoreCase))
                {
                    _st = new Forum(this.ConnectionString);
                    _st.LitePopulate(_id.Text, false);
                    _st.Sort = Convert.ToInt32(_sort.Text);
                    _st.Save();
                }

            }
        }
        BindData();
    }


}
