using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class SnacksLogic
{
    private JsonAccessor<SnackModel> _accesor;
    public List<SnackModel> snacks;
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
            Console.WriteLine($"PRICE: €{item.PriceFood}");
        }
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
    }
    public void BuySnacks()
    {
        // Console.WriteLine("Which snacks would you like?");
        // string choiceSnack = Console.ReadLine();
        // if (choiceSnack != null)
        // {
        //     food.Add(choiceSnack);
        //     foreach (SnackModel product in food)
        //     {
        //         Console.WriteLine($"IN YOUR SHOPPINGBAG: {product}");
        //     }
        // }
    }

}

