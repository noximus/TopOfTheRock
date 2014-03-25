<%@ Page Language="C#" MasterPageFile="~/master/SpecialOfferMasterPage.master" AutoEventWireup="true" CodeFile="specialoffers_combo.aspx.cs" Inherits="specialoffers_specialoffers_combo" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
<div class="specialOffers"></div>
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","COMBO TICKETS");
		        so.write("header1");
	        // ]]>
        </script>    
        
        <p style="padding:10px 0px 0px 62px; width:550px;font-size:11px;">
            </p>

        <div class="generalButton" style="top:80px; left:60px;text-align:left;width:400px;">
            <div class="storyForm">
            <p style="font-weight:bold; font-size:8pt;">Choose one or choose them all; you only go up from here.</p>
            </div>
        </div>
        <div class="generalButton" style="top:120px;left:62px;">
            <div>
               <div id="div1" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("ur", "specialoffers_rockpass.aspx");
                        so.addVariable("text", "ROCK PASS");
                        so.write("div1");
                    // ]]>
		    </script>             
            </div>
            <div style="padding-top:5px;">
               <div id="div2" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("ur","specialoffers_bodies.aspx");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "BODIES");
                        so.write("div2");
                    // ]]>
		    </script>              
            </div>
            <div style="padding-top:5px;">
               <div id="div3" align="center"></div>
                <script type="text/javascript">
                    // <![CDATA[
                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                        so.addParam("wmode", "transparent");
                        so.addVariable("ur","specialoffers_moma.aspx");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "MoMA");
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
                        so.addVariable("ur","specialoffers_art.aspx");
                        so.addParam("salign", "tl");
                        so.addVariable("text", "ART &amp; ARCHITECTURE");
                        so.write("div4");
                    // ]]>
		    </script>             
            </div>   
                                     
        </div>
        
    </div>
</asp:Content>

