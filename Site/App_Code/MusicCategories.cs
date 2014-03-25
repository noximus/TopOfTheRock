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
/// Summary description for MusicCategories
/// </summary>
[Serializable]
public class MusicCategories : BaseBusinessClass
{
    #region Constructors
    public MusicCategories() { }
    public MusicCategories(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBMusicCategories.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBMusicCategories m_dbObject;
    private String m_description;
    private Int32 m_sort;
    private Boolean m_default;
    private Int32 m_defaultPage;
    private string m_pageUrl;
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
        set { m_dbObject = (Data.DBMusicCategories)value; }
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
    public Boolean Default
    {
        get { return m_default; }
        set { m_default = value; }
    }
    public Int32 DefaultPageID
    {
        get { return m_defaultPage; }
        set { m_defaultPage = value; }
    }
    public string PageUrl
    {
        get { return m_pageUrl; }
        set { m_pageUrl = value; }
    }
    #endregion
}


namespace Data
{
    [Serializable]
    public class DBMusicCategories : IDBObject
    {

        #region Members
        private static DBMusicCategories m_instance;
        #endregion

        #region Constructor
        private DBMusicCategories() { }
        #endregion

        #region Methods
        public static DBMusicCategories GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBMusicCategories();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_MUSICCATEGORIES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_MUSICCATEGORIES_INSERT", inXmlData, inConnString);
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
