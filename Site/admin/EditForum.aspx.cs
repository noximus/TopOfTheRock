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

public partial class admin_EditForum : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navForum");
            _nc.Attributes.Add("class", "active");

            String _forumId = Request.QueryString["forumId"];
            if (!String.IsNullOrEmpty(_forumId))
            {
                ViewState.Add("forumId", _forumId);
                Forum _frm = new Forum(this.ConnectionString);
                _frm.LitePopulate(ViewState["forumId"], false);

                txt_Desc.Text = _frm.Description;
                txt_Title.Text = _frm.Title;
                ch_Active.Checked = _frm.Active;
                lbl_Header.Text = String.Format("{0}", _frm.Title);
            }
            else
            {
                lbl_Header.Text = "Add Forum";
            }

        }
    }

    protected void Save_Click(Object sender, EventArgs e)
    {
        if (IsValid)
        {
            Forum _frm = new Forum(this.ConnectionString);
            if (ViewState["forumId"] != null)
            {
                _frm.LitePopulate(ViewState["forumId"], false);
            }

            _frm.Title = txt_Title.Text;
            _frm.Description = txt_Desc.Text;

            _frm.Active = ch_Active.Checked;

            if (_frm.Save())
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'Forums.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
