using Newtonsoft.Json;
using PizzaRus;
using PizzaRus.Model;
using PizzaRus.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus
{

    public class DAL
    {

        private ObservableCollection<Pizza> PizzaDataBase;
        private ObservableCollection<Pizza> _PizzaPublicListe;

        private ObservableCollection<Drikkevarer> DrikkevarerDataBase;
        private ObservableCollection<Drikkevarer> _DrikkevarerPublicListe;

        private ObservableCollection<Tilbehør> TilbehørDataBase;
        private ObservableCollection<Tilbehør> _TilbehørPublicListe;

        private ObservableCollection<Toppings> ToppingsDataBase;
        private ObservableCollection<Toppings> _ToppingsPublicListe;

        //public ObservableCollection<Pizza> Pizzas { get; set; } = new ObservableCollection<Pizza>();
        //public ObservableCollection<Tilbehør> Tilbehøre { get; set; } = new ObservableCollection<Tilbehør>();
        public ObservableCollection<UserAccountModel> userAM { get; set; } = new ObservableCollection<UserAccountModel>();
        //public ObservableCollection<Tilbehør > _kurv2 { get; set; } = new ObservableCollection<Tilbehør>();


        public List<string> Info = new()
        {
            "4 stk. Mozzarella Sticks, 4 stk. Chili Cheese, 4 stk. Onion Rings, med Ketchup og Remoulade.", //0
            "Box med Kylling, Salat, Pommes Frites og Dressing.", //1
            "Klassisk Hvidløgsbrød med ost.", //2
            "5 stk. Hot Wings, med Pommes Frites, Salat og Dressing.", //3
            "10 stk. Chicken Nuggets, med Pommes Frites, Salat og Dressing", //4
            "Stor Pommes Frites med Ketchup og Pommes Frites sauce." //5
        };

        public DAL()
        {

            //JsonFiles(); // <--------> this has to be use just for first time and then i have to but it in comment
            string ToppingJson = File.ReadAllText("Topping.json");
            var Top = JsonConvert.DeserializeObject<ObservableCollection<Toppings>>(ToppingJson);
            ToppingsDataBase = new ObservableCollection<Toppings>(Top);
            _ToppingsPublicListe = new();

            string PizzaJson = File.ReadAllText("Pizza.json");
            var Piz = JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(PizzaJson);
            PizzaDataBase = new ObservableCollection<Pizza>(Piz);
            _PizzaPublicListe = new();

            string DrinksJson = File.ReadAllText("Drinks.json");
            var Dri = JsonConvert.DeserializeObject<ObservableCollection<Drikkevarer>>(DrinksJson);
            DrikkevarerDataBase = new ObservableCollection<Drikkevarer>(Dri);
            _DrikkevarerPublicListe = new();

            string TilbehørJson = File.ReadAllText("Tilbehør.json");
            var Til = JsonConvert.DeserializeObject<ObservableCollection<Tilbehør>>(TilbehørJson);
            TilbehørDataBase = new ObservableCollection<Tilbehør>(Til);
            _TilbehørPublicListe = new();
        }
        public ObservableCollection<Pizza> GetPizzas()
        {
            _PizzaPublicListe.Clear();

            foreach (Pizza p in PizzaDataBase)
            {
                _PizzaPublicListe.Add(p);
            }
            return _PizzaPublicListe;
        }
        public ObservableCollection<Toppings> GetToppings()
        {
            _ToppingsPublicListe.Clear();
            foreach (Toppings t in ToppingsDataBase)
            {
                _ToppingsPublicListe.Add(t);
            }
            return _ToppingsPublicListe;
        }
        public ObservableCollection<Drikkevarer> GetDrinks()
        {
            _DrikkevarerPublicListe.Clear();

            foreach (Drikkevarer d in DrikkevarerDataBase)
            {
                _DrikkevarerPublicListe.Add(d);
            }
            return _DrikkevarerPublicListe;
        }
        public ObservableCollection<Tilbehør> GetTilbehør()
        {
            _TilbehørPublicListe.Clear();

            foreach (Tilbehør tl in TilbehørDataBase)
            {
                _TilbehørPublicListe.Add(tl);
            }
            return _TilbehørPublicListe;
        }


        //DataBaseUserAccountModel = new ObservableCollection<UserAccountModel>();
        //_publicListeUserAccountModel = new ObservableCollection<UserAccountModel>(DataBaseUserAccountModel);


    

        public void JsonFiles()
        {
            //Toppings -------------
            ToppingsDataBase = new ObservableCollection<Toppings>
            {  new Toppings(0, "Tomatsauce", 0),
                new Toppings(1, "Ost", 9),
                new Toppings(2, "Oregano", 0),
                new Toppings(3, "Kebab", 9),
                new Toppings(4, "Pepperoni", 9),
                new Toppings(5, "Løg", 4.50),
                new Toppings(6, "Champignon", 4.50),
                new Toppings(7, "Jalapenos", 4.50),
                new Toppings(8, "Dressing", 4.50),
                new Toppings(9, "Skinke", 9),
                new Toppings(10, "Oksekød", 9),
                new Toppings(11, "Kylling", 9),
                new Toppings(12, "Pølser", 9),
                new Toppings(13, "Bacon", 9),
                new Toppings(14, "Peberfrugt", 4.50),
                new Toppings(15, "Oliven", 4.50),
                new Toppings(16, "Pommes Frites", 4.50),
                new Toppings(17, "Bearnaisesauce", 4.50),
                new Toppings(18, "Italiensk Salami", 4.50),
                new Toppings(19, "Ananas", 4.50),
                new Toppings(20, "Karrydressing", 4.50)
            };
            var ToppingJSON = JsonConvert.SerializeObject(ToppingsDataBase, Formatting.Indented);
            File.WriteAllText("Topping.json", ToppingJSON);
            //----------------------


            PizzaDataBase = new ObservableCollection<Pizza>
            {               
                new Pizza(0, "Margherita", 1, 60, new ObservableCollection<Toppings> {ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[2] }),
                //Pizza La Pappas - 77 dkk
                new Pizza(1, "Pizza La Pappas", 2, 77, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[3], ToppingsDataBase[4], ToppingsDataBase[5], ToppingsDataBase[6], ToppingsDataBase[2] }),
                //Viking - 60 dkk
                new Pizza(2, "Viking", 3, 77, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[3], ToppingsDataBase[5] }),
                //Meat Lovers - 93 dkk
                new Pizza(3, "Meat Lovers", 4, 93, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[10], ToppingsDataBase[11], ToppingsDataBase[4], ToppingsDataBase[12], ToppingsDataBase[13] }),
                //Pepperoni - 70 dkk
                new Pizza(4, "Pepperoni", 5, 70, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[4], ToppingsDataBase[2] }),
                //Aalborg - 77 dkk
                new Pizza(5, "Aalborg", 6, 77, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[3], ToppingsDataBase[10], ToppingsDataBase[5], ToppingsDataBase[14], ToppingsDataBase[2] }),
                //Hawaii - 75 dkk
                new Pizza(6, "Hawaii", 7, 75, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[19], ToppingsDataBase[2] }),
                //Vesterbro - 79 dkk
                new Pizza(7, "Vesterbro", 8, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[10], ToppingsDataBase[12], ToppingsDataBase[2], ToppingsDataBase[6] }),
                //Brønderslev - 79 dkk 
                new Pizza(8, "Brønderslev", 9, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[10], ToppingsDataBase[12], ToppingsDataBase[15], ToppingsDataBase[2], ToppingsDataBase[13] }),
                //Sicilia - 79 dkk
                new Pizza(9, "Sicilia", 10, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[10], ToppingsDataBase[12], ToppingsDataBase[2], ToppingsDataBase[15], ToppingsDataBase[13] }),
                //Sondos Pizza - 75 dkk
                new Pizza(10, "Sondos Pizza", 11, 75, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[4], ToppingsDataBase[9], ToppingsDataBase[8], ToppingsDataBase[2] }),
                //Rom - 79 dkk
                new Pizza(11, "Rom", 12, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[3], ToppingsDataBase[2], ToppingsDataBase[4], ToppingsDataBase[6] }),
                //Pommes Pizza - 79 dkk
                new Pizza(12, "Pommes Pizza", 12, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[3], ToppingsDataBase[16], ToppingsDataBase[8], ToppingsDataBase[2] }),
                //Bearnaise Pizza - 75 dkk
                new Pizza(13, "Bearnaise Pizza", 13, 75, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[10], ToppingsDataBase[17], ToppingsDataBase[2] }),
                //Salami Pizza - 79 ToppingsDataBase
                new Pizza(14, "Salami Pizza", 14, 79, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[9], ToppingsDataBase[18], ToppingsDataBase[2], ToppingsDataBase[5], ToppingsDataBase[13] }),
                //Karry Pizza - 75 dkk
                new Pizza(15, "Karry Pizza", 15, 75, new ObservableCollection<Toppings> { ToppingsDataBase[0], ToppingsDataBase[1], ToppingsDataBase[11], ToppingsDataBase[19], ToppingsDataBase[20], ToppingsDataBase[2] })
            };
            var PizzaJson = JsonConvert.SerializeObject(PizzaDataBase, Formatting.Indented);
            File.WriteAllText("Pizza.json", PizzaJson);
            //----------------------

            //Drinks----------------
            DrikkevarerDataBase = new ObservableCollection<Drikkevarer>
            {
                new Drikkevarer(30, 1, "Coca-Cola 0,5L", 18),
                new Drikkevarer(31, 2, "Coca-Cola Zero 0,5L", 18),
                new Drikkevarer(32, 3, "Fanta Orange 0,5L", 18),
                new Drikkevarer(33, 4, "Sprite 0,5L", 18),
                new Drikkevarer(34, 5, "Vitamin Vand 0,5L", 18),
                new Drikkevarer(35, 6, "Aloe Vera Drink 0,5L", 18)
            };
            var DrinksJson = JsonConvert.SerializeObject(DrikkevarerDataBase, Formatting.Indented);
            File.WriteAllText("Drinks.json", DrinksJson);
            //----------------------

            //Tilbehør -------------
            TilbehørDataBase = new ObservableCollection<Tilbehør>
            {
                new Tilbehør(45, 1, "Snack Kurv", 50, new List<string> { Info[0] }),
                new Tilbehør(46, 2, "Kyllinge Box", 50, new List<string> { Info[1] }),
                new Tilbehør(47, 3, "Hvidløgsbrød", 35, new List<string> { Info[2] }),
                new Tilbehør(48, 4, "Hot Wings", 60, new List<string> { Info[3] }),
                new Tilbehør(49, 5, "Chicken Nuggets", 60, new List<string> { Info[4] }),
                new Tilbehør(50, 6, "Pommes Frites", 30, new List<string> { Info[5] })
            };

            var TilbehørJson = JsonConvert.SerializeObject(TilbehørDataBase, Formatting.Indented);
            File.WriteAllText("Tilbehør.json", TilbehørJson);
            //----------------------
        }

      


        //public ObservableCollection<UserAccountModel> GetUserAccountModel()
        //{
        //    _publicListeUserAccountModel.Clear();
        //    foreach (UserAccountModel u in DataBaseUserAccountModel)
        //    {
        //        _publicListeUserAccountModel.Add(u);
        //    }
        //    return _publicListeUserAccountModel;
        //}

    }
}




