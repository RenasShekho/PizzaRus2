using HandyControl.Controls;
using PizzaRus.Model;
using PizzaRus.UserControls;
using PizzaRus.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaRus
{

     
    public partial class KøbVinduet 
    {
        readonly KøbViewModel viewModel = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        MainWindow mw;
        DAL dal;
        
        public KøbVinduet(DAL dal)
        {
            this.dal = dal;

            MainWindow mw = (MainWindow)GetWindow(App.Current.MainWindow);

            InitializeComponent();

        

            lbkøbVinduet.ItemsSource = (mw.lbkurv.Items);
        }
        public KøbVinduet(ObservableCollection<Order> orders, double FullPrice)
        {
            InitializeComponent();
            viewModel.Orders = orders;
            viewModel.fullprice = FullPrice;
            this.DataContext = viewModel;
        }

        public KøbVinduet(ObservableCollection<Pizza> vM_PizzaDataBase, double fullPrice, CustomViewModel customViewModel, Order order)
        {
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void btnBetal_Click(object sender, RoutedEventArgs e)
        {
            //if (viewModel.VM_OrdersDataBase.Count != 0)
            //{
            //    KøbVinduet buy = new KøbVinduet(viewModel.VM_OrdersDataBase, viewModel.FullPrice);

            //    if (buy.ShowDialog() == true)
            //    {
            //        viewModel.Slet();
            //    }
            //}
            viewModel.OrdersJson();
            this.DialogResult = true;
        }
    }
}
