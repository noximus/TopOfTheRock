<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" ValidateRequest="false" Theme="Admin" AutoEventWireup="true" CodeFile="EditStory.aspx.cs" Inherits="admin_EditStory" Title="Edit/Create Story" %>
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
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Category">Category:</label></td>
        <td><asp:DropDownList ID="dd_Category" runat="Server" />
            <asp:RequiredFieldValidator ControlToValidate="dd_Category" ID="val_Category" runat="server" 
            Display="Dynamic" ErrorMessage="Category is required." />
            <a href="StoryCategoryList.aspx">Add New Category</a>
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
        <td class="label" style="vertical-align:top;"><label class="required" for="txt_Story">Story:</label></td>
        <td><asp:TextBox ID="txt_Story" runat="server" TextMode="MultiLine" Rows="5"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Story" ID="val_Story" runat="server" 
            Display="Dynamic" ErrorMessage="Story is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="txt_Fname">YouTube Link:</label></td>
        <td style="vertical-align:top;"><asp:TextBox ID="txt_YouTube" runat="server" TextMode="MultiLine" Rows="5"/>
            <asp:RegularExpressionValidator ValidationExpression="^<object[\s\S]+</object>$" ControlToValidate="txt_YouTube"
            Display="Dynamic" runat="server" ID="val_YouTube" ErrorMessage="Enter valid youtube link" />
        </td>
    </tr>
    <tr><td class="label"><label class="required">OR</label></td><td></td></tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="txt_Link">Image:</label></td>
        <td><asp:FileUpload ID="fu_Image" runat="server" />
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

