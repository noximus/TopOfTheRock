<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <TopOfRock:SecureHolder runat="server" ID="secureHolder" PermissionId="1">
        <h1 id="welcomeH1">Welcome<asp:Label ID="lbl_Welcome" runat="server" /></h1>
    </TopOfRock:SecureHolder>
</asp:Content>

