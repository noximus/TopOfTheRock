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
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;


public partial class forum_Default : BaseNoneSecurePage
{
    protected override void InitializeCulture()
    {
        String _cult = Request.Form["__EVENTARGUMENT"];

        if (!String.IsNullOrEmpty(_cult) && Regex.IsMatch(_cult, @"^\w{2}$"))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_cult);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_cult);
        }else{
	    CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
	    Thread.CurrentThread.CurrentUICulture = new CultureInfo(_profile.Culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_profile.Culture);
	}
	base.InitializeCulture();
    }

    protected void dg_Forum_PageIndexChanged(object sender, EventArgs e)  {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
	if(!IsPostBack){
		BindData();
	}
	dg_Forum.PageIndexChanged += new EventHandler(dg_Forum_PageIndexChanged);
	
    }

    protected void PostTopic_Click(Object sender, EventArgs e)
    {
        Response.Redirect("newtopic.aspx");
    }

    protected void ChangeCulture_Click(Object sender, EventArgs e)
    {
	
	BindData();
    }

    private void BindData(){
	CustomProfile _profile = (CustomProfile)HttpContext.Current.Profile;
        _profile.Culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        hid_Culture.Value = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

	  lit_FlashCulture.Text = String.Format("so.addVariable('selectFlag','{0}')", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);

	this.DataBind();

	  switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)  {
		case "en":
		    lit_FlashHeader.Text = "\"GLOBAL FORUM\"";
		    lit_HeaderTopic.Text = "Top of the Rock is always looking for its next rising stars of the tourism and hospitality fields. Our employees are our family and we’re committed to helping them advance their careers and improve their lives. Join the Top of the Rock team and become part of a 70-year legacy, sharing the excitement of the city and bringing visitor experiences to new heights.";
		    break;

		case "es":
		    lit_FlashHeader.Text = "\"FORO GLOBAL\"";
		    lit_HeaderTopic.Text = "Top of the Rock est&aacute; buscando constantemente nuevas estrellas en los campos del turismo y la hosteler&iacute;a. Nuestros empleados son nuestra familia y nos comprometemos a ayudarles a avanzar en sus carreras profesionales y mejorar sus vidas. Unase al equipo Top of the Rock y forme parte de un legado de 70 años, compartiendo la emoci&oacute;n de la ciudad y ofreciendo nuevos niveles de experiencia a los visitantes.";

		    break;

		case "de":
		    lit_FlashHeader.Text = "\"GLOBALES FORUM\"";
		    lit_HeaderTopic.Text = "Top of the Rock ist st&auml;ndig auf der Suche nach aufstrebenden Mitarbeitern im Tourismusbereich und im Gastst&auml;ttengewerbe. Wir nehmen die Verantwortung für unsere Mitarbeiter sehr ernst und unterst&uuml;tzen diese in allen Belangen ihrer Karriere und ihrer Weiterentwicklung. Kommen Sie ins Team von Top of the Rock und werden Sie Teil einer 70-j&auml;hrigen Geschichte. Vermitteln Sie die Einzigartigkeit der Stadt und eröffnen Sie den Besuchern neue Erlebnisdimensionen.";

		    break;

		case "ja":
		    lit_FlashHeader.Text = "\"GLOBAL FORUM\"";
		    lit_HeaderTopic.Text = "トップ・オブ・ザ・ロ ックでは、観光ホ スピタリティの分野で次に活躍でき る人材を常に求めています 。当社にとって社員は家 族のようなもので、社員 がキャリアをアップ し人生を豊かにできるよ う全力で支援していま す。街の魅力を見つけたり、 観光客に今までにないすばら しい経験を提供でき るよう、70年の歴史を 持つトップ・オブ・ザ・ロ ックのチームにぜひ参 加してみませんか。";
		    break;

		case "fr":
		    lit_FlashHeader.Text = "\"FORUM INTERNATIONAL\"";
		    lit_HeaderTopic.Text = "Le Top of the Rock recherche en permanence de nouveaux champions du tourisme et de l'hospitalit&eacute;. Nous consid&eacute;rons nos employ&eacute;s comme des membres de notre famille, et nous mettons tout en œuvre pour les aider &agrave; avancer dans leur carri&egrave;re et &agrave; vivre mieux. Rejoignez l'&eacute;quipe du Top of the Rock et participez &agrave; notre histoire, longue de 70 ans. Partagez votre passion pour notre ville et faites vivre aux visiteurs une exp&eacute;rience inoubliable.";
		    break;

		case "it":
		    lit_FlashHeader.Text = "\"GLOBAL FORUM\"";
		    lit_HeaderTopic.Text = "Top of the Rock &egrave; sempre alla ricerca di nuove stelle nel settore turistico e alberghiero. I nostri dipendenti sono la nostra famiglia e li sosteniamo nella loro carriera e nella loro vita. Entra nel team Top of the Rock e diventa parte di una storia lunga 70 anni, per condividere con i visitatori le eccezionali attrattive della citt&aagude; e far vivere loro esperienze a nuovi livelli.";
		    break;
	  }
    }

    protected void Topic_OnRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("View"))
        {
            Response.Redirect("viewtopic.aspx?topic=" + e.CommandArgument.ToString());
        }
    }
}
