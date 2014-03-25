<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="Timeofdays.aspx.cs" Inherits="admin_Timeofdays" Title="Time Of Day" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="Themes.aspx">Themes</a></li>
    <li id="liTimeOfDay" runat="server" class="activeLast"><a href="Timeofdays.aspx">Time of day</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Time Of Day</h1>
<p>Click the arrow next to any time of day to update. Click "Add" to create a new time of day.</p>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
            <tr>
                <td valign="top">
                    <div class="pane">
                        <h3><span class="title">Active Times Of Day</span><span class="nav"><asp:LinkButton runat="server" 
                        ID="lb_Update" Text="Update" OnClick="Updade_Click" />&nbsp;|&nbsp;<a href="EditTimeOfDay.aspx">Add</a></span></h3>
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
                                            <asp:LinkButton ID="lb_ThemesName" Text='<%# Eval("Description") %>' CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="260px" />
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
                        <h3>Inactive Times Of Day</h3>
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
                                            <asp:LinkButton ID="lb_UserName" Text='<%# Eval("Description") %>' CommandName="editThemes" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    &nbsp;&nbsp;No records found.
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

