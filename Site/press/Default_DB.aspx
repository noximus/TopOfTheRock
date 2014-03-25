<%@ Page Language="C#" MasterPageFile="~/master/PressMasterPage.master" AutoEventWireup="true" CodeFile="Default_DB.aspx.cs" Inherits="press_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","PRESS");
		        so.write("header1");
	        // ]]>
        </script>
    </div>
    
    <div class="generalButton" style="left:0px;top:70px;">
        <div id="DivFlag" align="center"></div>

	  <asp:literal runat="server" ID="litPressContent"></asp:literal>

    </div>    
</asp:Content>

