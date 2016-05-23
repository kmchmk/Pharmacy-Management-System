using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class AddProduct : Form
    {
        ProductDAO productDao;
        Product tempProduct;
        public AddProduct()
        {
            InitializeComponent();
            this.productDao = new ProductDAO();
        }

        public AddProduct(Product tempProduct)
        {
            InitializeComponent();
            this.productDao = new ProductDAO();


            this.tempProduct = tempProduct;
            textBox1.Text = tempProduct.getProductName();
            textBox2.Text = tempProduct.getBrand();
            textBox3.Text = tempProduct.getRackNo().ToString();
            textBox4.Text = tempProduct.getPrice().ToString();
            textBox5.Text = tempProduct.getCode();
            textBox6.Text = tempProduct.getDescription();

            button1.Text = "Save";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {




            string productName = textBox1.Text;
            string code = textBox5.Text;

            if (code == "" | productName == "")
            {
                MessageBox.Show("code and product name both should be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (code.Length > 5)
            {
                MessageBox.Show("Enter less than 5 characters for code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string brand = textBox2.Text;
            int rackNo;
            try
            {
                rackNo = Int32.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a valid rack number(integer)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double price;
            try
            {
                price = Double.Parse(textBox4.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a valid price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string description = textBox6.Text;



            if (button1.Text == "Add")
            {
                productDao.addProduct(new Product(0, code, productName, brand, rackNo, price, description));//0 is not inserting

            }

            else if (button1.Text == "Save")
            {

                tempProduct.setProductName(productName);
                tempProduct.setBrand(brand);
                tempProduct.setRackNo(rackNo);
                tempProduct.setPrice(price);
                tempProduct.setCode(code);
                tempProduct.setDescription(description);



                productDao.updateProduct(tempProduct);

            }

            else
            {
                MessageBox.Show("Something is wrong (search 1022)");
            }
            this.Dispose();
        }
    }
}
