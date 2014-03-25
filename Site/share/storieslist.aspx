<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="storieslist.aspx.cs" Inherits="share_storieslist" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="share" style="top: 20px;">
        <div style="position:absolute;">
        <div id="header1" align="center"></div>
			<script type="text/javascript">
		        // <![CDATA[
			        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
			        so.addParam("wmode", "transparent");
			        so.addVariable("barT","false");
			        <asp:Literal ID="tText" runat="server"/>
			        so.write("header1");
		        // ]]>
	        </script>
        </div>
        
    </div>
    <div class="generalButton" style="top:80px;left:0px;text-align:left;">
         <asp:GridView CssClass="stories" ID="dgStories"  runat="server" ShowHeader="true" AutoGenerateColumns="False"  
            BorderWidth="0px" GridLines="None" AllowPaging="true" AllowSorting="true"
            DataKeyNames="ID" PageSize="9" OnRowDataBound="Stories_OnRowDataBound"
            OnRowCommand="Stories_OnRowCommand">
            <Columns>
                <asp:TemplateField ItemStyle-Width="50">
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" ItemStyle-Width="250">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" id="lb_Title" Text='<%# Eval("Title") %>' CommandArgument='<%# Eval("ID") %>' CommandName="View" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" ItemStyle-Width="110">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("DateCreated")).ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Photo" ItemStyle-Width="90">
                    <ItemTemplate>
                        <asp:ImageButton ID="lb_ViewPhoto" runat="server" SkinId="HasPicture" CommandArgument='<%# Eval("ID") %>' CommandName="View"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Video" ItemStyle-Width="90">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="lb_ViewVideo" SkinId="HasVideo" CommandArgument='<%# Eval("ID") %>' CommandName="View"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Text" ItemStyle-Width="90">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="lb_ViewText" SkinId="HasText" CommandArgument='<%# Eval("ID") %>' CommandName="View"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="198">
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
		 <HeaderStyle HorizontalAlign="Left" />
        </asp:GridView>
<%--        <!--asp:ObjectDataSource ID="gridViewDataSource" runat="server" SelectMethod="GetStories" 
            EnablePaging="true" TypeName="GridViewUtility" SortParameterName="SortExpression" SelectCountMethod="GetStoriesCount">
        <SelectParameters>
            <asp:Parameter Name="sortExpression" Type="string" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:ControlParameter ControlID="hid_Category" Name="categoryValue" Type="string" />
            <asp:ControlParameter ControlID="hid_Status" Name="statusValue" Type="string" />
        </SelectParameters>
      </asp:ObjectDataSource-->  
--%>
        <asp:HiddenField ID="hid_Category" runat="server" />
        <asp:HiddenField ID="hid_Status" runat="server" />
    </div>
</asp:Content>

