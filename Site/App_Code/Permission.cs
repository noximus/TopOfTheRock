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
/// Summary description for Permission
/// </summary>
[Serializable]
public class Permissions : BaseBusinessClass
{
    #region Constructors
    public Permissions() { }
    public Permissions(String inConnString)
    {
        this.ConnectionString = inConnString;
        this.DBObject = Data.DBPermissions.GetInstance();
        //base.InitializeCollection();
    }
    #endregion

    #region Members
    private Object m_id;
    private Data.DBPermissions m_dbObject;
    private String m_description;
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
        set { m_dbObject = (Data.DBPermissions)value; }
    }
    public String Description
    {
        get { return m_description; }
        set { m_description = value; }
    }
    #endregion
}

namespace Data
{
    [Serializable]
    public class DBPermissions : IDBObject
    {

        #region Members
        private static DBPermissions m_instance;
        #endregion

        #region Constructor
        private DBPermissions() { }
        #endregion

        #region Methods
        public static DBPermissions GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new DBPermissions();
            }
            return m_instance;
        }

        public int Update(string inXmlData, string inConnString)
        {
           return 1;
        }

        public int Insert(string inXmlData, string inConnString)
        {
            return 1;
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
