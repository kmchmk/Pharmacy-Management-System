using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using MySql.Data.MySqlClient;



namespace Pharmacy
{
    class WebDAO
    {
        MySqlConnection conn;
        public WebDAO()
        {
            this.conn = new dbConnection().getConnection();
        }
        public void UpdateWebDatabase(MySqlCommand cmd)
        {
            string url = "http://msquad.tk/updateDatabase.php";



            string newQueryData = cmd.CommandText;
            foreach (MySqlParameter p in cmd.Parameters)
            {
                newQueryData = newQueryData.Replace("@" + p.ParameterName, "'" + p.Value.ToString() + "'");
            }

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;





                List<QueryData> queryDataList = getQueryDataList();



                bool empty = true;
                bool broke = false;
                foreach (QueryData q in queryDataList)
                {
                    empty = false;
                    try
                    {
                        string reply = "";
                        using (WebClient client = new WebClient())
                        {
                            reply = client.UploadString(url, q.getQueryData());
                        }
                        if ("Done".Equals(reply))
                        {
                            deleteQueryData(q.getID());
                        }
                        else
                        {
                            addQueryData(newQueryData);
                            broke = true;
                            break;
                        }
                    }
                    catch (WebException e)
                    {
                        addQueryData(newQueryData);
                        broke = true;
                        break;
                    }
                }

                if (empty | !broke)
                {
                    try
                    {
                        string reply = "";
                        using (WebClient client = new WebClient())
                        {
                            reply = client.UploadString(url, newQueryData);
                        }
                        if (!"Done".Equals(reply))
                        {
                            addQueryData(newQueryData);
                        }
                    }
                    catch (WebException e)
                    {
                        addQueryData(newQueryData);
                    }
                }
            }).Start();




        }


        public void addQueryData(string queryData)
        {


            try
            {

                conn.Open();
                string query = "INSERT INTO web (queryData) VALUES (@queryData)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("queryData", queryData);

                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in addWeb method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }



        public List<QueryData> getQueryDataList()
        {

            List<QueryData> queryDataList = new List<QueryData>();

            try
            {
                conn.Open();
                string query = "select id, queryData from web";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    // System.Diagnostics.Debug.WriteLine(result.GetString(1));//To avoid null exceptions
                    queryDataList.Add(new QueryData(result.GetInt32(0), result.GetString(1)));
                }
                //System.Diagnostics.Debug.WriteLine(result);

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getQueryDataList method...");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            // System.Diagnostics.Debug.WriteLine("------------------------");





            return queryDataList;
        }









        public void deleteQueryData(int id)
        {

            try
            {

                conn.Open();
                string query = "DELETE FROM web where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in deleteQueryData method...");

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
