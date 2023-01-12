using AW.WPF.Essentials.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus
{
    public class Tilbehør 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string Navn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Navn));
            }
        }     

        public int ID { get; set; }
        public string Name { get; set; }
        public int Number { get; private set; }
        public double TilbehørPris { get; set; }
        public List<string> Info { get; private set; } 


        public Tilbehør(int ID,int Number, string Name, double TilbehørPris, List<string> Info)
        {
            this.ID = ID;
            this.Name = Name;
            this.Number = Number;
            this.TilbehørPris = TilbehørPris;
            this.Info = Info;
        }

    }
}
