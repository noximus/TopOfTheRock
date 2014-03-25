<%@ Page Language="C#" MasterPageFile="~/master/VisitorMasterPage.master" AutoEventWireup="true" CodeFile="sp.aspx.cs" Inherits="visitor_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","");
		        so.write("header1");
	        // ]]>
        </script>
    </div>
    
    <div class="generalButton" style="left:500px;top:22px;">
        <div id="DivFlag" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/flags.swf", "TOTR Nav", "350", "40", "8", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addParam("salign", "tl");
		        so.addVariable("selectFlag","1");
		        so.write("DivFlag");
	        // ]]>
        </script>    
    </div>
    
    <div class="visitorSPBg"></div>

        
            

     <div class="generalButton" style="top:0px;left:454px;">
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

