<%@ Page Language="C#" MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="groups_Default"  Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="subBG"></div>
    <div class="share" style="top: 20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","TAKE A RIDE TO THE TOP");
		        so.write("header1");
	        // ]]>
        </script>
        <p style="padding:10px 0px 0px 63px;width:350px;">Select the category that best matches your group for information, special offers, and instructions on purchasing tickets for Top of the Rock.</p>

        <div class="generalButton" style="top:110px;left:63px;">

           <div id="div1" align="center"></div>
            <script type="text/javascript">
                // <![CDATA[
                    var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                    so.addParam("wmode", "transparent");
                    so.addVariable("u","groups_travel_pro");
                    so.addParam("salign", "tl");
                    so.addVariable("text", "TRAVEL PROFESSIONALS");
                    so.write("div1");
                // ]]>
            </script>  
            <div style="padding-top:15px;">
           <div id="div2" align="center"></div>
            <script type="text/javascript">
                // <![CDATA[
                    var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                    so.addParam("wmode", "transparent");
                    so.addVariable("u","groups_organizaionts_clubs");
                    so.addParam("salign", "tl");
                    so.addVariable("text", "ORGANIZATIONS AND CLUBS");
                    so.write("div2");
                // ]]>
            </script>  
            </div>
            <div style="padding-top:15px;">
           <div id="div3" align="center"></div>
            <script type="text/javascript">
                // <![CDATA[
                    var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                    so.addParam("wmode", "transparent");
                    so.addVariable("u","groups_corporate");
                    so.addParam("salign", "tl");
                    so.addVariable("text", "CORPORATE GROUPS");
                    so.write("div3");
                // ]]>
            </script> 
            </div> 
            <div style="padding-top:15px;">
           <div id="div4" align="center"></div>
            <script type="text/javascript">
                // <![CDATA[
                    var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "245", "31", "6", "#262626");
                    so.addParam("wmode", "transparent");
                    so.addVariable("u","groups_schools_camps");
                    so.addParam("salign", "tl");
                    so.addVariable("text", "SCHOOLS AND CAMPS");
                    so.write("div4");
                // ]]>
            </script>   
            </div>           
        </div>
            
    </div>
     <div class="groupsDefault"></div>
     
</asp:Content>

