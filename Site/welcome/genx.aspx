<%@ Page Language="C#" MasterPageFile="~/master/WelcomeMasterPage.master" AutoEventWireup="true" CodeFile="genx.aspx.cs" Inherits="welcome_genx" Title="Top Of The Rock" %><%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">        <div class="generalButton" style="left:0px;top:2px;">
    <div id="header1" align="center">
    </div>

    <script type="text/javascript">
            // <![CDATA[
	            var so = new SWFObject("<asp:Literal ID="litJSSetFlash" runat="server"></asp:Literal>", "TOTR Nav", "879", "242", "8", "#262626");
	            so.write("header1");
            // ]]>
    </script>

</div>
    <div class="hrule" style="top: 229px;">            </div>    <div class="hrule" style="top: 244px; height: 25px;">    </div>    <div class="generalButton" style="top:250px;left:20px;width:400px;">        <p style="font-size:11px;>There are thousands of ways to see New York. But only one way to experience it. From 70 stories up on our glass paneled observation decks, the city is yours to see, yours to have, and yours to love. But a great view is just the beginning of our story. Our thrilling vertical shuttle takes you from the street-level bustle to sky-high awe. And our multimedia exhibits dazzle the eye with the latest technology and stimulate minds of all ages with the rich history of Rockefeller Center.<br /><br /></p>        <p style="font-size:11px;>It�s the perfect spot to fall in love with New York and all the things that put it on top of the world.<br /><br /></p>        <p style="font-size:11px;><a href="javascript:__doPostBack('ctl00$ctl00$ContentTopMenu$wc_TopMenu$Share','')">Show us</a> the Top of your world.</p>    </div>    <div class="generalButton" style="top:251px;left:440px;">        <asp:Image runat="server" ID="img_right" SkinId="WelcomeGenxRight" Width="429" Height="160"/>    </div></asp:Content>