using PizzaRus.UserControls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaRus.UserControls
{
    
    public partial class Product : UserControl 
    {
        
        public Product()
        {       
            InitializeComponent();
                      
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static  DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Product));

        public string PName
        {
            get { return (string)GetValue(PNameProperty); }
            set { SetValue(PNameProperty, value); }
        }

        public static  DependencyProperty PNameProperty = DependencyProperty.Register("PName", typeof(string), typeof(Product));

        public int PID
        {
            get { return (int)GetValue(PIDProperty); }
            set { SetValue(PIDProperty, value); }
        }

        public static  DependencyProperty PIDProperty = DependencyProperty.Register("PID", typeof(int), typeof(Product));


        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public static  DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(Product));

        public int PPris
        {
            get { return (int)GetValue(PPrisProperty); }
            set { SetValue(PPrisProperty, value); }
        }

        public static  DependencyProperty PPrisProperty = DependencyProperty.Register("PPris", typeof(int), typeof(Product));


    }

}



