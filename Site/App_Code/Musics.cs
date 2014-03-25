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
/// Summary description for Musics
/// </summary>
[Serializable]
public class Musics : BaseBusinessClass
{
    #region Constructors
    public Musics() { }
    public Musics(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBMusics.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBMusics m_dbObject;
    private Int32 m_categoryid;
    private DateTime m_datecreated;
    private DateTime m_dateupdated;
    private String m_filetype;
    private Int32 m_sort;
    private Int32 m_status;
    private String m_title;
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
        set { m_dbObject = (Data.DBMusics)value; }
    }
    public Int32 CategoryId
    {
        get { return m_categoryid; }
        set { m_categoryid = value; }
    }
    public DateTime DateCreated
    {
        get { return m_datecreated; }
        set { m_datecreated = value; }
    }
    public DateTime DateUpdated
    {
        get { return m_dateupdated; }
        set { m_dateupdated = value; }
    }
    public String FileType
    {
        get { return m_filetype; }
        set { m_filetype = value; }
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
    public String Title
    {
        get { return m_title; }
        set { m_title = value; }
    }
    #endregion

    #region Methods
    public String GetMusicsByCategory(Int32 category, String path )
    {
        DataTable _ds = m_dbObject.ReturnMusicByCategory(category.ToString(), this.ConnectionString);
        String _imgPath;
        String _xml = "<data>";
        foreach (DataRow I in _ds.Rows)
        {
            _imgPath = String.Format(path, I["ID"].ToString(), I["FileType"].ToString());
            _xml += "<musics>";
            _xml += String.Format("<title><![CDATA[{0}]]></title>", I["Title"].ToString());
            _xml += String.Format("<path><![CDATA[{0}]]></path>", _imgPath);
            _xml += String.Format("<category><![CDATA[{0}]]></category>", I["CatDesc"].ToString());

            _xml += "</musics>";
        }
        _xml += "</data>";
        return _xml;
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBMusics : IDBObject
    {

        #region Members
        private static DBMusics m_instance;
        #endregion

        #region Constructor
        private DBMusics() { }
        #endregion

        #region Methods
        public static DBMusics GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBMusics();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_MUSICS_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_MUSICS_INSERT", inXmlData, inConnString);
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
           return SQLHelper.RetrieveDataTable(inDataTable, "USP_MUSICS_GET", inXmlData, inConnString);
        }

        public DataTable ReturnMusicByCategory(string categoryId, string inConnString)
        {
            return SQLHelper.RetrieveDataTable("USP_MUSICS_GETBYCATEGID", categoryId, inConnString);
        }

        #endregion
    }

}

