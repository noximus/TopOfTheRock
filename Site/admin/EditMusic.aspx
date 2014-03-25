<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditMusic.aspx.cs" Inherits="admin_EditMusic" Title="Edit Music" %>
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
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Category">Category:</label></td>
        <td><asp:DropDownList ID="dd_Category" runat="Server" />
            <asp:RequiredFieldValidator ControlToValidate="dd_Category" ID="val_Category" runat="server" 
            Display="Dynamic" ErrorMessage="Category is required." />
            <a href="MusicCategoryList.aspx">Add New Category</a>
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_Fname">Title:</label></td>
        <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="200"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
            Display="Dynamic" ErrorMessage="Title is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_File">MP3 File:</label></td>
        <td><asp:FileUpload ID="fu_File" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_File" ID="val_File" runat="server" 
            Display="Dynamic" ErrorMessage="Music File is required." />
            <asp:RegularExpressionValidator ControlToValidate="fu_File" ID="reg_File" runat="server"
            Display="Dynamic" ErrorMessage="Enter valid mp3 file." ValidationExpression="[\s\S]+.mp3$" />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="ch_Active">Status:</label></td>
        <td>
            <asp:DropDownList ID="dd_Status" runat="server"/>
        </td>
    </tr>
    <tr>
        <td style="height: 30px"></td>
        <td>
            <asp:Button ID="btnSaveUser" runat="server" Text="Save" OnClick="Save_Click"/>&nbsp;
        </td>
    </tr>
 </table>
</TopOfRock:SecureHolder>
</asp:Content>

