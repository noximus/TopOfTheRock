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
/// Summary description for Stories
/// </summary>
[Serializable]
public class Stories : BaseBusinessClass
{
    #region Constructors
    public Stories() { }
    public Stories(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBStories.GetInstance();
       
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBStories m_dbObject;
    private int m_status;
    private Int32 m_categoryid;
    private DateTime m_datecreated;
    private DateTime m_dateupdated;
    private String m_imgtype;
    private String m_story;
    private String m_title;
    private String m_youtubelink;
    private string m_catDesc;
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
        set { m_dbObject = (Data.DBStories)value; }
    }
    public Int32 Status
    {
        get { return m_status; }
        set { m_status = value; }
    }
    public Int32 CategoryId
    {
        get { return m_categoryid; }
        set { m_categoryid = value; }
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
    public String ImgType
    {
        get { return m_imgtype; }
        set { m_imgtype = value; }
    }
    public String Story
    {
        get { return m_story; }
        set { m_story = value; }
    }
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }
    public String YouTubeLink
    {
        get { return m_youtubelink; }
        set { m_youtubelink = value; }
    }
    public string CategoryDescription
    {
        get { return m_catDesc; }
        set { m_catDesc = value; }
    }

    #endregion

    #region Methods
    public StoriesCollection<Stories> GetStories(Int32 maximumRows, String categoryValue, String statusValue)
    {
        StoriesCollection<Stories> _st = new StoriesCollection<Stories>(this.ConnectionString);
        _st.PopulateFixedRecords(_st.CreateArgListForFixedRecords(maximumRows, categoryValue, statusValue));
        return _st;
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBStories : IDBObject
    {

        #region Members
        private static DBStories m_instance;
        #endregion

        #region Constructor
        private DBStories() { }
        #endregion

        #region Methods
        public static DBStories GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBStories();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_STORIES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_STORIES_INSERT", inXmlData, inConnString);
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_STORIES_GET", inXmlData, inConnString);
        }

        #endregion
    }

}