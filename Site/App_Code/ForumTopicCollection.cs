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
/// Summary description for ForumTopicCollection
/// </summary>
[Serializable]
public class ForumTopicsCollection<ForumTopics> : BaseBusinessCollection
{
    #region Constructors
    public ForumTopicsCollection() { m_memberType = typeof(ForumTopics); }
    public ForumTopicsCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBForumTopicsCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBForumTopicsCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBForumTopicsCollection)value; }
    }
    #endregion
}

namespace Data
{
    public class DBForumTopicsCollection : IDBObjectCollection
    {

        #region Members
        private static DBForumTopicsCollection m_instance;
        #endregion

        #region Constructor
        private DBForumTopicsCollection() { }
        #endregion

        #region Methods
        public static DBForumTopicsCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBForumTopicsCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_FORUMTOPICS_GETBYPARENT", inParentID.ToString(), inConnString);
        }

        #endregion
    }

}