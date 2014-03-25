<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditForum.aspx.cs" Inherits="admin_EditForum" Title="Edit/Create Forum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server" class="activeLast"><a href="Forums.aspx">Forums</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    <tr>
        <td class="label"><label class="required" for="txt_Title">Title:</label></td>
        <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="200"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
            Display="Dynamic" ErrorMessage="Title is required." />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_Fname">Description:</label></td>
        <td><asp:TextBox ID="txt_Desc" runat="server" MaxLength="500" TextMode="MultiLine" Rows="3"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Desc" ID="val_Desc" runat="server" 
            Display="Dynamic" ErrorMessage="Description is required." />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="ch_Active">Active:</label></td>
        <td>
            <asp:CheckBox ID="ch_Active" runat="server" />
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

