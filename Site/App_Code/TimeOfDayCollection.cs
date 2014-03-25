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
/// Summary description for TimeOfDayCollection
/// </summary>
[Serializable]
public class TimeOfDayCollection<TimeOfDay> : BaseBusinessCollection
{
    #region Constructors
    public TimeOfDayCollection() { m_memberType = typeof(TimeOfDay); }
    public TimeOfDayCollection(String inConnString)
        : this()
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBTimeOfDayCollection.GetInstance();
    }
    #endregion

    #region Members
    private Data.DBTimeOfDayCollection m_dbObject;
    #endregion

    #region Properties
    public override IDBObjectCollection DBObject
    {
        get { return m_dbObject; }
        set { m_dbObject = (Data.DBTimeOfDayCollection)value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBTimeOfDayCollection : IDBObjectCollection
    {

        #region Members
        private static DBTimeOfDayCollection m_instance;
        #endregion

        #region Constructor
        private DBTimeOfDayCollection() { }
        #endregion

        #region Methods
        public static DBTimeOfDayCollection GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBTimeOfDayCollection();
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_TIMEOFDAY_GETBYARG", inXmlData, inConnString);
        }

        public DataTable LiteRetrieve(DataTable inDataTable, object inParentID, string inConnString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

}

