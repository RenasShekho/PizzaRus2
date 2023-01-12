using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PizzaRus.Model;
using PizzaRus.Repositories;

namespace PizzaRus.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        readonly DAL dal;
        private int OrderID;
        public ObservableCollection<Pizza> VM_PizzaDataBase { get; set; }
        public ObservableCollection<Drikkevarer> VM_DrinksDataBase { get; set; }
        public ObservableCollection<Tilbehør> VM_TilbehørDataBase { get; set; }
        public ObservableCollection<Order> VM_OrdersDataBase { get; set; }

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

        public void Slet()
        {
            VM_OrdersDataBase.Clear();
            FullPrice = 0;
        }

        public MainWindowViewModel()
        {
            dal = new DAL();
            VM_PizzaDataBase = dal.GetPizzas();
            VM_DrinksDataBase = dal.GetDrinks();
            VM_TilbehørDataBase = dal.GetTilbehør();
            VM_OrdersDataBase = new ObservableCollection<Order>();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

        public void UpdateOrder(Order order)
        {
            var oldOrder = VM_OrdersDataBase.FirstOrDefault(o => o.OrderID.Equals(order.OrderID));
            if (oldOrder != null)
                VM_OrdersDataBase[VM_OrdersDataBase.IndexOf(oldOrder)] = order;
        }


        public void AddToOrderPizza(Pizza pizza)
        {
            VM_OrdersDataBase.Add(new Order(pizza.ID, pizza.name, pizza.PizzaPris, new List<string>(), new ObservableCollection<Toppings>(pizza.Toppings), OrderID++));
            FullPrice += pizza.PizzaPris;
        }
        public void AddToOrderTilbehør(Tilbehør tilbehør)
        {
            VM_OrdersDataBase.Add(new Order(tilbehør.ID, tilbehør.Name, tilbehør.TilbehørPris, tilbehør.Info, new ObservableCollection<Toppings>(), OrderID++));
            FullPrice += tilbehør.TilbehørPris;
        }
        public void AddToOrderDrinks(Drikkevarer drikkevarer)
        {
            VM_OrdersDataBase.Add(new Order(drikkevarer.ID, drikkevarer.Navn, drikkevarer.Pris, new List<string>(), new ObservableCollection<Toppings>(), OrderID++));
            FullPrice += drikkevarer.Pris;
        }

        public void RemoveFromOrder(Order orders)
        {
            VM_OrdersDataBase.Remove(orders);
            FullPrice -= orders.Pris;
        }
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        //public MainWindowViewModel()
        //{
        //    userRepository = new UserRepository();
        //    CurrentUserAccount = new UserAccountModel();
        //    LoadCurrentUserData();
        //}

        //private void LoadCurrentUserData()
        //{
        //    var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

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
