using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus.Model
{
    public class Order : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public string Navn { get; private set; }

        private double price2;

        public double Pris
        {
            get
            {
                return price2;
            }
            set
            {
                price2 = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("ToppingsValues");
            }
        }

        public List<string> Info { get; private set; }

        private ObservableCollection<Toppings> toppings;
        public ObservableCollection<Toppings> Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                toppings = value;
                OnPropertyChanged("Toppings");
            }
        }

        public int OrderID { get; set; }


        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Name)); //Linq
            }
        }

        public Order(int ID, string Navn, double Pris, List<string> Info, ObservableCollection<Toppings> Toppings, int OrderID)
        {
            this.ID = ID;
           this.Navn = Navn;
            this.Pris = Pris;
            this.Info = Info;
            this.Toppings = Toppings;
            this.OrderID = OrderID;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

        public Order Copy()
        {
            return new Order(ID, Navn, Pris, new List<string>(Info), new ObservableCollection<Toppings>(Toppings), OrderID);
        }
    }
}