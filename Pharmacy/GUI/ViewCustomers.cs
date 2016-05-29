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





    public partial class ViewCustomers : Form
    {
        CustomerDAO customerDao;

        RoutingDetails routingDetails;
        List<Customer> customerList;



        public ViewCustomers()
        {
            InitializeComponent();
            customerDao = new CustomerDAO();

        }



        void search(object sender, EventArgs e)
        {
            string searchKey = textBox1.Text;


            customerList = customerDao.getCustomerList(textBox1.Text);
            dataGridView1.Rows.Clear();

            foreach (Customer i in customerList)
            {
                dataGridView1.Rows.Add();
                int rows = dataGridView1.RowCount - 1;
                dataGridView1.Rows[rows].Cells[0].Value = i.getName();
                dataGridView1.Rows[rows].Cells[1].Value = i.getTelephoneNumber();
                dataGridView1.Rows[rows].HeaderCell.Value = i.getID();



            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (routingDetails != null)
            {
                routingDetails.Dispose();
            }
            routingDetails = new RoutingDetails(customerList[e.RowIndex].getID());
            routingDetails.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            routingDetails.Show();





        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Send_sms().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)//if no rows selected
            {
                MessageBox.Show("Select a row");
                return;
            }

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)//delete all selected rows
            {

                int customerID = (int)item.HeaderCell.Value;
                customerDao.deleteCustomer(customerID);
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            search(sender, e);
        }
    }
}
