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

    // public List<string> boughtSnacks = new();
    // public List<int> amountSnacks = new();
    public List<DiscountModel> discounts;
    public List<SnackModel> snacks;
    public List<ShoppingCartModel> shoppingCart;

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
    public void AddShoppingCart()
    {
        EmailLogic.shopping_cart_list = new List<string>();
        foreach (var item in shoppingCart)
        {
            EmailLogic.shopping_cart_list.Add($"{item.Amount}x {item.NameFood}");
        }
    }

    public void AddSnacks()
    {
        int id = GetNextAvailableId();
        // checking if there is an available Id that is not used by any existing snack
        // If there is, it will be used. Otherwise, it will get the next available Id.
        Console.WriteLine("The name of the snack:");
        string? snackName = Console.ReadLine();
        while (string.IsNullOrEmpty(snackName) || int.TryParse(snackName, out _))
        {
            Console.WriteLine("Invalid input. Snack cannot be empty. Please enter a valid title:");
            snackName = Console.ReadLine();
        }
        Console.WriteLine("The price of the snack (format: 0,00):");
        double snackPrice;
        while (!double.TryParse(Console.ReadLine(), out snackPrice) || snackPrice <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid price:");
        }
        Console.WriteLine("The description of the snack:");
        string snackDescription = Console.ReadLine();
        while (string.IsNullOrEmpty(snackDescription) || int.TryParse(snackDescription, out _))
        {
            Console.WriteLine("Invalid input. Please enter a valid description:");
            snackDescription = Console.ReadLine();
        }
        SnackModel snack = new SnackModel(id, snackName, snackDescription, snackPrice);
        snacks.Add(snack);
        _productAccesor.WriteAll(snacks);
        Console.WriteLine("Snack Added \nPress any key to return to the Manager menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }

    private int GetNextAvailableId()
    {
        // If there are no snacks, start at 1.
        if (!snacks.Any())
        {
            return 1;
        }

        // Find the minimum available Id that doesn't exist in the data.
        int minAvailableId = 1;
        while (snacks.Any(snack => snack.Id == minAvailableId))
        {
            minAvailableId++;
        }

        return minAvailableId;
    }

    public void BuySnacks()
    {
        while (true)
        {
            Console.WriteLine();
            foreach (var item in snacks)
            {
                Console.WriteLine($"ITEM ID: {item.Id}");
                Console.WriteLine($"SNACK: {item.NameFood}");
                Console.WriteLine($"DESCRIPTION: {item.Description}");
                Console.WriteLine($"PRICE: {item.PriceFood}");
                Console.WriteLine();
            }
            Console.WriteLine("What would you like to buy? Please enter ID:");
            int itemId = Convert.ToInt32(Console.ReadLine());
            string idToString = Convert.ToString(itemId);
            // snacks is the list of available snacks.
            // FirstOrDefault() iterates over each element in the list and checks whether the NameFood property of the element matches the snackName entered by the user.
            SnackModel? snack = snacks.FirstOrDefault(snack => snack.Id == itemId);
            if (snack == null || itemId > snack.Id || itemId < snack.Id)
            {
                Console.WriteLine("Invalid, please try again.");
                continue;
            }
            Console.WriteLine($"ITEM ID: {snack.Id}");
            Console.WriteLine($"SNACK: {snack.NameFood}");
            Console.WriteLine($"DESCRIPTION: {snack.Description}");
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
                // Toegevoegd voor email:


                Console.WriteLine($"Added {amount}x {snack.NameFood} to cart!");
                Console.WriteLine("Your current shopping bag:");
                foreach (var item2 in shoppingCart)
                {
                    Console.WriteLine($"SNACK: {item2.NameFood}");
                    Console.WriteLine($"PRICE: {amount}x {item2.PriceFood}");

                }
                // boughtSnacks.Add(snack.NameFood);
                // amountSnacks.Add(amount);
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
        Console.WriteLine("[1] Add Snacks\n[2] Delete Snacks\n[3] View Snacks\n[4] Return to  Manager Menu");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            ManageSnacks();
            return;
        }
        if (choice == 1)
        {
            AddSnacks();
        }
        else if (choice == 2)
        {
            var result = DeleteSnack();
            if (result.Item1)
            {
                Console.WriteLine(result.Item2);
            }
            else
            {
                Console.WriteLine(result.Item2);
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey(true);
            ManagerMenu.Start();
        }
        else if (choice == 3)
        {
            LogicBase snack = new LogicBase();
            snack.ShowSnacksBase(false, true, false);
        }
        else if (choice == 4)
        {
            ManagerMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ManageSnacks();
            return;
        }
    }
    public (bool, string) DeleteSnack()
    {

        foreach (var item in snacks)
        {
            Console.WriteLine($"ID: {item.Id}  Snack: {item.NameFood}");
        }



        Console.WriteLine("Which snack do you want to delete? Please enter ID:");
        int snackId;

        // Validate user input for snackId
        while (!int.TryParse(Console.ReadLine(), out snackId) || snackId <= 0 || snackId > snacks.Max(s => s.Id))
        {
            Console.WriteLine("Invalid input. Please enter a valid ID:");
        }


        bool snackDeleted = false;
        string statusMessage = "Snack not found";

        for (int i = 0; i < snacks.Count; i++)
        {
            if (snacks[i].Id == snackId)
            {
                snacks.RemoveAt(i);
                _productAccesor.WriteAll(snacks);
                snackDeleted = true;
                statusMessage = "Snack deleted";
                break;
            }
        }
        if (!snackDeleted)
        {
            Console.WriteLine("This item was not found, can you try again\n");

        }
        return (snackDeleted, statusMessage);
    }


    // public void DeleteSnack()
    //     {
    //         foreach (var item in snacks)
    //         {
    //             Console.WriteLine($"Snacks: {item.NameFood}");
    //         }

    //         Console.WriteLine("Which snack do you want to delete?");
    //         string snack = Console.ReadLine();
    //         foreach (var item in snacks)
    //         {
    //             if (snack == item.NameFood)
    //             {
    //                 snacks.Remove(item);
    //                 _productAccesor.WriteAll(snacks);
    //                 Console.WriteLine("Snack deleted");
    //                 break;
    //             }
    //         }

    //         Console.WriteLine("Press any key to return to menu");
    //         Console.ReadKey(true);
    //         ManagerMenu.Start();
    //     }
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



