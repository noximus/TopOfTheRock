<%@ Page Language="C#" MasterPageFile="~/master/AdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="admin_Forgot" Title="Forgot Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<h1>Retrieve Password</h1>
<asp:Label ID="lblMsg" ForeColor="red" runat="server" />
<p>Have you forgotten your password? Please enter your email address below, and your password will be emailed to you.</p>
<table>
    <tr>
        <th><label class="required" for="txtEmail">Email:</label></th>
        <td>
            <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="val_Email"  runat="server" ControlToValidate="txt_Email" ErrorMessage="*" />
            </td>
    </tr>
    <tr>
        <th/>
        <td><asp:Button ID="btnSubmit" runat="server" Text="Email my password" OnClick="btnSubmit_Click" />
            <asp:Button ID="ButtonCancel" runat="server" OnClientClick="self.location = 'login.aspx';" Text="Cancel" /></td>
    </tr>
</table>

</asp:Content>

