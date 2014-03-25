<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EventGallery.aspx.cs" Inherits="admin_EventGallery" Title="Event Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liEvents" runat="server" class="activeLast"><a href="Events.aspx">Events</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1><asp:Label ID="lbl_Header" runat="server" /></h1>
<br />
<table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
    <tr>
        <td valign="top">
            <div class="widepane">
                <h3><span class="title">List of Photo</span><span class="nav">
                    <asp:LinkButton ID="lb_UpdateSort" runat="server" Text="Update Sort" OnClick="UpdateSort_OnClick" />&nbsp;
                    <asp:LinkButton ID="lb_AddNew" runat="server" Text="Add New Photo" OnClick="Add_Click" CausesValidation="false"/>
                   </span></h3>
                <div class="paneContents">
                    <asp:GridView ID="dgPhotos" runat="server" ShowHeader="false" OnRowCommand="Photos_OnRowCommand" 
                    AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Image ID="ib_Photo" runat="server" ImageUrl='<%# GetPhotoUrl(Eval("ID"), Eval("ThumbnailImgType")) %>'/>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_ForumName" Text='<%# Eval("Title") %>' CommandName="editEvent" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="350px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Sort" runat="server" Width="50" Text='<%# Eval("Sort") %>' />
                                    <asp:RequiredFieldValidator ID="valReq_Sort" runat="server" ControlToValidate="txt_Sort" Display="Dynamic" ErrorMessage="Enter valid number." />
                                    <asp:RegularExpressionValidator ID="val_Sort" runat="server" ControlToValidate="txt_Sort" Display="Dynamic" ErrorMessage="Enter valid number."
                                        ValidationExpression="^\d+$" />
                                    <asp:Label ID="lbl_Id" runat="Server" Text='<%# Eval("ID") %>' Visible="false" />
                                </ItemTemplate>
                                <ItemStyle Width="250px" />
                            </asp:TemplateField>
                            
                        </Columns>
                        <RowStyle CssClass="row" />
                    </asp:GridView>
                </div>
            </div>
        </td>
    </tr>
</table>
</TopOfRock:SecureHolder>
</asp:Content>

