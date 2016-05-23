using MySql.Data;
using MySql.Data.MySqlClient;

namespace Pharmacy
{

    public class dbConnection
    {
        // Connection String
        string ConnStr = "server=localhost;user id=root;password=1234;database=pharmacy";








       // server = "pc-name-whateveritis";
//database = "restaurantdb";
//uid = "root";
//password = "";
//string connectionString;
//connectionString = "SERVER=" + server + "; PORT = 3306 ;" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";




        string webConnStr = "SERVER=  sql301.byetcluster.com ; PORT = 3306 ; DATABASE= ltm_17966125_pharmacy ;  UID= ltm_17966125 ;PASSWORD= 123456789;";

       // string webConnStr = "server=sql301.ultimatefreehost.in;PORT = 3306 ;UID=ltm_17966125;password=chuttebuydssc;database=ltm_17966125_tb";
        
        
        
        
        
        
        
        
        
        
        MySqlConnection conn = null;
        MySqlConnection webConn = null;

        public dbConnection()
        {
            conn = new MySqlConnection(ConnStr);
            webConn = new MySqlConnection(webConnStr);
        }
        

        public MySqlConnection getConnection(){
            return conn;
        }

        public MySqlConnection getWebConnection()
        {
            return webConn;
        }

    }
}
