using System;
using System.Collections.Generic;

namespace ShoppingCartApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Important variables

            // --------------------------------------------------------------------------------------------------------

            // whole program variable

            List<string> cartItems = new List<string>(); // List to store cart items

            Stack<string> itemHistory = new Stack<string>(); // Stack to store item history for undo functionality

            string userInput; // User input for the switch case

            // case 2 variable

            string item; // user input on Item to be added or removed from the cart

            // case 3 variables

            string Removeinput; // user input to be parse to an integer for the item to be removed from the cart

            int Removeindex; // variable to store the index of the item to be removed from the cart

            string removed; // variable to store the removed item from the cart

            //case 4 variable

            string lastItem; // variable to store the last item added to the cart for undo functionality

            // --------------------------------------------------------------------------------------------------------


            // Main logic using a do-while loop to handle the program until the user chooses to exit


            do // the loop comtinues until the user chooses to exit
            {
                Console.Clear(); // Clear the console for a fresh display

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===================");
                Console.WriteLine("SHOPPING CART MENU    ");
                Console.WriteLine("===================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1. View Cart");
                Console.WriteLine("\n2. Add Item to Cart");
                Console.WriteLine("\n3. Remove Item from Cart");
                Console.WriteLine("\n4. Undo Last Add (Pop)");
                Console.WriteLine("\n5. Exit");
                Console.Write("\nEnter your choice: ");
                Console.ResetColor();

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": // case handles viewing the cart

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nCurrent Cart Items:");
                        Console.WriteLine();

                        if (cartItems.Count == 0) // if cart item is still empty
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("(Your cart is empty.)");
                            Console.ResetColor();
                        }
                        else
                        {
                            for (int i = 0; i < cartItems.Count; i++) // Loop through the cart items
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{i + 1}. {cartItems[i]}"); // display the items in the cart
                                Console.WriteLine();
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2": // case handles adding an item to your cart

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nEnter the name of the item to add: ");

                        item = Console.ReadLine();

                        if (item != null && item.Trim() != "") // Ensure the item is not empty or just whitespace by trimming spaces from both ends
                        {
                            item = item.Trim(); // Trim the item to remove any leading or trailing spaces and store it back in 'item'

                            cartItems.Add(item); // Add the item to the cart
                            itemHistory.Push(item); // Push the item to the history stack for undo functionality

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n'{item}' has been added to your cart.");
                            Console.ResetColor();
                        }
                        else // if the item is empty or just bunches of spaces
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOops! Can't add an empty item.");
                            Console.ResetColor();
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3": // case handles removing items form your cart

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nCurrent Cart Items:");
                        Console.WriteLine();

                        if (cartItems.Count == 0) // if your cart is empty
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("(Your cart is empty.)\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            for (int i = 0; i < cartItems.Count; i++) // Loop through the cart items
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{i + 1}. {cartItems[i]}"); // display the items in the cart
                                Console.WriteLine();
                                Console.ResetColor();
                            }

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\nEnter the item number to remove: ");

                            Removeinput = Console.ReadLine();
                            Removeindex = 0;

                            // user input here is number-based
                            if (int.TryParse(Removeinput, out Removeindex) && Removeindex >= 1 && Removeindex <= cartItems.Count) // Check if the input is a valid number and within the range of cart items
                            {
                                removed = cartItems[Removeindex - 1];  // Retrieve the item to be removed and store it for display/logging

                                cartItems.RemoveAt(Removeindex - 1);  // Remove the item from the cart list at the specified index

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"\n'{removed}' removed from the cart."); // print the removed item
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid item number.");
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4": // case hhandles undoing the last item added to the cart

                        Console.Clear();

                        if (itemHistory.Count > 0) // check if there is an item in the history
                        {
                            lastItem = itemHistory.Pop(); // pop the last item from the history stack

                            if (cartItems.Contains(lastItem)) // check if the item is in the cart
                            {
                                cartItems.Remove(lastItem); // remove the item from the cart
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\n'{lastItem}' has been removed (undo)."); /// print the removed item
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNothing to undo.");
                            Console.ResetColor();
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "5": // case handles exiting the program

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nExiting the cart... Bye!");
                        break;

                    default: // case handles invalid input

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option. Try again.");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }

            } while (userInput != "5"); // Loop goes back until the user chooses option 5 to exit
              {
                Console.ResetColor();
                Console.WriteLine();
              }
        }
    }
}