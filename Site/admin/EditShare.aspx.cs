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

public partial class admin_EditShare : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");

            Pages _page = new Pages(this.ConnectionString);
            _page.LitePopulate(ConfigurationManager.AppSettings["Share"], true);
            Bind(_page);
        }
    }

    private void Bind(Pages data)
    {
        rpt_Share.DataSource = data.PageContents;
        rpt_Share.DataBind();
    }


    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Boolean _status = true;

            foreach (RepeaterItem I in rpt_Share.Items)
            {
                Label _lbl = (Label)I.FindControl("lbl_ContentId");
                if (_lbl != null)
                {
                    SiteContents _cont = new SiteContents(this.ConnectionString);
                    _cont.LitePopulate(_lbl.Text, true);
                    _cont.Description = ((TextBox)I.FindControl("txt_Desc")).Text;
                    _cont.Title = ((TextBox)I.FindControl("txt_Title")).Text;
                    _cont.Sort = Convert.ToInt32(((TextBox)I.FindControl("txt_Sort")).Text);
                    _cont.PageId = Convert.ToInt32(ConfigurationManager.AppSettings["Share"]);


                    if (!_cont.Save(true, null))
                    {
                        lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                        lbl_Error.Visible = true;
                        _status = false;
                        break;
                    }
                }
            }
            if (_status)
            {
                Pages _page = new Pages(this.ConnectionString);
                _page.LitePopulate(ConfigurationManager.AppSettings["Share"], true);
                Bind(_page);
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');", true);
            }
        }
    }


}
