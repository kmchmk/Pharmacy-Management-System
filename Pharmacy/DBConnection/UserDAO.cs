using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pharmacy
{

    class UserDAO
    {
        MySqlConnection conn;
        public UserDAO()
        {
            this.conn = new dbConnection().getConnection();

        }

        public bool isPasswordMatch(string username, string password){
            
            try
            {

                conn.Open();
                string query = "SELECT EXISTS(SELECT * FROM user WHERE username = @username and password = @password)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                MySqlDataReader result = cmd.ExecuteReader();
                result.Read();

                if(result.GetInt32(0) == 1){
                    return true;
                }
                else {
                    return false;
                }
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in deleteProduct method...");
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




        public string getEmail(string username){
            try
            {

                conn.Open();
                string query = "SELECT email FROM user WHERE username = @username";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("username", username);
                MySqlDataReader result = cmd.ExecuteReader();
                result.Read();

                return result.GetString(0);

                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getEmail method...");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return "";
        }





        public string getPassword(string username)
        {
            try
            {

                conn.Open();
                string query = "SELECT password FROM user WHERE username = @username";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("username", username);
                MySqlDataReader result = cmd.ExecuteReader();
                result.Read();

                return result.GetString(0);

                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getPassword method...");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return "";
        }
    }
}
