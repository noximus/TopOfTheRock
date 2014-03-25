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
/// Summary description for MusicsCollection
/// </summary>
[Serializable]
public class MusicsCollection<Musics> : BaseBusinessCollection
{
    #region Constructors
    public MusicsCollection() { m_memberType = typeof(Musics); }
    public MusicsCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBMusicsCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBMusicsCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBMusicsCollection)value; }
    }
    #endregion

    #region Methods
    public ArgumentsList CreateArgumentList(string sortExpression, Int32 maximumRows, Int32 startRowIndex,
                                            String categoryValue, String statusValue)
    {
        ArgumentsList _arg = new ArgumentsList();
        _arg.Add(new ArgumentsListItem("Sort", (String.IsNullOrEmpty(sortExpression)) ? "Sort" : sortExpression));
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
    #endregion

}


namespace Data
{
    [Serializable]
    public class DBMusicsCollection : IDBObjectCollection
    {

        #region Members
        private static DBMusicsCollection m_instance;
        #endregion

        #region Constructor
        private DBMusicsCollection() { }
        #endregion

        #region Methods
        public static DBMusicsCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBMusicsCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_MUSICS_GETBYARGLIST", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public DataTable RetrieveByArgCount(string inXmlData, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_MUSICS_GETBYARGLIST_COUNT", inXmlData, inConnString);
        }
        #endregion
    }

}
