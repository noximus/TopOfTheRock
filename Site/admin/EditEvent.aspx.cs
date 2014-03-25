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
using CoreLibrary.Utility;

public partial class admin_EditEvent : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navEvents");
            _nc.Attributes.Add("class", "active");


            dd_Status.DataSource = this.LogedInUser.GetAllStatuses();
            dd_Status.DataTextField = "Description";
            dd_Status.DataValueField = "ID";
            dd_Status.DataBind();


            String _eventId = Request.QueryString["eventId"];

            ViewState.Add("parentId", Request.QueryString["parentId"]);

            if (!String.IsNullOrEmpty(_eventId))
            {
                ViewState.Add("eventId", _eventId);

                Events _event = new Events(this.ConnectionString);
                _event.LitePopulate(_eventId, false);

                txt_Title.Text = HttpUtility.HtmlDecode(_event.Title);
                txt_Desc.Text = HttpUtility.HtmlDecode(_event.Description);

                if (dd_Status.Items.FindByValue(_event.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_event.Status.ToString()).Selected = true;
                }

                lbl_Header.Text = HttpUtility.HtmlDecode(_event.Title);

                val_BigImg.Enabled = false;
                val_SmlImg.Enabled = false;
                val_Thumb.Enabled = false;
            }
            else
            {
                lbl_Header.Text = "Add Event";
            }

        }
    }

    protected void Save_OnClick(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Events _event = new Events(this.ConnectionString);
            if (ViewState["eventId"] != null)
            {
                _event.LitePopulate(ViewState["eventId"], false);
            }

            if (ViewState["parentId"] != null)
            {
                _event.ParentId = Convert.ToInt32(ViewState["parentId"]);
            }

            _event.Title = HttpUtility.HtmlEncode(txt_Title.Text);
            _event.Description = HttpUtility.HtmlEncode(txt_Desc.Text);
            _event.Status = Convert.ToInt32(dd_Status.SelectedValue);

            String _BigImgType = "";
            if (fu_BigImg.HasFile)
            {
                _BigImgType = fu_BigImg.FileName.Split('.')[1];
                _event.BigImgType = _BigImgType;
            }
            String _SmlImgType = "";
            if (fu_SmlImg.HasFile)
            {
                _SmlImgType = fu_SmlImg.FileName.Split('.')[1];
                _event.SmlImgType = _SmlImgType;
            }
            String _ThumImgType = "";
            if (fu_Thumb.HasFile)
            {
                _ThumImgType = fu_Thumb.FileName.Split('.')[1];
                _event.ThumbnailImgType = _ThumImgType;
            }

            if (_event.Save())
            {
                String _path;
                if (fu_BigImg.HasFile)
                {
                    _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["EventLargeImgPath"], _event.ID.ToString(), _BigImgType));
                    fu_BigImg.SaveAs(_path);
                }
                if (fu_SmlImg.HasFile)
                {
                    _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["EventSmallImgPath"], _event.ID.ToString(), _SmlImgType));
                    fu_SmlImg.SaveAs(_path);
                }
                if (fu_Thumb.HasFile)
                {
                    _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["EventThumbImgPath"], _event.ID.ToString(), _ThumImgType));
                    fu_Thumb.SaveAs(_path);
                }
                String _parent = CommonUtility.NullSafeString(ViewState["parentId"], "");
                String _url = (String.IsNullOrEmpty(_parent)) ? "Events.aspx" : "EventGallery.aspx?parentId=" + _parent;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location='" + _url + "';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
