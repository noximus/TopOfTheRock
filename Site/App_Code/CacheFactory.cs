using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

/// <summary>
/// Summary description for CacheFactory
/// </summary>
public class PortalCacheFactory
{
    public const string STORY_CATEGORY_KEY = "StoryCategoriesCollection";
    public const string MUSIC_CATEGORY_KEY = "MusicCategoriesCollection";
    public const string TIMEOFDAY_CATEGORY_KEY = "TimeOfDayCategoriesCollection";

    #region Property
    public static string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString; }
    }
    #endregion

    #region [Story Category]

    /// <summary>
    /// Return Story Category
    /// </summary>
    /// <returns></returns>
    public static StoryCategoriesCollection<StoryCategories> GetStoryCategory()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        StoryCategoriesCollection<StoryCategories> _coll = (StoryCategoriesCollection<StoryCategories>)_cf.GetData(STORY_CATEGORY_KEY);
        if (_coll == null)
        {
            RefreshStoryCategory();
            return (StoryCategoriesCollection<StoryCategories>)_cf.GetData(STORY_CATEGORY_KEY);
        }
        return _coll;
    }

    /// <summary>
    /// Refresh Story Category
    /// </summary>
    public static void RefreshStoryCategory()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        StoryCategoriesCollection<StoryCategories> _cat = new StoryCategoriesCollection<StoryCategories>(ConnectionString);
        _cat.LitePopulate(new CoreLibrary.ArgumentsList());

        _cf.Add(STORY_CATEGORY_KEY, _cat, CacheItemPriority.Normal, null,
            new SlidingTime(TimeSpan.FromHours(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultCacheingHours"]))));
    }
    #endregion

    #region [Music Category]
    /// <summary>
    /// Return Music Category
    /// </summary>
    /// <returns></returns>
    public static MusicCategoriesCollection<MusicCategories> GetMusicCategory()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        MusicCategoriesCollection<MusicCategories> _coll = (MusicCategoriesCollection<MusicCategories>)_cf.GetData(MUSIC_CATEGORY_KEY);
        if (_coll == null)
        {
            RefreshMusicCategory();
            return (MusicCategoriesCollection<MusicCategories>)_cf.GetData(MUSIC_CATEGORY_KEY);
        }
        return _coll;
    }

    /// <summary>
    /// Refresh Music Category
    /// </summary>
    public static void RefreshMusicCategory()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        MusicCategoriesCollection<MusicCategories> _cat = new MusicCategoriesCollection<MusicCategories>(ConnectionString);
        _cat.LitePopulate(new CoreLibrary.ArgumentsList());

        _cf.Add(MUSIC_CATEGORY_KEY, _cat, CacheItemPriority.Normal, null,
            new SlidingTime(TimeSpan.FromHours(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultCacheingHours"]))));
    }
    #endregion

    #region [Time Of Day]
    /// <summary>
    /// Return TimeOfDay Category
    /// </summary>
    /// <returns></returns>
    public static TimeOfDayCollection<TimeOfDay> GetTimeOfDayCategory()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        TimeOfDayCollection<TimeOfDay> _coll = (TimeOfDayCollection<TimeOfDay>)_cf.GetData(TIMEOFDAY_CATEGORY_KEY);
        if (_coll == null)
        {
            RefreshTimeOfDay();
            return (TimeOfDayCollection<TimeOfDay>)_cf.GetData(TIMEOFDAY_CATEGORY_KEY);
        }
        return _coll;
    }

    /// <summary>
    /// Refresh TimeOfDay
    /// </summary>
    public static void RefreshTimeOfDay()
    {
        CacheManager _cf = CacheFactory.GetCacheManager();
        TimeOfDay _time = new TimeOfDay(ConnectionString);
        TimeOfDayCollection<TimeOfDay> _coll = _time.GetTimeOfDays(Enums.enumStatuses.Active);

        _cf.Add(TIMEOFDAY_CATEGORY_KEY, _coll, CacheItemPriority.Normal, null,
            new SlidingTime(TimeSpan.FromHours(Convert.ToInt32(ConfigurationManager.AppSettings["DefaultCacheingHours"]))));
    }
    #endregion
}
