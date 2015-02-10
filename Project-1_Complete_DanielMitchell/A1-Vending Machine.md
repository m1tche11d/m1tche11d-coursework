# Assignment 1: Vending Machine Console App

**Deadline: February 06, 2015, 11:59pm, US Central**

## Tasks

In this first assignment, you are to develop a simple console app to simulate
a Vending Machine (VM). 

That is, the *VM* app *manages* an inventory of five *drinks*. Each drink consists of
*name*, a *price* and a *quantity* in stock.
The app works is two modes *customer* and *manager*
In the customer mode, the app provides several *operations* to:
(1) *buy* a drink,
(2) to *add* coins/bills to purchase a drink,
(3) to *select* the drink, 
(4) *cnacel* the purchase, and

In the managers mode, the app provides several *operations* to:
(1) *add* drinks to drinks inventory,
(2) to *withdraw* the money in the deposit box,
(3) to *change* a drink's name
(4) to *update* the drink's price
(5) to *show* the VM inventory/balance, and
(6) to *reset* VM


Since this is a console app, it is menu-based not UI-based
The menu system is best described using a running demo of the app input/output
below (when the app is started, it displays the VM vustomer's menu:

```
-----------------------------
 VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.00

Enter selection (1..3): 1
Amount (1,5,10,25): 25
---------------------------

 VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.25

Enter selection (1..3): 2
Amount (1,5): 1
--------------------------

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $1.25

Enter selection (1..3) (a,b): a
Vending... Pepsi
--------------------------
***************************************

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.00

Enter selection (1..3): 1
Amount (1,5,10,25): 25
---------------------------

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.25

Enter selection (1..3): 2
Amount (1,5): 1
--------------------------

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $1.25

Enter selection (1..3) (a,b): 2
Amount (1,5): 1
--------------------------

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $2.25

Enter selection (1..3) (a,b,c,d,e): d
Vending... Monster
Change ... $$0.50
--------------------------
****************************************

-----------------------------
VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.00

Enter selection (1..3): 1
Amount (1,5,10,25): 25
---------------------------

VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.25

Enter selection (1..3): 2
Amount (1,5): 1
--------------------------


VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $1.25

Enter selection (1..3) (b): b
Vending... Coke
--------------------------
****************************************

VM
=====
(a) Pepsi --- $1.25 
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.00

Enter selection (1..3): 1
Amount (1,5,10,25): 25
---------------------------

VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.25

Enter selection (1..3): 2
Amount (1,5): 1
--------------------------


VM
=====
(a) Pepsi --- $1.25
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $1.25

Enter selection (1..3) (a, b): 3
Refaund.... $1.25
--------------------------
****************************************
****************************************

VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Insert coin
2. Insert bill
3. Cancel

Amount: $0.00

Enter selection (1..3): 99
Going to 'Manager' mode
---------------------------

VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (1..6): 1
--------------------------

VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (a..e):a
Enter quantity: 5

--------------------------
VM
=====
(a) Pepsi --- $1.25 
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (1..6):

--------------------------
****************************************

VM
=====
(a) Pepsi --- $1.25 
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM

Enter selection (1..3): 2
Change price for (a..e): d
New price: $2.00

Price changed from $175 to $2.00
---------------------------
****************************************
VM
=====
(a) Pepsi --- $1.25 
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $2.00
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (1..6): 4
Dispensing: $145.25
--------------------------
****************************************
VM
=====
(a) Pepsi --- $1.25 (out of stock)
(b) Coke  --- $1.25
(c) RedBull - $2.25
(d) Monster - $1.75
(e) Water   - $1.00

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (1..6):5
Enter quantity: 5

--------------------------
VM
=====
(a) Pepsi --- $1.25 - 10
(b) Coke  --- $1.25 -  6
(c) RedBull - $2.25 -  3
(d) Monster - $1.75 -  4
(e) Water   - $1.00 - 12

Cash: $98.75

Menu
----
1. Add drinks to inventory
2. Change drink's name
3. Change drink's price
4. *Withdraw* money
5. *Show* inventory
6. *Reset* VM


Enter selection (1..6):6

Reseting all values to zero...
(a) Pepsi --- $1.25 -  0
(b) Coke  --- $1.25 -  0
(c) RedBull - $2.25 -  0
(d) Monster - $1.75 -  0
(e) Water   - $1.00 -  0

Cash: $0.00
--------------------------



Your tasks for this assignments are to:

1. implement the above menu-based Todo console app.

   **Important**: You should put comments at each class and method, even a group
   of statements to help us understand your implementation (see 
   the ``TodoConsoleTest.test`` method for example). 

2. develop automated app tests that reach **100%** coverage of the app code; 
   see the course notes on
   [(console) app testing](http://softwarearch.santoslab.org/01-tooling/index.html#app-testing)
   (the tests for the course note prime tool example reach 100% coverage).
   For most tests, you should have the expected output similar to the prime tool
   tests; note that you should be careful with white-spaces when entering 
   your expected output.
   You can first run the tests without an expected output (e.g., ``null``),
   once you inspect the output manually, you can copy and paste the test output
   to become the expected output.
   The tests are useful for detecting regression in your code when you modify
   the code later on (this is called *regression testing*).

**Important**: for each operation and sub-operation, you should define one test.
For example, based on the menu system illustrated above, there should be 1 test
defined to exercise adding a new entry; in addition, the app allows user
to cancel entry addition by entering an "empty" input for the entry description,
thus, 1 test should be defined to illustrate this scenario.
Note that your max score for this assignment is capped by the amount of test
coverage that you achieve. 
That is, if the assignment is worth 10 points and your tests cover only, for
example, 80% coverage, then, your max score is 8 out of 10.
The model solution achieves 100% coverage using 15 test scripts (and those
are not the minimal set); this gives an idea on the amount of efforts that you
should expect to spend.

The provided Visual Studio solution consists of two projects: 
(1) ``VM-Console``, and (2) ``VM-Console-Tests`` as starting point for 
the two tasks above (respectively).

**Note:** If you have specific programming questions, we are happy to answer 
them. However, try Googling or searching for answers at 
http://stackoverflow.com,  
http://msdn.microsoft.com, and
http://www.dotnetperls.com first because it is highly likely that people have 
asked similar questions in the past.
This helps you to make progress without waiting for us to respond to your 
questions (or even waiting to set up an appointment first).
If you send us a question, we will actually try Googling your question first
and see if it turns out with some acceptable answers that we believe you should
understand; if so, we will send you the links (and then setup an appointment 
if you still need more help).
This is how people in the industry (and the instructor) work with their peers
(i.e., by leveraging online resources for self-learning first and then resort
to asking for help from colleagues).
   

## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub 
by the deadline.
