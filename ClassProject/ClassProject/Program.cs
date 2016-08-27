using System;


namespace ClassProject
{

    //Create the struct with the appropriate data elements
    public struct InventoryData
    {
        public int IDNo;
        public string Description;
        public double PricePerItem;
        public int QuantityOnHand;
        public double OurCostPerItem;
        public double ValueofItem;
    }

    class MyInventory
    {
        static void Main()
        {
            //Initialize the array
            var numberofitems = 0;
            var inventorydata = new InventoryData[100];

            //Begin loop to capture user responses and enter data into the array
            while (true)
            {
                //Present main menu to the user and capture their menu selection
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Please select an option from the list below.\nA)dd an item\nC)hange an item\nD)elete an item\nL)ist all items\nQ)uit\n");
                string selection = Console.ReadLine();

                //Begin switch statement based on user's selected value from the main menu
                switch (selection)
                {

                    //Add Case
                    case "A":
                    case "a":
                        {
                            Console.WriteLine("You've chosen to add an item.\nPlease enter the following information:\n\n");

                            //Collect the user input value for the Item ID field
                            Console.Write("Our Item ID# (5 digit maximum): ");
                            var idno = Console.ReadLine();
                            bool existingvalue = false;

                            //Begin validation loop for error checking on the user input value for Item ID
                            while (true)
                            {
                                existingvalue = false;

                                //Throw error if user failed to input a value
                                if (idno.Length == 0)
                                {
                                    Console.WriteLine("\n\n");
                                    Console.Write("ERROR:  You must enter an Item ID#.  Please enter a value: ");
                                    idno = Console.ReadLine();
                                }
                                else
                                {
                                    //Check to see if the user input value already exists in the Item ID field in the array.  If so, set the existingvalue to true
                                    for (var index = 0; index < numberofitems;)
                                    {
                                        if (inventorydata[index].IDNo == int.Parse(idno))
                                        {
                                            existingvalue = true;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    //Throw an error if user input a value greater than five characters in length
                                    if (idno.Length > 5)
                                    {
                                        Console.WriteLine("\n\n");
                                        Console.Write("ERROR:  The value you have entered is greater than the 5 digit maximum.  Please enter another value: ");
                                        idno = Console.ReadLine();
                                    }

                                    //Throw an error if the user input value already exists in the array
                                    else if (existingvalue == true)
                                    {
                                        Console.WriteLine("\n\n");
                                        Console.Write("ERROR:  This Item ID# is already in use.  Please enter a unique Item ID#:  ");
                                        idno = Console.ReadLine();
                                    }

                                    //Break out of loop
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            //Collect the user input value for the Description field
                            Console.Write("Item Description (20 character maximum): ");
                            var description = Console.ReadLine();

                            //Check to ensure the user input Description doesn't exceed 20 characters.  If it does remove any characters beyond the limit and display captured value to the user
                            while (description.Length > 20)
                            {
                                description = description.Remove(20);
                                Console.Write("Description is more than 20 characters.  {0} will be saved as the item description.", description);
                                Console.WriteLine("\n\n");
                            }

                            //Collect the user input value for the Price field
                            Console.Write("Price We Charge Per Item: ");
                            var priceperitem = Console.ReadLine();

                            //Collect the user input value for the Quantity On Hand field
                            Console.Write("Quantity Currently On Hand: ");
                            var quantityonhand = Console.ReadLine();

                            //Collect the user input value for the Cost field
                            Console.Write("What Did We Pay For the Item (our cost per item)?: ");
                            var ourcostperitem = Console.ReadLine();

                            //Calculate the Value field based on user input for the Price and Quantity On Hand fields
                            double valueofitem = double.Parse(priceperitem) * double.Parse(quantityonhand);

                            //Write the user input values to the array
                            inventorydata[numberofitems].IDNo = int.Parse(idno);
                            inventorydata[numberofitems].Description = description;
                            inventorydata[numberofitems].PricePerItem = double.Parse(priceperitem);
                            inventorydata[numberofitems].QuantityOnHand = int.Parse(quantityonhand);
                            inventorydata[numberofitems].OurCostPerItem = double.Parse(ourcostperitem);
                            inventorydata[numberofitems].ValueofItem = valueofitem;
                            numberofitems++;

                            //Break out of the case
                            break;
                        }

                    //Change Case
                    case "C":
                    case "c":
                        {
                            //Throw an error if the list is empty
                            if (numberofitems == 0)
                            {
                                Console.WriteLine("\nERROR:  There are no items in the inventory to change.");
                                Console.WriteLine("\n\n");
                                break;
                            }

                            //Display Current List
                            Console.WriteLine("\n\n");
                            Console.WriteLine("#      ItemID  Description           Price   QOH   Cost   Value");
                            Console.WriteLine("-----  ------  --------------------  ------  ----  -----  -----");

                            for (var index = 0; index < numberofitems; index++)
                            {
                                Console.WriteLine("{0,-6} {1,-7} {2,-21} {3,-7:C} {4,-5} {5,-6:C} {6,-5:C}", index + 1, inventorydata[index].IDNo, inventorydata[index].Description, inventorydata[index].PricePerItem, inventorydata[index].QuantityOnHand, inventorydata[index].OurCostPerItem, inventorydata[index].ValueofItem);
                            }
                            Console.WriteLine("\n\n");

                            //Identify user's selected item to change
                            Console.Write("Above is a list of all items currently in our inventory.  Please select the # of the item you would like to change.:  ");
                            var changechoice = Console.ReadLine();
                            var indexchange = int.Parse(changechoice);
                            bool repeatchangeloop = true;

                            while (repeatchangeloop)
                            {
                                //Ensure the user has made a valid selection.  If not, loop until they make a valid selection
                                while (true)
                                {
                                    if (indexchange < 1 || indexchange > numberofitems)
                                    {
                                        Console.WriteLine("\n\n");
                                        Console.Write("ERROR: The # you have selected is invalid.  Please enter a valid #: ");
                                        indexchange = int.Parse(Console.ReadLine());
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                //Identify user's selected field to change
                                Console.WriteLine("\n\n");
                                Console.WriteLine("Please select the field you'd like to change from the list below.\n1. Item ID\n2. Description\n3. Price\n4. Quantity On Hand\n5. Cost\n");
                                string fieldchoice = Console.ReadLine();
                                switch (fieldchoice)
                                {
                                    case "1":
                                        fieldchoice = "Item ID";
                                        break;
                                    case "2":
                                        fieldchoice = "Description";
                                        break;
                                    case "3":
                                        fieldchoice = "Price";
                                        break;
                                    case "4":
                                        fieldchoice = "Quantity On Hand";
                                        break;
                                    case "5":
                                        fieldchoice = "Cost";
                                        break;
                                    default:
                                        {
                                            //Write error message if user selects something other than a valid case
                                            Console.WriteLine("\nERROR:  {0} is not a valid selection. Please make a valid selection", fieldchoice);

                                            //Break out of the case
                                            break;
                                        }
                                }

                                //Collect the user's new value for the field
                                Console.WriteLine("\n\n");
                                Console.Write("Please enter a new {0} value: ", fieldchoice);
                                var changeanswer = Console.ReadLine();

                                //Collect new user input values based on the field they've chosen to update
                                switch (fieldchoice)
                                {
                                    //Take user input for the new Item ID# and run through the error checking and update the value in the array
                                    case "Item ID":
                                        {
                                            bool existingvalue = false;

                                            //Begin validation loop for error checking on the user input value for Item ID
                                            while (true)
                                            {
                                                existingvalue = false;

                                                //Throw error if user failed to input a value
                                                if (changeanswer.Length == 0)
                                                {
                                                    Console.WriteLine("\n\n");
                                                    Console.Write("ERROR:  You must enter an Item ID#.  Please enter a value: ");
                                                    changeanswer = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    //Check to see if the user input value already exists in the Item ID field in the array.  If so, set the existingvalue to true
                                                    for (var index = 0; index < numberofitems;)
                                                    {
                                                        if (inventorydata[index].IDNo == int.Parse(changeanswer))
                                                        {
                                                            existingvalue = true;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }

                                                    //Throw an error if user input a value greater than five characters in length
                                                    if (changeanswer.Length > 5)
                                                    {
                                                        Console.WriteLine("\n\n");
                                                        Console.Write("ERROR:  The value you have entered is greater than the 5 digit maximum.  Please enter another value: ");
                                                        changeanswer = Console.ReadLine();
                                                    }

                                                    //Throw an error if the user input value already exists in the array
                                                    else if (existingvalue == true)
                                                    {
                                                        Console.WriteLine("\n\n");
                                                        Console.Write("ERROR:  This Item ID# is already in use.  Please enter a unique Item ID#:  ");
                                                        changeanswer = Console.ReadLine();
                                                    }

                                                    //Break out of loop
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }

                                            //Overwrite the existing value with the new input value provided by the user
                                            inventorydata[indexchange - 1].IDNo = int.Parse(changeanswer);
                                            break;
                                        }

                                    //Take user input for the new Description
                                    case "Description":
                                        {

                                            //Check to ensure the user input Description doesn't exceed 20 characters.  If it does remove any characters beyond the limit and display captured value to the user
                                            while (changeanswer.Length > 20)
                                            {
                                                changeanswer = changeanswer.Remove(20);
                                                Console.Write("Description is more than 20 characters.  {0} will be saved as the item description.", changeanswer);
                                                Console.WriteLine("\n\n");
                                            }
                                            inventorydata[indexchange - 1].Description = changeanswer;
                                            break;
                                        }

                                    //Take user input for the new Price.  Calculate and update the Value based on the existing Quantity On Hand and the newly entered Price
                                    case "Price":
                                        {
                                            inventorydata[indexchange - 1].PricePerItem = double.Parse(changeanswer);
                                            inventorydata[indexchange - 1].ValueofItem = inventorydata[indexchange - 1].PricePerItem * inventorydata[indexchange - 1].QuantityOnHand;
                                            break;
                                        }

                                    //Take user input for the new Quantity On Hand.  Calculate and update the Value based on the existing Price and the newly entered Quantity
                                    case "Quantity On Hand":
                                        {
                                            inventorydata[indexchange - 1].QuantityOnHand = int.Parse(changeanswer);
                                            inventorydata[indexchange - 1].ValueofItem = inventorydata[indexchange - 1].PricePerItem * inventorydata[indexchange - 1].QuantityOnHand;
                                            break;
                                        }
                                    case "Cost":
                                        {
                                            inventorydata[indexchange - 1].OurCostPerItem = double.Parse(changeanswer);
                                            break;
                                        }
                                }

                                Console.WriteLine("\n\n");
                                Console.Write("Would you like to make another update to line # {0}? Y/N:  ", indexchange);
                                string anotherchange = Console.ReadLine();
                                switch(anotherchange)
                                {
                                    case "N":
                                    case "n":
                                        {
                                            repeatchangeloop = false;
                                            break;
                                        }
                                    case "Y":
                                    case "y":
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\n\n");
                                            Console.Write("{0} is an invalid selection.  Please make a valid selection of Y or N: ", anotherchange);

                                            break;
                                        }  
                                }  
                            }

                            //Break out of the case
                            break;
                        }
                    
                    //Delete Case
                    case "D":
                    case "d":
                        {
                            //Throw an error if the list is empty
                            if (numberofitems == 0)
                            {
                                Console.WriteLine("\nERROR:  There are no items in the inventory to delete.");
                                Console.WriteLine("\n\n");
                                break;
                            }

                            //Display current list
                            Console.WriteLine("\n\n");
                            Console.WriteLine("#      ItemID  Description           Price   QOH   Cost   Value");
                            Console.WriteLine("-----  ------  --------------------  ------  ----  -----  -----");

                            for (var index = 0; index < numberofitems; index++)
                            {
                                Console.WriteLine("{0,-6} {1,-7} {2,-21} {3,-7:C} {4,-5} {5,-6:C} {6,-5:C}", index + 1, inventorydata[index].IDNo, inventorydata[index].Description, inventorydata[index].PricePerItem, inventorydata[index].QuantityOnHand, inventorydata[index].OurCostPerItem, inventorydata[index].ValueofItem);
                            }
                            Console.WriteLine("\n\n");

                            //Identify user's selected item to delete
                            Console.Write("Above is a list of all items currently in our inventory.  Please select the # of the item you would like to remove.:  ");
                            var deletechoice = Console.ReadLine();
                            var indexdelete = int.Parse(deletechoice);
                            
                            //Ensure the user has made a valid selection.  If not, loop until they make a valid selection
                            while (true)
                            {
                                if (indexdelete < 1 || indexdelete > numberofitems)
                                {
                                    Console.WriteLine("\n\n");
                                    Console.Write("ERROR: The # you have selected is invalid.  Please enter a valid #: ");
                                    indexdelete = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    break;
                                }
                            }

                            //Delete user's selected item and re-assign the item #'s for the subsequent items in the list
                            for (var index = indexdelete - 1; index < numberofitems; index++)
                                {
                                    inventorydata[index] = inventorydata[index + 1];
                                }
                                numberofitems--;
                           
                            //Break out of the case
                            break;
                        }   

                    //List case           
                    case "L":
                    case "l":
                        {

                            //Ensure the list has values to display and display current list
                            if (numberofitems > 0)
                            {
                                Console.WriteLine("\n\n");
                                Console.WriteLine("Here is a list of all items currently in our inventory\n");
                                Console.WriteLine("#      ItemID  Description           Price   QOH   Cost   Value");
                                Console.WriteLine("-----  ------  --------------------  ------  ----  -----  -----");

                                for (int index = 0; index < numberofitems; index++)
                                {
                                    Console.WriteLine("{0,-6} {1,-7} {2,-21} {3,-7:C} {4,-5} {5,-6:C} {6,-5:C}", index + 1, inventorydata[index].IDNo, inventorydata[index].Description, inventorydata[index].PricePerItem, inventorydata[index].QuantityOnHand, inventorydata[index].OurCostPerItem, inventorydata[index].ValueofItem);
                                }
                                Console.WriteLine("\n\n");
                            }

                            //Throw an error if the list is empty
                            else
                            {
                                Console.WriteLine("\nERROR:  There are currently no items in the inventory.  Please select another option.\n\n");
                            }

                            //Break out of the case
                            break;
                        }

                    //Quit Case
                    case "Q":
                    case "q":
                        {
                            while (true)
                            {
                                //Ensure the user really wants to quit the program.  Collect user's response.
                                Console.Write("All your data is about to be lost.  Are you sure you want to quit? Y/N:  ");
                                string quitchoice = Console.ReadLine();

                                switch (quitchoice)
                                {

                                    //Continue back to the top of the loop to display menu options if the user selects No
                                    case "N":
                                    case "n":
                                        {
                                            continue;
                                        }

                                    //Close the console window if the user selectes Yes
                                    case "Y":
                                    case "y":
                                        {
                                            return;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\n\n");
                                            Console.Write("\nERROR:  {0} is an invalid selection.  Please make a valid selection of Y or N: ", quitchoice);
                                            quitchoice = Console.ReadLine();
                                            break;
                                        }
                                }
                                break;
                            }
                            //Break out of the case
                            break;
                        }

                    //Default Case
                    default:
                        {
                            //Write error message if user selects something other than a valid case
                            Console.WriteLine("\nERROR:  {0} is not a valid selection. Please make a valid selection", selection);

                            //Break out of the case
                            break;
                        }
                }

            }
            Console.ReadLine();
        }
    }
}
