using HandyControl.Controls;
using PizzaRus.view;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

using Window = System.Windows.Window;

namespace PizzaRus
{
    
    public partial class Registration : Window
    {
       
        public Registration()
        {
           
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
           this.Close();
        }
       
        public void Reset()
        {
            txtUser.Text = "";
            txtfirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            Password.Password = "";
            ConfirmPassword.Password = "";
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
       

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length ==0)
            {
                errormessage.Text = "Enter a Username.";
                txtUser.Focus();
            }
            else if (txtfirstName.Text.Length == 0)
            {
                errormessage.Text = "Enter Your First Name.";
                txtfirstName.Focus();
            }
            else if (txtLastName.Text.Length == 0)
            {
                errormessage.Text = "Enter Your Last Name.";
                txtLastName.Focus();
            }
            else if (txtAddress.Text.Length == 0)
            {
                errormessage.Text = "Enter Your Address.";
                txtAddress.Focus();
            }
            else if (txtEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                string firstname = txtfirstName.Text;
                string lastname = txtLastName.Text;
                string email = txtEmail.Text;
                string password = Password.Password;
                string username = txtUser.Text;
                if (Password.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    Password.Focus();
                }
                else if (ConfirmPassword.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    ConfirmPassword.Focus();
                }
                else if (Password.Password != ConfirmPassword.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    ConfirmPassword.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    string address = txtAddress.Text;
                    SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into [LoginTable] (UserName,FirstName,LastName,Email,Password,Address) values('" + username + "','" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                    Reset();
                }
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
    
}
