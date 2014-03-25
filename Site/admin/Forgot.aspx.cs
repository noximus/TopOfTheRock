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
using System.Net.Mail;
using System.Net;


public partial class admin_Forgot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            BasePrincipal _user = BasePrincipal.GetByEmail(txt_Email.Text, ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString);
            if (_user != null)
            {
                MailMessage _mail = new MailMessage();
                MailAddress _madd = new MailAddress(((TopRockUser)_user.Identity).Email);
                _mail.To.Add(_madd);
                _mail.Subject = ConfigurationManager.AppSettings["ForgotPasswSubject"];
                _mail.IsBodyHtml = false;
                _mail.Body = String.Format(ConfigurationManager.AppSettings["ForgotPasswBody"],
                    ((TopRockUser)_user.Identity).Email, ((TopRockUser)_user.Identity).Password);

                SmtpClient _smtp = new SmtpClient();
                _smtp.Send(_mail);
                lblMsg.Text = "Your passsword has been sent";
            }
            else
            {
                lblMsg.Text = "Email address is not valid";
            }
        }
    }

}
