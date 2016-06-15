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
using System.Threading;

namespace Pharmacy
{
    public partial class MainMenu : Form
    {

        RoutingDAO routingDao;
        ProductDAO productDao;
        WebDAO webDao;
        List<Product> productList;
        Product tempSelectedProduct;//this is always temporary. This is the selected product of the list

        string password;
        string username;

        public MainMenu()
        {



            this.ShowInTaskbar = false;
            InitializeComponent();
            this.routingDao = new RoutingDAO();
            this.productDao = new ProductDAO();
            this.webDao = new WebDAO();
            searchAndDisplay();


            new Login(this,"","",0).Show();
            this.Opacity = 0;
        }

        public void startMainMenu(string username,            string password)
        {

            this.ShowInTaskbar = true;
            this.Opacity = 100;
            this.username = username;
            this.password = password;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegisterCustomer().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new RoutingDAO().getRoutingList(15);
        }

        private void smsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterCustomer().ShowDialog();
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
            refreshGUI(2);
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
                label8.Text = tempSelectedProduct.getPrice().ToString() + " Rs.";
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
                MessageBox.Show("Select an item first!", "Error");
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
            calculateTotal(sender, e);

        }

        private void calculateTotal(object sender, EventArgs e)
        {
            double sum = 0.00;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sum = sum + Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }

            label15.Text = sum.ToString() + " Rs.";

            double payment = 0.00;
            Double.TryParse(textBox3.Text, out payment);

            double balance = payment - sum;
            if (balance < 0)
            {
                label18.Text = "More " + (-balance).ToString() + " Rs. needed.";
            }
            else
            {
                label18.Text = balance.ToString() + " Rs.";
            }




        }


        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterCustomer().ShowDialog();
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
            button6_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            button7_Click(sender, e);
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            webDao.UpdateWebDatabaseFromLocalatabase();

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
            /*     string apiKey = "17SdmOculXGRr0ggJ8A7gV9qbiL06Hq6";
                 string projectID = "PJfe487b37facfa08c";
                 string number = "0717899366";
                 string content = textBox1.Text;

                 TelerivetClass testclass = new TelerivetClass();
                 //testclass.sendSMS(apiKey, projectID, content, number);
             * */
        }

        public void setDataGridViewHeight()
        {

            var height = 30;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                height += dr.Height;
            }

            dataGridView1.Height = height;


        }


        private void button4_Click(object sender, EventArgs e)
        {
            Boolean selected = false;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
                selected = true;
            }
            setDataGridViewHeight();





            if (selected)
            {
                calculateTotal(sender, e);
            }
            else
            {
                MessageBox.Show("Select a row", "Error");
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {



            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item first!", "Error");
                return;
            }



            new Login(this, username, password,1).Show();






        }
        public void returnFromEditPasswordAcception(){



            new AddProduct(tempSelectedProduct).ShowDialog();
            refreshGUI(1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item first!", "Error");
                return;
            }


            new Login(this, username, password,2).Show();
        }
        public void returnFromDeletePasswordAcception()
        {

            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }



            productDao.deleteProduct(tempSelectedProduct);


            refreshGUI(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AddProduct().ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            new ViewCustomers().ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new RegisterCustomer().ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            calculateTotal(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            dataGridView1.Rows.Clear();
            setDataGridViewHeight();
            calculateTotal(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            webDao.UpdateWebDatabaseFromLocalatabase();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button12_Click(object sender, EventArgs e)
        {


        }

        int i = 0;

        private void button12_Click_1(object sender, EventArgs e)
        {
            List<string> name = new List<string> { "Acetaminophen", "Adderall", "Alprazolam", "Amitriptyline", "Amlodipine", "Amoxicillin", "Ativan", "Atorvastatin", "Azithromycin", "Ciprofloxacin", "Citalopram", "Clindamycin", "Clonazepam", "Codeine", "Cyclobenzaprine", "Cymbalta", "Doxycycline", "Gabapentin", "Hydrochlorothiazide", "Ibuprofen", "Lexapro", "Lisinopril", "Loratadine", "Lorazepam", "Losartan", "Lyrica", "Meloxicam", "Metformin", "Metoprolol", "Naproxen", "Omeprazole", "Oxycodone", "Pantoprazole", "Prednisone", "Tramadol", "Trazodone", "Viagra", "Wellbutrin", "Xanax", "Zoloft" };
            List<string> description = new List<string> { "the gastrointestinal tract (digestive system)", "For the cardiovascular system", "the central nervous system", "pain (analgesic drugs)", "musculo-skeletal disorders", "the eye", "the ear, nose and oropharynx", "the respiratory system", "endocrine problems", "For the reproductive system or urinary system", "For contraception", "For obstetrics and gynecology", "For the skin", "For infections and infestations", "For the immune system", "For allergic disorders", "For nutrition", "For neoplastic disorders", "For diagnostics", "For euthanasia", "the gastrointestinal tract (digestive system)", "For the cardiovascular system", "the central nervous system", "pain (analgesic drugs)", "musculo-skeletal disorders", "the eye", "the ear, nose and oropharynx", "the respiratory system", "endocrine problems", "For the reproductive system or urinary system", "For contraception", "For obstetrics and gynecology", "For the skin", "For infections and infestations", "For the immune system", "For allergic disorders", "For nutrition", "For neoplastic disorders", "For diagnostics", "For euthanasia" };
            List<string> brand = new List<string> { "A & Z Pharmaceutical, Inc.", "A-S Medication Solutions, LLC", "AAIPharma", "Abbott Laboratories", "AbbVie Inc.", "Acadia Pharmaceuticals, Inc.", "Accord Healthcare Inc.", "Accredo Health Group, Inc.", "Acella Pharmaceuticals, LLC", "Acorda Therapeutics, Inc.", "Actavis Pharma, Inc.", "Actelion Pharmaceuticals US, Inc.", "Acura Pharmaceuticals, Inc.", "Acusphere, Inc.", "Adapt Pharma, Inc.", "Adeona Pharmaceuticals, Inc.,", "Adolor Corporation", "Advance Pharmaceuticals Inc.", "Advanced Life Sciences, Inc", "Advanced Pharmaceutical Services Inc", "A & Z Pharmaceutical, Inc.", "A-S Medication Solutions, LLC", "AAIPharma", "Abbott Laboratories", "AbbVie Inc.", "Acadia Pharmaceuticals, Inc.", "Accord Healthcare Inc.", "Accredo Health Group, Inc.", "Acella Pharmaceuticals, LLC", "Acorda Therapeutics, Inc.", "Actavis Pharma, Inc.", "Actelion Pharmaceuticals US, Inc.", "Acura Pharmaceuticals, Inc.", "Acusphere, Inc.", "Adapt Pharma, Inc.", "Adeona Pharmaceuticals, Inc.,", "Adolor Corporation", "Advance Pharmaceuticals Inc.", "Advanced Life Sciences, Inc", "Advanced Pharmaceutical Services Inc" };
            List<int> price = new List<int> { 50, 30, 70, 110, 190, 180, 30, 40, 90, 190, 80, 150, 100, 10, 130, 180, 130, 60, 190, 170, 170, 40, 140, 140, 170, 60, 80, 70, 60, 150, 120, 70, 190, 10, 20, 70, 150, 70, 70, 170 };
            List<int> rack = new List<int> { 2, 2, 12, 0, 5, 12, 0, 12, 2, 15, 1, 2, 2, 11, 11, 15, 9, 14, 4, 9, 5, 12, 13, 1, 5, 14, 13, 0, 11, 7, 10, 11, 4, 7, 3, 11, 8, 14, 14, 0 };
            List<string> code = new List<string> { "900a", "901b", "902c", "903d", "904e", "905f", "906g", "907h", "908i", "909j", "910k", "911l", "912m", "913n", "914o", "915p", "916q", "917r", "918s", "919t", "920u", "921v", "922w", "923x", "924y", "925z", "926a", "927b", "928c", "929d", "930e", "931f", "932g", "933h", "934i", "935j", "936k", "937l", "938m", "939n" };
            if (i > 39)
            {
                MessageBox.Show("i > 39");
                return;
            }
                productDao.addProduct(new Product(0, code[i], name[i], brand[i], rack[i], price[i], description[i]));
                i++;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            productDao.deleteAllProduct();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 41; i++)
            {
                button12_Click_1(sender, e);
            }
        }



    }
}