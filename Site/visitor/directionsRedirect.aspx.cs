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

public partial class visitor_Default :BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Response.Redirect("http://maps.google.com/maps?f=d&hl=en&saddr=&daddr=30+rockefeller+plaza,+manhattan,+NY&sll=37.0625,-95.677068&sspn=32.748002,59.765625&ie=UTF8&ll=40.759529,-73.978951&spn=0.007639,0.014591&z=16&iwloc=addr&om=1");
    }
}
