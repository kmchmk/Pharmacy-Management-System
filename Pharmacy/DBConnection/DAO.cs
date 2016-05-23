using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class DAO
    {

        MySqlConnection conn;

        public DAO()
        {
            this.conn = new dbConnection().getConnection();
        }




        public int getLastInsertedAutoIncrementedID()
        {
            int returnValue = -1;
            try
            {
                conn.Open();
                string query = "select Last_insert_id()";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader result = cmd.ExecuteReader();


                if (result.Read())
                {
                    returnValue = result.GetInt32(0);
                }
                //System.Diagnostics.Debug.WriteLine(result);

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getLastInsertedCustomerID method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }


            return returnValue;
        }












    }
}
