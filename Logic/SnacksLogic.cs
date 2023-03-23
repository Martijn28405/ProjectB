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
            Console.WriteLine("Which snacks would you like?");
            Console.WriteLine($"NAME SNACK: {item.NameFood}");
            Console.WriteLine($"MOVIETITLE: {item.PriceFood}");
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

}

