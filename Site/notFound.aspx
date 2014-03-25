<%@ Page Language="C#" MasterPageFile="~/master/EventsMasterPage.master" AutoEventWireup="true" CodeFile="notFound.aspx.cs" Inherits="events_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
        <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","Not Found");
		        so.write("header1");
	        // ]]>
        </script>
        </div>
        
        <div class="generalButton" style="left:0px;top:80px;">

		<table><tr><td width=100></td><td>
		<center><h2>This page is missing.  Please choose another section from the menu above.</h2></center>

		</td></tr></table>
        </div>
</asp:Content>

