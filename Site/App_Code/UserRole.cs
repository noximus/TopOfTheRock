using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CoreLibrary;

/// <summary>
/// Summary description for UserRole
/// </summary>
[Serializable]
public class UserRoles : BaseBusinessClass
{
    #region Constructors
    public UserRoles() { }
    public UserRoles(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBUserRoles.GetInstance();
        base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBUserRoles m_dbObject;
    private Int32 m_roleid;
    private Int32 m_userid;
    private PermissionsCollection<Permissions> m_permissions;
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
        set { m_dbObject = (Data.DBUserRoles)value; }
    }
    public Int32 RoleId
    {
        get { return m_roleid; }
        set { m_roleid = value; }
    }
    public Int32 UserId
    {
        get { return m_userid; }
        set { m_userid = value; }
    }
    [CollectionProperty]
    public PermissionsCollection<Permissions> Permissions
    {
        get { return m_permissions; }
        set { m_permissions = value; }
    }

    #endregion

    #region Methods
    protected override void LitePopulateCollectionProperties(bool inWithCollection, string[] inExcludeCollectionProperty)
    {
        this.Permissions.LitePopulate(this.RoleId, inWithCollection, inExcludeCollectionProperty);
    }
    #endregion
}

namespace Data
{
    public class DBUserRoles : IDBObject
    {

        #region Members
        private static DBUserRoles m_instance;
        #endregion

        #region Constructor
        private DBUserRoles() { }
        #endregion

        #region Methods
        public static DBUserRoles GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBUserRoles();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_USERROLES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_USERROLES_INSERT", inXmlData, inConnString);
        }

        public int Delete(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Retrieve(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable LiteRetrieve(DataTable inDataTable, string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}
