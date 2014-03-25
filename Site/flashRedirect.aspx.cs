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

public partial class flashRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch(Request.QueryString["p"].ToString()) {
            case "ticket_sales":
                Response.Redirect("http://www.google.com");
                break;
            case "refunds":
                Response.Redirect("http://www.google.com");
                break;
            case "careers":
                Response.Redirect("http://www.google.com");
                break;
            case "event_venues":
                Response.Redirect("http://www.google.com");
                break;
            case "share":
                Response.Redirect("~/share/Default.aspx");
                break;
            case "history":
                Response.Redirect("~/history/Default.aspx");
                break;
            case "skip":
                Response.Redirect("welcome/default.aspx");
                break;
            case "welcome":
                Response.Redirect("~/welcome.aspx");
                break;
            case "special_offers":
                Response.Redirect("~/specialoffers/Default.aspx");
                break;
            case "contact":
                Response.Redirect("~/contact/contact.aspx");
                break;
            case "shop_the_top":
                Response.Redirect("~/shopthetop/Default.aspx");
                break;
            case "tell_your_story":
                Response.Redirect("~/share/tellyourstory.aspx");
                break;
            case "story_from_top":
                Response.Redirect("~/share/storyfromtop.aspx");
                break;
            case "read_stories":
                Response.Redirect("~/share/storieslist.aspx?source="+Request.QueryString["source"].ToString());
                break;
            case "specialoffers_combo":
                Response.Redirect("~/specialoffers/specialoffers_combo.aspx");
                break;
            case "specialoffers_giftcard":
                Response.Redirect("~/specialoffers/specialoffers_giftcard.aspx");
                break;
            case "specialoffers_gps":
                Response.Redirect("~/specialoffers/specialoffers_gps.aspx");
                break;
            case "specialoffers_rockpath":
                Response.Redirect("~/specialoffers/specialoffers_rockpass.aspx");
                break;
            case "specialoffers_bodies":
                Response.Redirect("~/specialoffers/specialoffers_bodies.aspx");
                break;
            case "specialoffers_moma":
                Response.Redirect("~/specialoffers/specialoffers_moma.aspx");
                break;
            case "specialoffers_art":
                Response.Redirect("~/specialoffers/specialoffers_art.aspx");
                break;
            case "groups_corporate":
                Response.Redirect("~/groups/corporate.aspx");
                break;
            case "groups_travel_pro":
                Response.Redirect("~/groups/travelprofessionals.aspx");
                break;
            case "groups_organizaionts_clubs":
                Response.Redirect("~/groups/clubs.aspx");
                break;
            case "groups_schools_camps":
                Response.Redirect("~/groups/schoolscamps.aspx");
                break;
            case "groups_students":
                Response.Redirect("~/groups/students.aspx");
                break;
            case "groups_educators":
                Response.Redirect("~/groups/teachers.aspx");
                break;
            case "groups_travel_pro_learn":
                Response.Redirect("~/groups/travelprofessionalslearn.aspx");
                break;
        }
        
    }
}
