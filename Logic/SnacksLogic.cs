using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class SnacksLogic
{
    private JsonAccessor<SnackModel> _accesor;
    public List<SnackModel> snacks;
    public List<SnackModel>? shoppingBag;
    public SnacksLogic()
    {
        _accesor = new JsonAccessor<SnackModel>(@"DataSources/snacks.json");
        snacks = _accesor.LoadAll();
    }
    public void ShowSnacks()
    {
        List<SnackModel> food = new List<SnackModel>();
        foreach (var item in snacks)
        {
            Console.WriteLine($"SNACK: {item.NameFood}");
            Console.WriteLine($"PRICE: {item.PriceFood}");
        }
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey(true);
        AccountMenu.Start();
    }
    public void AddSnacks()
    {
        Console.WriteLine("The name of the snack:");
        string snackName = Console.ReadLine();
        Console.WriteLine("The price of the snack:");
        double snackPrice = Convert.ToDouble(Console.ReadLine());
        SnackModel snack = new SnackModel(snackName, snackPrice);
        snacks.Add(snack);
        _accesor.WriteAll(snacks);
        AccountMenu.Start();
    }
    public void BuySnacks()
    {
        shoppingBag = new List<SnackModel>();
        while (true)
        {
            Console.WriteLine("Do you want to buy a snack?");
            Console.WriteLine("Y/N");
            string start = Console.ReadLine().ToUpper();
            if (start == "Y")
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
                Console.WriteLine("Y/N");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    Console.WriteLine("How many do you want to buy?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in snacks)
                    {
                        if (item.NameFood == snackName)
                        {
                            double totalPrice = item.PriceFood * amount;
                            Console.WriteLine($"The total price is: {totalPrice}");
                            Console.WriteLine("Are you sure?");
                            Console.WriteLine("Y/N");
                            string answer2 = Console.ReadLine().ToUpper();
                            if (answer2 == "Y")
                            {
                                shoppingBag.Add(new SnackModel(snackName, item.PriceFood));
                                Console.WriteLine($"Added {amount}x {snackName} to cart!");
                                Console.WriteLine("Your current shopping bag:");
                                foreach (var item2 in shoppingBag)
                                {
                                    Console.WriteLine($"SNACK: {amount}x {item2.NameFood}");
                                    Console.WriteLine($"PRICE: {amount * item2.PriceFood}");
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

}

