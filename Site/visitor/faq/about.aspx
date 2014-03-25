<%@ Page Language="C#" MasterPageFile="~/master/FaqMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="history_Default" Title="FREQUENTLY ASKED QUESTIONS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
		
		
		<script language="javascript" src="/common/js/swfobject.js"></script>
		<script type="text/javascript">
	        // <![CDATA[
		        var so = new SWFObject("../../common/swf/bar.swf", "TOTR Nav", "879", "47", "6", "#262626");
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
			
			
			var Buttons=new Array();
			Buttons[0]={"label":'ABOUT THE TOP', "ur":'about.aspx'};
			Buttons[1]={"label":'DESIGN %26 SPECIAL FEATURES', "ur":'design_specialFeatures.aspx'};
			Buttons[2]={"label":'MEZZANINE PRE-SHOW', "ur":'mezzanine_preShow.aspx'};
			Buttons[3]={"label":'OBSERVATION DECK', "ur":'observationDeck.aspx'};
			Buttons[4]={"label":'TICKETING', "ur":'ticketing.aspx'};
			Buttons[5]={"label":'BOX OFFICE', "ur":'boxOffice.aspx'};
			Buttons[6]={"label":'ONLINE TICKETING', "ur":'onlineTicketing.aspx'};
			Buttons[7]={"label":'GROUP SALES', "ur":'groupSales.aspx'};
			Buttons[8]={"label":'RETAIL', "ur":'retail.aspx'};
			Buttons[9]={"label":'CANCELLATION \nREFUNDS, AND REISSUES', "ur":'cancellation.aspx'};
			Buttons[10]={"label":'KODAK', "ur":'kodak.aspx'};
			Buttons[11]={"label":'AREA INFORMATION', "ur":'areaInformation.aspx'};
			Buttons[12]={"label":'ROCKEFELLAR CENTER', "ur":'rockefellarCenter.aspx'};
			Buttons[13]={"label":'MISCELLANEOUS', "ur":'miscellaneous.aspx'};
			
			
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
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

