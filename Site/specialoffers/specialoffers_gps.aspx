<%@ Page Language="C#" MasterPageFile="~/master/SpecialOfferMasterPage.master" AutoEventWireup="true" CodeFile="specialoffers_gps.aspx.cs" Inherits="specialoffers_specialoffers_gps" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
<div class="specialOffersGPS"><a href="http://www.cityshownyc.com/orphan01.html" target="_blank"><img src="../images/spacer.gif" width="100%" height="100%" /></a></div>
<div class="specialOffersGPSGirl"></div>
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","YOUR PRIVATE TOUR AT THE TOP");
		        so.write("header1");
	        // ]]>
        </script>      
    </div>
    <div class="generalButton" style="top:100px;left:50px;text-align:left;">
        <div class="storyDetail">
            <p style="margin-bottom:20px;width:370px;font-size:11px;">On this historic Observation Deck, you can enjoy the sights of Manhattan with the very latest in technology. Our GPS Audio Tour by CityShow™ is the first of its kind, combining satellite technology and interactive audio guidance to seamlessly narrate your experience at Top of the Rock in English, German or French.</p>

            <p style="margin-bottom: 20px; width: 370px;font-size:11px;">Top of the Rock Observation Deck is the only place that offers this amazing technology, allowing you to enjoy a personal tour at your own pace, tailored to the aspects that interest you most.</p>

            <p style="margin-bottom: 20px; width: 370px;font-size:11px;">For more information about the Top of the Rock GPS Audio Experience, <a href="http://www.cityshownyc.com/orphan01.html">click here.</a></p>
            
        </div>
    </div>

</asp:Content>

