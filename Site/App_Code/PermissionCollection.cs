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
/// Summary description for PermissionCollection
/// </summary>
[Serializable]
public class PermissionsCollection<Permissions> : BaseBusinessCollection
{
    #region Constructors
    public PermissionsCollection() { m_memberType = typeof(Permissions); }
    public PermissionsCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBPermissionsCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBPermissionsCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBPermissionsCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBPermissionsCollection : IDBObjectCollection
    {

        #region Members
        private static DBPermissionsCollection m_instance;
        #endregion

        #region Constructor
        private DBPermissionsCollection() { }
        #endregion

        #region Methods
        public static DBPermissionsCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBPermissionsCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_PERMISSIONS_GETBYPARENT", inParentID.ToString(), inConnString);
        }

        #endregion
    }

}

