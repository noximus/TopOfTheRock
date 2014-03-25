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

public partial class admin_EditPublicity : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navPress");
            _nc.Attributes.Add("class", "active");

            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();

            String _pubId = Request.QueryString["pubId"];
            if (!String.IsNullOrEmpty(_pubId))
            {
                ViewState.Add("pubId", _pubId);

                Publicity _pub = new Publicity(this.ConnectionString);
                _pub.LitePopulate(_pubId, false);


                txt_Title.Text = HttpUtility.HtmlDecode(_pub.Title);
                txt_Date.Text = _pub.Date;
                if (dd_Status.Items.FindByValue(_pub.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_pub.Status.ToString()).Selected = true;
                }


                lbl_Header.Text = HttpUtility.HtmlDecode(_pub.Title);
                val_File.Enabled = false;
            }
            else
            {
                lbl_Header.Text = "Add New";
            }
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Publicity _pub = new Publicity(this.ConnectionString);
            if (ViewState["pubId"] != null)
            {
                _pub.LitePopulate(ViewState["pubId"], false);
            }

            _pub.Title = HttpUtility.HtmlEncode(txt_Title.Text);
            _pub.Status = Convert.ToInt32(dd_Status.SelectedValue);
            _pub.Date = txt_Date.Text;

            String _fileType = "";
            if (fu_File.HasFile)
            {
                _fileType = fu_File.FileName.Split('.')[1];
                _pub.FileType = _fileType;
            }
            if (_pub.Save())
            {
                if (fu_File.HasFile)
                {
                    String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PublicityFilePath"], _pub.ID.ToString(), _pub.FileType));
                    fu_File.SaveAs(_path);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'PublicityList.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
