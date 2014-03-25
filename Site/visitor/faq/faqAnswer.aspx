<%@ Page AutoEventWireup="true" CodeFile="faqAnswer.aspx.cs" 
    Inherits="faq_faqAnswer" Language="C#" MasterPageFile="~/master/FAQMasterPage.master"
    Title="FREQUENTLY ASKED QUESTIONS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		
		<script language="javascript" src="/common/js/swfobject.js"></script>

		<script type="text/javascript">
		// <![CDATA[
				var so = new SWFObject("/common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
				so.addParam("wmode", "transparent");
				so.addVariable("barT","false");
				so.addVariable("text","FAQ ABOUT THE TOP");
				so.write("header1");
		// ]]>
		</script>
	  </div>


        <div class="generalButton" style="text-align: left; left: 55px; top: 80px; width: 750px;">
	  <div class="visitorDefautlBg" style="color:White;">
		    <h2><asp:Literal ID="litQuestion" runat="server"></asp:Literal></h2>
		    <br />
		    <font style="font-size:small;"><asp:Literal ID="litAnswer" runat="server"></asp:Literal></font>
		    
		    </div>
		    
		        </div>
</asp:Content>

