using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus
{
    public class Toppings
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public double Toppings_Pris { get; set; }
  
        public Toppings(int ID, string Name, double Toppings_Pris)
        {
            this.ID = ID;
            this.Name = Name;
            this.Toppings_Pris = Toppings_Pris;
        }
    } 
}
