<%@ Page Language="C#" MasterPageFile="~/master/ShareMasterPage.master" AutoEventWireup="true" CodeFile="story_landscape.aspx.cs" Inherits="share_story" Title="Top Of The Rock" %>
<%@ OutputCache CacheProfile="Cache30Min"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">
    <div class="share" style="top: 20px;">
        <div id="div1" align="center"></div>
			<script type="text/javascript">
		        // <![CDATA[
			        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
			        so.addParam("wmode", "transparent");
			        so.addVariable("barT","false");
			        so.addVariable("text","share photo portrait mockup");
			        so.write("div1");
		        // ]]>
	        </script>
    </div>
    <div class="generalButton" style="top:80px;left:50px;text-align:left;">
        <div class="storyDetail">
            <h2><asp:Label ID="lbl_Title" runat="server" /></h2>
            <p style="margin-bottom:10px;">
                <asp:Label ID="lbl_Story" runat="server" />
            </p>
        </div>
    </div>
    <div class="shareFPhoto" id="div_Holder" runat="server" style="top:100px;left:510px;width:330px;height:270px;">
	<img src="../library/photos/stories/portrait.jpg" />
    </div>
</asp:Content>

