<%@ Page Language="C#" MasterPageFile="~/master/AdminMasterPage.master" AutoEventWireup="true" Theme="Admin" CodeFile="Login.aspx.cs" Inherits="admin_Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<h1>Log In</h1>
<asp:Label ID="lbl_Error" ForeColor="red" runat="server" />
<table>
    <tr>
        <th><label class="required" for="txt_UserName">Email:</label></th>
        <td><asp:TextBox ID="txt_UserName" runat="server" MaxLength="100" />
            <asp:RequiredFieldValidator ID="val_UserName" runat="server" ControlToValidate="txt_UserName" ErrorMessage="*" />
        </td>
    </tr>
    <tr>
        <th><label class="required" for="txtPassword">Password:</label></th>
        <td><asp:TextBox ID="txt_Password" runat="server" TextMode="password" MaxLength="15" />
        <asp:RequiredFieldValidator ID="val_Password"  runat="server" ControlToValidate="txt_Password" ErrorMessage="*" />
        </td>
            
    </tr>
    <tr>
        <td></td>
        <td><asp:CheckBox ID="ch_RememberMe" runat="server" Text="Remember me" />
        <br />
        <a href="Forgot.aspx">I forgot my password.</a>
        </td>
    </tr>
    <tr>
        <th/>
        <td><asp:Button ID="btnSubmit" runat="server" Text="Log In" OnClick="Login_OnClick" /></td>
    </tr>
    <tr>
        <td style="height: 18px"></td>
        <td style="height: 18px"></td>
    </tr>
</table>

</asp:Content>

