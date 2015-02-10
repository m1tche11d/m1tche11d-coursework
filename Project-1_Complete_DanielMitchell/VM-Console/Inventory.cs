using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Console
{
    public class Inventory
    {
        /// <summary>
        /// The string containing the name of the inventory item.
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// The int containing the price in cents of the inventory item.
        /// </summary>
        private int _price;
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// The int containing the quantity of the inventory item.
        /// </summary>
        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        /// <summary>
        /// The public constructor for class Inventory
        /// </summary>
        /// <param name="s">The name of the item.</param>
        /// <param name="p">The price, in cents, of the item.</param>
        /// <param name="q">The quantity of the item to initially carry.</param>
        public Inventory(string s, int p, int q)
        {
            _name = s;
            _price = p;
            _quantity = q;
        }
    }
}
