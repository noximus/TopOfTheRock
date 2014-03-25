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
/// Summary description for SiteContentCollection
/// </summary>
[Serializable]
public class SiteContentsCollection<SiteContents> : BaseBusinessCollection
{
    #region Constructors
    public SiteContentsCollection() { m_memberType = typeof(SiteContents); }
    public SiteContentsCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteContentsCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBSiteContentsCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBSiteContentsCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBSiteContentsCollection : IDBObjectCollection
    {

        #region Members
        private static DBSiteContentsCollection m_instance;
        #endregion

        #region Constructor
        private DBSiteContentsCollection() { }
        #endregion

        #region Methods
        public static DBSiteContentsCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteContentsCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITECONTENTS_GETBYPARENT", inParentID.ToString(), inConnString);
        }

        #endregion
    }

}
