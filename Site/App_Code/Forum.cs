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
/// Summary description for Forum
/// </summary>
[Serializable]
public class Forum : BaseBusinessClass
{
    #region Constructors
    public Forum() { }
    public Forum(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBForum.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBForum m_dbObject;
    private String m_description;
    private Int32 m_sort;
    private String m_title;
    private Boolean m_active;
    #endregion

    #region Properties
    public Boolean Active
    {
        get { return m_active; }
        set { m_active = value; }
    }
    public override object ID
    {
        get { return m_id; }
        set { m_id = value; }
    }
    public override IDBObject DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBForum)value; }
    }
    public String Description
    {
        get { return m_description; }
        set { m_description = value; }
    }
    public Int32 Sort
    {
        get { return m_sort; }
        set { m_sort = value; }
    }
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }
    #endregion

    #region Methods
    public ForumCollection<Forum> GetForums(Boolean active)
    {
        ForumCollection<Forum> _coll = new ForumCollection<Forum>(this.ConnectionString);
        ArgumentsList _arg = new ArgumentsList(new ArgumentsListItem("Active", active.ToString()));
        _coll.LitePopulate(_arg, false, null);
        return _coll;
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBForum : IDBObject
    {

        #region Members
        private static DBForum m_instance;
        #endregion

        #region Constructor
        private DBForum() { }
        #endregion

        #region Methods
        public static DBForum GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBForum();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_FORUM_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_FORUM_INSERT", inXmlData, inConnString);
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_FORUM_GET", inXmlData, inConnString);
        }

        #endregion
    }

}
