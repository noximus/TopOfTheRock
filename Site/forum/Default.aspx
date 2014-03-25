<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/master/ForumMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="forum_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text",<asp:Literal ID="lit_FlashHeader" runat="server" />);			
		        so.write("header1");
	        // ]]>
		</script>     
    </div>
    <div class="generalButton" style="left:500px;top:22px;">
        <div id="DivFlag" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/flagsForum.swf", "TOTR Nav", "350", "40", "8", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addParam("salign", "tl");
		        <asp:Literal ID="lit_FlashCulture" runat="server"/>
		        so.write("DivFlag");
	        // ]]>
        </script>    
    </div>    
    <div class="generalButton" style="top:70px;left:0px;text-align:left;">
    <p style="width:770px;padding:0px 0px 10px 50px;">
	<asp:Literal ID="lit_HeaderTopic" runat="server" meta:resourcekey="Header"/>
	</p>
         <asp:GridView CssClass="stories" ID="dg_Forum"  runat="server" ShowHeader="true" AutoGenerateColumns="False"  
            BorderWidth="0px" GridLines="None" DataSourceID="gridViewDataSource" AllowPaging="true"
            DataKeyNames="ID" PageSize="5" OnRowCommand="Topic_OnRowCommand">
            <Columns>
                <asp:TemplateField ItemStyle-Width="50">
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" ItemStyle-Width="550" HeaderStyle-Font-Bold="true" >
                    <ItemTemplate>
                       <asp:LinkButton  runat="server" id="lb_Title" Text='<%# Eval("Title") %>' CommandArgument='<%# Eval("ID") %>' CommandName="View" Font-Bold="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="130" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-Font-Bold="false">
                    <ItemTemplate>
                        <%# Eval("Replies") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100" meta:resourcekey="TemplateFieldResource3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-Font-Bold="false">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime(Eval("LastPost")).ToShortDateString() == "1900/01/01") ? "" : Convert.ToDateTime(Eval("LastPost")).ToShortDateString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="50">
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>

            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<%$ Resources:PagerSettings.FirstPageText %>" LastPageText=" <%$ Resources:PagerSettings.LastPageText %>" NextPageText="<%$ Resources:PagerSettings.NextPageText %>" PreviousPageText="<%$ Resources:PagereSettings.PreviousPageText%>" />
            <PagerStyle CssClass="Pager" />  
            
            <PagerTemplate>
		    <%# dg_Forum.PageIndex * dg_Forum.PageSize + 1 %>
		     - <%# (dg_Forum.PageIndex * dg_Forum.PageSize) + 1 + (dg_Forum.PageSize - 1) %>
		      of about <%# dg_Forum.PageSize * dg_Forum.PageCount %> &nbsp; &nbsp;
	            <asp:LinkButton runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>&nbsp;&nbsp;|&nbsp;&nbsp; 

			<asp:LinkButton runat="server" CommandName="Page" CommandArgument="Prev">&lt; Prev</asp:LinkButton>&nbsp;&nbsp;|&nbsp;&nbsp;

	            <asp:LinkButton runat="server" CommandName="Page" CommandArgument="Next">Next &gt;</asp:LinkButton>&nbsp;&nbsp;|&nbsp;&nbsp;

	            <asp:LinkButton runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
	
            </PagerTemplate>

        </asp:GridView>
       <asp:ObjectDataSource ID="gridViewDataSource" runat="server" SelectMethod="GetTopics" 
            EnablePaging="true" TypeName="GridViewUtility" SortParameterName="SortExpression" SelectCountMethod="GetTopicsCount">
        <SelectParameters>
            <asp:Parameter Name="sortExpression" Type="string" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
	    <asp:ControlParameter ControlID="hid_Culture" Name="cultureValue" Type="string" />
        </SelectParameters>
      </asp:ObjectDataSource>
	<asp:LinkButton id="lb_ChangeCulture" runat="server" OnClick="ChangeCulture_Click"  Visible="false"/> 

	<asp:HiddenField ID="hid_Culture" runat="server" />
      
      <div id="div5" style="position:absolute;top:230px;left:710px;"></div>
        <script type="text/javascript">
        // <![CDATA[
            var so = new SWFObject("../common/swf/button2.swf", "TOTR Nav", "130", "25", "6", "#262626");
            so.addParam("wmode", "transparent");
            so.addVariable("u","javascript:__doPostBack('ctl00$ctl00$ContentBodyHolder$ContentBodyHolder$lb_PostTopic','');");
            so.addParam("salign", "tl");
            <asp:Literal ID="lit_ButtonPostTopic" runat="server" meta:resourcekey="PostTopic"/>
            so.write("div5");
        // ]]>
    </script> 
    <div class="hrule" style="top:260px;"></div>
    <asp:LinkButton id="lb_PostTopic" runat="server" OnClick="PostTopic_Click" Visible="false" />  
    </div>
</asp:Content>

