<%@ Page AutoEventWireup="true" CodeFile="faqSection.aspx.cs" 
    Inherits="faq_faqSection" Language="C#" MasterPageFile="~/master/FAQMasterPage.master"
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


	  <div class="generalButton" style="text-align:left;left:55px;top:80px;width:800px;">
		<asp:DataList ID="dlQuestions" runat="server" >
		    <ItemTemplate>
				    <b><asp:HyperLink style="color:White;" ID="lnkQuestion" runat="server" NavigateUrl='<%# "faqAnswer.aspx?faqID=" + Eval("faqID") %>' Text='<%# Eval("question") %>'></asp:HyperLink></b><br />
		    </ItemTemplate>
		</asp:DataList></div>
            

     <div class="generalButton" style="top:0px;left:454px;">
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

