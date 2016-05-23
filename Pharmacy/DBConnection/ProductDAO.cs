using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class ProductDAO
    {
        MySqlConnection conn;

        public ProductDAO()
        {
            this.conn = new dbConnection().getConnection();
        }

        public List<Product> getProductList(string searchKey)
        {

            List<Product> productList = new List<Product>();
            if (searchKey != "")
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
                //System.Diagnostics.Debug.WriteLine("chanaa");



            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in updateProduct method...");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }







        public void addProduct(Product product)
        {


            try
            {

                conn.Open();


                string query = "INSERT INTO product (code, productName, brand, rackNo, price, description) VALUES (@code, @productName, @brand, @rackNo, @price, @description)";


                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("code", product.getCode());
                cmd.Parameters.AddWithValue("productName", product.getProductName());
                cmd.Parameters.AddWithValue("brand", product.getBrand());
                cmd.Parameters.AddWithValue("rackNo", product.getRackNo());
                cmd.Parameters.AddWithValue("price", product.getPrice());
                cmd.Parameters.AddWithValue("description", product.getDescription());

                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("chanaa");



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


                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("id", product.getID());


                cmd.ExecuteNonQuery();
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
    }
}