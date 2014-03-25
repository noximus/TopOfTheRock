<%@ Page AutoEventWireup="true" CodeFile="BuildABear.aspx.cs"
    Inherits="specialoffers_BuildABear" Language="C#" MasterPageFile="~/master/SpecialOfferMasterPage.master"
    Title="Top Of The Rock" %><%@ OutputCache CacheProfile="Cache30Min"%><asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">    <div class="share" style="top: 20px;">        <div id="header1" align="center"></div>		<script type="text/javascript">	        // <![CDATA[		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");		        so.addParam("wmode", "transparent");		        so.addVariable("barT","false");		        so.addVariable("text","Build-A-Bear");		        so.write("header1");	        // ]]>        </script>          </div>    <div class="generalButton" style="top:80px;left:62px;text-align:left;">        <div class="storyDetail" style="width:370px;">            <p style="margin-bottom:20px;">
	  Build-A-Bear Workshop® and American Girl Place Come to Top of
	  the Rock</p>     <p style="margin-bottom: 20px;">
    Start your Independence Day celebration early by bringing the
		whole family to Top of the Rock Observation Deck! Top of the
		Rock will be hosting family-friendly activities throughout the
		weekend. From 12:00 PM to 3:00 PM on June 30th and July 1st
		Bearemy, the mascot of Build-A- Bear Workshop, will be taking
		in the pawsome views at Top of the Rock. Families are welcome
		to get their picture taken with Bearemy, who will have special
		offers redeemable at Build-A-Bear Workshop on Fifth Avenue at
		46th Street, the biggest Build-A-Bear Workshop store in the
		world where you can make your own furry friends
	  </p>        </div>    </div>    <div class="generalButton" style="top:100px;left:500px;text-align:center;alignment-vertical:center;">        <asp:image id="img_right" runat="server" src="../images/events/buildabear.jpg" width=170 height=170>
</asp:image><!--        <map name="Map" id="Map">\			<area shape="rect" coords="0,222,157,292" href="http://www.radiocity.com/" target="_blank" />			<area shape="rect" coords="260,222,430,282" href="http://www.nbc.com/Footer/Tickets/" target="_blank" />		</map>    </div></asp:Content>