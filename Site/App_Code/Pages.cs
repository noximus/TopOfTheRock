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
/// Summary description for Pages
/// </summary>
[Serializable]
public class Pages : BaseBusinessClass
{
    #region Constructors
    public Pages() { }
    public Pages(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBPages.GetInstance();
        base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBPages m_dbObject;
    private String m_title;
    private string m_url;
    private SiteContentsCollection<SiteContents> m_contents;
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
        set { m_dbObject = (Data.DBPages)value; }
    }
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }

    [CollectionProperty]
    public SiteContentsCollection<SiteContents> PageContents
    {
        get { return m_contents; }
        set { m_contents = value; }
    }
    public string Url
    {
        get { return m_url; }
        set { m_url = value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBPages : IDBObject
    {

        #region Members
        private static DBPages m_instance;
        #endregion

        #region Constructor
        private DBPages() { }
        #endregion

        #region Methods
        public static DBPages GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBPages();
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

        public DataTable LiteRetrieve(DataTable inDataTable, string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_PAGES_GET", inXmlData, inConnString);
        }

        #endregion
    }

}