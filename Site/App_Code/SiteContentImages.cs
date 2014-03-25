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
/// Summary description for SiteContentImages
/// </summary>
[Serializable]
public class SiteContentImages : BaseBusinessClass
{
    #region Constructors
    public SiteContentImages() { }
    public SiteContentImages(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteContentImages.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBSiteContentImages m_dbObject;
    private Int32 m_contentid;
    private String m_imgtype;
    private Int32 m_sort;
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
        set { m_dbObject = (Data.DBSiteContentImages)value; }
    }
    public Int32 ContentId
    {
        get { return m_contentid; }
        set { m_contentid = value; }
    }
    public String ImgType
    {
        get { return m_imgtype; }
        set { m_imgtype = value; }
    }
    public Int32 Sort
    {
        get { return m_sort; }
        set { m_sort = value; }
    }
    #endregion
}


namespace Data
{
    [Serializable]
    public class DBSiteContentImages : IDBObject
    {

        #region Members
        private static DBSiteContentImages m_instance;
        #endregion

        #region Constructor
        private DBSiteContentImages() { }
        #endregion

        #region Methods
        public static DBSiteContentImages GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteContentImages();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_SITECONTENTIMAGES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_SITECONTENTIMAGES_INSERT", inXmlData, inConnString);
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITECONTENTIMAGES_GET", inXmlData, inConnString);
        }

        #endregion
    }

}
