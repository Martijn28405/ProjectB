using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Logic
{
    public class DeleteSnackLogic
    // This file is being used for an unit test.
    {
        private JsonAccessor<SnackModel> _productAccesor;
        public DeleteSnackLogic()
        {
            _productAccesor = new JsonAccessor<SnackModel>(@"DataSources/movies.json");
            snacks = _productAccesor.LoadAll();
        }
        public List<SnackModel> snacks;
        public void DeleteSnack(string snack)
        {
            foreach (var item in snacks)
            {
                Console.WriteLine($"Snacks: {item.NameFood}");
            }
            foreach (var item in snacks)
            {
                if (snack == item.NameFood)
                {
                    snacks.Remove(item);
                    _productAccesor.WriteAll(snacks);
                    Console.WriteLine("Snack deleted");
                    break;
                }
                else
                {
                    Console.WriteLine("Snack not found");
                }
            }
        }
    }
}
