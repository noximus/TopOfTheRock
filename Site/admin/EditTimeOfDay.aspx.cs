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

public partial class admin_EditTimeOfDay : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navThemes");
            _nc.Attributes.Add("class", "active");

            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();

            dd_Status.Items.FindByValue("3").Selected = true;

            String _Id = Request.QueryString["Id"];
            if (!String.IsNullOrEmpty(_Id))
            {
                ViewState.Add("Id", _Id);

                TimeOfDay _time = new TimeOfDay(this.ConnectionString);
                _time.LitePopulate(_Id, false);


                lbl_Header.Text = String.Format("Edit {0}", _time.Description);

                txt_Desc.Text = _time.Description;
                if (dd_Status.Items.FindByValue(_time.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_time.Status.ToString()).Selected = true;
                }

                val_File.Enabled = false;
            }
            else
            {
                lbl_Header.Text = "Add New Time of Day";
            }

        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            TimeOfDay _time = new TimeOfDay(this.ConnectionString);
            if (ViewState["Id"] != null)
            {
                _time.LitePopulate(ViewState["Id"], false);
            }

            _time.Description = txt_Desc.Text;
            _time.Status = Convert.ToInt32(dd_Status.SelectedValue);

            String _imgType = "";
            if (fu_File.HasFile)
            {
                _imgType = fu_File.FileName.Split('.')[1];
                _time.ImgType = _imgType;
            }
            if (_time.Save())
            {
                if (fu_File.HasFile)
                {
                    String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["TimeOfDayImagesPath"], _time.ID.ToString(), _imgType));
                    fu_File.SaveAs(_path);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'Timeofdays.aspx';", true);
                PortalCacheFactory.RefreshTimeOfDay();
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
