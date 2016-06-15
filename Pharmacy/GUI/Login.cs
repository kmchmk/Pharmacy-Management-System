using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Login : Form
    {
        UserDAO userDao;
        MainMenu mainMenu;
        bool old = false;
        int eOrD = 0; //edit 1, delete 2
        string usernameFromMainMenu;
        string passwordFromMainMenu;
        public Login(MainMenu mainMenu, string usernameFromMainMenu, string passwordFromMainMenu, int eOrD)
        {
            InitializeComponent();
            this.userDao = new UserDAO();
            this.mainMenu = mainMenu;

            this.usernameFromMainMenu = usernameFromMainMenu;
            this.passwordFromMainMenu = passwordFromMainMenu;
            this.eOrD = eOrD;

            if (usernameFromMainMenu != "")
            {
                Console.WriteLine(usernameFromMainMenu);
                textBox1.Text = usernameFromMainMenu;
                textBox1.Enabled = false;
                button1.Text = "Enter";
                old = true;
            }




        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            textBox2.ForeColor = Color.Gray;
            textBox2.Text = "password...";

            if (!old)
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "user name...";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.ForeColor == Color.Gray)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Gray)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*            if (textBox1.Text == "")
                        {
                            textBox1.ForeColor = Color.Gray;
                            textBox1.Text = "user name...";
                        }
             * */
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*            if (textBox1.Text == "")
                        {
                            textBox2.ForeColor = Color.Gray;
                            textBox2.Text = "password...";
                        }
                        */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (old)
            {
                if (passwordFromMainMenu == password)
                {
                    if (eOrD == 1)
                    {
                        mainMenu.returnFromEditPasswordAcception();
                    }
                    else if (eOrD == 2)
                    {
                        mainMenu.returnFromDeletePasswordAcception();
                    }
                    else
                    {
                        Console.WriteLine("Some error in password acception return function");
                    }
                }
                this.Dispose();
            }
            else
            {


                if (userDao.isPasswordMatch(username, password))
                {
                    this.Visible = false;
                    mainMenu.startMainMenu(username, password);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new Login(mainMenu, "", "",0).Show();
                    this.Visible = false;
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = textBox1.Text;
            string email = "";
            string password = "";

            if (username == "")
            {
                MessageBox.Show("Enter your username first!", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                email = userDao.getEmail(username);
                password = userDao.getPassword(username);
            }
            if (email != "" & password != "")
            {
                new Thread(() =>
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                            //                            SmtpClient client = new SmtpClient("proxy.mailserver.com", 8080);
                            mail.From = new MailAddress("pharmacy.management.system@gmail.com");

                            mail.To.Add(email);
                            mail.Subject = "Pharmacy Management System";
                            mail.Body = "Your Password is " + password;

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("kmchmk@gmail.com", "chuttebuydssc");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);
                            MessageBox.Show("An email has been sent to " + email, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There is a problem with your internet connection. Check and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.ToString());
                        }
                    }).Start();
            }
            else
            {
                MessageBox.Show("User name is incorrect", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

