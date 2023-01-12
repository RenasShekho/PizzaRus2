using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus.Model
{
    public class Drikkevarer
    {
       
            public int ID { get; private set; }
            public string Navn { get; private set; }
            public double Pris { get; private set; }

            public Drikkevarer(int ID, int Number, string Navn, double Pris)
            {
                this.ID = ID;
                this.Navn = Navn;
                this.Pris = Pris;
            }
        
    }
}
