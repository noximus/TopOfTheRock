<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="common_controls_TopMenu" %>
<div id="nav">
<div id="topNavFlash" align="center"></div>
			<script type="text/javascript">
		        // <![CDATA[
			        var so = new SWFObject("/common/swf/top_nav.swf", "TOTR Nav", "659", "49", "6", "#262626");
			        so.addParam("wmode", "transparent");
			        <asp:Literal ID="tColor" runat="server"/>
			        so.write("topNavFlash");
		        // ]]>
	        </script>
	  <span style="display:none;">      
	<asp:LinkButton ID="Welcome" runat="server" Text="Welcome" OnClick="Welcome_Click"/>   
	<asp:LinkButton ID="Share" runat="server" OnClick="Share_Click" Text="Share" />  
	<asp:LinkButton ID="Special_Offers" runat="server" OnClick="Special_Click" Text="Special Offers" />
	<asp:LinkButton ID="Contact" runat="server" OnClick="Contact_Click" Text="Contact" />
	<asp:LinkButton ID="Totr_Shop" runat="server" OnClick="Totr_Click"  Text="Totr Shop" />  
	<asp:LinkButton ID="History" runat="server" OnClick="History_Click"  Text="History" /> 
	<asp:LinkButton ID="Forum" runat="server" OnClick="Forum_Click"  Text="Forum" /> 
	<asp:LinkButton ID="Career" runat="server" OnClick="Career_Click"  Text="Career" />
	<asp:LinkButton ID="Visitor" runat="server" OnClick="Visitor_Click" Text="Visitor" />
	<asp:LinkButton ID="Events" runat="server" OnClick="Events_Click"  Text="Events" />
	<asp:LinkButton ID="TickSales" runat="server" OnClick="TickSales_Click"  Text="TickSales" />
	<asp:LinkButton ID="Refunds" runat="server" OnClick="Career_Click"  Text="Refunds" />
     </span>
</div>