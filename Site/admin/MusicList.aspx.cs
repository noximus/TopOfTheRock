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

public partial class admin_MusicList : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");


            MusicCategoriesCollection<MusicCategories> _cat = new MusicCategoriesCollection<MusicCategories>(this.ConnectionString);
            _cat.LitePopulate(new CoreLibrary.ArgumentsList());


            dd_Category.DataSource = _cat;
            dd_Category.DataTextField = "Description";
            dd_Category.DataValueField = "ID";
            dd_Category.DataBind();



            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();

            dd_Status.Items.FindByValue("3").Selected = true;


        }
    }

    protected void Search_OnClick(object sender, EventArgs e)
    {
        this.DataBind();
    }

    protected void Music_OnRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Update"))
        {
            Response.Redirect("EditMusic.aspx?musId=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.Equals("Download"))
        {
            Musics _mus = new Musics(this.ConnectionString);
            _mus.LitePopulate(e.CommandArgument, false);
            String _path = String.Format(ConfigurationManager.AppSettings["MusicFilePath"], _mus.ID.ToString(), _mus.FileType);
            Response.Redirect(_path);
        }
    }

    protected void Music_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Musics _mus = ((Musics)e.Row.DataItem);
            DropDownList _dd = (DropDownList)e.Row.FindControl("dd_Status");
            if (_dd != null)
            {
                _dd.DataSource = this.LogedInUser.GetAllStatuses();
                _dd.DataTextField = "Description";
                _dd.DataValueField = "ID";
                _dd.DataBind();
                if (_dd.Items.FindByValue(_mus.Status.ToString()) != null)
                {
                    _dd.Items.FindByValue(_mus.Status.ToString()).Selected = true;
                }
            }

        }
    }

    protected void Publish_Click(Object sender, EventArgs e)
    {
        Musics _st = null;
        foreach (GridViewRow I in dgMusics.Rows)
        {
            Label _id = (Label)I.FindControl("lbl_MusId");
            if (_id != null)
            {
                DropDownList _ddst = (DropDownList)I.FindControl("dd_Status");
                TextBox _sort = (TextBox)I.FindControl("txt_Sort");
                _st = new Musics(this.ConnectionString);
                _st.LitePopulate(_id.Text, false);
                if (!_st.Status.ToString().Equals(_ddst.SelectedValue))
                {
                    _st.Status = Convert.ToInt32(_ddst.SelectedValue);
                }
                if (Regex.IsMatch(_sort.Text, @"^\d+$"))
                {
                    _st.Sort = Convert.ToInt32(_sort.Text);
                }
                _st.Save();
            }
        }
        this.DataBind();
    }
}
