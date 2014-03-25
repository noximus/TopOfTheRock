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
using System.IO;
using ICSharpCode.SharpZipLib.Zip;


/// <summary>
/// Summary description for ThemesCollection
/// </summary>
[Serializable]
public class SiteThemesCollection<SiteThemes> : BaseBusinessCollection
{
    #region Constructors
    public SiteThemesCollection() { m_memberType = typeof(SiteThemes); }
    public SiteThemesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteThemesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBSiteThemesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBSiteThemesCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBSiteThemesCollection : IDBObjectCollection
    {

        #region Members
        private static DBSiteThemesCollection m_instance;
        #endregion

        #region Constructor
        private DBSiteThemesCollection() { }
        #endregion

        #region Methods
        public static DBSiteThemesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteThemesCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITETHEMES_GETBYARGLIST", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}
