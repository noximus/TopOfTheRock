using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using ClassLibrary.Controls;

/// <summary>
/// Summary description for SecurePage
/// </summary>
public class SecurePage : System.Web.UI.Page
{
    public SecurePage(){}

    #region Protected Methods
    private const string CONTROL_SECURE_ATTR = "PermissionId";

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ValidateControls();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        if (this.Context.User.Identity.IsAuthenticated)
        {
            BasePrincipal _bp = BasePrincipal.GetFromSession();
            if (_bp != null)
            {
                this.Context.User = _bp;
            }
            else
            {
                if (Regex.IsMatch(this.Context.User.Identity.Name, @"\d*"))
                {
                    BasePrincipal _brN = BasePrincipal.GetByUserID(Convert.ToInt32(this.Context.User.Identity.Name), ConnectionString);
                    this.Context.User = _brN;
                    _brN.SaveToSession();
                }
                else
                {
                    SessionTimeOut();
                }
            }
        }
        else
        {
            SessionTimeOut();
        }
        base.OnLoad(e);
    }

    public TopRockUser LogedInUser
    {
        get { return (TopRockUser)this.Context.User.Identity; }
    }

    public string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString; }
    }

    protected void SessionTimeOut()
    {
        Response.Redirect(String.Format("Login.aspx?source={0}", this.Context.Request.RawUrl));
    }
    #endregion

    #region Private Method
    /// <summary>
    /// Check if User is Authenticated
    /// </summary>
    /// <returns></returns>
    private Boolean IsValidUser()
    {
        return (this.User.Identity.IsAuthenticated && this.User.GetType() == typeof(BasePrincipal) && FormsAuthentication.GetAuthCookie(this.User.Identity.Name, true) != null);
    }

    /// <summary>
    /// Check if WebControl is secure
    /// </summary>
    /// <param name="inWebCtrl"></param>
    /// <returns></returns>
    private Boolean IsSecureControl(WebControl inWebCtrl)
    {
        return inWebCtrl.Attributes[CONTROL_SECURE_ATTR] != null;
    }

    /// <summary>
    /// Check if User has permission 
    /// </summary>
    /// <param name="permissionId"></param>
    /// <returns></returns>
    private Boolean IsValidPermission(Int16 permissionId)
    {
        return ((BasePrincipal)this.User).HasPermission(permissionId);
    }

    /// <summary>
    /// Check if webcontrol is valid to view for user
    /// </summary>
    /// <param name="inWebControl"></param>
    /// <returns></returns>
    private Boolean IsValidControl(WebControl inWebControl)
    {
        if (IsSecureControl(inWebControl))
        {
            if (!IsValidUser())
            {
                return false;
            }
            else
            {
                if (!IsValidPermission(Convert.ToInt16(inWebControl.Attributes[CONTROL_SECURE_ATTR])))
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Loop through all page controls and check the security
    /// </summary>
    private void ValidateControls()
    {
        foreach (Control _ctrl in this.Master.Controls)
        {
            ValidateChildControls(_ctrl, true);
        }
    }

    /// <summary>
    /// Loop through all page controls and check the security
    /// </summary>
    private void ValidateChildControls(Control inCtrl, Boolean inRecursive)
    {
        try
        {
            foreach (Control _ctrl in inCtrl.Controls)
            {
                if (_ctrl.GetType() != typeof(ContentPlaceHolder))
                {
                    if (_ctrl.GetType() == typeof(SecureHolder))
                    {
                        if (!((BasePrincipal)this.User).HasPermission(Convert.ToInt16(((SecureHolder)_ctrl).PermissionId)))
                        {
                            _ctrl.Controls.Clear();
                            Label _l = new Label();
                            _l.Text = "You do not have permission to view this page.";
                            _l.ForeColor = System.Drawing.Color.Red;
                            _ctrl.Controls.Add(_l);
                        }
                    }
                }
                if (inRecursive) { ValidateChildControls(_ctrl, inRecursive); };
            }
        }
        catch (Exception ex) { }
    }

    #endregion

}
