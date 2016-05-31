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

    public partial class Send_sms : Form
    {
        RoutingDAO routingDao;
        CustomerDAO customerDao;
        int customerID;
        public Send_sms()
        {

            InitializeComponent();
            this.routingDao = new RoutingDAO();
            this.customerDao = new CustomerDAO();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_medicine_Routine amr = new Add_medicine_Routine(this);
            amr.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            amr.ShowDialog();
        }

        public int getCustomerID()
        {
            return this.customerID;
        }

        public string getCustomerName()
        {
            return textBox1.Text;
        }
        public string getCustomerPhoneNumber()
        {
            return textBox2.Text;
        }



        private void button4_Click(object sender, EventArgs e)
        {

            string customerName = textBox1.Text;
            string phoneNumber = textBox2.Text;


            if (customerName == "")
            {
                MessageBox.Show("Enter a name");
                return;
            }

            if (phoneNumber == "")
            {
                MessageBox.Show("Enter a phone number");
                return;
            }


            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;



            customerID = customerDao.addCustomer(new Customer(0,customerName,phoneNumber));//this 0 is not functional

            dataGridView1.Show();
            button1.Show();
            button5.Show();
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }








        public void populateTable(int lastInsertedID)
        {
            List<Routing> routingList = routingDao.getRoutingList(customerID);

            //for (int i = 0; i < routingList.Count; i++)
            //{

            int lastRouting = routingList.Count - 1;
            dataGridView1.Rows.Add();












            dataGridView1.Rows[lastRouting].Cells[0].Value = routingDao.getRoutingContent(routingList[lastRouting]);
            dataGridView1.Rows[lastRouting].HeaderCell.Value = lastInsertedID;




            //System.Diagnostics.Debug.WriteLine(lastInsertedID);
            // System.Diagnostics.Debug.WriteLine(dataGridView1.Rows[lastRouting].HeaderCell.Value);

            // }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)//if no rows selected
            {
                MessageBox.Show("Select a row");
                return;
            }

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)//delete all selected rows
            {

                int routingID = (int)item.HeaderCell.Value;
                routingDao.deleteRouting(routingID);
                dataGridView1.Rows.RemoveAt(item.Index);
            }


        }




        


    }

}
