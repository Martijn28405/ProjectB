using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class SnacksLogic
{
    private JsonAccessor<SnackModel> _productAccesor;
    private JsonAccessor<ShoppingCartModel> _shoppingCartAccesor;
    public List<SnackModel> snacks;
    public List<ShoppingCartModel>? shoppingCart;
    public SnacksLogic()

    {
        _productAccesor = new JsonAccessor<SnackModel>(@"DataSources/snacks.json");
        snacks = _productAccesor.LoadAll();
        _shoppingCartAccesor = new JsonAccessor<ShoppingCartModel>(@"DataSources/shoppingcart.json");
        shoppingCart = _shoppingCartAccesor.LoadAll();
    }
    public void ShowSnacks()
    {
        List<SnackModel> food = new List<SnackModel>();
        foreach (var item in snacks)
        {
            Console.WriteLine($"SNACK: {item.NameFood}");
            Console.WriteLine($"PRICE: {item.PriceFood}");
            Console.WriteLine();
        }
        Console.WriteLine("Press any key to return to the menu");
        Console.ReadKey(true);
    }

    public void AddSnacks()
    {
        int index = snacks.Any() ? snacks.Max(snack => snack.Id) + 1 : 1;
        // checking if there is an id already in the JSON if not it becomes 1

        Console.WriteLine("The name of the snack:");
        string snackName = Console.ReadLine();
        Console.WriteLine("The price of the snack:");
        double snackPrice = Convert.ToDouble(Console.ReadLine());
        SnackModel snack = new SnackModel(snackName, snackPrice);
        snack.Id = index;
        snacks.Add(snack);
        _productAccesor.WriteAll(snacks);
        Console.WriteLine("Snack Added \nPress any key to return to the Manager menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }
    public void BuySnacks()
    {
        while (true)
        {
            Console.WriteLine("Do you want to buy a snack?");
            Console.WriteLine("[1] Yes\n[2] No");
            string start = Console.ReadLine();
            if (start == "1")
            {
                Console.WriteLine("What snack do you want to buy?");
                foreach (var item in snacks)
                {
                    Console.WriteLine($"SNACK: {item.NameFood}");
                    Console.WriteLine($"PRICE: {item.PriceFood}");
                }
                string snackName = Console.ReadLine();
                foreach (var item in snacks)
                {
                    if (item.NameFood == snackName)
                    {
                        Console.WriteLine($"SNACK: {item.NameFood}");
                        Console.WriteLine($"PRICE: {item.PriceFood}");
                    }
                }
                Console.WriteLine("Do you want to buy this snack?");
                Console.WriteLine("[1] Yes\n[2] No");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("How many do you want to buy?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in snacks)
                    {
                        if (item.NameFood == snackName)
                        {
                            double totalPrice = item.PriceFood * amount;
                            Console.WriteLine($"The total price is: {totalPrice}");
                            Console.WriteLine("Do you confirm your order?");
                            Console.WriteLine("[1] Yes\n[2] No");
                            string answer2 = Console.ReadLine();
                            if (answer2 == "1")
                            {
                                ShoppingCartModel boughtSnack = new ShoppingCartModel(snackName, item.PriceFood, amount);
                                shoppingCart.Add(boughtSnack);
                                _shoppingCartAccesor.WriteAll(shoppingCart);

                                Console.WriteLine($"Added {amount}x {snackName} to cart!");
                                Console.WriteLine("Your current shopping bag:");
                                foreach (var item2 in shoppingCart)
                                {
                                    Console.WriteLine($"SNACK: {amount}x {item2.NameFood}");
                                    Console.WriteLine($"PRICE: {amount * item2.PriceFood}");
                                }
                                Console.WriteLine("Press any key to return to the Account Menu");
                                Console.ReadKey(true);
                                AccountMenu.Start();

                            }
                            else
                            {
                                Console.WriteLine("Press any key to return to main menu");
                                Console.ReadKey(true);
                                AccountMenu.Start();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey(true);
                    AccountMenu.Start();
                }
            }
            else
            {
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadKey(true);
                AccountMenu.Start();
            }
        }
    }
    public void ManageSnacks()
    {
        //Add or delete snacks ONLY as Admin
        Console.WriteLine("[1] Add Snacks\n[2] Delete Snacks\n[3] Return to  Manager Menu");
        int choice = Int32.Parse(Console.ReadLine());
        if (choice == 1)
        {
            AddSnacks();
        }
        else if (choice == 2)
        {
            DeleteSnack();
        }
        else if (choice == 3)
        {
            ManagerMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ManageSnacks();
        }
    }
    public void DeleteSnack()
    {
        foreach (var item in snacks)
        {
            Console.WriteLine($"Snacks: {item.NameFood}");
        }

        Console.WriteLine("Which snack do you want to delete?");
        string snack = Console.ReadLine();
        foreach (var item in snacks)
        {
            if (snack == item.NameFood)
            {
                snacks.Remove(item);
                _productAccesor.WriteAll(snacks);
                Console.WriteLine("Snack deleted");
                break;
            }
        }

        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }

    public void EmptyShoppingCart()
    {
        foreach (var item in shoppingCart)
        {
            shoppingCart.Remove(item);
            _shoppingCartAccesor.WriteAll(shoppingCart);
        }
    }

}

