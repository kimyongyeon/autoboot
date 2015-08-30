<?php
include "dbconn.php";
?>
<script language=javascript>
function go(one){ 
    location.href="http://localhost/autobot/pop_loca.php/?date="+one; 
} 
function init()
{
	for(i=0;i<3;i++)
	{
		eval("chart" + i + ".filters[0].apply()");
		eval("chart" + i + ".style.visibility = 'visible'");
		eval("chart" + i + ".filters[0].play()");
	}
}
</script>
<html>
	<head>
		<meta http-equiv="content-type" content="text/html; charset=euc-kr">
	<title>위치별 측정값 그래프</title>
	<meta name="generator" content="Namo WebEditor v6.0">
	</head>
<style>
.layer3 {
  position: absolute;
  top:333; left:100;
  z-index: 3
}
</style>

<div class=layer3>			
<?
	$query = "select distinct Sens_Date from sensing";
	$result = mysql_query($query,$connect);

	echo "<select name='date' style='background:#D1E37A; color:#797979; font-size:8pt' onchange=go(this.value)>";
	echo "<option value=''>-선택-</option>";
	while($row = mysql_fetch_array($result))
	{
		echo"<option value='$row[Sens_Date]'>$row[Sens_Date]</option>";
	}
	echo "</select>";
?>
</div>
<TABLE WIDTH=500 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<TR>
		<TD COLSPAN=7><IMG SRC="/autobot/pop_loca/pop_loca_01.gif" WIDTH=500 HEIGHT=68 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=4><IMG SRC="/autobot/pop_loca/pop_loca_02.gif" WIDTH=39 HEIGHT=332 ALT=""></TD>
		<TD COLSPAN=5>
<body topmargin="0" leftmargin="0" onload=init()>
<div style="width:420; height:250; position:absolute; left:70; top:95; z-index:1;">
<script language=javascript>
function data(a,b)
{
	var data=new Array(a*5,b*5,50); //여기서 막대의 수치값을 조절
	var name=new Array(1,2,3);
	for(i=0;i<data.length;i++)
	{
		document.write("<div style='color:dimgray;font-style:bold;font-size:20pt;font-family:lucida Console;'>"+ name[i] +"</div> <div id=chart" + i + " style='filter: revealTrans(duration=1, transition=20); visibility: hidden;width:35;height:35;background:gold;left:0;top:"+ i*70 + ";border:1; solid;text-align:right;padding-right:1px;color:limegreen;font-size:20pt;font-family:lucida Console;font-style:bold;'>"+ data[i]/5 +"</div>");
	}
	for(i=0;i<data.length;i++)
	{
		if(eval("chart" + i + ".style.pixelWidth") < data[i])
		{
			gph("chart" + i,data[i]);
		}
	}
}
function gph(what,limit)
{
	if(eval(what + ".style.pixelWidth") < limit){
	eval(what +".style.pixelWidth=" + what + ".style.pixelWidth + 10");
	setTimeout("gph('"+ what + "'," + limit + ")",100);
}}
</script>
<?php
$query = "select Node_Num, AVG(Sens_val)";
$query .= " from sensing";
$query .= " Where Sens_Date = '$date'";
$query .= " group by Node_Num";

$result = mysql_query($query, $connect);
$row = mysql_fetch_array($result);

if(!$row[Node_Num])
{
	echo("<div align='center'></div>");
}
else
{
	$a = round(mysql_result($result, 0, 1));
	$b = round(mysql_result($result, 1, 1));
	//$c = round(mysql_result($result, 2, 1));
	?>
	<script language=javascript>
	data("<?=$a;?>","<?=$b;?>");
	</script>
<?}?>

		</TD>
		<TD><IMG SRC="/autobot/pop_loca/pop_loca_04.gif" WIDTH=40 HEIGHT=250 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=6><IMG SRC="/autobot/pop_loca/pop_loca_05.gif" WIDTH=461 HEIGHT=16 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=2><IMG SRC="/autobot/pop_loca/pop_loca_06.gif" WIDTH=60 HEIGHT=66 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/pop_loca_07.gif" WIDTH=108 HEIGHT=16 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/pop_loca_08.gif" WIDTH=112 HEIGHT=16 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/pop_loca_09.gif" WIDTH=45 HEIGHT=16 ALT=""></TD>
		<TD COLSPAN=2><IMG SRC="/autobot/pop_loca/pop_loca_10.gif" WIDTH=136 HEIGHT=16 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=5><IMG SRC="/autobot/pop_loca/pop_loca_11.gif" WIDTH=401 HEIGHT=50 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=39 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=60 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=108 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=112 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=45 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=96 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_loca/spacer.gif" WIDTH=40 HEIGHT=1 ALT=""></TD>
	</TR>
</TABLE>
</body>
</html>
