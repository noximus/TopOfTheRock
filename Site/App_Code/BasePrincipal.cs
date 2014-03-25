using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;
using CoreLibrary;

/// <summary>
/// Summary description for BasePrincipal
/// </summary>
[Serializable()]
public class BasePrincipal : IPrincipal
{
    #region Members
    protected IIdentity m_identity;
    public const string SESSIONNAME = "__BasePrincipal";
    #endregion

    #region Constructors
    public BasePrincipal() { }
    public BasePrincipal(TopRockUser user): this()
    {
        if (user.ID == null) { user = null; }
        m_identity = user;
    }
    public BasePrincipal(Int32 userId, string connectionString): this()
    {
        TopRockUser _u = new TopRockUser(connectionString);
        _u.Populate(userId);
        if (_u.ID == null) { _u = null; }
        m_identity = _u;
    }
    #endregion

    #region IPrincipal Members

    public IIdentity Identity
    {
        get { return m_identity; }
    }

    public bool IsInRole(string role)
    {
        return false;
    }

    #endregion

    #region Public Methods
    /// <summary>
    /// Get User Principal by ID
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static BasePrincipal GetByUserID(Int32 userId, string connectionString)
    {
        TopRockUser _u = new TopRockUser(connectionString);
        _u.LitePopulate(userId);
        if (_u.ID != null)
        {
            BasePrincipal _bp = new BasePrincipal(_u);
            return _bp;
        }
        return null;
    }


    /// <summary>
    /// Get by email
    /// </summary>
    /// <param name="email"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static BasePrincipal GetByEmail(string email, string connectionString)
    {
        TopRockUser _u = new TopRockUser(connectionString);
        _u.PopulateByEmail(email);
        if (_u.ID != null)
        {
            BasePrincipal _bp = new BasePrincipal(_u);
            return _bp;
        }
        return null;
    }


    /// <summary>
    /// User Login
    /// </summary>
    /// <param name="inUserName"></param>
    /// <param name="inPassword"></param>
    /// <param name="inConnString"></param>
    /// <returns></returns>
    public static BasePrincipal LoginUser(String inUserName, string inPassword, string inConnString)
    {
        TopRockUser _u = new TopRockUser(inConnString);
        _u.PopulateByLogin(inUserName, inPassword);
        if (_u.ID != null)
        {
            BasePrincipal _bp = new BasePrincipal(_u);
            return _bp;
        }
        return null;
    }

    /// <summary>
    /// Save User IPrincipal to Session
    /// </summary>
    public void SaveToSession()
    {
        if (HttpContext.Current != null)
        {
            HttpContext.Current.Session[SESSIONNAME] = this;
        }
    }

    /// <summary>
    /// Get User IPrincipal from Session
    /// </summary>
    /// <returns></returns>
    public static BasePrincipal GetFromSession()
    {
        if (HttpContext.Current != null)
        {
            BasePrincipal _member = new BasePrincipal();
            _member = (BasePrincipal)HttpContext.Current.Session[SESSIONNAME];
            return _member;
        }
        return null;
    }

    /// <summary>
    /// Check User Permission
    /// </summary>
    /// <param name="permissionId"></param>
    /// <returns></returns>
    public bool HasPermission(Int16 permissionId)
    {
        foreach (UserRoles I in ((TopRockUser)m_identity).Roles)
        {
            BaseBusinessClass _obj = I.Permissions.FindByID(permissionId.ToString());
            if (_obj != null) { return true; }
        }
        return false;
    }
    #endregion
}
