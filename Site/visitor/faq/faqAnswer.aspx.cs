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

public partial class faq_faqAnswer : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

	  string faqID = Request["faqID"].ToString();

	  litQuestion.Text = dataAccess.fetchDBValue("select question from totr_faqs where faqID=" + faqID).Replace("Q: ", "");
	  litAnswer.Text = dataAccess.fetchDBValue("select answer from totr_faqs where faqID=" + faqID).Replace("<PAR>", "<P>").Replace("</PAR>", "</P>").Replace("A: ", "");
    }
    
}
