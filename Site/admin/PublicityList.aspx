<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="PublicityList.aspx.cs" Inherits="admin_PublicityList" Title="Publicity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liPress" runat="server"><a href="PressList.aspx">Press</a></li>
    <li id="liTimeOfDay" runat="server" class="activeLast"><a href="PublicityList.aspx">Publicity</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Publicity</h1>
<p>Click the arrow next to any publicity to update the publicity. Click "Add" to create a new publicity.</p>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
        <tr>
            <td valign="top">
                <div class="pane">
                    <h3><span class="title">Active Publicity</span><span class="nav"><a href="EditPublicity.aspx">Add</a></span></h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_Publicity" runat="server" ShowHeader="false" OnRowCommand="Publicity_OnRowCommand"
                            AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editPress" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_ForumName" Text='<%# Eval("Title") %>' CommandName="editPress" CommandArgument='<%#Eval("ID") %>' runat="server" />
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
                    <h3>Inactive Publicity</h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_PublicityNotActive" runat="server" ShowHeader="False" OnRowCommand="Publicity_OnRowCommand"
                        AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editPress" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_UserName" Text='<%# Eval("Title") %>' CommandName="editPress" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                &nbsp;&nbsp;No Publicity found.
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

