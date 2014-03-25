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
/// Summary description for TimeOfDay
/// </summary>
[Serializable]
public class TimeOfDay : BaseBusinessClass
{
    #region Constructors
    public TimeOfDay() { }
    public TimeOfDay(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBTimeOfDay.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBTimeOfDay m_dbObject;
    private String m_description;
    private String m_imgtype;
    private Int32 m_sort;
    private Int32 m_status;
    private Int32 m_defaultPage;
    private string m_pageUrl;
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
        set { m_dbObject = (Data.DBTimeOfDay)value; }
    }
    public String Description
    {
        get { return m_description; }
        set { m_description = value; }
    }
    public String ImgType
    {
        get { return m_imgtype; }
        set { m_imgtype = value; }
    }
    public Int32 Sort
    {
        get { return m_sort; }
        set { m_sort = value; }
    }
    public Int32 Status
    {
        get { return m_status; }
        set { m_status = value; }
    }
    public Int32 DefaultPageID
    {
        get { return m_defaultPage; }
        set { m_defaultPage = value; }
    }
    public string PageUrl
    {
        get { return m_pageUrl; }
        set { m_pageUrl = value; }
    }
    #endregion

    #region Methods
    public TimeOfDayCollection<TimeOfDay> GetTimeOfDays(Enums.enumStatuses status)
    {
        TimeOfDayCollection<TimeOfDay> _coll = new TimeOfDayCollection<TimeOfDay>(this.ConnectionString);
        ArgumentsList _arg = new ArgumentsList(new ArgumentsListItem("Status", Convert.ToInt32(status).ToString()));
        _coll.LitePopulate(_arg, false, null);
        return _coll;
    }
    #endregion
}

namespace Data
{
    public class DBTimeOfDay : IDBObject
    {

        #region Members
        private static DBTimeOfDay m_instance;
        #endregion

        #region Constructor
        private DBTimeOfDay() { }
        #endregion

        #region Methods
        public static DBTimeOfDay GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBTimeOfDay();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_TIMEOFDAY_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_TIMEOFDAY_INSERT", inXmlData, inConnString);
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_TIMEOFDAY_GET", inXmlData, inConnString);
        }

        #endregion
    }
}