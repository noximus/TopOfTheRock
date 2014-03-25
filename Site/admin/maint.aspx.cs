using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_maint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)  {

	  if (!Page.IsPostBack) {

	  }
    }
    protected void btnGo_Click(object sender, EventArgs e) {
	  DataSet ds = dataAccess.fetchDS(txtStr.Text);
	  grdOut.DataSource = ds;
	  grdOut.DataBind();

    }
}

