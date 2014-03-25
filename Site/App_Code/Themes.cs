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
/// Summary description for Themes
/// </summary>
[Serializable]
public class SiteThemes : BaseBusinessClass
{
    #region Constructors
    public SiteThemes() { }
    public SiteThemes(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBSiteThemes.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBSiteThemes m_dbObject;
    private DateTime m_datecreated;
    private DateTime m_dateupdated;
    private String m_name;
    private Int32 m_sort;
    private Int32 m_status;
    private Boolean m_default;
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
        set { m_dbObject = (Data.DBSiteThemes)value; }
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
    public String Name
    {
        get { return m_name; }
        set { m_name = value; }
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
    public Boolean Default
    {
        get { return m_default; }
        set { m_default = value; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// UnZip Theme
    /// </summary>
    /// <param name="themesPath"></param>
    /// <param name="fileStream"></param>
    public void UnZip(string themesPath, Stream fileStream)
    {
        ZipInputStream s = new ZipInputStream(fileStream);
        ZipEntry theEntry = null;
        while ((theEntry = s.GetNextEntry()) != null)
        {

            string directoryName = Path.GetDirectoryName(themesPath + theEntry.Name);
            string fileName = Path.GetFileName(theEntry.Name);

            // create directory
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(directoryName);
            }

            if (fileName != String.Empty)
            {
                using (FileStream streamWriter = File.Create(themesPath + theEntry.Name))
                {

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        s.Close();
    }


    /// <summary>
    /// Get Themes by arglist
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public SiteThemesCollection<SiteThemes> GetThemes(Enums.enumStatuses status)
    {
        SiteThemesCollection<SiteThemes> _coll = new SiteThemesCollection<SiteThemes>(this.ConnectionString);
        ArgumentsList _arg = new ArgumentsList(new ArgumentsListItem("Status", Convert.ToInt32(status).ToString()));
        _coll.LitePopulate(_arg, false, null);
        return _coll;
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBSiteThemes : IDBObject
    {

        #region Members
        private static DBSiteThemes m_instance;
        #endregion

        #region Constructor
        private DBSiteThemes() { }
        #endregion

        #region Methods
        public static DBSiteThemes GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBSiteThemes();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteNonQuery("USP_SITETHEMES_UPDATE", inXmlData, inConnString);
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return SQLHelper.ExecuteInsertQuery("USP_SITETHEMES_INSERT", inXmlData, inConnString);
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
            return SQLHelper.RetrieveDataTable(inDataTable, "USP_SITETHEMES_GET", inXmlData, inConnString);
        }

        #endregion
    }
}

