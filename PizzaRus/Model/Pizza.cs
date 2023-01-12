using AW.WPF.Essentials.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace PizzaRus
{
    public class Pizza
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string Navn)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(Navn));
        //    }
        //}
       
        public int ID { get; set; }
        public string name { get; set; }
        public double PizzaPris { get; set; }
        public int Number { get; private set; }
        public ObservableCollection<Toppings> Toppings { get; set; } // this is for toppings with Pizza
     

        public Pizza(int ID, string name,int Number, double PizzaPris, ObservableCollection<Toppings> Toppings )
        {
            this.ID = ID;
            this.Number = Number;
            this.name = name;
            this.PizzaPris = PizzaPris;
            this.Toppings = Toppings;  
          
        }

        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Name)); //Linq
            }
        }
    }  
}

