using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class CustomerDAO
    {
        MySqlConnection conn;
        DAO dao;
        public CustomerDAO()
        {
            this.conn = new dbConnection().getConnection();
            this.dao = new DAO();
        }

        public int addCustomer(Customer customer)
        {
            try
            {

                conn.Open();
                string query = "INSERT INTO customer (customerName, phoneNumber) VALUES (@customerName, @phoneNumber)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("customerName", customer.getName());
                cmd.Parameters.AddWithValue("phoneNumber", customer.getTelephoneNumber());

                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in addCustomer method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dao.getLastInsertedAutoIncrementedID();
        }




        public List<Customer> getCustomerList(string searchKey)
        {

            List<Customer> customerList = new List<Customer>();
           
            
                try
                {
                    conn.Open();
                    string query = "select customerID, customerName, phoneNumber from customer where customerName like @searchKey or phoneNumber like @searchKey";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("searchKey", "%" + searchKey + "%");
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {

                        //System.Diagnostics.Debug.WriteLine(result.GetInt32(0));//To avoid null exceptions
                        customerList.Add(new Customer(result.GetInt32(0), result.GetString(1), result.GetString(2)));
                    }
                    System.Diagnostics.Debug.WriteLine("------------");

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Something went wrong in getCustomerList method...");
                }

                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                // System.Diagnostics.Debug.WriteLine("------------------------");


            
            
            return customerList;
        }
            
        







    }
}
