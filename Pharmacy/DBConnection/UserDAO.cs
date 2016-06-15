using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encrypt;

namespace Pharmacy
{

    class UserDAO
    {
        MySqlConnection conn;
        EncryptDecrypt encryptDecrypt;

        public UserDAO()
        {
            this.conn = new dbConnection().getConnection();
            this.encryptDecrypt = new EncryptDecrypt();
        }

        public bool isPasswordMatch(string username, string Unencryptedpassword)
        {

            string password = encryptDecrypt.passwordEncrypt(Unencryptedpassword,"keyisthekey");

            try
            {

                conn.Open();
                string query = "SELECT EXISTS(SELECT * FROM user WHERE username = @username and password = @password)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                MySqlDataReader result = cmd.ExecuteReader();

                result.Read();

                if (result.GetInt32(0) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in isPasswordMatch method...");
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




        public string getEmail(string username)
        {
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

                return encryptDecrypt.passwordDecrypt(result.GetString(0), "keyisthekey");

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
