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

public partial class admin_StoryCategoryList : SecurePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl _nc = (HtmlGenericControl)Master.FindControl("navHistory");
            _nc.Attributes.Add("class", "active");
            BindData();
        }
    }

    protected void BindData()
    {
        StoryCategoriesCollection<StoryCategories> _cat = new StoryCategoriesCollection<StoryCategories>(this.ConnectionString);
        _cat.LitePopulate(new CoreLibrary.ArgumentsList());

        dg_category.DataSource = _cat;
        dg_category.DataBind();

        PortalCacheFactory.RefreshStoryCategory();
    }

    protected void Category_OnEditCommand(Object sender, DataGridCommandEventArgs e)
    {
        dg_category.EditItemIndex = e.Item.ItemIndex;
        val_Desc.Enabled = false;
        BindData();
    }

    protected void Category_OnCancelCommand(Object sender, DataGridCommandEventArgs e)
    {
        dg_category.EditItemIndex = -1;
        val_Desc.Enabled = true;
        BindData();
    }

    protected void Category_OnUpdateCommand(Object sender, DataGridCommandEventArgs e)
    {
        StoryCategories _cat = new StoryCategories(this.ConnectionString);
        String _id = dg_category.DataKeys[e.Item.ItemIndex].ToString();
        _cat.ID = _id;
        _cat.Description = ((TextBox)e.Item.FindControl("txt_Desc")).Text;
        _cat.Sort = Convert.ToInt32(((TextBox)e.Item.FindControl("txt_Sort")).Text);
        if (!_cat.Save())
        {
            lbl_Error.Text = "An unexpected error has occurred. Please try again.";
        }
        else
        {
            lbl_Error.Text = "";
            dg_category.EditItemIndex = -1;
            val_Desc.Enabled = true;
            BindData();
        }
    }

    protected void Save_Click(Object sender, EventArgs e)
    {
        StoryCategories _cat = new StoryCategories(this.ConnectionString);
        _cat.Description = txt_Description.Text;
        if (!_cat.Save())
        {
            lbl_Error.Text = "An unexpected error has occurred. Please try again.";
        }
        else
        {
            lbl_Error.Text = "";
            txt_Description.Text = "";
            BindData();
        }
    }
}
