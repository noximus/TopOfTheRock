<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditTimeOfDay.aspx.cs" Inherits="admin_EditTimeOfDay" Title="Edit/Create Time Of Day" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="Themes.aspx">Themes</a></li>
    <li id="liTimeOfDay" runat="server" class="activeLast"><a href="Timeofdays.aspx">Time of day</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Desc">Description:</label></td>
        <td><asp:TextBox ID="txt_Desc" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txt_Desc" ID="val_Desc" runat="server" 
            Display="Dynamic" ErrorMessage="Description is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_File">Image:</label></td>
        <td><asp:FileUpload ID="fu_File" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_File" ID="val_File" runat="server" 
            Display="Dynamic" ErrorMessage="Image is required." />
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

