<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditThemes.aspx.cs" Inherits="admin_EditThemes" Title="Edit/Create Themes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server" class="active"><a href="Themes.aspx">Themes</a></li>
    <li id="liTimeOfDay" runat="server" class="last"><a href="Timeofdays.aspx">Time of day</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="SecureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />
<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:5px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;"><label class="required" for="txt_Name">Name:</label></td>
        <td><asp:TextBox ID="txt_Name" runat="server" MaxLength="50"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Name" ID="val_Name" runat="server" Display="Dynamic" ErrorMessage="Name is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_File">Zip Theme File:</label></td>
        <td><asp:FileUpload ID="fu_File" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_File" ID="val_File" runat="server" 
            Display="Dynamic" ErrorMessage="Music File is required." />
            <asp:RegularExpressionValidator ControlToValidate="fu_File" ID="reg_File" runat="server"
            Display="Dynamic" ErrorMessage="Enter valid zip file." ValidationExpression="[\s\S]+.zip$" />
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
            <asp:Button ID="btnSaveUser" runat="server" Text="Save" OnClick="Save_Themes"/>
            <asp:Button ID="btn_Download" runat="Server" Text="Download Theme" CausesValidation="false" Visible="false" OnClick="Download_Click"/>
        </td>
    </tr>
 </table>
</TopOfRock:SecureHolder>
</asp:Content>

