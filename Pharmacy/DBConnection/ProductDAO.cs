using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class ProductDAO
    {
        MySqlConnection conn;
        WebDAO webDao;
        DAO dao;
        public ProductDAO()
        {
            this.conn = new dbConnection().getConnection();
            this.webDao = new WebDAO();
            dao = new DAO();
        }

        public List<Product> getProductList(string searchKey)
        {

            List<Product> productList = new List<Product>();
            if (1 == 1)//searchKey != "")               //if the search box is empty commented code will return nothing
            {
                try
                {
                    conn.Open();

                    string query = "select id, code, productName, brand, rackNo, price, description from product where productName like @searchKey or code like @searchKey or brand like @searchKey";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("searchKey", "%" + searchKey + "%");
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        // System.Diagnostics.Debug.WriteLine(result.GetString(1));//To avoid null exceptions
                        productList.Add(new Product(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetInt32(4), result.GetDouble(5), result.GetString(6)));
                    }
                    //System.Diagnostics.Debug.WriteLine(result);

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Something went wrong in getProductList method...");
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                // System.Diagnostics.Debug.WriteLine("------------------------");


            }


            return productList;
        }





        public void updateProduct(Product tempProduct)
        {


            try
            {

                conn.Open();

                string query = "UPDATE product set code = @code, productName = @productName, brand = @brand, rackNo = @rackNo, price = @price, description = @description where id = @id";



                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("code", tempProduct.getCode());
                cmd.Parameters.AddWithValue("productName", tempProduct.getProductName());
                cmd.Parameters.AddWithValue("brand", tempProduct.getBrand());
                cmd.Parameters.AddWithValue("rackNo", tempProduct.getRackNo());
                cmd.Parameters.AddWithValue("price", tempProduct.getPrice());
                cmd.Parameters.AddWithValue("description", tempProduct.getDescription());
                cmd.Parameters.AddWithValue("id", tempProduct.getID());


                cmd.ExecuteNonQuery();

                close();
                webDao.UpdateWebDatabase(cmd);
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in updateProduct method...");

            }
            finally
            {
                close();
            }
        }



        public void close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }



        public void addProduct(Product product)
        {


            try
            {





                conn.Open();

                int maxID = 1;
                string query2 = "SELECT MAX(id) FROM product";

                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlDataReader result2 = cmd2.ExecuteReader();
                if (result2.Read())
                {
                    try
                    {
                        maxID = result2.GetInt32(0) + 1;
                    }
                    catch (SqlNullValueException e)
                    {

                    }
                }
                Console.WriteLine(maxID);

                close();






                conn.Open();
                string query = "INSERT INTO product (id, code, productName, brand, rackNo, price, description) VALUES (@id, @code, @productName, @brand, @rackNo, @price, @description);";
                MySqlCommand cmd = new MySqlCommand(query, conn);





                cmd.Parameters.AddWithValue("id", maxID);
                cmd.Parameters.AddWithValue("code", product.getCode());
                cmd.Parameters.AddWithValue("productName", product.getProductName());
                cmd.Parameters.AddWithValue("brand", product.getBrand());
                cmd.Parameters.AddWithValue("rackNo", product.getRackNo());
                cmd.Parameters.AddWithValue("price", product.getPrice());
                cmd.Parameters.AddWithValue("description", product.getDescription());
                cmd.ExecuteNonQuery();



                webDao.UpdateWebDatabase(cmd);



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in addProduct method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }



        public void deleteProduct(Product product)
        {
            try
            {

                conn.Open();


                string query = "DELETE from product where id = @id";
                //   string query = "DELETE from product where 1=1";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("id", product.getID());

                cmd.ExecuteNonQuery();
                close();
                webDao.UpdateWebDatabase(cmd);
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in deleteProduct method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void deleteAllProduct()
        {
            try
            {

                conn.Open();
                string query = "DELETE from product where 1=1";

                MySqlCommand cmd = new MySqlCommand(query, conn);


                cmd.ExecuteNonQuery();

                close();
                webDao.UpdateWebDatabase(cmd);
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in deleteAllProduct method...");

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