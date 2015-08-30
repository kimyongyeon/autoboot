<?        
	// PEAR Framework 사용
	function call_pear_init() {
		ini_set('include_path','C:/APM_Setup/Server/PHP5/PEAR/;'.ini_get('include_path'));	// include_path 연결시 마지막에 ; 
			}	
	
	// PEAR Framework DB 사용
	function call_pear_db_dsn() {		
		$dsn = array(
		 'phptype'  => 'mysql',
		 'hostspec' => 'localhost',
		 'database' => 'navi_info',
		 'username' => 'root',
		 'password' => 'tpakfl'         
		);		
		return($dsn);
	}		
?>