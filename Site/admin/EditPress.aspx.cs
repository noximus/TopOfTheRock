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

public partial class admin_EditPress : SecurePage
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

            dd_Format.DataSource = this.LogedInUser.GetPressTypes();
            dd_Format.DataTextField = "Description";
            dd_Format.DataValueField = "ID";
            dd_Format.DataBind();

            dd_Format.Items.Insert(0, new ListItem("---- Select One-----", ""));

            String _pressId = Request.QueryString["pressId"];
            if (!String.IsNullOrEmpty(_pressId))
            {
                ViewState.Add("pressId", _pressId);

                Press _press = new Press(this.ConnectionString);
                _press.LitePopulate(_pressId, false);

                if (dd_Format.Items.FindByValue(Convert.ToInt32(_press.ContentType).ToString()) != null)
                {
                    dd_Format.ClearSelection();
                    dd_Format.Items.FindByValue(Convert.ToInt32(_press.ContentType).ToString()).Selected = true;
                    dd_Format.Enabled = false;
                }

                txt_Title.Text = HttpUtility.HtmlDecode(_press.PressTitle);
                txt_Desc.Text = HttpUtility.HtmlDecode(_press.Deacription);
                txt_Date.Text = _press.PressDate;
                txt_Link.Text = _press.WebLink;
                if (dd_Status.Items.FindByValue(_press.Status.ToString()) != null)
                {
                    dd_Status.ClearSelection();
                    dd_Status.Items.FindByValue(_press.Status.ToString()).Selected = true;
                }

                val_AudFile.Enabled = false;
                val_AudThumb.Enabled = false;
                val_MThumb.Enabled = false;
                val_VidFile.Enabled = false;
                val_VidThumb.Enabled = false;
                val_TxtThumb.Enabled = false;
                Format_IndexChanged(dd_Format, EventArgs.Empty);

                lbl_Header.Text = _press.PressTitle;
            }
            else
            {
                lbl_Header.Text = "Add New";
            }
        }
    }

    protected void Format_IndexChanged(object sender, EventArgs e)
    {
        String _form = dd_Format.SelectedValue;
        if (String.IsNullOrEmpty(_form))
        {
            pnl_Audio.Visible = false;
            pnl_Text.Visible = false;
            pnl_Video.Visible = false;
        }
        else
        {
            Press.enumPressTypes _enum = (Press.enumPressTypes)Enum.Parse(typeof(Press.enumPressTypes), _form);
            switch (_enum)
            {
                case Press.enumPressTypes.Audio:
                    pnl_Audio.Visible = true;
                    pnl_Text.Visible = false;
                    pnl_Video.Visible = false;
                    break;
                case Press.enumPressTypes.Video:
                    pnl_Audio.Visible = false;
                    pnl_Text.Visible = false;
                    pnl_Video.Visible = true;
                    break;
                case Press.enumPressTypes.Text:
                    pnl_Audio.Visible = false;
                    pnl_Text.Visible = true;
                    pnl_Video.Visible = false;
                    break;
                default:
                    pnl_Audio.Visible = false;
                    pnl_Text.Visible = false;
                    pnl_Video.Visible = false;
                    break;
            }
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Press _press = new Press(this.ConnectionString);

            if (ViewState["pressId"] != null)
            {
                _press.LitePopulate(ViewState["pressId"], false);
            }

            _press.PressTitle = HttpUtility.HtmlEncode(txt_Title.Text);
            _press.ContentType = (Press.enumPressTypes)Enum.Parse(typeof(Press.enumPressTypes), dd_Format.SelectedValue);
            _press.Deacription = HttpUtility.HtmlEncode(txt_Desc.Text);
            _press.PressDate = txt_Date.Text;
            _press.Status = Convert.ToInt32(dd_Status.SelectedValue);

            String _pressImgType = "";
            if(fu_MThumb.HasFile)
            {
                _pressImgType = fu_MThumb.FileName.Split('.')[1];
                _press.PressThumbImgType = _pressImgType;
            }
            String _contThumb = "";
            String _contFile = "";
            switch (_press.ContentType)
            {
                case Press.enumPressTypes.Audio:
                    if (fu_AudThumb.HasFile)
                    {
                        _contThumb = fu_AudThumb.FileName.Split('.')[1];
                        _press.ContentThumbImgType = _contThumb;
                    }
                    if (fu_AudFile.HasFile)
                    {
                        _contFile = fu_AudFile.FileName.Split('.')[1];
                        _press.MusicType = _contFile;
                    }
                    break;
                case Press.enumPressTypes.Video:
                    if (fu_VidThumb.HasFile)
                    {
                        _contThumb = fu_VidThumb.FileName.Split('.')[1];
                        _press.ContentThumbImgType = _contThumb;
                    }
                    if (fu_VidFile.HasFile)
                    {
                        _contThumb = fu_VidFile.FileName.Split('.')[1];
                        _press.VideoType = _contThumb;
                    }
                    break;
                case Press.enumPressTypes.Text:
                    if (fu_TxtThumb.HasFile)
                    {
                        _contThumb = fu_TxtThumb.FileName.Split('.')[1];
                        _press.ContentThumbImgType = _contThumb;
                    }
                    _press.WebLink = txt_Link.Text;
                    break;
                default:
                    break;
            }

            if (_press.Save())
            {
                String _path;
                switch (_press.ContentType)
                {
                    case Press.enumPressTypes.Audio:
                        if (fu_AudThumb.HasFile)
                        {
                            _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressContentThumbPath"], _press.ID.ToString(), _press.ContentThumbImgType));
                            fu_AudThumb.SaveAs(_path);
                        }
                        if (fu_AudFile.HasFile)
                        {
                            _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressAudioPath"], _press.ID.ToString(), _press.MusicType));
                            fu_AudFile.SaveAs(_path);
                        }
                        break;
                    case Press.enumPressTypes.Video:
                        if (fu_VidThumb.HasFile)
                        {
                            _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressContentThumbPath"], _press.ID.ToString(), _press.ContentThumbImgType));
                            fu_VidThumb.SaveAs(_path);
                        }
                        if (fu_VidFile.HasFile)
                        {
                            _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressVideoPath"], _press.ID.ToString(), _press.VideoType));
                            fu_VidFile.SaveAs(_path);
                        }
                        break;
                    case Press.enumPressTypes.Text:
                        if (fu_TxtThumb.HasFile)
                        {
                            _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressContentThumbPath"], _press.ID.ToString(), _press.ContentThumbImgType));
                            fu_TxtThumb.SaveAs(_path);
                        }
                        break;
                    default:
                        break;
                }
                if (fu_MThumb.HasFile)
                {
                    _path = Server.MapPath(String.Format(ConfigurationManager.AppSettings["PressThumbPath"], _press.ID.ToString(), _press.PressThumbImgType));
                    fu_MThumb.SaveAs(_path);

                }


                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('Record has been updated successfully.');self.location = 'PressList.aspx';", true);
            }
            else
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
        }
    }
}
