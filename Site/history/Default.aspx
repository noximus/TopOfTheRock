<%@ Page Language="C#" MasterPageFile="~/master/HistoryMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="history_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="generalButton" style="top:2px; left:0px;text-align:left;">
            <div id="Div1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("totr_history_player.swf", "TOTR History", "878", "335", "8", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addParam("salign", "tl");
		        so.write("Div1");
	        // ]]>
        </script> 
        <div class="generalButton" style="top:293px;left:0px;"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/history/history_on.gif" OnClick="History" /></div>
        <div class="generalButton" style="top:293px;left:438px;"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/history/rock_center_off.gif" OnClick="Rock_Center" /></div>
        
        <div class="generalButton" style="top:333px;left:50px;">
            <p style="width:700px;">With the country facing economic catastrophe and the world between two wars, John D. Rockefeller’s vision for his center never wavered. <a href="http://www.rockefellercenter.com" target="_blank">Rockefeller Center</a> and the observation deck were his gifts to Manhattan- a place for locals and visitors to marvel at the city he loved.</p>

            <p style="width:700px;padding-top:15px;">Learn more about the legacy of Rockefeller and the thousands of laborers who built this plaza- a legacy we proudly continue by opening the deck’s doors for the world to see Manhattan the way he imagined it.</p>
        </div>
        
        <div class="generalButton" style="top:333px;left:775px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Photo_Credits">Photo Credits</asp:LinkButton>
        </div>
    </div>
</asp:Content>

