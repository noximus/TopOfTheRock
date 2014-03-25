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

public partial class common_controls_TopMenu : System.Web.UI.UserControl
{
    
    private Enums.enumTopMenu m_selectedMenu;

	public Enums.enumTopMenu SelectedMenu
	{
		get { return m_selectedMenu;}
		set { 
                m_selectedMenu = value;

               // ((LinkButton)this.FindControl(m_selectedMenu.ToString())).CssClass = "active";
        }
	}
	

    protected void Page_Load(object sender, EventArgs e)
    {
        CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
	
        tColor.Text = (Page.Request.QueryString["theme"] != null) ? "so.addVariable(\"oColor\",\"" + Page.Request.QueryString["theme"].ToString() + "\")" : "so.addVariable(\"oColor\",\"" + _profile.ThemeName + "\")";
    }


    protected void Welcome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/welcome.aspx");
    }

    protected void Share_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/share/Default.aspx");
    }
    protected void Totr_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/shopthetop/Default.aspx");
    }
    protected void Special_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/specialoffers/Default.aspx");
    }

    protected void Contact_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/contact/contact.aspx");
    }

    protected void History_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/history/Default.aspx");
    }
    protected void Forum_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/forum/Default.aspx");
    }
   protected void Events_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/events/Default.aspx");
    }

    protected void Career_Click(object sender, EventArgs e) {
	  Response.Redirect("~/careers/Default.aspx");
    }
    protected void Visitor_Click(object sender, EventArgs e) {
	  Response.Redirect("~/visitor/Default.aspx");
    }
    protected void TickSales_Click(object sender, EventArgs e) {
	  Response.Write("<script>window.open('https://secure.topoftherocknyc.com/ODTInternet/Web/BuyTicket/captureticket.aspx','TOTR_Ticket_Sales');</script>");
    }

}
