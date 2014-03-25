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

public partial class welcome_nightlife : BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e) {
	  string flashSWF = "/common/swf/intro.swf";

	  int i;
	  if (!int.TryParse(Profile.TimeOfDay, out i)) i = 2;

	  switch (i) {
		case 1:
		    flashSWF = "/common/swf/morning.swf";
		    break;
		case 2:
		    flashSWF = "/common/swf/day.swf";
		    break;
		case 3:
		    flashSWF = "/common/swf/dusk.swf";
		    break;
		case 4:
		    flashSWF = "/common/swf/latenight.swf";
		    break;
		default:
		    flashSWF = "/common/swf/day.swf";
		    break;

	  }

	  litJSSetFlash.Text = flashSWF;

    }
}
