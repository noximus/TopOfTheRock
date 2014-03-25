<%@ Page Language="C#" MasterPageFile="~/master/SpecialOfferMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="specialoffers_Default" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="specialOffers"></div>
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("/common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","SPECIAL OFFERS");
		        so.write("header1");
	        // ]]>
        </script>
       
        <p style="padding:0px 0px 0px 50px;width:550px;font-size:11px;">It’s true. You could spend days at Top of the Rock simply watching the city unfold, transforming itself from morning to night. But there’s even more to do and see in New York City.
            <br />
            <br />

           We created these special offers to help you get the most of your visit. Some enhance your experience at Top of the Rock. Others offer great discounts on other exciting venues near the deck.
            <br />
            <br />          </p>

        <div class="generalButton" style="top:160px; left:50px;text-align:left;width:350px;">
            <div class="storyForm">
            <p style="font-size:16px;font-weight:bold;">Choose one or choose them all;<br />your experience only goes up from here.</p>
            </div>
        </div>
        <div class="generalButton" style="top:210px;left:50px;">
            <div>
                <div id="div2" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("ur","specialoffers_events.aspx");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "EVENTS AT THE TOP");
                        so.write("div2");
                    // ]]>
                </script>             
            </div>
            <div style="padding-top:5px;">
                <div id="div1" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("u","specialoffers_combo");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "COMBO TICKETS");
                        so.write("div1");
                    // ]]>
                </script>            
            </div>
            <div style="padding-top:5px;">
                <div id="div3" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("u","specialoffers_gps");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "TOP OF THE ROCK GPS TOUR");
                        so.write("div3");
                    // ]]>
                </script>             
            </div>                                    
            <div style="padding-top:5px;">
                <div id="div4" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("u","specialoffers_giftcard");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "TOP OF THE ROCK GIFT CARDS");
                        so.write("div4");
                    // ]]>
                </script>              
            </div>   
            
        </div>
            
    </div>
</asp:Content>

