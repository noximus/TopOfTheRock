using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for dataAccess
/// </summary>
public static class dataAccess : Object
{
    private static SqlConnection dbConn =
        new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connectionString"]);


    private static void openConn()  {
        if (dbConn.State != ConnectionState.Open)
                dbConn.Open();
    }

    public static void postEvent(string ID, string eventDate,
        string eventTitle, string eventDesc, bool active) {
        openConn();

        if (ID == "-1")
            ID = addRecordGetID("insert into rnh_events (active) values(1)").ToString();

        execSQL("update rnh_events set eventDate='" + eventDate +
            "' where eventID=" + ID);

        execSQL("update rnh_events set eventTitle='" + dbStr(eventTitle) + 
            "' where eventID=" + ID);

        execSQL("update rnh_events set eventDesc='" + dbStr(eventDesc) +
            "' where eventID=" + ID);

        execSQL("update rnh_events set eventDate='" + dbStr(eventDate) +
            "' where eventID=" + ID);

        execSQL("update rnh_events set active='" + dbBool(active) +
            "' where eventID=" + ID);

    }

    public static string fetchDBValue(string sql)  {
            openConn();
            SqlCommand objCommand = new SqlCommand(sql, dbConn);
            SqlDataReader objDataReader;
            objDataReader = objCommand.ExecuteReader();
            string value;
            if (objDataReader.Read()) {
                value = objDataReader[0].ToString();
            }  else  {
                value = "";
            }
            objDataReader.Close();
            objDataReader = null;
            objCommand = null;
            return value;
        }

    public static void updateWhatsNew(string str)   {
        execSQL("insert into rnh_whatsnew (whatsNewText) " +
            "values('" + dbStr(str) + "')");
    }

    public static int addSubprogram(int progID) {
        return addRecordGetID("insert into rnh_subPrograms " + 
            "(programID, subProgramName) values (" + progID + ", 'new subprogram')");
    }

    public static void updateSubprogram(int subID, string subName, string subDesc, string subPicFile) {
        execSQL("update rnh_subprograms set subProgramName='" + dbStr(subName) + "' where subProgramID=" + subID);
        execSQL("update rnh_subprograms set subProgramText='" + dbStr(subDesc) + "' where subProgramID=" + subID);
        execSQL("update rnh_subprograms set subProgramImage='" + dbStr(subPicFile) + "' where subProgramID=" + subID);
    }

    public static void deleteSubprogram(int subID) {
        execSQL("delete from rnh_subprograms where subProgramID=" + subID);
    }

    private static int addRecordGetID(string sql)  {
        openConn();
        SqlDataAdapter da = new SqlDataAdapter();
        da.InsertCommand = new SqlCommand(sql, dbConn);
        da.InsertCommand.ExecuteNonQuery();

        da.SelectCommand = new SqlCommand("SELECT @@IDENTITY", da.InsertCommand.Connection);
        int newID = Convert.ToInt32(da.SelectCommand.ExecuteScalar());

        return newID;
    }

    public static DataSet getEvents(bool activeOnly) {
        openConn();
        string sql = "select * from rnh_events ";
        if (activeOnly)  sql += "where active=1 and eventDate > '" + DateTime.Now + "' ";
        sql += "order by eventDate asc";
        DataSet dsEvents = fetchDS(sql);
        return dsEvents;
    }

    public static DataSet getEvent(int eventID) {
        openConn();
        string sql = "select * from rnh_events where eventID=" + eventID;
        DataSet dsEvents = fetchDS(sql);
        return dsEvents;
    }

    public static DataSet getEvents(DateTime from, DateTime to) {
        openConn();
        string sql = "select * from rnh_events ";
        sql += "where active=1 and eventDate >= '" + from + "' ";
        sql += "and eventDate <= '" + to + "' ";
        sql += "order by eventDate asc";
        DataSet dsEvents = fetchDS(sql);
        return dsEvents;
    }

    public static DataSet getPrograms() {
        openConn();
        string sql = "select * from rnh_programs order by idx";
        DataSet dsEvents = fetchDS(sql);
        return dsEvents;
    }

    public static DataSet getSubPrograms(int programID) {
        openConn();
        string sql = "select * from rnh_subprograms where programID=" + programID;
        DataSet dsEvents = fetchDS(sql);
        return dsEvents;
    }

    public static void deleteEvent(string id) {
    openConn();
    execSQL("delete from rnh_events where eventID=" + id);
    }

    private static void execSQL(string sql)  {
        openConn();
        SqlCommand comm = new SqlCommand(sql, dbConn);
        comm.CommandType = CommandType.Text;
        comm.ExecuteNonQuery();
    }

    private static DataSet fetchDS(string sql) {
openConn();
        SqlDataAdapter adap = new SqlDataAdapter(sql, dbConn);
        DataSet dsRet = new DataSet();
        adap.Fill(dsRet);

        return dsRet;
    }

    private static string dbStr(string str) {
        return str.Replace("'", "''");
    }

    private static string dbBool(bool val) {
        if (val) return "1";
        return "0";
    }
}
