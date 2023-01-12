using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
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
using HandyControl.Controls;
using MaterialDesignThemes.Wpf;
using PizzaRus.ViewModel;
using System.Windows.Navigation;
using Window = System.Windows.Window;

namespace PizzaRus.view
{
    
    public partial class LoginWindow : Window
    {
       
        public bool IsLoggedIn { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }     

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }      

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
        Registration  registration = new Registration();
            registration.Show();
         this.Close();

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
    

