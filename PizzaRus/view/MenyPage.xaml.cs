using PizzaRus.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace PizzaRus
{
    
    public partial class MenyPage : Page
    {
        KøbVinduet købV;
       
        

        DAL dal;

        public MenyPage(DAL dal)
        {

            this.dal = dal;

            InitializeComponent();
            this.DataContext = dal;

        }


        private void btnTilføj_Click(object sender, RoutedEventArgs e)
        {


            Button btn = (Button)sender; // sender is the button pressed
            if (btn != null) //if btn is not empty
            {
                for (int i = 0; i < lbMeny.Items.Count; i++) //Runs through every item in the listbox
                {
                    if (btn.Tag.ToString() == (i ).ToString())
                    { //checks if the btn tag is the same as i+1 making sure its the corrct item
                        var tmp = lbMeny.Items[i]; //places the correct item in tmp
                        //Gets a refrence to mainwindow
                        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);
                        if (mw != null) //Checks if mainwindow isn't empty
                        {
                            Pizza p = (Pizza)tmp; //Makes tmp to a pizza object
                            //Creates the output string
                            string item = $"{p.ID} {p.name} \n" + $"{p.Toppings}, \n" + $"{p.PizzaPris} Kr.";
                            mw.lbkurv.Items.Add(item); //adds the string to kurv listbox                             
                          
                        }
                    }
                   
                }
            }
            Button b = (Button)sender;
            if (b != null)
            {
                Pizza p = (Pizza)b.DataContext;
                if (p != null)
                {
                    //dal._kurv.Add(p);

                }
            }
        }              
        private void btnSlet_Click_1(object sender, RoutedEventArgs e)
        {
        //    while (mw.lbkurv.SelectedItems.Count > 0)
        //    {
        //        mw.lbkurv.Items.RemoveAt(mw.lbkurv.SelectedIndex);
        //    }           
        Button btn = (Button)sender; // sender is the button pressed
        if (btn != null) //if btn is not empty
        {
                for (int i = 0; i < lbMeny.Items.Count; i++) //Runs through every item in the listbox
                {
                    if (btn.Tag.ToString() == (i + 1).ToString())
                    { //checks if the btn tag is the same as i+1 making sure its the corrct item
                        var tmp = lbMeny.Items[i]; //places the correct item in tmp
                                                   //Gets a refrence to mainwindow
                        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);

                        if (mw != null) //Checks if mainwindow isn't empty
                        {
                            Pizza p = (Pizza)tmp; //Makes tmp to a pizza object
                                                  //Creates the output string
                            string item = $"{p.ID} {p.name} \n" + $"{p.Toppings}, \n" + $"{p.PizzaPris} Kr.";
                            mw.lbkurv.Items.Remove(item); //adds the string to kurv listbox
                        }
                    }
                }
            }

        }   
       
    }
}
