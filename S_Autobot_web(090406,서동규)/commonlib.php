<?        
	// PEAR Framework ���
	function call_pear_init() {
		ini_set('include_path','C:/APM_Setup/Server/PHP5/PEAR/;'.ini_get('include_path'));	// include_path ����� �������� ; 
			}	
	
	// PEAR Framework DB ���
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