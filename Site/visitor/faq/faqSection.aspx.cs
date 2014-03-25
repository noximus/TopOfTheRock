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

public partial class faq_faqSection : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
	  string categoryID = Request["catid"].ToString();

	  DataSet dsQs;
	  dsQs = dataAccess.fetchDS("select * from totr_faqs where categoryID=" + categoryID);
	  dlQuestions.DataSource = dsQs;
	  dlQuestions.DataBind();

    }
    
}
