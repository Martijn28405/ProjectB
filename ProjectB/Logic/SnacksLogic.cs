using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
public class SnacksLogic
{
    private JsonAccessor<SnackModel> _productAccesor;
    private JsonAccessor<DiscountModel> _discountAccesor;
    private JsonAccessor<ShoppingCartModel> _shoppingCartAccesor;
    public List<DiscountModel> discounts;
    public List<SnackModel> snacks;
    public List<ShoppingCartModel>? shoppingCart;
    public SnacksLogic()

    {
        _productAccesor = new JsonAccessor<SnackModel>(@"DataSources/snacks.json");
        snacks = _productAccesor.LoadAll();

        _shoppingCartAccesor = new JsonAccessor<ShoppingCartModel>(@"DataSources/shoppingcart.json");
        shoppingCart = _shoppingCartAccesor.LoadAll();

        _discountAccesor = new JsonAccessor<DiscountModel>(@"DataSources/actieSnack.json");
        discounts = _discountAccesor.LoadAll();
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
    public void AddShoppingCart()
    {
        foreach (var item in shoppingCart)
        {

            EmailLogic.shopping_cart_list.Add(item.NameFood);
            EmailLogic.shopping_cart_list.Add(item.PriceFood.ToString());
        }
    }

    public void AddSnacks()
    {
        int index = snacks.Any() ? snacks.Max(snack => snack.Id) + 1 : 1;
        // checking if there is an id already in the JSON if not it becomes 1

        Console.WriteLine("The name of the snack:");
        string snackName = Console.ReadLine();
        Console.WriteLine("The price of the snack:");
        double snackPrice = Convert.ToDouble(Console.ReadLine());
        string snackDescprition = null;
        SnackModel snack = new SnackModel(snackName, snackDescprition, snackPrice);
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
            Console.WriteLine("What would you like to buy? Please enter ID:");
            Console.WriteLine();
            foreach (var item in snacks)
            {
                Console.WriteLine($"ITEM ID: {item.Id}");
                Console.WriteLine($"SNACK: {item.NameFood}");
                Console.WriteLine($"PRICE: {item.PriceFood}");
                Console.WriteLine();
            }
            int itemId = Convert.ToInt32(Console.ReadLine());
            // snacks is the list of available snacks.
            // FirstOrDefault() iterates over each element in the list and checks whether the NameFood property of the element matches the snackName entered by the user.
            SnackModel? snack = snacks.FirstOrDefault(snack => snack.Id == itemId);
            if (snack == null)
            {
                Console.WriteLine("Invalid, please try again.");
                continue;
            }
            Console.WriteLine($"ITEM ID: {snack.Id}");
            Console.WriteLine($"SNACK: {snack.NameFood}");
            Console.WriteLine($"PRICE: {snack.PriceFood}");
            Console.WriteLine();

            Console.WriteLine("How many do you want to buy?");
            int amount = Convert.ToInt32(Console.ReadLine());
            double totalPrice = snack.PriceFood * amount;
            Console.WriteLine($"The total price is: {totalPrice}");

            Console.WriteLine("Would you like to add this to your cart?");
            Console.WriteLine("[1] Yes\n[2] No");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                ShoppingCartModel boughtSnack = new ShoppingCartModel(snack.NameFood, snack.PriceFood, amount);
                shoppingCart.Add(boughtSnack);
                _shoppingCartAccesor.WriteAll(shoppingCart);

                Console.WriteLine($"Added {amount}x {snack.NameFood} to cart!");
                Console.WriteLine("Your current shopping bag:");
                foreach (var item2 in shoppingCart)
                {
                    Console.WriteLine($"SNACK: {item2.NameFood}");
                    Console.WriteLine($"PRICE: {amount}x {item2.PriceFood}");
                }
                AddShoppingCart();
            }
            Console.WriteLine("Would you like to buy another snack?");
            Console.WriteLine("[1] Yes\n[2] No");
            string anotherSnack = Console.ReadLine();
            if (anotherSnack == "1")
            {
                continue;
            }
            return;
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
        shoppingCart.Clear();
        _shoppingCartAccesor.WriteAll(shoppingCart);
        
    }

    public void ViewShoppingCart()
    {
        foreach (var item in shoppingCart)
        {
            if (shoppingCart != null)
            {
                Console.WriteLine($"Snack: {item.NameFood}");
                Console.WriteLine($"Amount: {item.Amount}");
                Console.WriteLine($"Price: {item.PriceFood}");
            }
            else
            {
                Console.WriteLine("Your shopping cart is empty");
            }

        }
    }

    public void ActieBox()
    {
        Console.WriteLine("Overzicht van onze verschillende actie boxen:\n");
        foreach (var item in discounts)
        {
            Console.WriteLine($"[{item.Id}]{item.NameFood}\n   {item.Description}\n   {item.PriceFood} euro");
        }
        Console.WriteLine("Would you like to add something to your cart?");
        Console.WriteLine("[1] Yes\n[2] No");


        foreach (var item in discounts)
        {
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("Which box would you like to buy: 1, 2 or 3? ");
                int input = Convert.ToInt32(Console.ReadLine());
                foreach (var id in discounts)
                {
                    if (id.Id == input)
                    {
                        System.Console.WriteLine(id.NameFood);
                        System.Console.WriteLine($"{id.PriceFood} euro's");
                        Console.WriteLine("How many do you want to buy?");
                        int amounts = Convert.ToInt32(Console.ReadLine());
                        ShoppingCartModel boughtSnacks = new ShoppingCartModel(id.NameFood, id.PriceFood, amounts);
                        shoppingCart.Add(boughtSnacks);
                        _shoppingCartAccesor.WriteAll(shoppingCart);

                        Console.WriteLine("Your current shopping bag:");
                        foreach (var item2 in shoppingCart)
                        {
                            if (item2.NameFood != null)
                            {
                                Console.WriteLine($"SNACK: {item2.NameFood}");
                                Console.WriteLine($"PRICE: {amounts}x {item2.PriceFood}");
                            }
                        }
                        Console.WriteLine("Press any key to return to the Account Menu");
                        Console.ReadKey(true);
                        AccountMenu.Start();
                        break;


                    }
                }
            }

            {
                // Console.WriteLine("Press any key to return to the Account Menu");
                // Console.ReadKey(true);
                // AccountMenu.Start();
                // break;

            }
        }
    }


}



