<%@ Page Language="C#" MasterPageFile="~/master/VisitorMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="visitor_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text","VISITOR INFORMATION");
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
		        so.addVariable("selectFlag","0");
		        so.write("DivFlag");
	        // ]]>
        </script>
    </div>
    <div class="generalButton" style="top:60px;width:500px;">
<p style="padding-top:10px;">Why just see the city when you can experience it? Here’s all the information you need to make your trip to the Top into a journey of a lifetime.</p>

<p style="padding-top:20px;">Pinpoint our location; discover the best dining and shopping in the area, and exchange tips and recommendations in our <a href="javascript:__doPostBack('ctl00$ctl00$ContentTopMenu$wc_TopMenu$Forum','')">Global Forum.</a></p>
</div>

        <div class="generalButton" style="top:160px;">

                        <div id="Div1" align="center"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","directionsRedirect.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","DIRECTIONS BY CAR");
		                        so.write("Div1");
		                        
	                        // ]]>
                        </script>
                    
                        <div id="Div2" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.hopstop.com/?address2=30+rockefeller+plaza");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","DIRECTIONS BY MASS TRANSIT");
		                        so.write("Div2");
		                        
	                        // ]]>
				    </script>

                        <div id="Div3" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.rockefellercenter.com/home.asp?skip=eat");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","DINING");
		                        so.write("Div3");
		                        
	                        // ]]>
                        </script>
                        
                        <div id="Div4" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.rockefellercenter.com/home.asp?skip=shop");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","SHOPPING");
		                        so.write("Div4");
		                        
	                        // ]]>
                        </script>                        

                        <div id="Div5" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../forum/Default.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","GLOBAL FORUMS");
		                        so.write("Div5");
		                        
	                        // ]]>
                        </script> 
                        
                        <div id="Div6" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("u","read_stories");
								so.addVariable("ur","./faq/default.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","FAQ");
		                        so.write("Div6");
		                        
	                        // ]]>
                        </script>
                        
                        <div id="Div7" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../contact/contact.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","CONTACT");
		                        so.write("Div7");
		                        
	                        // ]]>
                        </script>                                                   

        </div>
            

     <div class="generalButton" style="top:0px;left:454px;">
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

