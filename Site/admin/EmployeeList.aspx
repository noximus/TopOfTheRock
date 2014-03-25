<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="admin_EmployeeList" Title="Employee List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="LiMyProfile" runat="server"><a href="MyProfile.aspx">My Profile</a></li>
    <li id="LiManageUsers" runat="server" class="activeLast"><a href="EmployeeList.aspx">Employee</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Users</h1>
<p>Click the arrow next to any user to update the user's profile. Click "Add" to create a new user.</p>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
            <tr>
                <td valign="top">
                    <div class="pane">
                        <h3><span class="title">Active Users</span><span class="nav"><a href="EditEmployee.aspx">Add</a></span></h3>
                        <div class="paneContents">
                            <asp:GridView ID="dgUsers" OnRowCommand="Users_OnRowCommand"  runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editUser" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lb_UserName" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>' CommandName="editUser" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LabelEmail" Text='<%#Eval("Email") %>' CommandName="editUser" CommandArgument='<%#Eval("ID") %>' runat="server" />
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
                        <h3>Inactive Users</h3>
                        <div class="paneContents">
                            <asp:GridView ID="dgUsersNotActive" OnRowCommand="InUsers_OnRowCommand" runat="server" ShowHeader="False"  AutoGenerateColumns="False" Width="100%" BorderWidth="0px" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEditRegion" runat="server" CommandName="editUser" CommandArgument='<%#Eval("ID") %>' SkinID="gridArrow" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>   
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lb_UserName" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>' CommandName="editUser" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LabelEmail" Text='<%#Eval("Email") %>' CommandName="editUser" CommandArgument='<%#Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    &nbsp;&nbsp;No users found.
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

