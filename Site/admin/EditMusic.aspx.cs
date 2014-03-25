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

public partial class admin_EditMusic : SecurePage
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


            String _musId = Request.QueryString["musId"];
            if (!String.IsNullOrEmpty(_musId))
            {
                ViewState.Add("musId", _musId);

                Musics _music = new Musics(this.ConnectionString);
                _music.LitePopulate(_musId, false);

                if (dd_Category.Items.FindByValue(_music.CategoryId.ToString()) != null)
                {
                    dd_Category.ClearSelection();
                    dd_Category.Items.FindByValue(_music.CategoryId.ToString()).Selected = true;
                }

                txt_Title.Text = HttpUtility.HtmlDecode(_music.Title);
                if (dd_Status.Items.FindByValue(_music.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_music.Status.ToString()).Selected = true;
                }

                val_File.Enabled = false;
                reg_File.Enabled = false;
            }


        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Musics _mus = new Musics(this.ConnectionString);
            if (ViewState["musId"] != null)
            {
                _mus.LitePopulate(ViewState["musId"], false);
            }

            _mus.Title = HttpUtility.HtmlEncode(txt_Title.Text);
            _mus.Status = Convert.ToInt32(dd_Status.SelectedValue);
            _mus.CategoryId = Convert.ToInt32(dd_Category.SelectedValue);

            String _imgType = "";
            if (fu_File.HasFile)
            {
                _imgType = fu_File.FileName.Split('.')[1];
                _mus.FileType = _imgType;
            }

	    

            if (_mus.Save())
            {
                if (fu_File.HasFile)
                {
                    String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["MusicFilePath"], _mus.ID.ToString(), _imgType));
                    fu_File.SaveAs(_path);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'MusicList.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
