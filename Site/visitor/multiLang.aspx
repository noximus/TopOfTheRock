<%@ Page Language="C#" MasterPageFile="~/master/VisitorMasterPage.master" AutoEventWireup="true" CodeFile="multiLang.aspx.cs" Inherits="visitor_Default" Title="Top Of The Rock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <asp:literal id="litJSTranslations" runat="server"></asp:literal>

    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
		        so.addParam("wmode", "transparent");
		        so.addVariable("barT","false");
		        so.addVariable("text",langTitle);
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
		        so.addVariable("selectFlag",langID);
		        so.write("DivFlag");
	        // ]]>
        </script>    
    </div>
    <div class="generalButton" style="left:0px;top:60px;width:400px;">
<p style="padding:10px 0px 0px 62px;">
    <asp:literal runat="server" ID="litTrans"></asp:literal></p>

</div>

        <div class="generalButton" style="top:160px;left:55px;">

                        <div id="Div1" align="center"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","directionsRedirect.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text",langDrivingDirections);
		                        so.write("Div1");
		                        
	                        // ]]>
				    </script>
                    
                        <div id="Div2" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.hopstop.com/?action=dir_home");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text",langTransit);
		                        so.write("Div2");
		                        
	                        // ]]>
                        </script>

                        <div id="Div3" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../underConstruction.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text",langDining);
		                        so.write("Div3");
		                        
	                        // ]]>
                        </script>
                        
                        <div id="Div4" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../underConstruction.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text",langShopping);
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
		                        so.addVariable("text",langForums);
		                        so.write("Div5");
		                        
	                        // ]]>
                        </script> 
                        
                        <div id="Div6" align="center" style="padding-top:5px;"></div>
		                <script type="text/javascript">
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", "240", "31", "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("u","read_stories");
								so.addVariable("ur","faq/default.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text",langFAQ);
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
		                        so.addVariable("text",langContact);
		                        so.write("Div7");
		                        
	                        // ]]>
                        </script>                                                   

        </div>
            

     <div class="generalButton" style="top:0px;left:454px;">
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

