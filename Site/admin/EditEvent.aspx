<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditEvent.aspx.cs" Inherits="admin_EditEvent" Title="Edit/Create Event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liEvents" runat="server" class="activeLast"><a href="Events.aspx">Events</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Title">Title:</label></td>
        <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="50"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
            Display="Dynamic" ErrorMessage="Title is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Desc">Description:</label></td>
        <td><asp:TextBox ID="txt_Desc" runat="server" TextMode="MultiLine" Rows="5"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Desc" ID="val_Desc" runat="server" 
            Display="Dynamic" ErrorMessage="Description is required." />
        </td>
    </tr>    
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_BigImg">Big Image:</label></td>
        <td><asp:FileUpload ID="fu_BigImg" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_BigImg" ID="val_BigImg" runat="server" 
            Display="Dynamic" ErrorMessage="Big Image is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_SmlImg">Small Image:</label></td>
        <td><asp:FileUpload ID="fu_SmlImg" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_SmlImg" ID="val_SmlImg" runat="server" 
            Display="Dynamic" ErrorMessage="Small Image is required." />
        </td>
    </tr>
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required" for="fu_Thumb">Thumbnail:</label></td>
        <td><asp:FileUpload ID="fu_Thumb" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_Thumb" ID="val_Thumb" runat="server" 
            Display="Dynamic" ErrorMessage="Thumbnail is required." />
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
            <asp:Button ID="btnSaveUser" runat="server" Text="Save" OnClick="Save_OnClick"/>&nbsp;
        </td>
    </tr>
 </table>
 
</TopOfRock:SecureHolder>
</asp:Content>

