using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Security.Principal;

using CoreLibrary;

/// <summary>
/// Summary description for TopRockUser
/// </summary>
[Serializable]
public class TopRockUser : BaseBusinessClass, IIdentity
{
    #region Constructors
        public TopRockUser() { }
        public TopRockUser(String inConnString)
        {
            this.ConnectionString = inConnString;
            this.DBObject = Data.DBUsers.GetInstance();
            base.InitializeCollection();
        }
    #endregion 

    #region Members
    public enum enumRegisterStatus { Ok = 1, EmailExists = 2, Error = 3 }
    public enum enumStatuses { Active = 1, Inactive = 0, All = 2 }
    private Object m_id;
    private Data.DBUsers m_dbObject;
    private Boolean m_active;
    private DateTime m_datecreated;
    private DateTime m_dateupdated;
    private String m_email;
    private String m_firstname;
    private String m_lastname;
    private String m_password;
    private UserRolesCollection<UserRoles> m_roles;
    #endregion 

    #region Properties
        public override object ID
        {
        get { return m_id; }
        set { m_id = value; }
        }
        public override IDBObject DBObject
        {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBUsers)value; }
        }
        public Boolean Active
        {
        get { return m_active; }
        set { m_active = value; }
        }
        public DateTime DateCreated
        {
        get { return m_datecreated; }
        set { m_datecreated = value; }
        }
        public DateTime DateUpdated
        {
        get { return m_dateupdated; }
        set { m_dateupdated = value; }
        }
        public String Email
        {
        get { return m_email; }
        set { m_email = value; }
        }
        public String FirstName
        {
        get { return m_firstname; }
        set { m_firstname = value; }
        }
        public String LastName
        {
        get { return m_lastname; }
        set { m_lastname = value; }
        }
        public String Password
        {
        get { return m_password; }
        set { m_password = value; }
        }
        [CollectionProperty]
        public UserRolesCollection<UserRoles> Roles
        {
            get { return m_roles; }
            set { m_roles = value; }
        }

    #endregion 

    #region IIdentity Members
    [ExcludeFromToXml]
    public string AuthenticationType
    {
        get { return "Custom Authentication"; }
    }
    [ExcludeFromToXml]
    public bool IsAuthenticated
    {
        get { return true; }
    }
    [ExcludeFromToXml]
    public string Name
    {
        get {return this.ID.ToString(); }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Populate User By Email
    /// </summary>
    /// <param name="email"></param>
    public void PopulateByEmail(string email)
    {
        DataRowCollection _dr = m_dbObject.RetrieveByEmail(this.GetDataTableSchema(DATATABLE_EXCLUDE_PROPERTY), email, this.ConnectionString).Rows;
        if (_dr.Count > 0) { this.LitePopulate(_dr[0], false, null); }
    }

    /// <summary>
    /// Login User
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    public void PopulateByLogin(string email, string password)
    {
        String _xml = String.Format("<data><Email><![CDATA[{0}]]></Email><Password><![CDATA[{1}]]></Password></data>", email, password);
        DataRowCollection _dr = m_dbObject.RetrieveByLogin(this.GetDataTableSchema(DATATABLE_EXCLUDE_PROPERTY), _xml, this.ConnectionString).Rows;
        if (_dr.Count > 0) { this.LitePopulate((DataRow)_dr[0], true, null); }
    }

    /// <summary>
    /// Save User
    /// </summary>
    /// <returns></returns>
    public enumRegisterStatus SaveUser(bool withCollection, string[] excludeCollection)
    {
        enumRegisterStatus _status = (enumRegisterStatus)this.CheckRegisterUniqueness();
        if (_status == enumRegisterStatus.Ok)
        {
            if (this.Save(withCollection, excludeCollection))
            {
                return enumRegisterStatus.Ok;
            }
            else
            {
                return enumRegisterStatus.Error;
            }
        }
        return _status;
    }

    /// <summary>
    /// Check user uniqueness
    /// </summary>
    /// <returns></returns>
    public enumRegisterStatus CheckRegisterUniqueness()
    {
        enumRegisterStatus _ret = enumRegisterStatus.EmailExists;
        String _xml = String.Format("<data><Email><![CDATA[{0}]]></Email><UserId>{1}</UserId></data>", this.Email, (this.ID == null)? "0" : this.ID.ToString());
        DataRowCollection _dr = m_dbObject.CheckUserUniqueness(_xml, this.ConnectionString).Rows;
        if (_dr.Count > 0)
        {
            _ret = (enumRegisterStatus)_dr[0][0];
        }
        return _ret;
    }

    /// <summary>
    /// Get Users
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public UsersCollection<TopRockUser> GetUsers(enumStatuses status)
    {
        UsersCollection<TopRockUser> _coll = new UsersCollection<TopRockUser>(this.ConnectionString);
        ArgumentsList _arg = new ArgumentsList(new ArgumentsListItem("Status", Convert.ToInt32(status).ToString()));
        _coll.LitePopulate(_arg,false, null);
        return _coll;
    }

    /// <summary>
    /// Get All Roles
    /// </summary>
    /// <returns></returns>
    public DataTable GetAllRoles()
    {
        return m_dbObject.RetrieveAllRoles(this.ConnectionString);
    }

    /// <summary>
    /// Get All Statuses
    /// </summary>
    /// <returns></returns>
    public DataTable GetAllStatuses()
    {
        return m_dbObject.GetAllStatuses(this.ConnectionString);
    }
    #endregion
}

namespace Data
{
    public class DBUsers : IDBObject
    {

        #region Members
        private static DBUsers m_instance;
        #endregion

        #region Constructor
        private DBUsers() { }
        #endregion

        #region Methods
        public static DBUsers GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBUsers();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_USERS_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_USERS_INSERT", inXmlData, inConnString);
        }

        public int Delete(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_USERS_DELETE", inXmlData, inConnString);
        }

        public string Retrieve(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable LiteRetrieve(DataTable inDataTable, string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_USERS_GET", inXmlData, inConnString);
        }

        public DataTable RetrieveByEmail(DataTable inDataTable, string Email, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_USERS_GETBYEMAIL", Email, inConnString);
        }
        public DataTable RetrieveByLogin(DataTable inDataTable, string LoginXml, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_USERS_GETBYLOGIN", LoginXml, inConnString);
        }

        public DataTable CheckUserUniqueness(string XmlString, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_USERS_CHECK_UNIQUENESS", XmlString, inConnString);
        }

        public DataTable RetrieveAllRoles(string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_ROLES_GETALL", "", inConnString);
        }
        public DataTable GetAllStatuses(string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_STATUSES_GETALL", "", inConnString);
        }


        #endregion
    }

}
