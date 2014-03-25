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
/// Summary description for StoryCategories
/// </summary>
[Serializable]
public class StoryCategories : BaseBusinessClass
{
    #region Constructors
    public StoryCategories() { }
    public StoryCategories(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBStoryCategories.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBStoryCategories m_dbObject;
    private String m_description;
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
        set { m_dbObject = (Data.DBStoryCategories)value; }
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
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBStoryCategories : IDBObject
    {

        #region Members
        private static DBStoryCategories m_instance;
        #endregion

        #region Constructor
        private DBStoryCategories() { }
        #endregion

        #region Methods
        public static DBStoryCategories GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBStoryCategories();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_STORYCATEGORIES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_STORYCATEGORIES_INSERT", inXmlData, inConnString);
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