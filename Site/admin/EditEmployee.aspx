<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditEmployee.aspx.cs" Inherits="admin_EditEmployee" Title="Edit Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="LiMyProfile" runat="server"><a href="MyProfile.aspx">My Profile</a></li>
    <li id="LiManageUsers" runat="server" class="activeLast"><a href="EmployeeList.aspx">Employee</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:20px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;"><label class="required" for="txt_Fname">First Name:</label></td>
        <td><asp:TextBox ID="txt_Fname" runat="server" MaxLength="45"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Fname" ID="val_Fname" runat="server" Display="Dynamic" ErrorMessage="First Name is required." />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_Lname">Last Name:</label></td>
        <td><asp:TextBox ID="txt_Lname" runat="server" MaxLength="45"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Lname" ID="val_Lname" runat="server" Display="Dynamic" ErrorMessage="Last Name is required." />
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_Email">Email:</label></td>
        <td><asp:TextBox ID="txt_Email" runat="server" MaxLength="100"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Email" ID="val_Email" runat="server" Display="Dynamic" ErrorMessage="Email is required." />
            <asp:RegularExpressionValidator ID="val_EmailRegEx" runat="server" ControlToValidate="txt_Email"
            Display="Dynamic" ErrorMessage="Email address must be in a valid format." ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"></asp:RegularExpressionValidator>

        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="dd_Roles">Role:</label></td>
        <td>
            <asp:DropDownList ID="dd_Role" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="dd_Role" ID="val_Roles" runat="server" Display="Dynamic" ErrorMessage="Please select user role." />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="height:12px;"></td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_NewPassword">Password:</label></td>
        <td><asp:TextBox ID="txt_NewPassword" runat="server" MaxLength="15" TextMode="Password"/>
        <asp:RequiredFieldValidator ID="val_Password" runat="server" Display="Dynamic" ControlToValidate="txt_NewPassword" ErrorMessage="Password is required." />
        <asp:RegularExpressionValidator ID="val_PasswRegEx" runat="server" ControlToValidate="txt_NewPassword"
        Display="Dynamic" ErrorMessage="Must be between 5 and 15 characters." ValidationExpression="^[A-Za-z0-9~!@#$%^&_]{5,15}$"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="txt_RetNewPassword">Repeat Password:</label></td>
        <td><asp:TextBox ID="txt_RetNewPassword" runat="server" MaxLength="15" TextMode="Password"/>
            <asp:CompareValidator ID="val_PasswordCompare" runat="server" ControlToCompare="txt_NewPassword"
            ControlToValidate="txt_RetNewPassword" Display="Dynamic" ErrorMessage="Password and Repeat Password should be the same."></asp:CompareValidator>
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

