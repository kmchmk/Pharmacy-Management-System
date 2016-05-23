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
    public partial class Add_medicine_Routine : Form
    {
        RoutingDAO routingDao;
        CustomerDAO customerDao;
        DAO dao;
        Send_sms send_sms;
        public Add_medicine_Routine(Send_sms send_sms)
        {
            InitializeComponent();
            routingDao = new RoutingDAO();
            customerDao = new CustomerDAO();
            dao = new DAO();
            this.send_sms = send_sms;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(dateTimePicker1.Value);
            //Add data to the database

            string medicineName = textBox1.Text;

            if (medicineName == "")
            {
                MessageBox.Show("Enter medicine name");
                return;
            }

            int how = 0; //if not selected 0, if with meals 1, if per hours 2, if at a time 3
            int beforeOrAfter = 0; //if not checked 0, if before 1, if after 2
            int breakfast = 0;
            int lunch = 0;
            int dinner = 0;
            int hours = 0;
            DateTime? time = null;


            if (radioButton0.Checked)
            {

                how = 1;

                if (checkBox1.Checked)
                {
                    breakfast = 1;
                }
                if (checkBox2.Checked)
                {
                    lunch = 1;
                }
                if (checkBox3.Checked)
                {
                    dinner = 1;
                }

                if (radioButton3.Checked)
                {
                    beforeOrAfter = 1;
                }
                else if (radioButton4.Checked)
                {
                    beforeOrAfter = 2;
                }
            }

            else if (radioButton1.Checked)
            {
                how = 2;
                try
                {
                    hours = int.Parse(comboBox1.SelectedItem.ToString());
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Select the number of hours");
                    return;
                }
            }

            else if (radioButton2.Checked)
            {
                how = 3;
                time = dateTimePicker1.Value;
            }





            routingDao.addRouting(new Routing(send_sms.getCustomerID(), medicineName, how, breakfast, lunch, dinner, beforeOrAfter, hours, time));




            send_sms.populateTable(dao.getLastInsertedAutoIncrementedID());
            this.Dispose();


        }


    }
}
