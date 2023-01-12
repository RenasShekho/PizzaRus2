using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using System.Diagnostics;
using PizzaRus.ViewModel;
using PizzaRus.view;
using System.Threading;
using PizzaRus.Model;
using PizzaRus.Repositories;
using System.Linq;
using HandyControl.Controls;


namespace PizzaRus
{



    public partial class MainWindow :  INotifyPropertyChanged
    {
       readonly DAL dal = new DAL();
        
        private int OrderID;
        public ObservableCollection<Pizza> VM_PizzaDataBase { get; set; }
        public ObservableCollection<Drikkevarer> VM_DrinksDataBase { get; set; }
        public ObservableCollection<Tilbehør> VM_TilbehørDataBase { get; set; }
        public ObservableCollection<Order> VM_OrdersDataBase { get; set; }


        private UserAccountModel _currentUserAccount;
        private IUserRepository UserRepository;

        //public UserAccountModel CurrentUserAccount
        //{
        //    get
        //    {
        //        return _currentUserAccount;
        //    }

        //    set
        //    {
        //        _currentUserAccount = value;
        //        OnPropertyChanged(nameof(CurrentUserAccount));
        //    }
        //}

        private DependencyPropertyChangedEventArgs nameof(UserAccountModel currentUserAccount)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;      
            
        
        readonly MainWindowViewModel viewModel = new();

        KøbVinduet køV;
        MenyPage MP;
        TilbehørPage TP;
            
  
        
        public MainWindow()
        {

            //UserRepository = new UserRepository();
            //CurrentUserAccount = new UserAccountModel();
            //LoadCurrentUserData();

            InitializeComponent();
            //this.Text = this.Text + "--" + LoginTable.UserName;
            VM_PizzaDataBase = dal.GetPizzas();
            VM_DrinksDataBase = dal.GetDrinks();
            VM_TilbehørDataBase = dal.GetTilbehør();
            VM_OrdersDataBase = new ObservableCollection<Order>();

            TP = new TilbehørPage(dal);
            MP = new MenyPage(dal);
            this.DataContext = viewModel;
            Main.Navigate(viewModel);
        }

       
        private void windowLoaded(object sende, RoutedEventArgs eva)
        {
            this.Hide();
            LoginWindow lw = new LoginWindow();
            lw.ShowDialog();
            if (Thread.CurrentPrincipal?.Identity?.IsAuthenticated == true)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }


        }
        private double _FullPrice;
        public double FullPrice
        {
            get
            {
                return _FullPrice;
            }
            set
            {
                _FullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public void Slet()
        {
            VM_OrdersDataBase.Clear();
            FullPrice = 0;
        }

        private void btTilbehør_Click(object sender, RoutedEventArgs e)
        {
            TP.DataContext = viewModel;
            Main.Content = TP;
        }

        private void btMeny_Click(object sender, RoutedEventArgs e)
        {
                           
                MP.DataContext = viewModel;
                Main.Content = MP;            
                  
        }

        private void btnKurv_Click(object sender, RoutedEventArgs e)
        {

            //if (viewModel.VM_OrdersDataBase.Count != 0)
            //{
            //    KøbVinduet buy = new KøbVinduet(viewModel.VM_OrdersDataBase, viewModel.FullPrice);

            //    if (buy.ShowDialog() == true)
            //    {
            //        viewModel.Slet();
            //    }
            //}
            KøbVinduet køv = new KøbVinduet(dal);
            køv.ShowDialog();
            køv.DataContext = dal;
        
        
        }


        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {
            //for (int v = 0; v < lbkurv.SelectedItems.Count; v++)
            //{
            //    lbkurv.Items.Remove(lbkurv.SelectedItems[v]);
           //}
        //    lbkurv.Items.Clear();           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
                
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

      

       

        private void btn_Edit_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.DataContext is Order order)
                    if (order.Toppings.Count > 0)
                    {
                        {
                            var customViewModel = new CustomViewModel();
                            KøbVinduet købv = new KøbVinduet(viewModel.VM_PizzaDataBase, viewModel.FullPrice, customViewModel, order);
                            købv.ShowDialog();


                            viewModel.FullPrice = 0;
                            for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Adds the price of items in Order, to FullPrice.
                            {
                                viewModel.FullPrice += customViewModel.selected.Pris;
                            }
                            viewModel.UpdateOrder(customViewModel.selected);
                        }
                    }
            }
        }

        private void btn_Edit_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button b)
            {
                if (b != null)
                {
                    Order o = (Order)b.DataContext;
                    if (o != null)
                    {
                        viewModel.RemoveFromOrder(o);
                        viewModel.FullPrice = 0;
                        for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Looks at 
                        {
                            viewModel.FullPrice += viewModel.VM_OrdersDataBase[i].Pris;
                        }
                    }
                }
            }
        }

        //Fields






        //private void LoadCurrentUserData()
        //{
        //    var user = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
        //    if (user != null)
        //    {
        //        CurrentUserAccount.Username = user.Username;
        //        CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
        //        CurrentUserAccount.ProfilePicture = null;
        //    }
        //    else
        //    {
        //        CurrentUserAccount.DisplayName = "Invalid user, not logged in";
        //        //Hide child views.
        //    }
        //}


    }
}
   