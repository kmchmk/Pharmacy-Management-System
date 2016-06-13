using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Telerivet.Client;

namespace Pharmacy
{
    public partial class Add_medicine_Routine : Form
    {
        RoutingDAO routingDao;
        CustomerDAO customerDao;
        DAO dao;
        RegisterCustomer registerCustomer;


        string apiKey = "17SdmOculXGRr0ggJ8A7gV9qbiL06Hq6";
        string projectID = "PJfe487b37facfa08c";
        string number = "0717899366";





        public Add_medicine_Routine(RegisterCustomer registerCustomer)
        {
            InitializeComponent();
            routingDao = new RoutingDAO();
            customerDao = new CustomerDAO();
            dao = new DAO();
            this.registerCustomer = registerCustomer;
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
            int times = 0;
            DateTime? time = null;


            if (radioButton0.Checked)
            {


                how = 1;

                try
                {
                    times = int.Parse(comboBox2.SelectedItem.ToString());
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Select how many times");
                    return;
                }


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



                int i = 0;
                int days = 0;
                while (i < times)
                {

                    DateTime now = DateTime.Now;

                    DateTime tempTime = now.AddDays(days);


                    //shedule smses
                    if (breakfast == 1 & i < times & (tempTime.Date + new TimeSpan(7, 0, 0) > now))
                    {
                        sheduleWithMealSMS(7, days, medicineName);
                        i++;
                    }

                    if (lunch == 1 & i < times & (tempTime.Date + new TimeSpan(12, 0, 0) > now))
                    {
                        sheduleWithMealSMS(12, days, medicineName);
                        i++;
                    }

                    if (dinner == 1 & i < times & (tempTime.Date + new TimeSpan(19, 0, 0) > now))
                    {
                        sheduleWithMealSMS(19, days, medicineName);
                        i++;
                    }

                    days++;
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


                try
                {
                    times = int.Parse(comboBox2.SelectedItem.ToString());
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Select how many times");
                    return;
                }




                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    for (int i = 0; i < times; i++)
                    {

                        string dateTime = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + (i * 3600 * hours) + 600).ToString();
                        string content = registerCustomer.getCustomerName() + ",\nYou have to take " + medicineName + " now (" + DateTime.UtcNow.AddSeconds((i * 3600 * hours) + 600).AddHours(5.5) + ").\n-Pharmacy-";



                        new TelerivetClass().schedule(apiKey, projectID, registerCustomer.getCustomerPhoneNumber(), dateTime, content);
                    }

                }).Start();



            }

            else if (radioButton2.Checked)
            {
                how = 3;
                time = dateTimePicker1.Value;
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    string dateTime = (dateTimePicker1.Value.Subtract(new DateTime(1970, 1, 1, 5, 30, 0))).TotalSeconds.ToString();

                    string content = registerCustomer.getCustomerName() + ",\nYou have to take " + medicineName + " now (" + time + ").\n-Pharmacy-";



                    new TelerivetClass().schedule(apiKey, projectID, registerCustomer.getCustomerPhoneNumber(), dateTime, content);
                }).Start();


            }


            routingDao.addRouting(new Routing(registerCustomer.getCustomerID(), medicineName, how, breakfast, lunch, dinner, beforeOrAfter, hours, times, time));




            registerCustomer.populateTable(dao.getLastInsertedAutoIncrementedID());
            this.Dispose();


        }


        void sheduleWithMealSMS(int clock, int days, string medicineName)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                string dateTime = ((Int32)((DateTime.UtcNow.Date.AddDays(days) + new TimeSpan(clock, 0, 0)).Subtract(new DateTime(1970, 1, 1, 5, 30, 0))).TotalSeconds).ToString();
                string content = registerCustomer.getCustomerName() + ", You have to take " + medicineName + " now (" + (DateTime.UtcNow.Date.AddDays(days) + new TimeSpan(clock, 0, 0)) + ").\n-Pharmacy-";
                System.Diagnostics.Debug.WriteLine(content);
                new TelerivetClass().schedule(apiKey, projectID, registerCustomer.getCustomerPhoneNumber(), dateTime, content);

            }).Start();




        }
    }
}