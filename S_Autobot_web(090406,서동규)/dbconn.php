<? 
$connect = mysql_connect("localhost","root","tpakfl") or die("SQL server에 연결할 수 없습니다."); 
mysql_select_db("navi_info",$connect);
mysql_query("set names euckr");
?>