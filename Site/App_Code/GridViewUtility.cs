using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for GridViewUtility
/// </summary>
public class GridViewUtility
{
    #region Constructor
    public GridViewUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region Properties

    public string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["TopRockConnection"].ConnectionString; }
    }

    #endregion


    #region [Admin] Stories
    public StoriesCollection<Stories> GetStories(string sortExpression, Int32 maximumRows,
        Int32 startRowIndex, string categoryValue, string statusValue)
    {
        StoriesCollection<Stories> _stories = new StoriesCollection<Stories>(this.ConnectionString);
        _stories.LitePopulate(_stories.CreateArgumentList(sortExpression,maximumRows,startRowIndex, categoryValue, statusValue), false, null);
        return _stories;
    }
    public Int32 GetStoriesCount(string sortExpression, Int32 maximumRows,
        Int32 startRowIndex, string categoryValue, string statusValue)
    {
        StoriesCollection<Stories> _stories = new StoriesCollection<Stories>(this.ConnectionString);
        return _stories.GetTotalByArgList(_stories.CreateArgumentList(sortExpression, maximumRows, startRowIndex, categoryValue, statusValue));
    }
    #endregion

    #region [Admin] Musics
    public MusicsCollection<Musics> GetMusics(string sortExpression, Int32 maximumRows,
        Int32 startRowIndex, string categoryValue, string statusValue)
    {
        MusicsCollection<Musics> _mus = new MusicsCollection<Musics>(this.ConnectionString);
        _mus.LitePopulate(_mus.CreateArgumentList(sortExpression, maximumRows, startRowIndex, categoryValue, statusValue), false, null);
        return _mus;
    }

    public Int32 GetMusicsCount(string sortExpression, Int32 maximumRows,
        Int32 startRowIndex, string categoryValue, string statusValue)
    {
        MusicsCollection<Musics> _mus = new MusicsCollection<Musics>(this.ConnectionString);
        return _mus.GetTotalByArgList(_mus.CreateArgumentList(sortExpression, maximumRows, startRowIndex, categoryValue, statusValue));
    }
    #endregion

    #region [Forum]
    public DataTable GetTopics(string sortExpression, Int32 maximumRows, Int32 startRowIndex, String cultureValue)
    {
        ForumTopics _ft = new ForumTopics(this.ConnectionString);
        return _ft.GetTopics(_ft.CreateArgumentList(sortExpression, maximumRows, startRowIndex, cultureValue));
    }

    public Int32 GetTopicsCount(string sortExpression, Int32 maximumRows, Int32 startRowIndex, String cultureValue)
    {
        ForumTopics _ft = new ForumTopics(this.ConnectionString);
        return _ft.GetTopicTotal(_ft.CreateArgumentList(sortExpression, maximumRows, startRowIndex, cultureValue));
    }
    #endregion

}
