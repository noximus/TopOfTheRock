<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="admin_Forums" Title="Forums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server" class="activeLast"><a href="Forums.aspx">Forums</a></li>
</ul>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Forums</h1>
<p>Click the arrow next to any forum to update the forum. Click "Add" to create a new forum.</p>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
        <tr>
            <td valign="top">
                <div class="pane">
                    <h3><span class="title">Active Forums</span><span class="nav"><asp:LinkButton runat="server" 
                    ID="lb_Update" Text="Update" OnClick="Updade_Click"/>&nbsp;|&nbsp;<a href="EditForum.aspx">Add</a></span></h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_Forum" runat="server" ShowHeader="false" OnRowCommand="Forum_OnRowCommand" 
                            AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editForum" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_ForumName" Text='<%# Eval("Title") %>' CommandName="editForum" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="290px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sort">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Sort" runat="server" Text='<%# Eval("Sort") %>' Width="30" />
                                        <asp:Label runat="server" ID="lbl_Id" Text='<%# Eval("ID") %>' Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="row" />
                        </asp:GridView>
                    </div>
                </div>
                
            </td>
            <td style="width: 10px;"></td>
            <td valign="top">
                <div class="pane">
                    <h3>Inactive Forums</h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_ForumNotActive" runat="server" ShowHeader="False" OnRowCommand="InForum_OnRowCommand"  
                        AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editForum" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_UserName" Text='<%# Eval("Title") %>' CommandName="editForum" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                &nbsp;&nbsp;No forum found.
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle CssClass="row" />
                            <RowStyle CssClass="row" />
                        </asp:GridView>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</TopOfRock:SecureHolder>
</asp:Content>

