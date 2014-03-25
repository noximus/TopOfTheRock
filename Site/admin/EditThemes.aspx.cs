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
using System.IO;

public partial class admin_EditThemes : SecurePage
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


            String _themeId = Request.QueryString["themeId"];
            if (!String.IsNullOrEmpty(_themeId))
            {
                ViewState.Add("themeId", _themeId);
                SiteThemes _tms = new SiteThemes(this.ConnectionString);
                _tms.LitePopulate(ViewState["themeId"], false);

                txt_Name.Text = _tms.Name;
                txt_Name.Enabled = false;

                if (dd_Status.Items.FindByValue(_tms.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_tms.Status.ToString()).Selected = true;
                }

                lbl_Header.Text = String.Format("{0} Theme", _tms.Name);
                btn_Download.Visible = true;
                val_File.Enabled = false;
                reg_File.Enabled = false;
            }
            else
            {
                lbl_Header.Text = "Add Theme";
            }
        }

    }

    /// <summary>
    /// Save Themes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Themes(object sender, EventArgs e)
    {
        if (IsValid)
        {
            SiteThemes _tms = new SiteThemes(this.ConnectionString);
            String _orgFileName = "";
            if (ViewState["themeId"] != null)
            {
                _tms.LitePopulate(ViewState["themeId"], false);
                _orgFileName = _tms.Name;
            }

            _tms.Name = Regex.Replace(txt_Name.Text, @"\s+", "_");
            _tms.Status = Convert.ToInt32(dd_Status.SelectedValue);

            if (_tms.Save())
            {
                String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["ThemesZipPath"], _tms.Name));
                String _orgPath = Server.MapPath(String.Format(ConfigurationManager.AppSettings["ThemesZipPath"], _orgFileName));
                if (fu_File.HasFile)
                {
                    fu_File.SaveAs(_path);

                    String _themesPath = Server.MapPath(String.Format("../App_Themes/{0}/", _tms.Name));

                    Directory.CreateDirectory(_themesPath);

                    _tms.UnZip(_themesPath, fu_File.PostedFile.InputStream);
                }
                //if (!String.IsNullOrEmpty(_orgFileName))
                //{
                //    if (!_orgFileName.Equals(_tms.Name))
                //    {
                //        File.Move(_orgPath, _path);
                //        File.Delete(_orgPath);
                //    }
                //}
                
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'Themes.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }

    /// <summary>
    /// DownLoad Theme
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Download_Click(object sender, EventArgs e)
    {
        
        if (ViewState["themeId"] != null)
        {
            SiteThemes _tms = new SiteThemes(this.ConnectionString);
            _tms.LitePopulate(ViewState["themeId"], false);
            String _path = String.Format(ConfigurationManager.AppSettings["ThemesZipPath"], _tms.Name);
            Response.Redirect(_path);
        }
    }

}
