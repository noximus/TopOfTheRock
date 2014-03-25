<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="admin" AutoEventWireup="true" CodeFile="Themes.aspx.cs" Inherits="admin_Themes" Title="Manage Themes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server" class="active"><a href="Themes.aspx">Themes</a></li>
    <li id="liTimeOfDay" runat="server" class="last"><a href="Timeofdays.aspx">Time of day</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Themes</h1>
<p>Click the arrow next to any themes to update the themes. Click "Add" to create a new themes.</p>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
            <tr>
                <td valign="top">
                    <div class="pane">
                        <h3><span class="title">Active Themes</span><span class="nav"><asp:LinkButton runat="server" 
                        ID="lb_Update" Text="Update" OnClick="Updade_Click" />&nbsp;|&nbsp;<a href="EditThemes.aspx">Add</a></span></h3>
                        <div class="paneContents">
                            <asp:GridView ID="gv_Themes" runat="server" ShowHeader="false" OnRowCommand="Themes_OnRowCommand"
                                AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lb_ThemesName" Text='<%# Eval("Name") %>' CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Sort" runat="server" Text='<%# Eval("Sort") %>' Width="30" />
                                            <asp:Label runat="server" ID="lbl_Id" Text='<%# Eval("ID") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField ReadOnly="true" DataField="Default" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lb_SetDefault" runat="server" CommandArgument='<%# Eval("ID") %>' Text='Set Default' CommandName="SetDefault" />
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
                        <h3>Inactive Themes</h3>
                        <div class="paneContents">
                            <asp:GridView ID="gv_ThemesNotActive" runat="server" ShowHeader="False" OnRowCommand="InThemes_OnRowCommand"  
                            AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lb_UserName" Text='<%# Eval("Name") %>' CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    &nbsp;&nbsp;No themes found.
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

