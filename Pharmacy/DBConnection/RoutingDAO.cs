using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace Pharmacy
{
    class RoutingDAO
    {
        MySqlConnection conn;

        public RoutingDAO()
        {
            this.conn = new dbConnection().getConnection();
        }




        public void addRouting(Routing routing)
        {

            //int how - if not selected 0, if with meals 1, if per hours 2, if at a time 3
            //if ticked, 1. else 0
            try
            {

                conn.Open();
                string query = "INSERT INTO routing (customerID, medicineName, how, breakfast, lunch, dinner, beforeOrAfter, hours, time) VALUES (@customerID, @medicineName, @how, @breakfast, @lunch, @dinner, @beforeOrAfter, @hours, @time)";




                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("customerID", routing.getCustomerID());
                cmd.Parameters.AddWithValue("medicineName", routing.getMedicineName());
                cmd.Parameters.AddWithValue("how", routing.getHow());
                cmd.Parameters.AddWithValue("breakfast", routing.getBreakfast());
                cmd.Parameters.AddWithValue("lunch", routing.getLunch());
                cmd.Parameters.AddWithValue("dinner", routing.getDinner());
                cmd.Parameters.AddWithValue("beforeOrAfter", routing.getBeforeOrAfter());
                cmd.Parameters.AddWithValue("hours", routing.getHours());
                cmd.Parameters.AddWithValue("time", routing.getTime());


                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in addRouting method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




        public List<Routing> getRoutingList(int customerID)
        {

            List<Routing> routingList = new List<Routing>();

            try
            {
                conn.Open();
                string query = "select customerID, medicineName, how, breakfast, lunch, dinner, beforeOrAfter, hours, time from routing where routing.customerID = @customerID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("customerID", customerID);
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {

                    // System.Diagnostics.Debug.WriteLine(result.GetString(1));//To avoid null exceptions
                    routingList.Add(new Routing(result.GetInt32(0), result.GetString(1), result.GetInt32(2), result.GetInt32(3), result.GetInt32(4), result.GetInt32(5), result.GetInt32(6), result.GetInt32(7), result[8] as DateTime?));
                }
                //System.Diagnostics.Debug.WriteLine(result);

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getRoutingList method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            // System.Diagnostics.Debug.WriteLine("------------------------");

            return routingList;
        }



        public void deleteRouting(int routingID)
        {
            try
            {

                conn.Open();
                string query = "delete from routing where id = @routingID";


                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("routingID", routingID);


                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in DeleteRouting method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }






    }
}
