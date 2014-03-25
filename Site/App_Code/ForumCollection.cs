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
/// Summary description for ForumCollection
/// </summary>
[Serializable]
public class ForumCollection<Forum> : BaseBusinessCollection
{
    #region Constructors
    public ForumCollection() { m_memberType = typeof(Forum); }
    public ForumCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBForumCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBForumCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBForumCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBForumCollection : IDBObjectCollection
    {

        #region Members
        private static DBForumCollection m_instance;
        #endregion

        #region Constructor
        private DBForumCollection() { }
        #endregion

        #region Methods
        public static DBForumCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBForumCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_FORUM_GETBYARGLIST", inXmlData,  inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            return null;
        }

        #endregion
    }

}
