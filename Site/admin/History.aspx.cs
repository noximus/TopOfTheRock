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

public partial class admin_History : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");

            Pages _page = new Pages(this.ConnectionString);
            _page.LitePopulate(ConfigurationManager.AppSettings["History"], true);
            Bind(_page);
        }
    }

    private void CheckImageValidate(Pages data)
    {
        foreach (RepeaterItem I in rpt_History.Items)
        {
            Label _lbl = (Label)I.FindControl("lbl_ContentId");
            if (_lbl != null)
            {
                SiteContents _cnt = (SiteContents)data.PageContents.FindByID(_lbl.Text);
                if (_cnt.Images.Count > 0)
                {
                    RequiredFieldValidator _val = (RequiredFieldValidator)I.FindControl("val_Image");
                    _val.Enabled = false;
                }
            }
        }
    }

    private void Bind(Pages data)
    {
        rpt_History.DataSource = data.PageContents;
        rpt_History.DataBind();
        CheckImageValidate(data);
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Boolean _status = true;
            
            foreach (RepeaterItem I in rpt_History.Items)
            {
                Label _lbl = (Label)I.FindControl("lbl_ContentId");
                if (_lbl != null)
                {
                    SiteContents _cont = new SiteContents(this.ConnectionString);
                    _cont.LitePopulate(_lbl.Text, true);
                    _cont.Description = ((TextBox)I.FindControl("txt_Desc")).Text;
                    _cont.Title = ((TextBox)I.FindControl("txt_Title")).Text;
                    _cont.Sort = Convert.ToInt32(((TextBox)I.FindControl("txt_Sort")).Text);
                    _cont.PageId = Convert.ToInt32(ConfigurationManager.AppSettings["History"]);

                    String _imgFile = "";
                    FileUpload _fu = (FileUpload)I.FindControl("fu_Image");
                    SiteContentImages _siteImg = null;
                    if (_fu.HasFile)
                    {
                        _imgFile = _fu.FileName.Split('.')[1];
                        
                        if (_cont.Images.Count == 0)
                        {
                            _siteImg = new SiteContentImages(this.ConnectionString);
                            _cont.Images.Add(_siteImg);
                            _siteImg.ContentId = Convert.ToInt32(_cont.ID);
                        }
                        else
                        {
                            _siteImg = (SiteContentImages)_cont.Images[0];
                        }

                        _siteImg.Sort = Convert.ToInt32(((TextBox)I.FindControl("txt_Sort")).Text);
                        _siteImg.ImgType = _imgFile;
                    }

                    if (!_cont.Save(true, null))
                    {
                        lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                        lbl_Error.Visible = true;
                        _status = false;
                        break;
                    }
                    else
                    {
                        if (_fu.HasFile)
                        {
                            String _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["HistoryImagesPath"], _siteImg.ID.ToString(), _imgFile));
                            _fu.SaveAs(_path);
                        }
                    }
                }
            }
            if (_status)
            {
                Pages _page = new Pages(this.ConnectionString);
                _page.LitePopulate(ConfigurationManager.AppSettings["History"], true);
                Bind(_page);
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');", true);
            }
        }
    }
}
