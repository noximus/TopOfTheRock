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

public partial class admin_MyProfile : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navManageUser");
            _nc.Attributes.Add("class", "active");

            LabelPageTitle.Text = String.Format("{0} {1} Profile", this.LogedInUser.FirstName, this.LogedInUser.LastName);

            TopRockUser _user = LogedInUser;

            txt_Email.Text = _user.Email;
            txt_Fname.Text = _user.FirstName;
            txt_Lname.Text = _user.LastName;
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            TopRockUser _user = LogedInUser;

            _user.LastName = txt_Lname.Text;
            _user.FirstName = txt_Fname.Text;
            _user.Email = txt_Email.Text;

            if (!String.IsNullOrEmpty(txt_NewPassword.Text))
            {
                _user.Password = txt_NewPassword.Text;
            }
            TopRockUser.enumRegisterStatus _ret = _user.SaveUser(false, null);
            if (_ret == TopRockUser.enumRegisterStatus.Error)
            {
                lbl_Error.Text = "An unexpected error has occurred. Please try again.";
                lbl_Error.Visible = true;
            }
            else if (_ret == TopRockUser.enumRegisterStatus.EmailExists)
            {
                lbl_Error.Text = "That email is already in use under another username.";
                lbl_Error.Visible = true;
            }
            else
            {
                lbl_Error.Text = "Your profile has been updated successfully";
                lbl_Error.Visible = true;
            }
        }
    }
}
