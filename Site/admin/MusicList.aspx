<%@ Page Language="C#" Theme="Admin" MasterPageFile="~/master/SecureAdminMasterPage.master" AutoEventWireup="true" CodeFile="MusicList.aspx.cs" Inherits="admin_MusicList" Title="Musics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="History.aspx">History</a></li>
    <li id="liShare" runat="Server"><a href="EditShare.aspx">Share</a></li>
    <li id="liStories" runat="Server"><a href="StoriesList.aspx">Stories</a></li>
    <li id="liMusics" runat="Server" class="activeLast"><a href="MusicList.aspx">Musics</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Musics</h1>
Status: <asp:DropDownList ID="dd_Status" runat="server"/>
Category: <asp:DropDownList ID="dd_Category" runat="server" />&nbsp;
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="Search_OnClick"/>
<br /><br />

<div class="paneFull">
    <h3><span class="title">Musics</span><span class="nav"><asp:LinkButton OnClick="Publish_Click" ID="lb_Publish" runat="server" Text="Update"/>&nbsp;|&nbsp;<a href="EditMusic.aspx">Add</a></span></h3>
    <div class="paneContents">
        <asp:GridView ID="dgMusics"  runat="server" ShowHeader="true" AutoGenerateColumns="False" Width="100%" 
            BorderWidth="0px" GridLines="None" AllowPaging="true" AllowSorting="true"
            DataKeyNames="ID" PageSize="10" DataSourceID="gridViewDataSource" OnRowCommand="Music_OnRowCommand"
            OnRowDataBound="Music_OnRowDataBound">
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
                <asp:TemplateField HeaderText="Sort" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Sort" runat="server" Text='<%# Eval("Sort") %>' Width="30" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_Music" runat="server" Text="Download" CommandArgument='<%# Eval("ID") %>' CommandName="Download"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="dd_Status" runat="server" />
                        <asp:Label ID="lbl_MusId" runat="server" Visible="false" Text='<%# Eval("ID") %>' />
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
        <asp:ObjectDataSource ID="gridViewDataSource" runat="server" SelectMethod="GetMusics" 
            EnablePaging="true" TypeName="GridViewUtility" SortParameterName="SortExpression" SelectCountMethod="GetMusicsCount">
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

