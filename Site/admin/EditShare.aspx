<%@ Page Language="C#"  MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditShare.aspx.cs" Inherits="admin_EditShare" Title="Edit Share Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="History.aspx">History</a></li>
    <li id="liShare" runat="Server" class="active"><a href="EditShare.aspx">Share</a></li>
    <li id="liStories" runat="Server"><a href="StoriesList.aspx">Stories</a></li>
    <li id="liMusics" runat="Server" class="last"><a href="MusicList.aspx">Musics</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Share Page</h1>
<asp:Label ID="lbl_Error" runat="server" CssClass="error" />
<asp:Repeater ID="rpt_Share" runat="server">
    <ItemTemplate>
        <fieldset>
            <legend><%# Eval("Title") %></legend>
            <table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
            <tr>
                <td class="label" style="width:150px;"><label class="required" for="txt_Title">Title:</label></td>
                <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="50" Text='<%# Eval("Title") %>'/>
                    <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
                    Display="Dynamic" ErrorMessage="Title is required." />
                </td>
            </tr>
            <tr>
                <td class="label" style="vertical-align:top;"><label class="required" for="txt_Desc">Description:</label></td>
                <td><asp:TextBox ID="txt_Desc" runat="server" Rows="5" TextMode="MultiLine" Text='<%# Eval("Description") %>'/>
                    <asp:RequiredFieldValidator ControlToValidate="txt_Desc" ID="val_Desc" runat="server" Display="Dynamic" ErrorMessage="Description is required." />
                </td>
            </tr>
            <tr>
                <td class="label" style="vertical-align:top;"><label class="required" for="txt_Desc">Sort:</label></td>
                <td><asp:TextBox ID="txt_Sort" runat="server" MaxLength="2" Text='<%# Eval("Sort") %>' Width="20"/>
                    <asp:RequiredFieldValidator ControlToValidate="txt_Sort" ID="val_Sort" runat="server" 
                    Display="Dynamic" ErrorMessage="Sort is required." />
                </td>
            </tr>
            </table>
            <asp:Label ID="lbl_ContentId" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
        </fieldset>
        <br />
    </ItemTemplate>
</asp:Repeater>
<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr>
        <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Save_Click"/></td>
    </tr>
</table>
</TopOfRock:SecureHolder>
</asp:Content>

