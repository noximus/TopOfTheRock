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
/// Summary description for SiteContentImage
/// </summary>
[Serializable]
public class SiteContentImagesCollection<SiteContentImages> : BaseBusinessCollection
{
    #region Constructors
    public SiteContentImagesCollection() { m_memberType = typeof(SiteContentImages); }
    public SiteContentImagesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteContentImagesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBSiteContentImagesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBSiteContentImagesCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBSiteContentImagesCollection : IDBObjectCollection
    {

        #region Members
        private static DBSiteContentImagesCollection m_instance;
        #endregion

        #region Constructor
        private DBSiteContentImagesCollection() { }
        #endregion

        #region Methods
        public static DBSiteContentImagesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteContentImagesCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITECONTENTIMAGES_GETBYPARENT", inParentID.ToString(), inConnString);
        }

        #endregion
    }

}