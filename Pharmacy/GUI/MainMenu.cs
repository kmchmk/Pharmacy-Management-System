using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
using Telerivet.Client;

namespace Pharmacy
{
    public partial class MainMenu : Form
    {


        RoutingDAO routingDao;
        ProductDAO productDao;
        List<Product> productList;
        Product tempSelectedProduct;//this is always temporary. This is the selected product of the list
        public MainMenu()
        {
            InitializeComponent();
            this.routingDao = new RoutingDAO();
            this.productDao = new ProductDAO();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Send_sms().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new RoutingDAO().getRoutingList(15);
        }

        private void smsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Send_sms().ShowDialog();
        }



        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void searchAndDisplay()
        {

            this.productList = productDao.getProductList(textBox2.Text);
            listBox1.Items.Clear();
            bool itemExist = false;
            foreach (Product i in productList)
            {
                listBox1.Items.Add(i.getProductName());
                itemExist = true;
            }
            if (itemExist)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            searchAndDisplay();
        }




        private void setDetails()
        {
            if (listBox1.SelectedIndex > -1)
            {
                tempSelectedProduct = productList[listBox1.SelectedIndex];
                label2.Text = tempSelectedProduct.getProductName();
                label4.Text = tempSelectedProduct.getBrand();
                label6.Text = tempSelectedProduct.getRackNo().ToString();
                label8.Text = tempSelectedProduct.getPrice().ToString();
                label10.Text = tempSelectedProduct.getCode();
                label12.Text = tempSelectedProduct.getDescription();
            }
            if (listBox1.SelectedIndex == -1)
            {
                label2.Text = "";
                label4.Text = "";
                label6.Text = "";
                label8.Text = "";
                label10.Text = "";
                label12.Text = "";
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDetails();
            //System.Diagnostics.Debug.WriteLine(listBox1.SelectedIndex);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddProduct().ShowDialog();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {




        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }


        private void refreshGUI(int eOrD)//e==1, d==2
        {
            if (eOrD == 1)
            {
                int selectedIndex = listBox1.SelectedIndex;
                searchAndDisplay();
                listBox1.SelectedIndex = selectedIndex;
            }
            else if (eOrD == 2)
            {
                searchAndDisplay();
            }
            setDetails();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                productDao.addProduct(new Product(0, i.ToString(), "test" + i.ToString(), "just", 12, 35.00, "this is just a test"));
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item first!");
                return;
            }
            int row = dataGridView1.RowCount;
            int quantity = Int32.Parse(comboBox1.Text);
            dataGridView1.Rows.Add();
            dataGridView1.Height = dataGridView1.Height + dataGridView1.Rows[row].Height;
            dataGridView1.Rows[row].Cells[0].Value = tempSelectedProduct.getProductName().ToString();
            dataGridView1.Rows[row].Cells[1].Value = quantity;
            dataGridView1.Rows[row].Cells[2].Value = tempSelectedProduct.getPrice() * quantity;


            comboBox1.Text = "1";
            calculateTotal();

        }

        private void calculateTotal()
        {
            double sum = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            label15.Text = sum.ToString() + " Rs.";
        }


        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Send_sms().ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddProduct().ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item first!");
                return;
            }


            new AddProduct(tempSelectedProduct).ShowDialog();





            refreshGUI(1);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item first!");
                return;
            }
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }



            productDao.deleteProduct(tempSelectedProduct);


            refreshGUI(2);
        }

        private void button1_Click_4(object sender, EventArgs e)
        {


            System.Diagnostics.Debug.WriteLine(DateTime.UtcNow.Date + new TimeSpan(7, 0, 0) > DateTime.UtcNow);

            System.Diagnostics.Debug.WriteLine(DateTime.UtcNow);
            System.Diagnostics.Debug.WriteLine(DateTime.Now);

















            /*
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            System.Diagnostics.Debug.WriteLine(reply.Status);
            System.Diagnostics.Debug.WriteLine(IPStatus.Success);
            if (reply.Status == IPStatus.Success)
            {
                System.Diagnostics.Debug.WriteLine("Internet is connected");
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("");
            }

            
            
            //string webConnStr = "SERVER =  sql301.byetcluster.com ; PORT = 3306 ; DATABASE= ltm_17966125_pharmacy ;  UID= ltm_17966125 ;PASSWORD= 123456789;";
            string webConnStr = "Server = sql301.byetcluster.com; Database = ltm_17966125_pharmacy; User Id = ltm_17966125; Password = 123456789;";

           // MySqlConnection webConn = new MySqlConnection(webConnStr);

            MySqlConnection webConn = new MySqlConnection("Data Source = sql301.ultimatefreehost.in; Initial Catalog = ltm_17966125_pharmacy; User Id = ltm_17966125; Password = 123456789;");

            

            //MySqlConnection webConn = new dbConnection().getWebConnection();

            try
            {
                webConn.Open();
                //string query = "select id, code, productName, brand, rackNo, price, description from product where productName like @searchKey or code like @searchKey or brand like @searchKey";
    /*          string query = "select * from product";
                MySqlCommand cmd = new MySqlCommand(query, webConn);
                //cmd.Parameters.AddWithValue("searchKey", "%" + searchKey + "%");
                MySqlDataReader result = cmd.ExecuteReader();
                int i = 0;
                while (result.Read())
                {
                    i++;
                   //productList.Add(new Product(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetInt32(4), result.GetDouble(5), result.GetString(6)));
                }
                System.Diagnostics.Debug.WriteLine(i);
     
      
     
     

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in getWebData method...");
            }
            finally
            {
                if (webConn != null)
                {
                    webConn.Close();
                }
            }







           

            


*/
        }



        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewCustomers().Show();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            string apiKey = "17SdmOculXGRr0ggJ8A7gV9qbiL06Hq6";
            string projectID = "PJfe487b37facfa08c";
            string number = "0717899366";
            string content = textBox1.Text;

            TelerivetClass testclass = new TelerivetClass();
            //testclass.sendSMS(apiKey, projectID, content, number);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }
            calculateTotal();
        }
    }
}