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

	  int langID = Convert.ToInt32("0" + Request["langID"]);



	  string[] langTitles = new string[6] {

		"VISITOR INFORMATION",

		"INFORMATIONS VISITEURS",

		"INFORMATIONEN FÜR BESUCHER",

		"ビジター･インフォメーション",

		"INFORMATIONS VISITEURS",

		"INFORMAZIONI PER I VISITATORI"

	  };

	  

	  string[] langTexts = new string[6] {

		"<p style='padding:0px 0px 0px 62px;'>Why just see the city when you can experience it? Here s all the information you need to make your trip to the Top into a journey of a lifetime.<p style='padding:00px 0px 0px 62px;'>Pinpoint our location; discover the best dining and shopping in the area, and exchange tips and recommendations in our <a href=../forum>Global Forum</a>.",

		"Hey I'm in spanish!",

		"<p style='padding:0px 0px 0px 62px;'>Warum sich die Stadt bloß ansehen, wenn man sie auch erleben kann? Hier finden Sie alle nötigen Informationen, um aus Ihrem Besuch im Top of the Rock ein einzigartiges Erlebnis zu machen.<p style='padding:0px 0px 0px 62px;'>Lokalisieren Sie unseren genauen Standort, entdecken Sie unser erstklassiges Restaurant- und Einkaufsangebot und tauschen Sie Tipps und Empfehlungen in unserem Globalen Forum aus.",

		"<p style='padding:0px 0px 0px 62px;'>街をただ見るだけでなく素晴らしい体験を楽しみましょう。ここには、あなたの旅を生涯最高の思い出にするために必要な情報がすべてつまっています。<br/><br />地域を指定して、そのエリアで最高のレストランやお店を見つけてください。また、グローバル･フォーラムでは旅のヒントやお勧め情報を見たり書き込むことができます。",

		"<p style='padding:0px 0px 0px 62px;'>Pourquoi vous contenter de voir la ville quand vous pouvez la vivre? Vous trouverez ici toutes les informations nécessaires pour préparer le voyage de votre vie au Top of the Rock!<p style='padding:0px 0px 0px 62px;'>Venez voir où nous sommes situés ! Découvrez les meilleurs restaurants et magasins de la ville ! Échangez vos meilleurs plans et conseils sur notre forum international!",

		"<p style='padding:0px 0px 0px 62px;'>Perché limitarti a visitare la città se puoi viverla fino in fondo? Trova qui tutte le informazioni necessarie per rendere la tua visita un vero e proprio viaggio da sogno.<p style='padding:0px 0px 0px 62px;'>Scopri dove siamo e come raggiungerci, trova i migliori ristoranti e i negozi più in voga della zona e scambia consigli e opinioni nel nostro Global Forum."

       };



	  string[,] langButts = new string[6,7]  {

		{

		    "DIRECTION BY CAR",

		    "DIRECTIONS BY MASS TRANSIT",

		    "DINING",

		    "SHOPPING",

		    "GLOBAL FORUMS",

		    "FAQ",

		    "CONTACT"

		},

		{

		    "VENIR EN VOITURE",

		    "VENIR PAR UN AUTRE MOYEN",

		    "RESTAURANTS",

		    "MAGASINS",

		    "FORUM INTERNATIONAL",

		    "FAQ",

		    "NOUS CONTACTER"

		},

		{

		    "ANFAHRT MIT DEM AUTO",

		    "ANFAHRT MIT BUS / U-BAHN",

		    "RESTAURANTS",

		    "SHOPPING",

		    "GLOBALES FORUM",

		    "HÄUFIG GESTELLTE FRAGEN",

		    "KONTAKT"

		},

		{

		    "ÂÛÝÀÛpßÀÛwßÀÛžßÀÛ«ßÀÛ·ßÀÛµß",

		    ">ÁÛ¬ßÁÛžÞÁÛ;ÞÁÛÞÀÛpßÀÛwßÀÛžßÀÛ«ßÀÛ·ßÀÛµß",

		    "ÀÛèßÀÛµßÀÛÄßÀÛåßÀÛïß",

		    "ÀÛ³ßÀÛãßÀÛ¿ßÀÛÐßÀÛïßÀÛ¬ß",

		    "ÀÛ¬ßÀÛéßÀÛ”ÞÀÛÌßÀÛçßÀÛKÝÀÛÑßÀÛ¥ßÀÛ”ÞÀÛåßÀÛÜß",

		    "ÀÛ‘ßÀÛXßÀÛKßÀÛ”ßÂÛíÜÃÛðÞ<",

		    "ÀÛSßÃÛðÞÀÛMßÁÛùßÀÛ˜ßÀÛdß"

		},

		{

		    "VENIR EN VOITURE",

		    "VENIR PAR UN AUTRE MOYEN",

		    "RESTAURANTS",

		    "MAGASINS",

		    "FORUM INTERNATIONAL",

		    "FAQ",

		    "NOUS CONTACTER"

		},

		{

		    "COME ARRIVARE IN AUTO",

		    "TRASPORTO PUBBLICO",

		    "RISTORANTI",

		    "SHOPPING",

		    "GLOBAL FORUM",

		    "DOMANDE FREQUENTI",

		    "CONTATTI"

		}

        };



	  litTrans.Text = langTexts[langID];



	  litJSTranslations.Text = "<script>langTitle = '" + langTitles[langID] +

		"';langDrivingDirections = '" + langButts[langID, 0] +

		"';langTransit = '" + langButts[langID, 1] +

		"';langDining = '" + langButts[langID, 2] +

		"';langShopping = '" + langButts[langID, 3] +

		"';langForums = '" + langButts[langID, 4] +

		"';langFAQ = '" + langButts[langID, 5] +

		"';langContact = '" + langButts[langID, 6] +

		"';langID=" + langID + ";</script>";





    }

}

