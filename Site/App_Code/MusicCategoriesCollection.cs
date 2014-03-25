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
/// Summary description for MusicCategoriesCollection
/// </summary>
[Serializable]
public class MusicCategoriesCollection<MusicCategories> : BaseBusinessCollection
{
    #region Constructors
    public MusicCategoriesCollection() { m_memberType = typeof(MusicCategories); }
    public MusicCategoriesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBMusicCategoriesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBMusicCategoriesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBMusicCategoriesCollection)value; }
    }
    #endregion
}


namespace Data
{
    [Serializable]
    public class DBMusicCategoriesCollection : IDBObjectCollection
    {

        #region Members
        private static DBMusicCategoriesCollection m_instance;
        #endregion

        #region Constructor
        private DBMusicCategoriesCollection() { }
        #endregion

        #region Methods
        public static DBMusicCategoriesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBMusicCategoriesCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_MUSICCATEGORIES_GETBYARG", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}