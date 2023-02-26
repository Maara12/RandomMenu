using System;
using System.Collections.Generic;
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

namespace RandomMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeTheMenu();
        }

        private void MakeTheMenu()
        {
            MenuItem[] menuItems = new MenuItem[5];
            string guacamolePrice;

            for(int i =0; i < 5; i++)
            {
                menuItems[i] = new MenuItem();
                if(i >2)
                {
                    menuItems[i].breads = new string[] { "plain bagel",
                        "onion bagel", "pumpernickel bagel", "everything bagel" };

                }
                menuItems[i].Generate();
            }

            item1.Text = menuItems[0].description;
            price1.Text = menuItems[0].cost;
            item2.Text = menuItems[1].description;
            price2.Text = menuItems[1].cost;
            item3.Text = menuItems[2].description;
            price3.Text = menuItems[2].cost;
            item4.Text = menuItems[3].description;
            price4.Text = menuItems[3].cost;
            item5.Text = menuItems[4].description;
            price5.Text = menuItems[4].cost;

            MenuItem specialMenuItem = new MenuItem()
            {
                proteins = new string[] { "Organic ham", "Mushroom patty", "Mortadella" },
                breads = new string[]  { "a gluten free roll", "a wrap", "pita" },
                condiments = new string[] { "dijon mustard", "miso dressing", "au jus" }
            };

            specialMenuItem.Generate();

            item6.Text = specialMenuItem.description;
            price6.Text = specialMenuItem.cost;

            MenuItem guacamoleItem = new MenuItem();
            guacamoleItem.Generate();
            guacamolePrice = guacamoleItem.cost;

            guacamole.Text = "Add Guacamole for " + guacamolePrice;
        }
    }

    class MenuItem
    {
        Random randomizer = new Random();
        
        public string[] proteins = {"Roast Beef", "Salami", "Turkey",
            "Ham", "Pastrami", "Tofu"};

        public string[] condiments = {"Yellow Mustard","Brown Mustard","Honey Mustard",
            "Mayo", "Relish","French dressing"};

        public string[] breads = {"rye","white","wheat",
            "pumpernickel","a roll"};

        public string description = "";
        public string cost;

        public void Generate()
        {
            string randomProtein = proteins[randomizer.Next(proteins.Length)];
            string randomCondiment = condiments[randomizer.Next(condiments.Length)];
            string randomBread = breads[randomizer.Next(breads.Length)];
            description = randomProtein + " with " + randomCondiment + " on " + randomBread;

            decimal bucks = randomizer.Next(2, 5);
            decimal cents = randomizer.Next(1, 98);
            decimal price = bucks + (cents * .01m);
            cost = price.ToString("c");
        }
    }
}
