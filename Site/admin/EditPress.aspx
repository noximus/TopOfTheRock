<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EditPress.aspx.cs" Inherits="admin_EditPress" Title="Edit/Create Press" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liPress" runat="server" class="active"><a href="PressList.aspx">Press</a></li>
    <li id="liTimeOfDay" runat="server" class="last"><a href="PublicityList.aspx">Publicity</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
    <tr><td style="height:10px;" colspan="2"></td></tr>
    
    <tr>
        <td class="label" style="width:150px;vertical-align:top;"><label class="required" for="txt_Fname">Title:</label></td>
        <td><asp:TextBox ID="txt_Title" runat="server" MaxLength="100"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Title" ID="val_Title" runat="server" 
            Display="Dynamic" ErrorMessage="Title is required." />
        </td>
    </tr>
    <tr>
        <td class="label" ><label class="required" for="txt_Category">Format:</label></td>
        <td><asp:DropDownList ID="dd_Format" runat="Server" OnSelectedIndexChanged="Format_IndexChanged" AutoPostBack="true"  />
            <asp:RequiredFieldValidator ControlToValidate="dd_Format" ID="val_Format" runat="server" 
            Display="Dynamic" ErrorMessage="Format is required." />
        </td>
    </tr>  
    <tr>
        <td class="label"><label class="required" >Text:</label></td>
        <td><asp:TextBox ID="txt_Desc" runat="server" TextMode="MultiLine" Rows="3"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Desc" ID="val_Desc" runat="server" 
            Display="Dynamic" ErrorMessage="Description is required." />
        </td>
    </tr>
    <tr>
        <td class="label" ><label class="required">Date:</label></td>
        <td><asp:TextBox ID="txt_Date" runat="server" MaxLength="25"/>
            <asp:RequiredFieldValidator ControlToValidate="txt_Date" ID="val_Date" runat="server" 
            Display="Dynamic" ErrorMessage="Date is required." />
        </td>
    </tr> 
    <tr>
        <td class="label" style="vertical-align:top;"><label class="required">Main Thumbnail:</label></td>
        <td><asp:FileUpload ID="fu_MThumb" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="fu_MThumb" ID="val_MThumb" runat="server" 
            Display="Dynamic" ErrorMessage="Thumbnail is required." />
            
        </td>
    </tr>
    <tr>
        <td class="label"><label class="required" for="ch_Active">Status:</label></td>
        <td>
            <asp:DropDownList ID="dd_Status" runat="server"/>
        </td>
    </tr>
   
 </table>
 
 <asp:Panel ID="pnl_Audio" runat="server" Visible="false">
 <fieldset>
            <legend>Audio</legend>
            <table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
                <tr><td style="height:10px;" colspan="2"></td></tr>
                
                <tr>
                    <td class="label" style="width:150px;vertical-align:top;" style="vertical-align:top;"><label class="required">Thumbnail:</label></td>
                    <td><asp:FileUpload ID="fu_AudThumb" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="fu_AudThumb" ID="val_AudThumb" runat="server" 
                        Display="Dynamic" ErrorMessage="Thumbnail is required." />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="vertical-align:top;"><label class="required" for="fu_File">MP3 File:</label></td>
                    <td><asp:FileUpload ID="fu_AudFile" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="fu_AudFile" ID="val_AudFile" runat="server" 
                        Display="Dynamic" ErrorMessage="Music File is required." />
                        <asp:RegularExpressionValidator ControlToValidate="fu_AudFile" ID="reg_AudFile" runat="server"
                        Display="Dynamic" ErrorMessage="Enter valid mp3 file." ValidationExpression="[\s\S]+.mp3$" />
                    </td>
                </tr>
             </table>
 </fieldset>
 </asp:Panel>
 
 <asp:Panel ID="pnl_Text" runat="server" Visible="false">
 <fieldset>
            <legend>Text</legend>
            <table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
                <tr><td style="height:10px;" colspan="2"></td></tr>
                <tr>
                    <td class="label" style="vertical-align:top;" style="width:150px;vertical-align:top;"><label class="required">Thumbnail:</label></td>
                    <td><asp:FileUpload ID="fu_TxtThumb" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="fu_TxtThumb" ID="val_TxtThumb" runat="server" 
                        Display="Dynamic" ErrorMessage="Thumbnail is required." />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="vertical-align:top;"><label class="required">Web Link:</label></td>
                    <td><asp:TextBox ID="txt_Link" runat="server" MaxLength="500"/>
                        <asp:RequiredFieldValidator ControlToValidate="txt_Link" ID="val_Link" runat="server" 
                        Display="Dynamic" ErrorMessage="Link is required." />
                    </td>
                </tr>
             </table>
 </fieldset>
 </asp:Panel>
 
 <asp:Panel ID="pnl_Video" runat="server" Visible="false">
 <fieldset>
            <legend>Video</legend>
            <table border="0" cellpadding="0" cellspacing="0" visible="true" class="form" style="width: 642px">
                <tr><td style="height:10px;" colspan="2"></td></tr>
                
                <tr>
                    <td class="label" style="width:150px;vertical-align:top;" style="vertical-align:top;"><label class="required">Thumbnail:</label></td>
                    <td><asp:FileUpload ID="fu_VidThumb" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="fu_VidFile" ID="val_VidThumb" runat="server" 
                        Display="Dynamic" ErrorMessage="Thumbnail is required." />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="vertical-align:top;"><label class="required">Flash Video:</label></td>
                    <td><asp:FileUpload ID="fu_VidFile" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="fu_VidFile" ID="val_VidFile" runat="server" 
                        Display="Dynamic" ErrorMessage="Video is required." />
                    </td>
                </tr>
             </table>
 </fieldset>
 </asp:Panel>
 
 <table style="width: 642px">
    <tr>
        <td style="height: 30px"></td>
        <td>
            <asp:Button ID="btnSaveUser" runat="server" Text="Save" OnClick="Save_Click"/>&nbsp;
        </td>
    </tr>
 </table>
 
</TopOfRock:SecureHolder>
</asp:Content>

