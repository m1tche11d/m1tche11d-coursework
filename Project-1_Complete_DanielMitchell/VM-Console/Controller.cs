using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VM_Console
{
    public class Controller
    {
        private VendingMachine vm = new VendingMachine();

        public Controller()
        {

        }

        /// <summary>
        /// Displays the main menu for the customer.
        /// </summary>
        public void showCustomerOptions()
        {
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.WriteLine("VM");
            Console.WriteLine("====");
            Console.WriteLine("(a) " + vm.invOne.Name + " ---- " + intToDollars(vm.invOne.Price) + " " + getDrinkAvailability(vm.invOne));
            Console.WriteLine("(b) " + vm.invTwo.Name + " ----- " + intToDollars(vm.invTwo.Price) + " " + getDrinkAvailability(vm.invTwo));
            Console.WriteLine("(c) " + vm.invThree.Name + " - " + intToDollars(vm.invThree.Price) + " " + getDrinkAvailability(vm.invThree));
            Console.WriteLine("(d) " + vm.invFour.Name + " -- " + intToDollars(vm.invFour.Price) + " " + getDrinkAvailability(vm.invFour));
            Console.WriteLine("(e) " + vm.invFive.Name + " ---- " + intToDollars(vm.invFive.Price) + " " + getDrinkAvailability(vm.invFive));
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("----");
            Console.WriteLine("1. Insert coin");
            Console.WriteLine("2. Insert bill");
            Console.WriteLine("3. Cancel");
            Console.WriteLine();
            Console.WriteLine("Amount: " + intToDollars(vm.cBalance));
            Console.Write("Enter selection (1..3)" + vm.getAvailableDrinks() + ": ");
            //CustomerOperate(getUserInput(), vm);
        }

        /// <summary>
        /// Displays the main menu for the manager.
        /// </summary>
        public void showManagerOptions()
        {
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.WriteLine("VM");
            Console.WriteLine("====");
            Console.WriteLine("(a) " + vm.invOne.Name + " ---- " + intToDollars(vm.invOne.Price) + " " + getDrinkAvailability(vm.invOne));
            Console.WriteLine("(b) " + vm.invTwo.Name + " ----- " + intToDollars(vm.invTwo.Price) + " " + getDrinkAvailability(vm.invTwo));
            Console.WriteLine("(c) " + vm.invThree.Name + " - " + intToDollars(vm.invThree.Price) + " " + getDrinkAvailability(vm.invThree));
            Console.WriteLine("(d) " + vm.invFour.Name + " -- " + intToDollars(vm.invFour.Price) + " " + getDrinkAvailability(vm.invFour));
            Console.WriteLine("(e) " + vm.invFive.Name + " ---- " + intToDollars(vm.invFive.Price) + " " + getDrinkAvailability(vm.invFive));
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("----");
            Console.WriteLine("1. Add drinks to inventory");
            Console.WriteLine("2. Change drink's name");
            Console.WriteLine("3. Change drink's price");
            Console.WriteLine("4. Withdraw money");
            Console.WriteLine("5. Show inventory");
            Console.WriteLine("6. Reset Vending Machine");
            Console.WriteLine();
            Console.Write("Enter selection (1..6): ");
            //ManagerOperate(getUserInput());
        }

        /// <summary>
        /// Takes a number of cents and converts it to an easy-to-read dollars and cents string.
        /// </summary>
        /// <param name="i">The number to convert.</param>
        /// <returns>The string containing the formatted number.</returns>
        public string intToDollars(int i)
        {
            string s = i.ToString();
            if (s.Length > 2)
            {
                s = s.Insert(s.Length - 2, ".");
                s = "$" + s;
            }
            else if (s.Length == 2)
            {
                s = "$0." + s;
            }
            else if (s.Length == 1)
            {
                s = "$0.0" + s;
            }
            return s;
        }

        /// <summary>
        /// Simply gets the user input from the Console.
        /// </summary>
        /// <returns>A string containing what the user typed.</returns>
        public string getUserInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Controls all of the customer-side vending machine operations.
        /// </summary>
        /// <param name="s">The user input.</param>
        public void CustomerOperate(string s, VendingMachine vm)
        {
            if (s == "1")
            {
                coinMenu(vm);
                showCustomerOptions();
            }
            else if (s == "2")
            {
                billMenu(vm);
                showCustomerOptions();
            }
            else if (s == "3")
            {
                Console.WriteLine("Refund . . . " + intToDollars(vm.cBalance));
                vm.cBalance = 0;
                showCustomerOptions();
            }
            else if (s == "99")
            {
                Console.Clear();
                showManagerOptions();
            }
            else if (s == "a" || s == "b" || s == "c" || s == "d" || s == "e")
            {
                int i = vm.vend(s);
                Console.WriteLine("Vending . . . " + vm.getInventory(s).Name);
                if (i != -1)
                {
                    if (i != 0)
                    {
                        Console.WriteLine("Change . . . " + intToDollars(i));
                    }
                }
                showCustomerOptions();
            }
        }

        /// <summary>
        /// Controls all of the manager-side vending machine operations.
        /// </summary>
        /// <param name="s">The user command being inputted.</param>
        public void ManagerOperate(string s)
        {
            if (s == "1")
            {
                addDrinksMenu(vm);
                showManagerOptions();
            }
            else if (s == "2")
            {
                changeNameMenu(vm);
                showManagerOptions();
            }
            else if (s == "3")
            {
                changePriceMenu(vm);
                showManagerOptions();
            }
            else if (s == "4")
            {
                Console.WriteLine("Dispensing: " + intToDollars(vm.Balance));
                vm.Balance = 0;
                showManagerOptions();
            }
            else if (s == "5")
            {
                displayInventoryScreen(vm);
                showManagerOptions();
            }
            else if (s == "6")
            {
                displayResetScreen(vm);
                showManagerOptions();
            }
            else if (s == "99")
            {
                Console.Clear();
                showCustomerOptions();
            }
        }

        /// <summary>
        /// Shows the menu for adding a coin.
        /// </summary>
        public void coinMenu(VendingMachine vend)
        {
            Console.Write("Enter amount (1,5,10,25): ");
            string s = getUserInput();
            vend.addCoin(Convert.ToInt32(s));
        }

        /// <summary>
        /// Shows the menu for adding a bill.
        /// </summary>
        public void billMenu(VendingMachine vend)
        {
            Console.Write("Enter amount (1,5): ");
            vend.addBill(Convert.ToInt32(getUserInput()));
        }

        /// <summary>
        /// Returns a string to display based on drink availability.
        /// </summary>
        /// <param name="i">The inventory item to check.</param>
        /// <returns>A string showing the results.</returns>
        public string getDrinkAvailability(Inventory i)
        {
            if (i.Quantity > 0)
            {
                return "";
            }
            else
            {
                return "(out of stock)";
            }
        }

        /// <summary>
        /// Displays the menu to add drinks to the vending machine.
        /// </summary>
        /// <param name="vend"></param>
        public void addDrinksMenu(VendingMachine vend)
        {
            Console.Write("Enter selection (a..e): ");
            string drink = getUserInput();
            Console.Write("Enter amount to add: ");
            int amt = Convert.ToInt32(getUserInput());
            vend.addDrinks(drink, amt);
        }

        /// <summary>
        /// Changes the name of a given drink.
        /// </summary>
        /// <param name="vend">The vending machine with the drink.</param>
        public void changeNameMenu(VendingMachine vend)
        {
            Console.Write("Enter selection (a..e): ");
            string drink = getUserInput();
            Console.Write("Enter new name: ");
            string oldName = vend.getInventory(drink).Name;
            string newName = getUserInput();
            vend.changeDrinkName(drink, newName);
            Console.WriteLine("Drink name changed from " + oldName + " to " + newName);
        }

        /// <summary>
        /// Changes the price of a given drink.
        /// </summary>
        /// <param name="vend">The vending machine with the drink.</param>
        public void changePriceMenu(VendingMachine vend)
        {
            Console.Write("Enter selection (a..e): ");
            string drink = getUserInput();
            Console.Write("Enter new price, in cents: ");
            int oldPrice = vend.getInventory(drink).Price;
            int newPrice = Convert.ToInt32(getUserInput());
            vend.changeDrinkPrice(drink, newPrice);
            Console.WriteLine("Drink price changed from " + intToDollars(oldPrice) + " to " + intToDollars(newPrice));
        }

        /// <summary>
        /// Displays the inventory screen of the vending machine.
        /// </summary>
        /// <param name="vend"></param>
        public void displayInventoryScreen(VendingMachine vend)
        {
            Console.WriteLine("VM");
            Console.WriteLine("====");
            Console.WriteLine("(a) " + vend.invOne.Name + " ---- " + intToDollars(vend.invOne.Price) + " - " + vend.invOne.Quantity);
            Console.WriteLine("(b) " + vend.invTwo.Name + " ----- " + intToDollars(vend.invTwo.Price) + " - " + vend.invTwo.Quantity);
            Console.WriteLine("(c) " + vend.invThree.Name + " - " + intToDollars(vend.invThree.Price) + " - " + vend.invThree.Quantity);
            Console.WriteLine("(d) " + vend.invFour.Name + " -- " + intToDollars(vend.invFour.Price) + " - " + vend.invFour.Quantity);
            Console.WriteLine("(e) " + vend.invFive.Name + " ---- " + intToDollars(vend.invFive.Price) + " - " + vend.invFive.Quantity);
            Console.WriteLine();
            Console.WriteLine("Vending Machine balance: " + intToDollars(vend.Balance));
            Console.WriteLine();
            Console.Write("Press enter to continue...");
            getUserInput();
        }

        /// <summary>
        /// Displays the reset screen for the given vending machine.
        /// </summary>
        /// <param name="vend">The vending machine to pass in.</param>
        public void displayResetScreen(VendingMachine vend)
        {
            Console.WriteLine("Resetting machine...");
            vend.reset();
            displayInventoryScreen(vend);
        }
    }
}