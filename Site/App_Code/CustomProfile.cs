using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
using System.IO;
using System;
using System.Configuration;

public class CustomProfile : ProfileBase
{
    
    [SettingsAllowAnonymous(true)]
    public string ThemeName
    {
        get
        {
            string theme = "";
            if (HttpContext.Current.Request.Cookies.Get("ThemeName") != null)
            {
                theme = HttpContext.Current.Request.Cookies.Get("ThemeName").Value;
            }
            //// Set up a default theme if necessary
            if (String.IsNullOrEmpty(theme))
            {
                theme = "Gray";
                HttpCookie _cook = new HttpCookie("ThemeName");
                _cook.Expires = DateTime.Now.AddYears(1);
                _cook.Value = theme;
                HttpContext.Current.Response.Cookies.Add(_cook);
                

            }
            return theme;
        }
        set
        {
            string newThemeName = value;
            string path = HttpContext.Current.Server.MapPath("~/App_Themes");
            if (Directory.Exists(path))
            {
                // Retrieve array of theme folder names
                String[] themeFolders = Directory.GetDirectories(path);

                // See if the specified theme name actually exists
                // as a theme folder
                bool found = false;
                foreach (String folder in themeFolders)
                {
                    DirectoryInfo info = new DirectoryInfo(folder);
                    if (String.Compare(info.Name ,newThemeName, true) == 0)
                        found = true;
                }
                // Only set the theme if this theme exists
                if (found)
                {
                    HttpCookie _cook = new HttpCookie("ThemeName");
                    _cook.Expires = DateTime.Now.AddYears(1);
                    _cook.Value = newThemeName;
                    HttpContext.Current.Response.Cookies.Add(_cook);
                }
            }
        }
    }

    [SettingsAllowAnonymous(true)]
    public string TimeOfDay
    {
        get
        {
            string timeOfDay = "";

            if (HttpContext.Current.Request.Cookies.Get("TimeOfDay") != null)
            {
                timeOfDay = HttpContext.Current.Request.Cookies.Get("TimeOfDay").Value;
            }
            
            if (String.IsNullOrEmpty(timeOfDay))
            {
                timeOfDay = ConfigurationManager.AppSettings["DefaultTimeOfDay"];
                HttpCookie _cook = new HttpCookie("TimeOfDay");
                _cook.Expires = DateTime.Now.AddYears(1);
                _cook.Value = timeOfDay;
                HttpContext.Current.Response.Cookies.Add(_cook);

            }
            return timeOfDay;
        }
        set
        {
            string newTimeOfDay = value;
            HttpCookie _cook = new HttpCookie("TimeOfDay");
            _cook.Expires = DateTime.Now.AddYears(1);
            _cook.Value = newTimeOfDay;
            HttpContext.Current.Response.Cookies.Add(_cook);
        }
    }

    [SettingsAllowAnonymous(true)]
    public string MusicCategory
    {
        get
        {
            string musicCategory = "";

            if (HttpContext.Current.Request.Cookies.Get("MusicCategory") != null)
            {
                musicCategory = HttpContext.Current.Request.Cookies.Get("MusicCategory").Value;
            }


            if (String.IsNullOrEmpty(musicCategory) || musicCategory.Equals("undefined"))
            {
                MusicCategoriesCollection<MusicCategories> _cat = PortalCacheFactory.GetMusicCategory();
                MusicCategories _c = (MusicCategories)_cat.FindByProperty("Default", true.ToString())[0];
                if (_c != null)
                {
                    musicCategory = _c.ID.ToString();
                    HttpCookie _cook = new HttpCookie("MusicCategory");
                    _cook.Expires = DateTime.Now.AddYears(1);
                    _cook.Value = musicCategory;
                    HttpContext.Current.Response.Cookies.Add(_cook);
                }

            }
            return musicCategory;
        }
        set
        {
            string newmusicCategory = value;
            HttpCookie _cook = new HttpCookie("MusicCategory");
            _cook.Expires = DateTime.Now.AddYears(1);
            _cook.Value = newmusicCategory;
            HttpContext.Current.Response.Cookies.Add(_cook);
        }
    }

    [SettingsAllowAnonymous(true)]
    public string Culture
    {
        get
        {
            string culture = "";
            if (HttpContext.Current.Request.Cookies.Get("Culture") != null)
            {
                culture = HttpContext.Current.Request.Cookies.Get("Culture").Value;
            }
            //// Set up a default theme if necessary
            if (String.IsNullOrEmpty(culture))
            {
                culture = "en";
                HttpCookie _cook = new HttpCookie("Culture");
                _cook.Expires = DateTime.Now.AddYears(1);
                _cook.Value = culture;
                HttpContext.Current.Response.Cookies.Add(_cook);
            }
            return culture;
        }

        set
        {
            string culture = value;
            HttpCookie _cook = new HttpCookie("Culture");
            _cook.Expires = DateTime.Now.AddYears(1);
            _cook.Value = culture;
            HttpContext.Current.Response.Cookies.Add(_cook);
        }
    }

}