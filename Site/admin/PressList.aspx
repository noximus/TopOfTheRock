<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="PressList.aspx.cs" Inherits="admin_PressList" Title="Press" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liPress" runat="server" class="active"><a href="PressList.aspx">Press</a></li>
    <li id="liTimeOfDay" runat="server" class="last"><a href="PublicityList.aspx">Publicity</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Press</h1>
<p>Click the arrow next to any press to update the press. Click "Add" to create a new press.</p>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
        <tr>
            <td valign="top">
                <div class="pane">
                    <h3><span class="title">Active Press</span><span class="nav"><a href="EditPress.aspx">Add</a></span></h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_Press" runat="server" ShowHeader="false" OnRowCommand="Press_OnRowCommand" 
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
                                        <asp:LinkButton ID="lb_ForumName" Text='<%# Eval("PressTitle") %>' CommandName="editPress" CommandArgument='<%#Eval("ID") %>' runat="server" />
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
                    <h3>Inactive Press</h3>
                    <div class="paneContents">
                        <asp:GridView ID="gv_PressNotActive" runat="server" ShowHeader="False" OnRowCommand="Press_OnRowCommand" 
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
                                        <asp:LinkButton ID="lb_UserName" Text='<%# Eval("PressTitle") %>' CommandName="editPress" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                &nbsp;&nbsp;No Press found.
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

