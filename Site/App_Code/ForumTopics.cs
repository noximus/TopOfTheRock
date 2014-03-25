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
/// Summary description for ForumTopics
/// </summary>
[Serializable]
public class ForumTopics : BaseBusinessClass
{
    #region Constructors
    public ForumTopics() { }
    public ForumTopics(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBForumTopics.GetInstance();
        base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBForumTopics m_dbObject;
    private DateTime m_datecreated;
    private String m_email;
    private Int32 m_forumid;
    private String m_nickname;
    private Int32 m_parentid;
    private Int32 m_status;
    private String m_title;
    private String m_topic;
    private String m_cutrure;
    private ForumTopicsCollection<ForumTopics> m_threads;

	
    #endregion

    #region Properties
    [CollectionProperty]
    public ForumTopicsCollection<ForumTopics> Threads
    {
        get { return m_threads; }
        set { m_threads = value; }
    }

    public override object ID
    {
        get { return m_id; }
        set { m_id = value; }
    }
    public override IDBObject DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBForumTopics)value; }
    }
    public DateTime DateCreated
    {
        get { return m_datecreated; }
        set { m_datecreated = value; }
    }
    public String Email
    {
        get { return m_email; }
        set { m_email = value; }
    }
    public Int32 ForumId
    {
        get { return m_forumid; }
        set { m_forumid = value; }
    }
    public String NickName
    {
        get { return m_nickname; }
        set { m_nickname = value; }
    }
    public Int32 ParentId
    {
        get { return m_parentid; }
        set { m_parentid = value; }
    }
    public Int32 Status
    {
        get { return m_status; }
        set { m_status = value; }
    }
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }
    public String Topic
    {
        get { return m_topic; }
        set { m_topic = value; }
    }
    public String CultureInfo
    {
        get { return m_cutrure; }
        set { m_cutrure = value; }
    }
	
    #endregion

    #region Methods
    public ArgumentsList CreateArgumentList(string sortExpression, Int32 maximumRows, Int32 startRowIndex, String cultureValue)
    {
        ArgumentsList _arg = new ArgumentsList();
        _arg.Add(new ArgumentsListItem("Sort", sortExpression));
        _arg.Add(new ArgumentsListItem("PageSize", maximumRows.ToString()));
        _arg.Add(new ArgumentsListItem("PageNumber", startRowIndex.ToString()));
        _arg.Add(new ArgumentsListItem("CultureName", cultureValue));
        return _arg;
    }

    public DataTable GetTopics(ArgumentsList argList)
    {
        return m_dbObject.RetriveTopicsByArgList(argList.ToXml(), this.ConnectionString);
    }

    public Int32 GetTopicTotal(ArgumentsList argList)
    {
        DataTable _dt =  m_dbObject.RetriveTotalTopicsByArgList(argList.ToXml(), this.ConnectionString);
        if (_dt.Rows.Count > 0)
        {
            return Convert.ToInt32(_dt.Rows[0][0]);
        }
        return 0;
    }
    #endregion
}

namespace Data
{
    public class DBForumTopics : IDBObject
    {

        #region Members
        private static DBForumTopics m_instance;
        #endregion

        #region Constructor
        private DBForumTopics() { }
        #endregion

        #region Methods
        public static DBForumTopics GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBForumTopics();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_FORUMTOPICS_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_FORUMTOPICS_INSERT", inXmlData, inConnString) ;
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_FORUMTOPICS_GET", inXmlData, inConnString);
        }

        public DataTable RetriveTopicsByArgList(String inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_FORUMTOPIC_GETBYARGLIST", inXmlData, inConnString);
        }
        public DataTable RetriveTotalTopicsByArgList(String inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_FORUMTOPIC_GETBYARGLIST_COUNT", inXmlData, inConnString);
        }

        #endregion
    }

}

