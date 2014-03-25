using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class press_DefaultDB :BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

	  // Which page are we starting at?
	  int startItem = 16 * (Convert.ToInt32("0" + Request["page"]));
	  int i = 0;
	  SqlDataReader rdrPress = dataAccess.fetchRDR("select * from press order by PressDate desc");
	  while (i < startItem) { rdrPress.Read(); i++; }  // skip ahead to the first item for that page

	  StringBuilder sb = new StringBuilder();
	  sb.AppendLine("<script type=\"text/javascript\">");
	  sb.AppendLine("var so = new SWFObject(\"../common/swf/press.swf\", \"TOTR Nav\", \"878\", \"335\", \"8\", \"#262626\");");
	  sb.AppendLine("so.addParam(\"wmode\", \"transparent\");");
	  sb.AppendLine("so.addParam(\"salign\", \"tl\");");

	  int ID; 

	  while (i < startItem + 16 && rdrPress.Read())

	  {
		ID = Convert.ToInt32(rdrPress["ID"]);

		sb.AppendLine("so.addParam(\"PressTitle" + i + "\", \"" +
		    rdrPress["PressTitle"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addParam(\"ID" + i + "\", \"" +
		    rdrPress["ID"].ToString().Replace("\"", "\\\"") + "\");");
		sb.AppendLine("so.addParam(\"ContentType" + i + "\", \"" +
		    rdrPress["ContentType"].ToString().Replace("\"", "\\\"") + "\");");

		switch (Convert.ToInt32(rdrPress["ContentType"])) {
		    case 1:  // audio
			  sb.AppendLine("so.addParam(\"Audio" + i + "\", \"/library/press/audio/"
				+ ID + ".mp3\");");

			  break;

		    case 2:  // video

			  sb.AppendLine("so.addParam(\"Video" + i + "\", \"/library/press/video/"
				+ ID + "." + rdrPress["VideoType"] + "\");");
			  break;

		    case 3:  //text
			  // nothin'
			  break;

		}
		sb.AppendLine("so.addParam(\"Thumb" + i + "\", \"/library/press/thumb/"
		    + ID + "." + rdrPress["PressThumbImgType"] + "\");");
		sb.AppendLine("so.addParam(\"ContThumb" + i + "\", \"/library/press/contthumb/"
		    + ID + "." + rdrPress["ContentThumbImgType"] + "\");");

		sb.AppendLine("so.addParam(\"PressDate" + i + "\", \"" +
		    rdrPress["PressDate"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addParam(\"Description" + i + "\", \"" +
		    rdrPress["Deacription"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addParam(\"PressThumbImgType" + i + "\", \"" +
		    rdrPress["PressThumbImgType"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addParam(\"WebLink" + i + "\", \"" +
		    rdrPress["WebLink"].ToString().Replace("\"", "\\\"") + "\");");
		i++;
	  }
	  rdrPress.Close();

	  sb.AppendLine("so.write(\"DivFlag\");");
        sb.AppendLine("</script>");

	  litPressContent.Text = sb.ToString();
    }
}
