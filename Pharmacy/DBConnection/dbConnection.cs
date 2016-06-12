using MySql.Data;
using MySql.Data.MySqlClient;

namespace Pharmacy
{

    public class dbConnection
    {
        // Connection String
        string ConnStr = "server=localhost;user id=malithtk_chanaka;password=123chanaka123;database=malithtk_pharmacy";

        MySqlConnection conn = null;


        public dbConnection()
        {
            conn = new MySqlConnection(ConnStr);
        }
        

        public MySqlConnection getConnection(){
            return conn;
        }

    }
}
