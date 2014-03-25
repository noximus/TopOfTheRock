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
/// Summary description for StoryCategoriesCollection
/// </summary>
[Serializable]
public class StoryCategoriesCollection<StoryCategories> : BaseBusinessCollection
{
    #region Constructors
    public StoryCategoriesCollection() { m_memberType = typeof(StoryCategories); }
    public StoryCategoriesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBStoryCategoriesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBStoryCategoriesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBStoryCategoriesCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBStoryCategoriesCollection : IDBObjectCollection
    {

        #region Members
        private static DBStoryCategoriesCollection m_instance;
        #endregion

        #region Constructor
        private DBStoryCategoriesCollection() { }
        #endregion

        #region Methods
        public static DBStoryCategoriesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBStoryCategoriesCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_STORYCATEGORIES_GETBYARG", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}
