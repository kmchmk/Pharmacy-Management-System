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

        private void button1_Click(object sender, EventArgs e)
        {


            string searchKey = textBox1.Text;


            customerList = customerDao.getCustomerList(textBox1.Text);
            dataGridView1.Rows.Clear();

            foreach (Customer i in customerList)
            {
                dataGridView1.Rows.Add();
                int rows = dataGridView1.RowCount - 1;
                System.Diagnostics.Debug.WriteLine(rows);
                dataGridView1.Rows[rows].Cells[0].Value = i.getName();
                dataGridView1.Rows[rows].Cells[1].Value = i.getTelephoneNumber();
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
    }
}
