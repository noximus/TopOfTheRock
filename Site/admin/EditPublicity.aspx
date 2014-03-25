<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditPublicity.aspx.cs" Inherits="admin_EditPublicity" Title="Edit/Create Publicity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liPress" runat="server"><a href="PressList.aspx">Press</a></li>
    <li id="liTimeOfDay" runat="server" class="activeLast"><a href="PublicityList.aspx">Publicity</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    
    <tr>
        <td style="width:150px;vertical-align:top;" class="label"><label class="required">Title:</label></td>
        <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="300"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
            Display="Dynamic" ErrorMessage="Title is required." />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required">Date:</label></td>
        <td><asp:TextBox ID="txt_Date" runat="server" MaxLength="30"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Date" ID="val_Date" runat="server" 
            Display="Dynamic" ErrorMessage="Date is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required">Pdf File:</label></td>
        <td><asp:FileUpload ID="fu_File" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_File" ID="val_File" runat="server" 
            Display="Dynamic" ErrorMessage="File is required." />
            <asp:RegularExpressionValidator ControlToValidate="fu_File" ID="reg_File" runat="server"
            Display="Dynamic" ErrorMessage="Enter valid pdf file." ValidationExpression="[\s\S]+.pdf$" />
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

