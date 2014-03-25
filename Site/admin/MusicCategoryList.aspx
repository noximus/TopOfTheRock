<%@ Page Language="C#" MasterPageFile="~/master/SecureAdminMasterPage.master" Theme="Admin" AutoEventWireup="true" CodeFile="MusicCategoryList.aspx.cs" Inherits="admin_MusicCategoryList" Title="Music Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphNav" Runat="Server">
<ul>
    <li id="liHistory" runat="server"><a href="History.aspx">History</a></li>
    <li id="liShare" runat="Server"><a href="EditShare.aspx">Share</a></li>
    <li id="liStories" runat="Server"><a href="StoriesList.aspx">Stories</a></li>
    <li id="liMusics" runat="Server" class="activeLast"><a href="MusicList.aspx">Musics</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<TopOfRock:SecureHolder ID="secureHolder" runat="server" PermissionId="1">
<h1>Manage Music Categories</h1>

<asp:Label ID="lbl_Error" runat="server" CssClass="error" />

<table cellpadding="0" cellspacing="0" border="0" width="100%" id="tblAllUsers" runat="server">
    <tr>
        <td valign="top">
            <div class="pane">
                <h3><span class="title">Category</span></h3>
                <div class="paneContents">
                    <asp:DataGrid ID="dg_category" runat="server" ShowHeader="false" EnableViewState="true"
                            AutoGenerateColumns="False" Width="100%" BorderWidth="0px" 
                            OnEditCommand="Category_OnEditCommand" OnCancelCommand="Category_OnCancelCommand"
                             OnUpdateCommand="Category_OnUpdateCommand" GridLines="None" DataKeyField="ID">
                        <Columns>
                            <asp:TemplateColumn ItemStyle-Width="250px">
                                <ItemTemplate>
                                    &nbsp;<%# Eval("Description")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txt_Desc" Text='<%# Eval("Description") %>' />
                                    <br />
                                    <asp:RequiredFieldValidator ID="val_Desc" runat="Server" 
                                     Display="Dynamic" ErrorMessage="Description is required." ControlToValidate="txt_Desc" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ch_Default" runat="server" Enabled="false" Checked='<%# Eval("Default") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="ch_Default" runat="server" Checked='<%# Eval("Default") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                    <%# Eval("Sort") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txt_Sort" Text='<%# Eval("Sort") %>' Width="20px" />
                                    <asp:RequiredFieldValidator ID="val_Sort" runat="Server" 
                                     Display="Dynamic" ErrorMessage="Sort is required." ControlToValidate="txt_Sort" />
                                     <asp:RegularExpressionValidator ID="reg_Sort" runat="server" Display="Dynamic" 
                                     ErrorMessage="Enter valid sort value." ControlToValidate="txt_Sort" ValidationExpression="\d+" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn   EditText="Edit" CancelText="Cancel" UpdateText="Update" ButtonType="LinkButton" />
                        </Columns>
                        <ItemStyle CssClass="row" />
                    </asp:DataGrid>
                    
                </div>
            </div>
            
        </td>
        <td style="width: 10px;"></td>
        <td valign="top">
            <div class="pane">
                <h3>Add New Category</h3>
                <div class="paneContents">
                <table width="100%" cellspacing="0" border="0">
                    <tr class="row">
                        <td style="width:320px;">
                            <asp:TextBox runat="server" ID="txt_Description" />
                            <asp:RequiredFieldValidator ID="val_Desc" runat="Server" 
                                     Display="Dynamic" ErrorMessage="Description is required." ControlToValidate="txt_Description" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lb_Insert" runat="server" Text="Save" OnClick="Save_Click" />
                        </td>
                    </tr>
                </table>
                </div>
            </div>
        </td>
    </tr>
</table>

</TopOfRock:SecureHolder>
</asp:Content>

