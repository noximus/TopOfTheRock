using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Enums
/// </summary>
public class Enums
{
    public enum enumStatuses
    {
        Active = 1,
        Inactive = 2,
        Pending = 3,
        All = 0
    }

    public enum enumTopMenu
    {
        Welcome, 
        Share,
        Contact,
        Totr_Shop,
        Special_Offers,
        Global_Forum
    }
}
