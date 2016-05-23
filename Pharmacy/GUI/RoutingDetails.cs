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
    public partial class RoutingDetails : Form
    {


        RoutingDAO routingDao;
        List<Routing> routingList;


        public RoutingDetails(int customerID)
        {
            InitializeComponent();
            routingDao = new RoutingDAO();


            routingList = routingDao.getRoutingList(customerID);

            foreach (Routing i in routingList)
            {
                listBox1.Items.Add(i.getMedicineName());
            }






        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
