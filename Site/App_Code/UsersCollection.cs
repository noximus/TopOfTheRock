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
/// Summary description for UsersCollection
/// </summary>
[Serializable]
public class UsersCollection<TopRockUser> : BaseBusinessCollection
{
    #region Constructors
    public UsersCollection() { m_memberType = typeof(TopRockUser); }
    public UsersCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBUsersCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBUsersCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBUsersCollection)value; }
    }
    #endregion
}

namespace Data
{
    public class DBUsersCollection : IDBObjectCollection
    {

        #region Members
        private static DBUsersCollection m_instance;
        #endregion

        #region Constructor
        private DBUsersCollection() { }
        #endregion

        #region Methods
        public static DBUsersCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBUsersCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_USERS_GETBYARGLIST", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}
