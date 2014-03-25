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

public partial class admin_EditEmployee : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navManageUser");
            _nc.Attributes.Add("class", "active");


            dd_Role.DataSource = this.LogedInUser.GetAllRoles();
            dd_Role.DataTextField = "Description";
            dd_Role.DataValueField = "ID";
            dd_Role.DataBind();
            dd_Role.Items.Insert(0, new ListItem("---- Select One ---", ""));


            String _userId = Request.QueryString["userId"];
            if (!String.IsNullOrEmpty(_userId))
            {
                ViewState.Add("UserId", _userId);
                TopRockUser _user = new TopRockUser(this.ConnectionString);
                _user.LitePopulate(Convert.ToInt32(_userId), true);

                lbl_Header.Text = String.Format("{0} {1} Profile", _user.FirstName, _user.LastName);

                txt_Email.Text = _user.Email;
                txt_Fname.Text = _user.FirstName;
                txt_Lname.Text = _user.LastName;


                if (dd_Role.Items.FindByValue(((UserRoles)_user.Roles[0]).RoleId.ToString()) != null)
                {
                    dd_Role.Items.FindByValue(((UserRoles)_user.Roles[0]).RoleId.ToString()).Selected = true;
                }

                ch_Active.Checked = _user.Active;

                val_Password.Enabled = false;
            }
            else
            {
                lbl_Header.Text = "Add User";
            }
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            TopRockUser _user = new TopRockUser(this.ConnectionString);
            UserRoles _role;
            if (ViewState["UserId"] != null)
            {
                _user.LitePopulate(Convert.ToInt32(ViewState["UserId"]), true);
                _role = (UserRoles)_user.Roles[0];
            }
            else
            {
                _role = new UserRoles(this.ConnectionString);
                _user.Roles.Add(_role);
            }

            _role.RoleId = Convert.ToInt32(dd_Role.SelectedValue);

            _user.Email = txt_Email.Text;
            _user.FirstName = txt_Fname.Text;
            _user.LastName = txt_Lname.Text;

            if (!String.IsNullOrEmpty(txt_NewPassword.Text))
            {
                _user.Password = txt_NewPassword.Text;
            }

            _user.Active = ch_Active.Checked;

            TopRockUser.enumRegisterStatus _ret = _user.SaveUser(true, null);
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
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", "alert('" + txt_Email.Text + " profile has been updated successfully.');self.location = 'employeelist.aspx';", true);
            }
        }
    }
}
