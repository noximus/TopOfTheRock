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

public partial class press_Publicity :BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e) {

	  // Which page are we starting at?
	  int startItem = 12 * (Convert.ToInt32("0" + Request["page"]));
	  int i = 0; int tilesPassed = 0;
	  SqlDataReader rdrPress = dataAccess.fetchRDR("select * from publicity where status = 1 order by [date] desc");
	  while ((i < startItem) && (rdrPress.Read())) { i++; }  // skip ahead to the first item for that page

	  StringBuilder sb = new StringBuilder();
	  sb.AppendLine("<script type=\"text/javascript\">");
	  sb.AppendLine("var so = new SWFObject(\"../common/swf/publicity.swf\", \"TOTR Nav\", \"878\", \"241\", \"8\", \"#262626\");");
	  sb.AppendLine("so.addParam(\"wmode\", \"transparent\");");
	  sb.AppendLine("so.addParam(\"salign\", \"tl\");");

	  int ID;

	  while (i < startItem + 12 && rdrPress.Read()) {
		ID = Convert.ToInt32(rdrPress["ID"]);

		sb.AppendLine("so.addVariable(\"Title" + i + "\", \"" +
		    rdrPress["Title"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addVariable(\"ID" + i + "\", \"" +
		    rdrPress["ID"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addVariable(\"Date" + i + "\", \"" +
		    rdrPress["Date"].ToString().Replace("\"", "\\\"") + "\");");

		sb.AppendLine("so.addVariable(\"Document" + i + "\", \"http://totr2.maxliberman.com/library/publicity/"
		    + ID + "." + rdrPress["FileType"] + "\");");

		sb.AppendLine("so.addVariable(\"ContentType" + i + "\", \"" +
		    rdrPress["FileType"].ToString().Replace("\"", "\\\"") + "\");");

		i++; tilesPassed++;
	  }
	  rdrPress.Close();

	  sb.AppendLine("so.addVariable(\"tilespassed\", \"" + tilesPassed + "\");");

	  sb.AppendLine("so.write(\"DivFlag\");");
	  sb.AppendLine("</script>");

	  litPressContent.Text = sb.ToString();
    }
}
