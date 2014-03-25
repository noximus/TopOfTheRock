<%@ Page Language="C#" MasterPageFile="~/master/FaqMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="history_Default" Title="FREQUENTLY ASKED QUESTIONS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBodyHolder" Runat="Server">

    <div class="generalButton" style="left:0px;top:20px;">
        <div id="header1" align="center"></div>
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
    
	<script language="javascript" src="/common/js/swfobject.js"></script>
		
		
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
			Buttons[1]={"label":'DESIGN & SPECIAL FEATURES', "ur":'design_specialFeatures.aspx'};
			Buttons[2]={"label":'MEZZANINE PRE-SHOW', "ur":'mezzanine_preShow.aspx'};
			Buttons[3]={"label":'OBSERVATION DECK', "ur":'observationDeck.aspx'};
			Buttons[4]={"label":'TICKETING', "ur":'ticketing.aspx'};
			Buttons[5]={"label":'BOX OFFICE', "ur":'boxOffice.aspx'};
			Buttons[6]={"label":'ONLINE TICKETING', "ur":'onlineTicketing.aspx'};
			Buttons[7]={"label":'GROUP SALES', "ur":'groupSales.aspx'};
			Buttons[8]={"label":'RETAIL', "ur":'retail.aspx'};
			Buttons[9]={"label":'CANCELLATION<BR>REFUNDS, AND REISSUES', "ur":'cancellation.aspx'};
			Buttons[10]={"label":'KODAK', "ur":'kodak.aspx'};
			Buttons[11]={"label":'AREA INFORMATION', "ur":'areaInformation.aspx'};
			Buttons[12]={"label":'ROCKEFELLAR CENTER', "ur":'rockefellarCenter.aspx'};
			Buttons[13]={"label":'MISCELLANEOUS', "ur":'miscellaneous.aspx'};
			
			
			function placeButtons(Buttons, rows, cols) {
				for(var i=0; i<13;i++) {
					if (i>1) {
					var row=Math.floor((i/rows)+1);
					var col=Math.floor((i/cols)+1);
					ww('<div id="Div'+parseInt(i)+1+'" align="left" style="position: relative; top:'+Vslots[row]+'px; left: '+Hslots[col]+'">');
					var so = new SWFObject("../../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
					so.addVariable("ur",Buttons[i]["ur"]);
					so.addParam("salign", "tl");
					so.addVariable("text",Buttons[i]["label"]);
					so.write("Div"+parseInt(i)+1);
					ww('</div>');
				}
			}
			
		</script>
		

    <div class="generalButton" style="left:0px;top:110px;width:400px;">


	</div>

        <div class="generalButton" style="top:110px;left:44px;">

                        <!--<div id="Div1" align="center"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div1" align="left" style="position: relative; top:'+Vslots[0]+'px; left: '+Hslots[0]+'">');
							ww('HHHH');
							
	                        // <![CDATA[
		                        var so = new SWFObject("../../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://maps.google.com/maps?f=d&hl=en&saddr=&daddr=30+rockefeller+plaza,+manhattan,+NY&sll=37.0625,-95.677068&sspn=32.748002,59.765625&ie=UTF8&ll=40.759529,-73.978951&spn=0.007639,0.014591&z=16&iwloc=addr&om=1");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","ABOUT THE TOP");
		                        so.write("Div1");
		                        
	                        // ]]>
					
                        </script>
						</div>
						

                    
                        <!--<div id="Div2" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div2" align="left" style="position: absolute; top:'+Vslots[1]+'px; left: '+Hslots[0]+'px;">');
	                        // <![CDATA[
		                        var so = new SWFObject("../../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.hopstop.com/?action=dir_home");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","DESIGN & SPECIAL FEATURES");
		                        so.write("Div2");
		                        
	                        // ]]>
                        </script>
						</div>
						
                        <!--<div id="Div3" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div3" align="left" style="position: absolute; top:'+Vslots[2]+'px; left: '+Hslots[0]+'px;">');

	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.google.com");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","MEZZANINE PRE-SHOW");
		                        so.write("Div3");
		                        
	                        // ]]>
                        </script>
						</div>
                        
                        <!--<div id="Div4" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div4" align="left" style="position: absolute; top:'+Vslots[3]+'px; left: '+Hslots[0]+'px;">');

	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.google.com");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","OBSERVATION DECK");
		                        so.write("Div4");
		                        
	                        // ]]>
                        </script>                        
						</div>

                        <!--<div id="Div5" align="center" style="padding-top:5px;"></div>-->
						<script type="text/javascript">
							ww('<div id="Div5" align="left" style="position: absolute; top:'+Vslots[4]+'px; left: '+Hslots[0]+'px;">');
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../forum/Default.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","TICKETING");
		                        so.write("Div5");
		                        
	                        // ]]>
                        </script> 
						</div>
						
						<!--MIDDLE COLUMN-->
						
						  <script type="text/javascript">
							ww('<div id="Div6" align="left" style="position: absolute; top:'+Vslots[0]+'px; left: '+Hslots[1]+'px;">');
							alert(Hslots[0]);
							alert(Hslots[1]);
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://maps.google.com/maps?f=d&hl=en&saddr=&daddr=30+rockefeller+plaza,+manhattan,+NY&sll=37.0625,-95.677068&sspn=32.748002,59.765625&ie=UTF8&ll=40.759529,-73.978951&spn=0.007639,0.014591&z=16&iwloc=addr&om=1");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","BOX OFFICE");
		                        so.write("Div6");
		                        
	                        // ]]>
					
                        </script>
						</div>
						
						
						 
                        <!--<div id="Div2" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div7" align="left" style="position: absolute; top:'+Vslots[1]+'px; left: '+Hslots[1]+'px;">');
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.hopstop.com/?action=dir_home");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","ONLINE TICKETING");
		                        so.write("Div7");
		                        
	                        // ]]>
                        </script>
						</div>
						
                        <!--<div id="Div3" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div8" align="left" style="position: absolute; top:'+Vslots[2]+'px; left: '+Hslots[1]+'px;">');

	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.google.com");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","GROUP SALES");
		                        so.write("Div8");
		                        
	                        // ]]>
                        </script>
						</div>
                        
                        <!--<div id="Div4" align="center" style="padding-top:5px;"></div>-->
		                <script type="text/javascript">
							ww('<div id="Div9" align="left" style="position: absolute; top:'+Vslots[3]+'px; left: '+Hslots[1]+'px;">');

	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","http://www.google.com");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","RETAIL");
		                        so.write("Div9");
		                        
	                        // ]]>
                        </script>                        
						</div>

                        <!--<div id="Div5" align="center" style="padding-top:5px;"></div>-->
						<script type="text/javascript">
							ww('<div id="Div10" align="left" style="position: absolute; top:'+Vslots[4]+'px; left: '+Hslots[1]+'px;">');
	                        // <![CDATA[
		                        var so = new SWFObject("../common/swf/button.swf", "TOTR Nav", eWidth, eHeight, "6", "#262626");
		                        so.addParam("wmode", "transparent");
		                        so.addVariable("ur","../forum/Default.aspx");
		                        so.addParam("salign", "tl");
		                        so.addVariable("text","CANCELLATION, REFUNDS, AND REISSUES");
		                        so.write("Div10");
		                        
	                        // ]]>
                        </script> 
						</div>
									
		              
						

        </div>
            

     <div class="generalButton" style="top:0px;left:454px;">
            <div class="visitorDefautlBg">&nbsp;</div>    </div>
</asp:Content>

