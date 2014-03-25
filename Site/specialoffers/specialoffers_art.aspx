<%@ Page Language="C#" MasterPageFile="~/master/SpecialOfferMasterPage.master" AutoEventWireup="true" CodeFile="specialoffers_art.aspx.cs" Inherits="specialoffers_specialoffers_art" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","ART AND ARCHITECTURE TOUR");
		        so.write("header1");
	        // ]]>
        </script>     
    </div>
    <div class="generalButton" style="top:80px;left:50px;text-align:left;">
        <div class="storyDetail">
            <p style="margin-bottom:20px;width:370px;font-size:11px;">Top of the Rock and NBC Studios present a one-of-a-kind tour through the art and architecture of beautiful, historic Rockefeller Center.</p>

            <p style="margin-bottom: 20px; width: 370px;font-size:11px;">These expertly guided tours offer visitors a window into the past, present, and future of John D. Rockefeller’s vision for his world-famous plaza. Explore the exquisite Art Deco details of this 20th century architectural masterpiece and learn all about the rich legacy of the observation deck.</p>

            <p style="margin-bottom: 20px; width: 370px;font-size:11px;">The Art & Architecture tours run from 9am-1pm, everyday. Each tour is limited to 26 visitors to ensure an intimate, personal experience for all our guests.</p>
            <p style="margin-bottom: 20px; width: 370px;font-size:11px;">Get your tickets exclusively at the NBC Experience Store for just $20.</p>
            <p><a href="../common/pdf/terms&conditions.pdf" target="_blank">Terms and Conditions</a></p>
        </div>
    </div>
    <div class="generalButton" style="top:100px;left:450px;">
        <asp:Image runat="server" ID="img_right" SkinId="SpecOfferArtRight"/>
    </div>
</asp:Content>

