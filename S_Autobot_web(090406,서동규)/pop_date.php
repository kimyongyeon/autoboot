<?php
include "dbconn.php";
?>
<script language=javascript>
function go(one){ 
    location.href="http://localhost/autobot/pop_date.php/?loca="+one; 
}
</script>
<html>
<head>
<title>날짜별 변화추이 그래프</title>
<meta http-equiv="content-type" content="text/html; charset=euc-kr">
<style type='text/css'> 
html, body, div, span, p, a, font, img { 
    margin:0; padding:0; border:0; 
} 

body { margin:0 auto; width:100%; padding-bottom:25px; font-size:9pt; font-family:굴림, Gulim, AppleGothic, sans-serif; } 
img { border:0px; padding:0; margin:0; } 
#chart { padding:0; margin:0; } 
#chart { width:920; margin:0 auto; } 
#chartPannel { background-image:url('images/scale_l.gif'); background-repeat:repeat-x; background-position:left; } 
.dot { position:relative; float:left; width:1px; height:1px; background:#eee url('images/1x1red.gif'); background-repeat:no-repeat;} 
.layer1 {
  position: absolute;
  top:85; left:50; width:20; height:50;
  z-index: 1
}

.layer2 {
  position: absolute;
  top:0; left:30; width:550; height:550;
  z-index: 2
}
.layer3 {
  position: absolute;
  top:333; left:100;
  z-index: 3
}
</style> 
</head>

<body topmargin="0" leftmargin="0" bgcolor="white" text="black" link="blue" vlink="purple" alink="red">
<div class=layer3>
<?
	$query = "select Loca_Name from fixed_set";
	$result = mysql_query($query,$connect);

	echo "<select name='loca' style='background:#D1E37A; color:#797979; font-size:8pt' onchange=go(this.value)>";
	echo "<option value=''>-선택-</option>";
	while($row = mysql_fetch_array($result))
	{
		echo"<option value='$row[Loca_Name]'>$row[Loca_Name]</option>";
	}
	echo "</select>";
?>
</div>
<?
$query = "select Sens_Val, Sens_Date";
$query .= " from sensing";
$query .= " Where Node_Num = (select Node_Num from fixed_set where Loca_Name = '$loca')";

$result = mysql_query($query, $connect);
$total = mysql_affected_rows();
$row = mysql_fetch_array($result);

if(!$row[Sens_Val])
{
	echo("<div align='center'></div>");
}
else
{	
	if(!$start) 
	{
		$start=0;
	}		
	echo "<script> var value_a = Array(7);</script>";
	echo "<script> var value_b = Array(7);</script>";
	 for($i=$start; $i<$total; $i++)
	{
		 mysql_data_seek($result, $i);
		 $rows = mysql_fetch_array($result);		
		 $a[$i] = round(mysql_result($result, $i, 0));
		 $b[$i] = substr(mysql_result($result, $i, 1), 5, 5);		
		 echo "<script> value_a[$i] = '$a[$i]';</script>";
		 echo "<script> value_b[$i] = '$b[$i]';</script>";
	}
}
?>

<TABLE WIDTH=500 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_01.gif" WIDTH=40 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_02.gif" WIDTH=37 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_03.gif" WIDTH=110 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_04.gif" WIDTH=63 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_05.gif" WIDTH=119 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_06.gif" WIDTH=20 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_07.gif" WIDTH=39 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_08.gif" WIDTH=20 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_09.gif" WIDTH=14 HEIGHT=29 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_10.gif" WIDTH=38 HEIGHT=29 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_11.gif" WIDTH=40 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_12.gif" WIDTH=37 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_13.gif" WIDTH=110 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_14.gif" WIDTH=63 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_15.gif" WIDTH=119 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_16.gif" WIDTH=20 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_17.gif" WIDTH=39 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_18.gif" WIDTH=20 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_19.gif" WIDTH=14 HEIGHT=14 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_20.gif" WIDTH=38 HEIGHT=14 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_21.gif" WIDTH=40 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_22.gif" WIDTH=37 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_23.gif" WIDTH=110 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_24.gif" WIDTH=63 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_25.gif" WIDTH=119 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_26.gif" WIDTH=20 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_27.gif" WIDTH=39 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_28.gif" WIDTH=20 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_29.gif" WIDTH=14 HEIGHT=25 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_30.gif" WIDTH=38 HEIGHT=25 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_31.gif" WIDTH=40 HEIGHT=250 ALT=""></TD>
		<TD COLSPAN=8>
		<div class=layer1>

<div id="chart"></div> 

<p>&nbsp;</p>
<p>
<script type="text/javascript">
 
 /*
	scores = new Array(); 
	scores[0]=value_a[0]; 
	scores[1]=value_a[1]; 
	scores[2]=value_a[2]; 
	scores[3]=value_a[3]; 
	scores[4]=value_a[4]; 
	scores[5]=value_a[5]; 
	scores[6]=value_a[6]; 
*/

scores = new Array(); 
	scores[0]=40; 
	scores[1]=25; 
	scores[2]=36; 
	scores[3]=38; 
	scores[4]=39; 
	scores[5]=30; 
	scores[6]=40; 

	date = new Array(); 
	date[0]=value_b[0];
	date[1]=value_b[1];
	date[2]=value_b[2];
	date[3]=value_b[3];
	date[4]=value_b[4];
	date[5]=value_b[5];
	date[6]=value_b[6];

	var os = '℃/D'; 
	var pannelWidth = '400'; 
	var cellWidth = Math.floor(pannelWidth/7); 
	var inline  = ''; 

	// left Pannel 
	inline += "<div style='float:left; width:30px; height:30px;'>"; 
	for( var idx=4; idx>-3; idx-- ) 
	{ 
		avg = idx*10; 
		inline += "<p style='height:30px; font-size:8pt;'>"+avg+"</p>"; 
	} 
	inline += "</div>"; 

	// middle Pannel 
	inline += "<div id='chartPannel' style='float:left; width:"+360+"px; height:100px; border-left:1px solid #000000; border-bottom:1px solid #000000'>"; 

	inline += "<div style='position:relative; top:120px; width:100%; height:100px;'>"; 

	for( var idx=1; idx<scores.length; idx++ ) 
	{ 
		firstPos = scores[idx-1]; 
		nextPos  = scores[idx]; 

		factor = (firstPos-nextPos) / (cellWidth); 

		inline += "<div style='position:relative; float:left; width:"+cellWidth+"px; height:"+200+"px;'>"; 

		for( var jdx=0; jdx<cellWidth; jdx++ ) 
		{ 
			
			pixelPos = Math.floor((firstPos-(jdx*factor))*3); 		
			inline += "<div style='float:left; width:1px; height:200px;'>"; 		
			inline += "<p class='dot' style='top:-"+pixelPos+"px; height:"+(10)+"px'></p></div>"; 
			
		} 

		inline += "</div>"; 

		inline += "<div style='position:relative; top:100px; float:left; width:1px; height:100px;background-image:url(images/1x1bk.gif)'></div>"; 
	} 

	inline += "</div>"; 
	inline += "</div>"; 

	// bottom Pannel 
	inline += "<div style='clear:both; float:left; width:20px; height:20px; color:green;'>"; 
	inline += "<p style=' height:30px; font-size:8pt; line-height:25px;'>"+os+"</p>"; 
	inline += "</div>"; 

	inline += "<div style='float:left; width:690px; height:20px;'>"; 
	for( var idx=0; idx<date.length; idx++ ) 
	{ 
		inline += "<p style='height:10px; float:left; width:"+cellWidth+"px; line-height:30px; font-size:8pt;'>&nbsp;"+date[idx]+"</p>";  
	} 
</script>

</p>
<div class=layer2 style='font-size:10pt; color:limegreen;'>
<p><b>
<script type="text/javascript">
var a="<a style='width:55px;'>";
var b="<p style='height:";
var c="px;'></p>";
for( var idx=0; idx<scores.length; idx++ ) 
	document.write(a+scores[idx]+b+((scores[idx]+25)*3)+c);
</script></p></div>
<p><script type="text/javascript">document.getElementById('chart').innerHTML=inline;</script></p>
</div>
		</TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_33.gif" WIDTH=38 HEIGHT=250 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_34.gif" WIDTH=40 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_35.gif" WIDTH=37 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_36.gif" WIDTH=110 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_37.gif" WIDTH=63 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_38.gif" WIDTH=119 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_39.gif" WIDTH=20 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_40.gif" WIDTH=39 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_41.gif" WIDTH=20 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_42.gif" WIDTH=14 HEIGHT=11 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_43.gif" WIDTH=38 HEIGHT=11 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_44.gif" WIDTH=40 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_45.gif" WIDTH=37 HEIGHT=21 ALT=""></TD>
		<TD></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_47.gif" WIDTH=63 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_48.gif" WIDTH=119 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_49.gif" WIDTH=20 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_50.gif" WIDTH=39 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_51.gif" WIDTH=20 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_52.gif" WIDTH=14 HEIGHT=21 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_53.gif" WIDTH=38 HEIGHT=21 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_date/pop_date_54.gif" WIDTH=40 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_55.gif" WIDTH=37 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_56.gif" WIDTH=110 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_57.gif" WIDTH=63 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_58.gif" WIDTH=119 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_59.gif" WIDTH=20 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_60.gif" WIDTH=39 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_61.gif" WIDTH=20 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_62.gif" WIDTH=14 HEIGHT=50 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_date/pop_date_63.gif" WIDTH=38 HEIGHT=50 ALT=""></TD>
	</TR>
</TABLE>
</body>
</html>
