<%@ Page Language="C#" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="nightlife.aspx.cs" Inherits="welcome_nightlife" Title="Top Of The Rock" %>

<%@ OutputCache CacheProfile="Cache30Min"%><asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">    <div class="generalButton" style="left:0px;top:2px;">
    <div id="header1" align="center">
    </div>

    <script type="text/javascript">
            // <![CDATA[
	            var so = new SWFObject("<asp:Literal ID="litJSSetFlash" runat="server"></asp:Literal>", "TOTR Nav", "879", "242", "8", "#262626");
	            so.write("header1");
            // ]]>
    </script>

</div>
    <div class="hrule" style="top: 229px;">    </div>    <div class="hrule" style="top: 244px; height: 25px;">    </div>    <div class="generalButton" style="top:265px;left:20px;width:400px;">        <p style="font-size:11px;">The streets of New York glitter. But so does its skyline. Our high-speed vertical shuttle is your path to the stars in the sky and the stars of the city. Stop by our multimedia exhibits to take in the latest in high-tech chic and prepare to be dazzled by Swarovski’s sparkling crystal wall. Then, rise to the top, and take your place above it all from 70 stories up. New York’s ultimate scene is waiting to be seen by you.<br /><br /></p>    </div>    <div class="generalButton" style="top:251px;left:440px;">        <p><asp:Image runat="server" ID="img_right" SkinId="WelcomeNightRight" Width="418" Height="160"/></p>    </div>    </asp:Content>