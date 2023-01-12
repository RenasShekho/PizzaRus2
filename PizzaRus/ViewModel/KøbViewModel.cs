using Newtonsoft.Json;
using PizzaRus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace PizzaRus.ViewModel
{
    public class KøbViewModel
    {
       
        public ObservableCollection<Order> Orders { get; set; } = new();       // gets info from order class
        public double fullprice { get; set; }                                  // giv final price for order


        public void OrdersJson()        // this is for Json file to display
        {
            var PizzaJson = JsonConvert.SerializeObject(Orders, Formatting.Indented);
            File.WriteAllText("Orders.json", PizzaJson);
        }


    }
}
