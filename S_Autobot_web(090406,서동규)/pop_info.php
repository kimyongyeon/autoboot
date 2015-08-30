<?php
include "dbconn.php";
?>
<script language="javascript">
function go(one){ 
    location.href="http://localhost/autobot/pop_info.php/?day="+one; 
} 
</script> 
<HTML>
<HEAD>
<TITLE>주행정보</TITLE>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=euc-kr">
</HEAD>
<BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0 text="black" link="blue" vlink="purple" alink="red">
<style>
.layer3 {
  position: absolute;
  top:333; left:100;
  z-index: 3
}
.layer4 {
  position: absolute;
  top:123; left:37;
  z-index: 4
}
</style>
<div class=layer4>
<form name="info">
<table border="0" width="422">
<?
$query = "select Datetime, First, Second, Third";
$query .= " From setting";
$query .= " Where Date = '$day'";

$result = mysql_query($query, $connect);
$total = mysql_affected_rows();
$row = mysql_fetch_array($result);
if(!$row[Datetime])
{
	echo("<div align='center'></div>");
}
else
{
	if(!$start) 
	{
		$start=0;
	}
	 for($i=$start; $i<$total; $i++)
	{
		 mysql_data_seek($result, $i);
		 $rows = mysql_fetch_array($result);
		 ?>
			<tr>
				<td width="94" height="31" align="center" valign="middle"><p align="center"><font size="2" face="돋움"><?=$rows[Datetime]?></font></p></td>
				<td width="116" height="31" align="center" valign="middle"><?=$rows[First]?></td>
				<td width="101" height="31" align="center" valign="middle"><?=$rows[Second]?></td>
				<td width="93" height="31" align="center" valign="middle"><?=$rows[Third]?></td>
			</tr>
		<?
	}
}?>
</table></form></div>
<div class=layer3>			
<?
	$query = "select distinct Date from setting order by Date asc ";
	$result = mysql_query($query,$connect);

	echo "<select name='navi' style='background:#D1E37A; color:#797979; font-size:8pt' onchange=go(this.value)>";
	echo "<option value=''>-선택-</option>";
	while($row = mysql_fetch_array($result))
	{
		echo"<option value='$row[Date]'>$row[Date]</option>";
	}
	echo "</select>";
?>
</div>

<TABLE WIDTH=500 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<TR><TD COLSPAN=5 height="105"><IMG SRC="/autobot/pop_info/pop_info_01.gif" WIDTH=500 HEIGHT=122 ALT=""></TD>
	</TR>	
	<TR>
		<TD ROWSPAN=4 height="249"><IMG SRC="/autobot/pop_info/pop_info_02.gif" WIDTH=35 HEIGHT=278 ALT=""></TD>
		<TD COLSPAN=3 height="162"><IMG SRC="/autobot/pop_info/pop_info_03.gif" WIDTH=430 HEIGHT=196 ALT=""></TD>
		<TD height="162"><IMG SRC="/autobot/pop_info/pop_info_04.gif" WIDTH=35 HEIGHT=196 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=3><IMG SRC="/autobot/pop_info/pop_info_05.gif" WIDTH=64 HEIGHT=82 ALT=""></TD>
		<TD COLSPAN=3><IMG SRC="/autobot/pop_info/pop_info_06.gif" WIDTH=401 HEIGHT=16 ALT=""></TD>
	</TR>
	<TR>
		<TD></TD>
		<TD COLSPAN=2><IMG SRC="/autobot/pop_info/pop_info_08.gif" WIDTH=293 HEIGHT=16 ALT=""></TD>
	</TR>
	<TR><TD COLSPAN=3><IMG SRC="/autobot/pop_info/pop_info_09.gif" WIDTH=401 HEIGHT=50 ALT=""></TD>
	</TR>
	<TR>
		<TD><IMG SRC="/autobot/pop_info/spacer.gif" WIDTH=35 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_info/spacer.gif" WIDTH=64 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_info/spacer.gif" WIDTH=108 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_info/spacer.gif" WIDTH=258 HEIGHT=1 ALT=""></TD>
		<TD><IMG SRC="/autobot/pop_info/spacer.gif" WIDTH=35 HEIGHT=1 ALT=""></TD>
	</TR>
</TABLE>
</BODY>
</HTML>