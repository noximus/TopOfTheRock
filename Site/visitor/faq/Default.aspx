<%@ Page AutoEventWireup="true" CodeFile="Default.aspx.cs" 
    Inherits="faq_Default" Language="C#" MasterPageFile="~/master/FAQMasterPage.master"
    Title="FREQUENTLY ASKED QUESTIONS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <div class="generalButton" style="left:0px;top:10px;">
        <div id="header1" align="center"></div>
		
		<script language="javascript" src="/common/js/swfobject.js"></script>

		<script type="text/javascript">
		// <![CDATA[
				var so = new SWFObject("/common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
				so.addParam("wmode", "transparent");
				so.addVariable("barT","false");
				so.addVariable("text","FREQUENTLY ASKED QUESTIONS");
				so.write("header1");
		// ]]>
		</script>
	  </div>
    
	
		
		
		<script type=" text/javascript">
			
			function getSlotAlignSeries(total, startAt, eLength, eSpace) {
				var slots=new Array();
				for ( i=0;i<total;i++) {
					slots[i]=getSlotAlign(i, startAt, eLength, eSpace);
				}
				return slots;
			}
			
			function getSlotAlign(iter, startAt, eLength, eSpace) {
				return iter*(eLength+eSpace)+startAt;
			}
		
			eWidth=225;
			eHeight=30;
			var rows=5;
			var cols=3;
			Hslots=getSlotAlignSeries(cols, 0, eWidth , 57);			
			Vslots=getSlotAlignSeries(rows, 0, eHeight, 25);
			
			
			ww=function(s) {
				document.write(s);
			}
			
			var fUrl='faqSection.aspx';
			var fQstr='?catid=';
			var fUrl_Q=fUrl+fQstr;
			var Buttons=new Array();
			Buttons[0]={"label":'ABOUT THE TOP', "ur":fUrl_Q+'1'};
			Buttons[1]={"label":'DESIGN %26 SPECIAL FEATURES', "ur":fUrl_Q+'2'};
			Buttons[2]={"label":'MEZZANINE PRE-SHOW', "ur":fUrl_Q+'3'};
			Buttons[3]={"label":'OBSERVATION DECK', "ur":fUrl_Q+'4'};
			Buttons[4]={"label":'TICKETING', "ur":fUrl_Q+'5'};
			Buttons[5]={"label":'BOX OFFICE', "ur":fUrl_Q+'6'};
			Buttons[6]={"label":'ONLINE TICKETING', "ur":fUrl_Q+'7'};
			Buttons[7]={"label":'GROUP SALES', "ur":fUrl_Q+'8'};
			Buttons[8]={"label":'RETAIL', "ur":fUrl_Q+'9'};
			Buttons[9]={"label":'CANCELLATION %26 REFUNDS', "ur":fUrl_Q+'10'};
			Buttons[10]={"label":'KODAK', "ur":fUrl_Q+'11'};
			Buttons[11]={"label":'AREA INFORMATION', "ur":fUrl_Q+'12'};
			Buttons[12]={"label":'ROCKEFELLER CENTER', "ur":fUrl_Q+'13'};
			Buttons[13]={"label":'MISCELLANEOUS', "ur":fUrl_Q+'14'};
			
			var Categories=new Array();
			Categories[1]={"label":'ABOUT THE TOP', "xmlFile":'about.xml'};
			Categories[2]={"label":'DESIGN %26 SPECIAL FEATURES', "xmlFile":'design.xml'};
			Categories[3]={"label":'MEZZANINE PRE-SHOW', "xmlFile":'mezzanine.xml'};
			Categories[4]={"label":'OBSERVATION DECK', "xmlFile":'observation.xml'};
			Categories[5]={"label":'TICKETING', "xmlFile":'ticketing.xml'};
			Categories[6]={"label":'BOX OFFICE', "xmlFile":'boxOffice.xml'};
			Categories[7]={"label":'ONLINE TICKETING', "xmlFile":'onlineTicketing.xml'};
			Categories[8]={"label":'GROUP SALES', "xmlFile":'groupSales.xml'};
			Categories[9]={"label":'RETAIL', "xmlFile":'retail.xml'};
			Categories[10]={"label":'CANCELLATION', "xmlFile":'cancellation.xml'};
			Categories[11]={"label":'KODAK', "xmlFile":'kodak.xml'};
			Categories[12]={"label":'ROCKEFELLER CENTER', "xmlFile":'rockellar.xml'};
			Categories[13]={"label":'AREA INFORMATION', "xmlFile":'areaInformation.xml'};
			Categories[14]={"label":'MISCELLANEOUS', "xmlFile":'misc.xml'};
			
			
			function placeButtons(Buttons, rows, cols) {
				var radj=0;
				var col=0;
				var row=-1;
				var posit;
				for(var i=0; i<14;i++) {
					if (Math.floor(i/rows)==i/rows && i>0 ) {
						row-=(rows-1); col+=1;
						} else {
						row+=1;
					}	
					if (i==0) {
						posit='relative';
						}else {
						posit='absolute';
					} 
					ww('<div id="Div'+parseInt(i)+'" align="left" style="position:'+posit+'; top:'+Vslots[row]+'px; left: '+Hslots[col]+'px">');
					var so = new SWFObject("../../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
					so.addVariable("ur",Buttons[i]["ur"]);
					so.addParam("salign", "tl");
					so.addVariable("text",Buttons[i]["label"]);
					so.write("Div"+parseInt(i));
					ww('</div>');
				}
			}
			
		</script>
		

    <div class="generalButton" style="left:0px;top:110px;width:400px;">


	</div>

        <div class="generalButton" style="top:110px;left:44px;">

                     
						
									
		              <script type="text/javascript">
					  placeButtons(Buttons, rows, cols);
					  </script>
						

        </div>
            

     <div class="generalButton" style="top:0px;left:454px;">
           <div>&nbsp;</div>  	      </div>
</asp:Content>

