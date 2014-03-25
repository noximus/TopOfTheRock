using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class contact_contactForm :BaseNoneSecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
	  btnSubmit.Click += new ImageClickEventHandler(btnSubmit_Click);
    }

    protected void btnSubmit_Click(object sender, EventArgs e) {
	  bool error = false;

	  StringBuilder sbStr = new StringBuilder();

	  DateTime dt, dt2;
	  try {
		dt = Convert.ToDateTime(txtMonth.Text + "/" + txtDay.Text + "/" + txtYear.Text);
	  } catch {
		dt = Convert.ToDateTime("4/20/1980");
	  }

	  try {
		dt2 = Convert.ToDateTime(txtMonth2.Text + "/" + txtDay2.Text + "/" + txtYear2.Text);
	  } catch {
		dt2 = Convert.ToDateTime("4/20/1980");
	  }

	  sbStr.AppendLine("insert into totr_requestfilmshoot ");
	  sbStr.AppendLine("(name, organization, phone, fax, email, website, purpose, " +
		"[620loft], weatherroom, [date], [date2], ");
	  sbStr.AppendLine("loadintime, loadouttime, film, photo, numpeople, talent, otherinfo) ");
	  sbStr.AppendLine(" values('" + dataAccess.dbStr(txtName.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtOrganization.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtPhone.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtFax.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtEmail.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtWebsite.Text) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(txtPurpose.Text) + "', ");

	  if (chk620loft.Checked) { sbStr.AppendLine("'Yes', "); } else { sbStr.AppendLine("'No', "); }
	  if (chkWeather.Checked) { sbStr.AppendLine("'Yes', "); } else { sbStr.AppendLine("'No', "); }

	  sbStr.AppendLine("'" + dt.ToString() + "', ");
	  sbStr.AppendLine("'" + dt2.ToString() + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(ddLoadInTime.SelectedValue) + "', ");
	  sbStr.AppendLine("'" + dataAccess.dbStr(ddLoadOutTime.SelectedValue) + "', ");

	  if (chkFilm.Checked) { sbStr.AppendLine("'Yes', "); } else { sbStr.AppendLine("'No', "); }
	  if (chkPhoto.Checked) { sbStr.AppendLine("'Yes', "); } else { sbStr.AppendLine("'No', "); }

	  sbStr.AppendLine("'" + dataAccess.dbStr(txtNumPeople.Text) + "', ");

	  sbStr.AppendLine("'" + rbTalent.SelectedValue + "', ");

	  sbStr.AppendLine("'" + dataAccess.dbStr(txtOtherInfo.Text) + "')");

	  try {
		//TO DO: Create table for this data

		dataAccess.execSQL(sbStr.ToString());

	  } catch (Exception ex) {
		Response.Write("Could not write to the database:  <BR><PRE>" + ex.ToString() + "<BR><BR>" + sbStr.ToString() + "</PRE>");
		error = true;
	  }

	  // now send the email
	  sbStr.Remove(0, sbStr.Length);
	  sbStr.AppendLine("SPECIAL EVEN REGISTRATION FORM");
	  sbStr.AppendLine("Name: " + txtName.Text);
	  sbStr.AppendLine("Organization: " + txtOrganization.Text);
	  sbStr.AppendLine("Phone: " + txtPhone.Text);
	  sbStr.AppendLine("Fax: " + txtFax.Text);
	  sbStr.AppendLine("Email: " + txtEmail.Text);
	  sbStr.AppendLine("Website: " + txtWebsite.Text);
	  sbStr.AppendLine("Purpose: " + txtPurpose.Text);

	  sbStr.Append("620 Loft: ");
	  if (chk620Loft.Checked) { sbStr.AppendLine("Yes"); } else { sbStr.AppendLine("No"); }

	  sbStr.Append("Weather Room: ");
	  if (chkWeather.Checked) { sbStr.AppendLine("Yes"); } else { sbStr.AppendLine("No"); }

	  sbStr.AppendLine("Start Date: " + dt.ToString() + "/" + txtYear.Text);
	  sbStr.AppendLine("End Date: " + dt2.ToString() + "/" + txtYear.Text);

	  sbStr.AppendLine("Load-in Time: " + ddLoadInTime.Text);
	  sbStr.AppendLine("Load-out Time: " + ddLoadOutTime.Text);

	  sbStr.Append("Film Shoot: ");
	  if (chkFilm.Checked) { sbStr.AppendLine("Yes"); } else { sbStr.AppendLine("No"); }
	  sbStr.Append("Photo Shoot: ");
	  if (chkPhoto.Checked) { sbStr.AppendLine("Yes"); } else { sbStr.AppendLine("No"); }

	  sbStr.AppendLine("Number of people: " + txtNumPeople.Text);


	  sbStr.Append("Talent: " + rbTalent.SelectedValue);

	  sbStr.AppendLine("Other info: " + txtOtherInfo.Text);

	  try {
		email.sendEmail("info@topoftherock.com", txtEmail.Text, "Your Special Event Information Request",
		    sbStr.ToString());

		email.sendEmail(txtEmail.Text, "info@topoftherock.com", "Special Event Information Request",
		    sbStr.ToString());
	  } catch (Exception ex) {
		Response.Write("There was a problem sending out email:<PRE>" + ex.ToString() + "</pre>");
		error = true;
	  }

	  if (!error) {
		Response.Redirect("thankyou.aspx");
	  }


    }

}
