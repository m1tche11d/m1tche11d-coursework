using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Console
{
    public class VendingMachine
    {
        /// <summary>
        /// The money being held inside the machine.
        /// </summary>
        private int _balance;
        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        /// <summary>
        /// The money that the customer has just put into the machine.
        /// </summary>
        private int _cBalance;
        public int cBalance
        {
            get
            {
                return _cBalance;
            }
            set
            {
                _cBalance = value;
            }
        }

        /// <summary>
        /// The five Inventory array holding the contents of the machine.
        /// </summary>
        Inventory[] _inventory = new Inventory[5];
        public Inventory invOne
        {
            get
            {
                return _inventory[0];
            }
            set
            {
                _inventory[0] = value;
            }
        }
        public Inventory invTwo
        {
            get
            {
                return _inventory[1];
            }
            set
            {
                _inventory[1] = value;
            }
        }
        public Inventory invThree
        {
            get
            {
                return _inventory[2];
            }
            set
            {
                _inventory[2] = value;
            }
        }
        public Inventory invFour
        {
            get
            {
                return _inventory[3];
            }
            set
            {
                _inventory[3] = value;
            }
        }
        public Inventory invFive
        {
            get
            {
                return _inventory[4];
            }
            set
            {
                _inventory[4] = value;
            }
        }

        /// <summary>
        /// The public constructor for the VendingMachine class.
        /// </summary>
        public VendingMachine()
        {
            //Starts the machine with no money and with the default drinks.
            _balance = 0;
            _cBalance = 0;
            _inventory[0] = new Inventory("Pepsi", 125, 10);
            _inventory[1] = new Inventory("Coke", 125, 10);
            _inventory[2] = new Inventory("Red Bull", 225, 10);
            _inventory[3] = new Inventory("Monster", 175, 10);
            _inventory[4] = new Inventory("Water", 100, 10);
        }

        /// <summary>
        /// Checks to see if a drink is in stock.
        /// </summary>
        /// <param name="i">The inventory item to check.</param>
        /// <returns></returns>
        public bool isInStock(Inventory i)
        {
            if (i.Quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if a drink is affordable with current funds.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool canAfford(Inventory i)
        {
            if (cBalance >= i.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the appropriate inventory item from a given letter.
        /// </summary>
        /// <param name="s">The drink that the user selects with a-e.</param>
        /// <returns></returns>
        public Inventory getInventory(string s)
        {
            Inventory i = new Inventory("error", -1, -1);
            if (s == "a")
            {
                i = invOne;
            }
            else if (s == "b")
            {
                i = invTwo;
            }
            else if (s == "c")
            {
                i = invThree;
            }
            else if (s == "d")
            {
                i = invFour;
            }
            else if (s == "e")
            {
                i = invFive;
            }
            return i;
        }

        /// <summary>
        /// Adds a coin to the current balance.
        /// </summary>
        /// <param name="i"></param>
        public void addCoin(int i)
        {
            _cBalance = _cBalance + i;
        }

        /// <summary>
        /// Adds a bill to the current balance.
        /// </summary>
        /// <param name="i"></param>
        public void addBill(int i)
        {
            _cBalance = _cBalance + (i * 100);
        }

        /// <summary>
        /// Sells a drink to a customer with appropriate funds.
        /// </summary>
        /// <param name="s">The letter that the customer pressed for a drink.</param>
        /// <returns>The change as an int. Returns -1 if there was an error.</returns>
        public int vend(string s)
        {
            Inventory i = getInventory(s);
            if (isInStock(i) && canAfford(i))
            {
                _balance = _balance + i.Price;
                i.Quantity--;
                int a = getChange(i);
                cBalance = 0;
                return a;
            }
            else return -1;
        }

        /// <summary>
        /// Calculates the change to be returned for any given operation.
        /// </summary>
        /// <param name="i">The inventory item to be purchased.</param>
        /// <returns></returns>
        public int getChange(Inventory i)
        {
            return cBalance - i.Price;
        }

        /// <summary>
        /// Resets the vending machine and its values.
        /// </summary>
        public void reset()
        {
            foreach (Inventory i in _inventory)
            {
                i.Quantity = 0;
            }
            _balance = 0;
            _cBalance = 0;
        }

        /// <summary>
        /// Returns balance to zero and returns the amount before reset.
        /// </summary>
        /// <returns>The cash withdrawn from the machine in cents.</returns>
        public int withdrawCash()
        {
            int i = _balance;
            _balance = 0;
            return i;
        }

        /// <summary>
        /// Adds drinks to the machine.
        /// </summary>
        /// <param name="s">The letter of the drink to add.</param>
        /// <param name="i">The amount of the drink to add.</param>
        public void addDrinks(string s, int i)
        {
            Inventory inv = getInventory(s);
            inv.Quantity = inv.Quantity + i; ;
        }

        /// <summary>
        /// Sets a new name for a drink.
        /// </summary>
        /// <param name="s">The drink to change.</param>
        /// <param name="newName">The new name for the drink.</param>
        public void changeDrinkName(string s, string newName)
        {
            Inventory i = getInventory(s);
            i.Name = newName;
        }

        /// <summary>
        /// Sets a new price for a drink.
        /// </summary>
        /// <param name="s">The drink to change.</param>
        /// <param name="newPrice">The new price, in cents, for the drink.</param>
        public void changeDrinkPrice(string s, int newPrice)
        {
            Inventory i = getInventory(s);
            i.Price = newPrice;
        }

        /// <summary>
        /// Returns a string to display based on drinks that are available for purchase.
        /// </summary>
        /// <returns></returns>
        public string getAvailableDrinks()
        {
            string s = "";
            if (canAfford(_inventory[0]) && isInStock(_inventory[0]))
            {
                s = s + "a";
            }
            if (canAfford(_inventory[1]) && isInStock(_inventory[1]))
            {
                s = s + "b";
            }
            if (canAfford(_inventory[2]) && isInStock(_inventory[2]))
            {
                s = s + "c";
            }
            if (canAfford(_inventory[3]) && isInStock(_inventory[3]))
            {
                s = s + "d";
            }
            if (canAfford(_inventory[4]) && isInStock(_inventory[4]))
            {
                s = s + "e";
            }

            if (s.Length == 1)
            {
                return "(" + s + ")";
            }
            else if (s.Length == 2)
            {
                s = s.Insert(1, ",");
                return "(" + s + ")";
            }
            else if (s.Length == 3)
            {
                s = s.Insert(2, ",");
                s = s.Insert(1, ",");
                return "(" + s + ")";
            }
            else if (s.Length == 4)
            {
                s = s.Insert(3, ",");
                s = s.Insert(2, ",");
                s = s.Insert(1, ",");
                return "(" + s + ")";
            }
            else if (s.Length == 5)
            {
                s = s.Insert(4, ",");
                s = s.Insert(3, ",");
                s = s.Insert(2, ",");
                s = s.Insert(1, ",");
                return "(" + s + ")";
            }
            else
            {
                return "";
            }
        }
    }
}
