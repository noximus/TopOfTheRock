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
/// Summary description for StoriesCollection
/// </summary>
[Serializable]
public class StoriesCollection<Stories> : BaseBusinessCollection
{
    #region Constructors
    public StoriesCollection() { m_memberType = typeof(Stories); }
    public StoriesCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBStoriesCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBStoriesCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBStoriesCollection)value; }
    }
    #endregion

    #region Methods
    public ArgumentsList CreateArgumentList(string sortExpression, Int32 maximumRows, Int32 startRowIndex, 
                                            String categoryValue, String statusValue)
    {
        ArgumentsList _arg = new ArgumentsList();
        _arg.Add(new ArgumentsListItem("Sort", sortExpression));
        _arg.Add(new ArgumentsListItem("PageSize", maximumRows.ToString()));
        _arg.Add(new ArgumentsListItem("PageNumber", startRowIndex.ToString()));
        _arg.Add(new ArgumentsListItem("Category", categoryValue));
        _arg.Add(new ArgumentsListItem("Status", statusValue));
        return _arg;
    }


    public Int32 GetTotalByArgList(ArgumentsList argList)
    {
        return Convert.ToInt32(m_dbObject.RetrieveByArgCount(argList.ToXml(), this.ConnectionString).Rows[0][0]);
    }


    public ArgumentsList CreateArgListForFixedRecords(Int32 maximumRows, String categoryValue, String statusValue)
    {
        ArgumentsList _arg = new ArgumentsList();
        _arg.Add(new ArgumentsListItem("PageSize", maximumRows.ToString()));
        _arg.Add(new ArgumentsListItem("Category", categoryValue));
        _arg.Add(new ArgumentsListItem("Status", statusValue));
        return _arg;
    }

    public void PopulateFixedRecords(ArgumentsList argList)
    {
        BaseBusinessClass _newMember;
        _newMember = (BaseBusinessClass)this.MemberType.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { (object)ConnectionString });
        DataTable _dt = m_dbObject.RetrieveFixedRecords(_newMember.GetDataTableSchema(), argList.ToXml(), this.ConnectionString);
        this.LitePopulate(_dt, false, null);
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBStoriesCollection : IDBObjectCollection
    {

        #region Members
        private static DBStoriesCollection m_instance;
        #endregion

        #region Constructor
        private DBStoriesCollection() { }
        #endregion

        #region Methods
        public static DBStoriesCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBStoriesCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_STORIES_GETBYARGLIST", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public DataTable RetrieveByArgCount(string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_STORIES_GETBYARGLIST_COUNT", inXmlData, inConnString);
        }
        public DataTable RetrieveFixedRecords(DataTable inDataTable, string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_STORIES_GETBYARGLIST_FIXED", inXmlData, inConnString);
        }
        #endregion
    }

}