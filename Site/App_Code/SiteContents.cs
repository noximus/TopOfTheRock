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
/// Summary description for SiteContents
/// </summary>
[Serializable]
public class SiteContents : BaseBusinessClass
{
    #region Constructors
    public SiteContents() { }
    public SiteContents(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteContents.GetInstance();
        base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBSiteContents m_dbObject;
    private String m_description;
    private String m_title;
    private Int32 m_sort;
    private Int32 m_pageId;
    private SiteContentImagesCollection<SiteContentImages> m_Images;

	
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
        set { m_dbObject = (Data.DBSiteContents)value; }
    }
    public String Description
    {
        get { return m_description; }
        set { m_description = value; }
    }
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }
    public Int32 Sort
    {
        get { return m_sort; }
        set { m_sort = value; }
    }
    public Int32 PageId
    {
        get { return m_pageId; }
        set { m_pageId = value; }
    }
    [CollectionProperty]
    public SiteContentImagesCollection<SiteContentImages> Images
    {
        get { return m_Images; }
        set { m_Images = value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBSiteContents : IDBObject
    {

        #region Members
        private static DBSiteContents m_instance;
        #endregion

        #region Constructor
        private DBSiteContents() { }
        #endregion

        #region Methods
        public static DBSiteContents GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteContents();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_SITECONTENTS_UPDATE", inXmlData, inConnString);
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

        public DataTable LiteRetrieve(DataTable inDataTable, string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITECONTENTS_GET", inXmlData, inConnString);
        }

        #endregion
    }

}

