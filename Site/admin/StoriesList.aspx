<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="StoriesList.aspx.cs" Inherits="admin_StoriesList" Title="Stories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="History.aspx">History</a></li>
    <li id="liShare" runat="Server"><a href="EditShare.aspx">Share</a></li>
    <li id="liStories" runat="Server" class="active"><a href="StoriesList.aspx">Stories</a></li>
    <li id="liMusics" runat="Server" class="last"><a href="MusicList.aspx">Musics</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<script type="text/javascript">
    function ViewFile(file){
        window.open("ViewStoryFile.aspx?storId=" + file, "", "resizable=yes,location=no,width=450, height=370, left=100, top=100");
        return false;
    }
</script>
<h1>Manage Stories</h1>
Status: <asp:DropDownList ID="dd_Status" runat="server"/>
Category: <asp:DropDownList ID="dd_Category" runat="server" />&nbsp;
<asp:Button ID="btnSearch" runat="server" OnClick="Search_OnClick" Text="Search"/>
<br /><br />
<div class="paneFull">
    <h3><span class="title">Stories</span><span class="nav"><asp:LinkButton ID="lb_Publish" runat="server" Text="Update" OnClick="Publish_Click"/>&nbsp;|&nbsp;<a href="EditStory.aspx">Add</a></span></h3>
    <div class="paneContents">
        <asp:GridView ID="dgStories"  runat="server" ShowHeader="true" AutoGenerateColumns="False" Width="100%" 
            BorderWidth="0px" GridLines="None" AllowPaging="true" AllowSorting="true"
            DataKeyNames="ID" PageSize="10" DataSourceID="gridViewDataSource" OnRowDataBound="Stories_OnRowDataBound" 
            OnRowCommand="Stories_OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Title" ItemStyle-Width="300">
                    <ItemTemplate>
                        <%# Eval("Title") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("DateCreated")).ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Photo" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_ViewPhoto" runat="server" Text="View"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Video" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_ViewVideo" runat="server" Text="View"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList ID="dd_Status" runat="server" />
                        <asp:Label ID="lbl_StorId" runat="server" Visible="false" Text='<%# Eval("ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_Update" runat="server" CommandArgument='<%# Eval("ID") %>' Text='Edit' CommandName="Update" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="row" />
        </asp:GridView>
        <asp:ObjectDataSource ID="gridViewDataSource" runat="server" SelectMethod="GetStories" 
            EnablePaging="true" TypeName="GridViewUtility" SortParameterName="SortExpression" SelectCountMethod="GetStoriesCount">
        <SelectParameters>
            <asp:Parameter Name="sortExpression" Type="string" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:ControlParameter ControlID="dd_Category" Name="categoryValue" Type="string" />
            <asp:ControlParameter ControlID="dd_Status" Name="statusValue" Type="string" />
        </SelectParameters>
      </asp:ObjectDataSource>  

        
    </div>
</div>

</TopOfRock:SecureHolder>
</asp:Content>

