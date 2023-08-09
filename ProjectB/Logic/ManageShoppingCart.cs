
public class ManageShoppingCart
{
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = "Shopping Cart Manager";
        string[] options = { "View Shopping Cart", "Empty Shopping Cart", "Empty Seats Cart", "Return to Menu" };
        Menu shoppingcartmenu = new Menu(prompt, options);
        int Selectedindex = shoppingcartmenu.Run();
        switch (Selectedindex)
        {
            case 0:
                SnacksLogic shoppingcart = new SnacksLogic();
                shoppingcart.ViewShoppingCart();
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 1:
                SnacksLogic shoppingcartempty = new SnacksLogic();
                shoppingcartempty.EmptyShoppingCart();
                Console.WriteLine("Shopping cart emptied");
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 2:
                if (ReservationsLogic._carts == null)
                {
                    Console.WriteLine("Cart was already empty");
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadKey(true);
                    Start();
                    break;
                }
                ReservationsLogic.EmptySeatCarts();
                Console.WriteLine("Seats cart emptied");
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey(true);
                Start();
                break;
            case 3:
                GuestMenu.Start();
                break;

        }
    }
}