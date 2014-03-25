<%@ Page Language="C#" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="welcome_Default" Title="Top Of The Rock" %>

<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="left:0px;top:2px;">
	  <div id="header1" align="center">
	  </div>

	  <script type="text/javascript">
            // <![CDATA[
	            var so = new SWFObject("<asp:Literal ID="litJSSetFlash" runat="server"></asp:Literal>", "TOTR Nav", "879", "242", "8", "#262626");
	            so.write("header1");
            // ]]>
	  </script>

    </div>
    <div class="hrule" style="top: 229px;">
        
    </div>
    <div class="hrule" style="top: 244px; height: 25px;">
    </div>
    <div class="generalButton" style="top:270px;left:20px;width:400px;">
        <p style="font-size:11px;">Is your New York bold? Is it brilliant? Is it tranquil? Is it peaceful? Discover New York in all its forms from 70 stories up at Top of the Rock Observation Deck. Our high-speed shuttle sends you racing to the sky. Our dazzling multimedia history exhibits are a feast for the eyes and stimulate the minds of all ages. And then there’s the view: the city’s only crystal-clear, 360˚ experience of your New York.<br /><br /></p>
        <p style="font-size:11px;"><a href="javascript:__doPostBack('ctl00$ctl00$ContentTopMenu$wc_TopMenu$Share','')">Show</a> the world your New York.<br /><br /></p>
        <p style="font-size:11px;"><a href="javascript:__doPostBack('ctl00$ctl00$ContentTopMenu$wc_TopMenu$History','')">Learn more</a> about Top of the Rock from the very top.</p>
    </div>
    <div class="generalButton" style="top:251px;left:440px;">
        <asp:Image runat="server" id="img_right" SkinId="WelcomeDefaultRight" Width="421" Height="160"/>
    </div>
</asp:Content>

