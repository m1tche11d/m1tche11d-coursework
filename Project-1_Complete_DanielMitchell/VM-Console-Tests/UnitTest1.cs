using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM_Console;
using System.IO;

namespace VM_Console_Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests the entire inventory class
        /// </summary>
        [TestMethod]
        public void InventoryTest()
        {
            Inventory i = new Inventory("new coke", 225, 10);

            Assert.AreEqual(i.Name, "new coke");
            Assert.AreEqual(i.Price, 225);
            Assert.AreEqual(i.Quantity, 10);

            i.Name = "crystal pepsi";
            i.Price = 200;
            i.Quantity = 1;

            Assert.AreEqual(i.Name, "crystal pepsi");
            Assert.AreEqual(i.Price, 200);
            Assert.AreEqual(i.Quantity, 1);
        }

        /// <summary>
        /// Tests the public properties of the VendingMachine class
        /// </summary>
        [TestMethod]
        public void VendingMachineTest1()
        {
            //initializes a new vending machine
            VendingMachine vm = new VendingMachine();

            //Checks the initial values of the machine's balance properties.
            Assert.AreEqual(vm.Balance, 0);
            Assert.AreEqual(vm.cBalance, 0);

            //Checks the initial values of each property of the machine's inventory.
            Assert.AreEqual(vm.invOne.Name, "Pepsi");
            Assert.AreEqual(vm.invOne.Price, 125);
            Assert.AreEqual(vm.invOne.Quantity, 10);
            Assert.AreEqual(vm.invTwo.Name, "Coke");
            Assert.AreEqual(vm.invTwo.Price, 125);
            Assert.AreEqual(vm.invTwo.Quantity, 10);
            Assert.AreEqual(vm.invThree.Name, "Red Bull");
            Assert.AreEqual(vm.invThree.Price, 225);
            Assert.AreEqual(vm.invThree.Quantity, 10);
            Assert.AreEqual(vm.invFour.Name, "Monster");
            Assert.AreEqual(vm.invFour.Price, 175);
            Assert.AreEqual(vm.invFour.Quantity, 10);
            Assert.AreEqual(vm.invFive.Name, "Water");
            Assert.AreEqual(vm.invFive.Price, 100);
            Assert.AreEqual(vm.invFive.Quantity, 10);

            //Sets the balance variable to all new values...
            vm.Balance = 13276;
            vm.cBalance = 250;

            //...and then checks again to make sure that they are set correctly
            Assert.AreEqual(vm.Balance, 13276);
            Assert.AreEqual(vm.cBalance, 250);

            //Sets the inventory variables to all new values...
            vm.invOne = new Inventory("new name", 500, 200);
            vm.invTwo = new Inventory("new name", 500, 200);
            vm.invThree = new Inventory("new name", 500, 200);
            vm.invFour = new Inventory("new name", 500, 200);
            vm.invFive = new Inventory("new name", 500, 200);

            //...and then checks again to make sure that they are set correctly
            Assert.AreEqual(vm.invOne.Name, "new name");
            Assert.AreEqual(vm.invOne.Price, 500);
            Assert.AreEqual(vm.invOne.Quantity, 200);
            Assert.AreEqual(vm.invTwo.Name, "new name");
            Assert.AreEqual(vm.invTwo.Price, 500);
            Assert.AreEqual(vm.invTwo.Quantity, 200);
            Assert.AreEqual(vm.invThree.Name, "new name");
            Assert.AreEqual(vm.invThree.Price, 500);
            Assert.AreEqual(vm.invThree.Quantity, 200);
            Assert.AreEqual(vm.invFour.Name, "new name");
            Assert.AreEqual(vm.invFour.Price, 500);
            Assert.AreEqual(vm.invFour.Quantity, 200);
            Assert.AreEqual(vm.invFive.Name, "new name");
            Assert.AreEqual(vm.invFive.Price, 500);
            Assert.AreEqual(vm.invFive.Quantity, 200);
        }

        /// <summary>
        /// Tests the remaining Vending Machine methods
        /// </summary>
        [TestMethod]
        public void VendingMachineTest2()
        {
            //Initializes a new vending machine and inventory item to test functions with.
            VendingMachine vm = new VendingMachine();
            Inventory i = new Inventory("testInventory", 100, 10);

            //Tests both branches of the isInStock function.
            Assert.AreEqual(vm.isInStock(i), true);
            i.Quantity = 0;
            Assert.AreEqual(vm.isInStock(i), false);

            //Tests both branches of the canAfford function.
            vm.cBalance = 125;
            Assert.AreEqual(vm.canAfford(i), true);
            vm.cBalance = 50;
            Assert.AreEqual(vm.canAfford(i), false);

            //Tests both currency adding functions.
            vm.cBalance = 0;
            vm.addCoin(25);
            Assert.AreEqual(vm.cBalance, 25);
            vm.addBill(5);
            Assert.AreEqual(vm.cBalance, 525);

            //Tests the getInventory function.
            i = vm.getInventory("a");
            Assert.AreEqual(i.Name, vm.invOne.Name);
            Assert.AreEqual(i.Price, vm.invOne.Price);
            Assert.AreEqual(i.Quantity, vm.invOne.Quantity);
            i = vm.getInventory("b");
            Assert.AreEqual(i.Name, vm.invTwo.Name);
            Assert.AreEqual(i.Price, vm.invTwo.Price);
            Assert.AreEqual(i.Quantity, vm.invTwo.Quantity);
            i = vm.getInventory("c");
            Assert.AreEqual(i.Name, vm.invThree.Name);
            Assert.AreEqual(i.Price, vm.invThree.Price);
            Assert.AreEqual(i.Quantity, vm.invThree.Quantity);
            i = vm.getInventory("d");
            Assert.AreEqual(i.Name, vm.invFour.Name);
            Assert.AreEqual(i.Price, vm.invFour.Price);
            Assert.AreEqual(i.Quantity, vm.invFour.Quantity);
            i = vm.getInventory("e");
            Assert.AreEqual(i.Name, vm.invFive.Name);
            Assert.AreEqual(i.Price, vm.invFive.Price);
            Assert.AreEqual(i.Quantity, vm.invFive.Quantity);

            //Tests both branches of the vend function.
            vm.cBalance = 200;
            vm.Balance = 0;
            vm.vend("a");
            Assert.AreEqual(vm.Balance, 125);
            Assert.AreEqual(vm.invOne.Quantity, 9);
            Assert.AreEqual(vm.cBalance, 0);
            vm.cBalance = 50;
            vm.vend("a");
            Assert.AreEqual(vm.Balance, 125);
            Assert.AreEqual(vm.invOne.Quantity, 9);
            Assert.AreEqual(vm.cBalance, 50);
            vm.cBalance = 200;
            vm.Balance = 125;
            vm.invOne.Quantity = 0;
            vm.vend("a");
            Assert.AreEqual(vm.cBalance, 200);
            Assert.AreEqual(vm.invOne.Quantity, 0);
            Assert.AreEqual(vm.Balance, 125);

            //Tests the getChange function.
            vm.cBalance = 200;
            int transactionChange = vm.getChange(vm.invOne);
            Assert.AreEqual(transactionChange, 75);

            //Tests the reset function.
            vm.reset();
            Assert.AreEqual(vm.invOne.Quantity, 0);
            Assert.AreEqual(vm.invTwo.Quantity, 0);
            Assert.AreEqual(vm.invThree.Quantity, 0);
            Assert.AreEqual(vm.invFour.Quantity, 0);
            Assert.AreEqual(vm.invFive.Quantity, 0);
            Assert.AreEqual(vm.Balance, 0);
            Assert.AreEqual(vm.cBalance, 0);

            //Tests the withdrawCash function.
            vm.Balance = 12376;
            Assert.AreEqual(vm.withdrawCash(), 12376);
            Assert.AreEqual(vm.Balance, 0);

            //Tests the addDrinks function.
            vm.reset();
            vm.addDrinks("a", 200);
            Assert.AreEqual(vm.invOne.Quantity, 200);

            //Tests the changeDrinkName and changeDrinkPrice functions.
            vm.changeDrinkName("a", "testNameOne");
            vm.changeDrinkPrice("a", 1000);
            Assert.AreEqual(vm.invOne.Name, "testNameOne");
            Assert.AreEqual(vm.invOne.Price, 1000);

            //Tests all six possible outcomes of the getAvailableDrinks function.
            vm = new VendingMachine();
            vm.changeDrinkPrice("a", 1000);
            vm.cBalance = 0;
            Assert.AreEqual(vm.getAvailableDrinks(), "");
            vm.cBalance = 100;
            Assert.AreEqual(vm.getAvailableDrinks(), "(e)");
            vm.cBalance = 125;
            Assert.AreEqual(vm.getAvailableDrinks(), "(b,e)");
            vm.cBalance = 175;
            Assert.AreEqual(vm.getAvailableDrinks(), "(b,d,e)");
            vm.cBalance = 399;
            Assert.AreEqual(vm.getAvailableDrinks(), "(b,c,d,e)");
            vm.cBalance = 1000;
            Assert.AreEqual(vm.getAvailableDrinks(), "(a,b,c,d,e)");
        }

        /// <summary>
        /// Tests the basic controller construction and functions.
        /// </summary>
        [TestMethod]
        public void BasicControllerTest()
        {
            //Initializes a new controller and vending machine for the tests.
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();

            //Tests both branches of the getDrinkAvailability function.
            Assert.AreEqual(c.getDrinkAvailability(vm.invOne), "");
            vm.invOne.Quantity = 0;
            Assert.AreEqual(c.getDrinkAvailability(vm.invOne), "(out of stock)");

            //Tests the three possible brances of the intToDollars function.
            string s1 = c.intToDollars(5);
            string s2 = c.intToDollars(65);
            string s3 = c.intToDollars(754);
            Assert.AreEqual(s1, "$0.05");
            Assert.AreEqual(s2, "$0.65");
            Assert.AreEqual(s3, "$7.54");
        }

        [TestMethod]
        public void CustomerOptionsTest()
        {
            Controller c = new Controller();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.showCustomerOptions();
                string expected = string.Format("{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void ManagerOptionsTest()
        {
            Controller c = new Controller();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.showManagerOptions();
                string expected = string.Format("{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Add drinks to inventory{0}2. Change drink's name{0}3. Change drink's price{0}4. Withdraw money{0}5. Show inventory{0}6. Reset Vending Machine{0}{0}Enter selection (1..6): ", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void getUserInputTest()
        {
            Controller c = new Controller();
            using (StringReader sr = new StringReader("foo"))
            {
                Console.SetIn(sr);

                string actual = c.getUserInput();
                string expected = "foo";

                Assert.AreEqual<string>(expected, actual);
            }
        }

        /// <summary>
        /// Tests the coin menu method
        /// </summary>
        [TestMethod]
        public void coinMenuTest()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            vm.cBalance = 200;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("25{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.coinMenu(vm);
                    string expected = "Enter amount (1,5,10,25): ";
                    string actual = sw.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        /// <summary>
        /// Tests the bill menu method.
        /// </summary>
        [TestMethod]
        public void billMenuTest()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            vm.cBalance = 200;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("5{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.billMenu(vm);
                    string expected = "Enter amount (1,5): ";
                    string actual = sw.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        /// <summary>
        /// Tests the inventory display screen.
        /// </summary>
        [TestMethod]
        public void InventoryDisplayTest()
        {
            Controller c = new Controller();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(""))
                {
                    Console.SetIn(sr);
                    VendingMachine vm = new VendingMachine();
                    c.displayInventoryScreen(vm);
                    string expected = string.Format("VM{0}===={0}(a) Pepsi ---- $1.25 - 10{0}(b) Coke ----- $1.25 - 10{0}(c) Red Bull - $2.25 - 10{0}(d) Monster -- $1.75 - 10{0}(e) Water ---- $1.00 - 10{0}{0}Vending Machine balance: $0.00{0}{0}Press enter to continue...", Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        /// <summary>
        /// Tests the displayResetScreen function
        /// </summary>
        [TestMethod]
        public void ResetDisplayTest()
        {
            Controller c = new Controller();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(""))
                {
                    Console.SetIn(sr);
                    VendingMachine vm = new VendingMachine();
                    c.displayResetScreen(vm);
                    string expected = string.Format("Resetting machine...{0}VM{0}===={0}(a) Pepsi ---- $1.25 - 0{0}(b) Coke ----- $1.25 - 0{0}(c) Red Bull - $2.25 - 0{0}(d) Monster -- $1.75 - 0{0}(e) Water ---- $1.00 - 0{0}{0}Vending Machine balance: $0.00{0}{0}Press enter to continue...", Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        /// <summary>
        /// Tests the drink adding method
        /// </summary>
        [TestMethod]
        public void DrinkAddTest()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("a{0}10{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.addDrinksMenu(vm);
                    string expected = string.Format("Enter selection (a..e): Enter amount to add: ", Environment.NewLine);
                    string actual = sw.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        /// <summary>
        /// Makes sure that the price change function works correctly.
        /// </summary>
        [TestMethod]
        public void PriceChangeTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Controller c = new Controller();
                VendingMachine vm = new VendingMachine();

                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("a{0}234{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.changePriceMenu(vm);
                    string expected = string.Format("Enter selection (a..e): Enter new price, in cents: Drink price changed from $1.25 to $2.34{0}", Environment.NewLine);
                    Assert.AreEqual(expected, sw.ToString());
                }
            }
        }

        /// <summary>
        /// Makes sure that the name change function works correctly.
        /// </summary>
        [TestMethod]
        public void NameChangeTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Controller c = new Controller();
                VendingMachine vm = new VendingMachine();

                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("a{0}Coca-Cola{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.changeNameMenu(vm);
                    string expected = string.Format("Enter selection (a..e): Enter new name: Drink name changed from Pepsi to Coca-Cola{0}", Environment.NewLine);
                    Assert.AreEqual(expected, sw.ToString());
                }
            }
        }

        /// <summary>
        /// Makes sure that the Main method starts the program correctly.
        /// </summary>
        [TestMethod]
        public void MainTest()
        {
            Program.Main(new string[] { });
            Controller c = new Controller();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.showCustomerOptions();
                string expected = string.Format("{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        /// <summary>
        /// Tests what happens if the customer inputs 1
        /// </summary>
        [TestMethod]
        public void CustomerMenuTest1()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            vm.cBalance = 200;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("25{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.CustomerOperate("1", vm);
                    string expected = string.Format("Enter amount (1,5,10,25): {0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                    string actual = sw.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        /// <summary>
        /// Tests what happens if the customer inputs 2
        /// </summary>
        [TestMethod]
        public void CustomerMenuTest2()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            vm.cBalance = 200;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader sr = new StringReader(string.Format("5{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    c.CustomerOperate("2", vm);
                    string expected = string.Format("Enter amount (1,5): {0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                    string actual = sw.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }

        /// <summary>
        /// Tests what happens if the customer inputs 3
        /// </summary>
        [TestMethod]
        public void CustomerMenuTest3()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.CustomerOperate("3", vm);
                string expected = string.Format("Refund . . . $0.00{0}{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                string actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }
        }

        /// <summary>
        /// Tests what happens if the customer inputs 99
        /// </summary>
        [TestMethod]
        public void CustomerMenuTest99()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.CustomerOperate("99", vm);
                string expected = string.Format("{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Add drinks to inventory{0}2. Change drink's name{0}3. Change drink's price{0}4. Withdraw money{0}5. Show inventory{0}6. Reset Vending Machine{0}{0}Enter selection (1..6): ", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        /// <summary>
        /// Tests what happens if the customer inputs a letter
        /// </summary>
        [TestMethod]
        public void CustomerMenuTesta()
        {
            Controller c = new Controller();
            VendingMachine vm = new VendingMachine();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                c.CustomerOperate("a", vm);
                string expected = string.Format("Vending . . . Pepsi{0}{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                string actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
                using (StringWriter sw2 = new StringWriter())
                {
                    Console.SetOut(sw2);
                    vm.cBalance = 150;
                    c.CustomerOperate("a", vm);
                    expected = string.Format("Vending . . . Pepsi{0}Change . . . $0.25{0}{0}****************************************{0}****************************************{0}{0}VM{0}===={0}(a) Pepsi ---- $1.25 {0}(b) Coke ----- $1.25 {0}(c) Red Bull - $2.25 {0}(d) Monster -- $1.75 {0}(e) Water ---- $1.00 {0}{0}Menu{0}----{0}1. Insert coin{0}2. Insert bill{0}3. Cancel{0}{0}Amount: $0.00{0}Enter selection (1..3): ", Environment.NewLine);
                    actual = sw2.ToString();
                    Assert.AreEqual<string>(expected, actual);
                }
            }
        }


    }
}