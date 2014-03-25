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
/// Summary description for UserRolesCollection
/// </summary>
[Serializable]
public class UserRolesCollection<UserRoles> : BaseBusinessCollection
{
    #region Constructors
    public UserRolesCollection() { m_memberType = typeof(UserRoles); }
    public UserRolesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBUserRolesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBUserRolesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBUserRolesCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBUserRolesCollection : IDBObjectCollection
    {

        #region Members
        private static DBUserRolesCollection m_instance;
        #endregion

        #region Constructor
        private DBUserRolesCollection() { }
        #endregion

        #region Methods
        public static DBUserRolesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBUserRolesCollection();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Insert(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Retrieve(string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Retrieve(object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable LiteRetrieve(DataTable inDataTable, string inXmlData, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_USERROLES_GETBYPARENT", inParentID.ToString(), inConnString);
        }

        #endregion
    }

}

